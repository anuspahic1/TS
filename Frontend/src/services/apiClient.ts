const API_BASE_URL = import.meta.env.VITE_API_URL;

export const apiClient = {
  async get<T>(url: string): Promise<T> {
    return request<T>(url, 'GET');
  },
  async post<T>(url: string, body?: unknown): Promise<T> {
    return request<T>(url, 'POST', body);
  },
};

let isRefreshing = false;

async function request<T>(
  url: string,
  method: string,
  body?: unknown
): Promise<T> {
  const token = sessionStorage.getItem('accessToken');
  
  const response = await fetch(`${API_BASE_URL}${url}`, {
    method,
    credentials: 'include',
    headers: {
      'Content-Type': 'application/json',
      ...(token && { Authorization: `Bearer ${token}` }),
    },
    body: body ? JSON.stringify(body) : undefined,
  });

  if (response.status === 401 && !isRefreshing) {
    isRefreshing = true;

    const refreshResponse = await fetch(`${API_BASE_URL}/authentication/refresh`, {
      method: 'POST',
      credentials: 'include',
    });

    isRefreshing = false;

    if (!refreshResponse.ok) {
      sessionStorage.removeItem('accessToken');
      window.location.href = '/login';
      throw new Error('Session expired');
    }

    const { accessToken } = await refreshResponse.json();
    sessionStorage.setItem('accessToken', accessToken);

    return request<T>(url, method, body);
  }

  if (!response.ok) {
    const error = await response.json().catch(() => ({}));
    throw new Error(error.message || `Request failed (${response.status})`);
  }

  return response.json();
}
