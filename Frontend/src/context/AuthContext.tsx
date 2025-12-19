import { createContext, useContext, useState } from "react";
import { authService } from "../services/auth.service";

type AuthContextType = {
  token: string | null;
  login: (data: any) => Promise<void>;
  logout: () => void;
};

const AuthContext = createContext<AuthContextType | null>(null);

export function AuthProvider({ children }: { children: React.ReactNode }) {
  const [token, setToken] = useState(
    localStorage.getItem("authToken")
  );

  const login = async (data: any) => {
    const res = await authService.login(data);
    console.log("Login successful:", res);
    localStorage.setItem("authToken", res.accessToken);
    setToken(res.accessToken);
  };

  const logout = () => {
    console.log("Logging out");
    localStorage.removeItem("authToken");
    setToken(null);
  };

  return (
    <AuthContext.Provider value={{ token, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
}

export const useAuth = () => {
  const ctx = useContext(AuthContext);
  if (!ctx) throw new Error("useAuth must be used inside AuthProvider");
  return ctx;
};
