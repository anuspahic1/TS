const API_BASE_URL = import.meta.env.VITE_API_URL;

export const apiClient = {
  async get<T>(url: string): Promise<T> {
    return request<T>(url, 'GET');
  },
  async post<T>(url: string, body?: unknown): Promise<T> {
    return request<T>(url, 'POST', body);
  },
};

async function request<T>(
  url: string,
  method: string,
  body?: unknown
): Promise<T> {
  const token = localStorage.getItem('authToken');

  const response = await fetch(`${API_BASE_URL}${url}`, {
    method,
    headers: {
      'Content-Type': 'application/json',
      ...(token && { Authorization: `Bearer ${token}` }),
    },
    body: body ? JSON.stringify(body) : undefined,
  });

  if (!response.ok) {
    const error = await response.json().catch(() => ({}));
    throw new Error(error.message || `Request failed (${response.status})`);
  }

  return response.json();
}
