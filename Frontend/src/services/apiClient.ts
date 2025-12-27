const API_BASE_URL = import.meta.env.VITE_API_URL;

export const apiClient = {
  async get<T>(url: string, headers?: Record<string, string>): Promise<T> {
    return request<T>(url, 'GET', undefined, headers);
  },

  async post<T>(url: string, body?: unknown, headers?: Record<string, string>): Promise<T> {
    return request<T>(url, 'POST', body, headers);
  },
  async put<T>(url: string, body?: unknown): Promise<T> {
    return request<T>(url, 'PUT', body);
  },
  async delete<T>(url: string): Promise<T> {
    return request<T>(url, 'DELETE');
  }
};

let isRefreshing = false;

async function request<T>(
  url: string,
  method: string,
  body?: unknown,
  headers: Record<string, string> = {}
): Promise<T> {
  const accessToken = localStorage.getItem('accessToken');

    const token = localStorage.getItem('authToken');  

  const response = await fetch(`${API_BASE_URL}${url}`, {
    method,
    credentials: 'include',
    headers: {
      'Content-Type': 'application/json',

      ...(headers.Authorization
        ? { Authorization: headers.Authorization }
        : accessToken
        ? { Authorization: `Bearer ${accessToken}` }
        : {}),

      ...headers,
    },
    body: body ? JSON.stringify(body) : undefined,
  });

  if (response.status === 401 && !isRefreshing && !url.includes('/authentication/login') && !headers.Authorization) {
    isRefreshing = true;

    const refreshResponse = await fetch(`${API_BASE_URL}/token/refresh`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        accessToken: localStorage.getItem('accessToken'),
        refreshToken: localStorage.getItem('refreshToken'),
      }),
    });

    isRefreshing = false;

    if (!refreshResponse.ok) {
      localStorage.removeItem('accessToken');
      window.location.href = '/login';
      throw new Error('Session expired');
    }

    const { accessToken: newAccessToken } = await refreshResponse.json();
    localStorage.setItem('accessToken', newAccessToken);

    return request<T>(url, method, body);
  }

  if (!response.ok) {
    let errorMessage = 'An error occurred';
  let errorData: any = {};

  if (response.status === 204) {
    return {} as T;
  }

    try {
      const text = await response.text();
      const errorData = text ? JSON.parse(text) : {};
    
      if (errorData.title) {
        errorMessage = errorData.title === 'Unauthorized' ? 'Invalid credentials' : errorData.title;
      } else if (typeof errorData === 'object' && errorData !== null && !Array.isArray(errorData)) {
        const messages = Object.values(errorData).flat();
        if (messages.length > 0) {
          errorMessage = messages.join('. ');
        }
      } else if (errorData.message) {
        errorMessage = errorData.message;
      }
    } catch {
      errorMessage = `Error ${response.status}: ${response.statusText}`;
    }

    throw new Error(errorMessage);
  error.status = response.status;
  error.statusText = response.statusText;
  error.data = errorData;
  error.isApiError = true;
  
  throw error;
  }

  if (response.status === 201 || response.status === 204) {
    return undefined as T;
  }

  const text = await response.text();
  return text ? (JSON.parse(text) as T) : (undefined as T);
}
