const API_BASE_URL = import.meta.env.VITE_API_URL;

export async function apiFetch<T>(
  url: string,
  options: RequestInit = {}
): Promise<T> {
  const token = localStorage.getItem("accessToken");

  const response = await fetch(`${API_BASE_URL}${url}`, {
    ...options,
    headers: {
      "Content-Type": "application/json",
      ...(token && { Authorization: `Bearer ${token}` }),
      ...options.headers,
    },
  });

 if (!response.ok) {
    const errorData = await response.json().catch(() => ({}));
    let errorMessage = "Request failed";

    if (Array.isArray(errorData)) {
      errorMessage = errorData.map((e: any) => e.description).join(". ");
    } else if (errorData.message) {
      errorMessage = errorData.message;
    } else if (errorData.errors) {
      errorMessage = Object.values(errorData.errors).flat().join(". ");
    }

    throw new Error(errorMessage);
  }

  return response.json();
}
