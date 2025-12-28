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
  },
};

let isRefreshing = false;

async function request<T>(
  url: string,
  method: string,
  body?: unknown,
  headers: Record<string, string> = {}
): Promise<T> {
  const accessToken = localStorage.getItem('accessToken');

  const response = await fetch(`${API_BASE_URL}${url}`, {
    method,
    credentials: 'include',
    headers: {
      'Content-Type': 'application/json',
      Accept: 'application/json',

      ...(headers.Authorization
        ? { Authorization: headers.Authorization }
        : accessToken
        ? { Authorization: `Bearer ${accessToken}` }
        : {}),

      ...headers,
    },
    body: body ? JSON.stringify(body) : undefined,
  });

  console.log('API Response:', response);

  if (
    response.status === 401 &&
    !isRefreshing &&
    !url.includes('/authentication/login') &&
    !url.includes('/token/refresh')
  ) {
    isRefreshing = true;

    const refreshResponse = await fetch(`${API_BASE_URL}/token/refresh`, {
      method: 'POST',
      credentials: 'include',
    });

    console.log('Token refresh response:', refreshResponse);

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
  }

  if (response.status === 201 || response.status === 204) {
    return undefined as T;
  }

  const text = await response.text();
  return text ? (JSON.parse(text) as T) : (undefined as T);
}
