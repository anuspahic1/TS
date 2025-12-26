import { createContext, useContext, useState } from "react";
import { authService } from "../services/auth.service";

type AuthContextType = {
  token: string | null;
  login: (data: any) => Promise<LoginResult>;
  completeLogin: (token: string) => void;
  logout: () => void;
};

type LoginResult = {
  accessToken: string;
  refreshToken: string;
  twoFactorEnabled: boolean;
  hasAuthenticatorKey: boolean;
};

const AuthContext = createContext<AuthContextType | null>(null);

export function AuthProvider({ children }: { children: React.ReactNode }) {
  const [token, setToken] = useState(
    localStorage.getItem("authToken")
  );

  const login = async (data: any): Promise<LoginResult> => {
    const res = await authService.login(data);
    return res;
  };

  const completeLogin = (token: string) => {
    localStorage.setItem("authToken", token);
    setToken(token);
  };

  const logout = () => {
    localStorage.removeItem("authToken");
    setToken(null);
  };

  return (
    <AuthContext.Provider value={{ token, login, completeLogin, logout }}>
      {children}
    </AuthContext.Provider>
  );
}

export const useAuth = () => {
  const ctx = useContext(AuthContext);
  if (!ctx) throw new Error("useAuth must be used inside AuthProvider");
  return ctx;
};
