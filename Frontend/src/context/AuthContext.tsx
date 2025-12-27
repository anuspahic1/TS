import { createContext, useContext, useState } from "react";
import { authService } from "../services/auth.service";

type AuthContextType = {
  token: string | null;
  login: (data: any) => Promise<LoginResult>;
  completeLogin: (token: string) => void;

type LoginResult = {
  accessToken: string;
  refreshToken: string;
  twoFactorEnabled: boolean;
  hasAuthenticatorKey: boolean;
  requiresTwoFactor: boolean;
  preAuthToken?: string;
};

const AuthContext = createContext<AuthContextType | null>(null);

export function AuthProvider({ children }: { children: React.ReactNode }) {
  const [token, setToken] = useState(
    localStorage.getItem("accessToken")
  );


  const login = async (data: any): Promise<LoginResult> => {
    const res = await authService.login(data);

    return res;
  };

  const completeLogin = (token: string) => {
    localStorage.setItem("accessToken", token);
    setToken(token);
  };

  const logout = () => {
    localStorage.removeItem("accessToken");
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
  return ctx;
};
