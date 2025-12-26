import { apiClient } from './apiClient';

export interface ILoginRequest {
  userName: string;
  password: string;
  totpCode?: string;
}

export interface ISignupRequest {
  firstName?: string;
  lastName?: string;
  userName: string;
  password: string;
  email?: string;
}

export interface IAuthResponse {
  accessToken: string;
  refreshToken: string;
  twoFactorEnabled: boolean;
  hasAuthenticatorKey: boolean;
  requiresTwoFactor: boolean;
  preAuthToken?: string;
}

export interface ITwoFactorSetupInfo {
  formattedKey: string;
  authenticatorKey: string;
}

export const authService = {
  login,
  signup,
  getTfaSetup,
  postTfaSetup,
  verifyTfa,
  refresh,
};

async function login(data: ILoginRequest): Promise<IAuthResponse> {
  return apiClient.post('/authentication/login', data);
}

async function signup(data: ISignupRequest): Promise<void> {
  await apiClient.post('/authentication', data);
}

async function getTfaSetup(): Promise<ITwoFactorSetupInfo> {
  return apiClient.get('/authentication/tfa-setup');
}

async function postTfaSetup(code: string, email: string): Promise<void> {
  return apiClient.post('/authentication/tfa-setup', {
    email,
    code,
  });
}

async function verifyTfa(code: string): Promise<IAuthResponse> {
  const preAuthToken = localStorage.getItem("preAuthToken");

  return apiClient.post(
    "/authentication/verify-tfa",
    { code },
    {
      Authorization: `Bearer ${preAuthToken}`,
    }
  );
}

async function refresh(): Promise<IAuthResponse> {
  return apiClient.post('/authentication/refresh');
}