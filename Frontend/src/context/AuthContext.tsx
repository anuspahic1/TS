import { createContext, useContext, useState, useEffect } from "react";
import { authService } from "../services/auth.service";
import { jwtDecode } from "jwt-decode";

type AuthContextType = {
  token: string | null;
  user: any | null;
  login: (data: any) => Promise<LoginResult>;
  logout: () => void;
  updateToken: (newToken: string) => void;
};

type LoginResult = {
  accessToken: string;
  refreshToken: string;
  twoFactorEnabled: boolean;
  hasAuthenticatorKey: boolean;
};

const AuthContext = createContext<AuthContextType | null>(null);

export const getUserFromToken = (t: string) => {
  try {
    const decoded: any = jwtDecode(t);
    console.log("Sadržaj tokena:", decoded);
    return {
      id: decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"],
      name: decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"],
      email: decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"],
      roles: Array.isArray(decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"])
        ? decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
        : [decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]]
    };
  } catch {
    return null;
  }
};

export function AuthProvider({ children }: { children: React.ReactNode }) {
  const [token, setToken] = useState<string | null>(localStorage.getItem("authToken"));
  
  const [user, setUser] = useState<any | null>(() => {
    const t = localStorage.getItem("authToken");
    return t ? getUserFromToken(t) : null;
  });

export function AuthProvider({ children }: { children: React.ReactNode }) {
  const [token, setToken] = useState<string | null>(localStorage.getItem("authToken"));
  const [user, setUser] = useState<any | null>(null);



  useEffect(() => {
    if (token) {
      const userData = getUserFromToken(token);
      setUser(userData);
    }
  }, [token]);

  const updateToken = (newToken: string) => {
    localStorage.setItem("authToken", newToken);
    setToken(newToken);
    const userData = getUserFromToken(newToken);
    setUser(userData);
  };

  const login = async (data: any): Promise<LoginResult> => {
    const res = await authService.login(data);
    if (!res.twoFactorEnabled && res.hasAuthenticatorKey) {
      updateToken(res.accessToken);
    }
    return res;
  };

  const logout = () => {
    localStorage.removeItem("authToken");
    setToken(null);
    setUser(null);
  };

  return (
    <AuthContext.Provider value={{ token, user, login, logout, updateToken }}>
      {children}
    </AuthContext.Provider>
  );
}

export const useAuth = () => {
  const ctx = useContext(AuthContext);
  if (!ctx) throw new Error("useAuth must be used inside AuthProvider");
  return ctx;
};