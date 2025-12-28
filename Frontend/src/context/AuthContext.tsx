import { createContext, useContext, useEffect, useState } from 'react';
import { authService } from '../services/auth.service';
import { jwtDecode } from 'jwt-decode';

type LoginResult = {
  accessToken: string;
  twoFactorEnabled: boolean;
  hasAuthenticatorKey: boolean;
  requiresTwoFactor: boolean;
  preAuthToken?: string;
};

type AuthContextType = {
  token: string | null;
  user: any | null;
  login: (data: any) => Promise<LoginResult>;
  completeLogin: (token: string) => void;
  logout: () => void;
};

const AuthContext = createContext<AuthContextType | null>(null);

export const getUserFromToken = (token: string) => {
  try {
    const decoded: any = jwtDecode(token);
    return {
      id: decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'],
      name: decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'],
      email: decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'],
      roles: Array.isArray(decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'])
        ? decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']
        : [decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']],
    };
  } catch {
    return null;
  }
};

export function AuthProvider({ children }: { children: React.ReactNode }) {
  const [token, setToken] = useState<string | null>(localStorage.getItem('accessToken'));
  const [user, setUser] = useState<any | null>(null);

  useEffect(() => {
    if (token) {
      setUser(getUserFromToken(token));
    } else {
      setUser(null);
    }
  }, [token]);

  const login = async (data: any): Promise<LoginResult> => {
    return await authService.login(data);
  };

  const completeLogin = (newToken: string) => {
    localStorage.setItem('accessToken', newToken);
    setToken(newToken);
  };

  const logout = () => {
    localStorage.removeItem('accessToken');
    localStorage.removeItem('preAuthToken');
    setToken(null);
    setUser(null);
  };

  return <AuthContext.Provider value={{ token, user, login, completeLogin, logout }}>{children}</AuthContext.Provider>;
}

export const useAuth = () => {
  const ctx = useContext(AuthContext);
  if (!ctx) throw new Error('useAuth must be used inside AuthProvider');
  return ctx;
};
