import axios from "axios";

const axiosInstance = axios.create({
  baseURL: import.meta.env.VITE_API_URL,
});

// Ovaj presretač se pokreće prije svakog zahtjeva
axiosInstance.interceptors.request.use((config) => {
  const token = localStorage.getItem("token"); // Provjeri da li ti je ključ baš "token"
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

export default axiosInstance;