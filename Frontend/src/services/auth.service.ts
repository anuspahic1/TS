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
  twoFactorEnabled: boolean;
  hasAuthenticatorKey: boolean;
  roles?: string[];
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
};

async function login(data: ILoginRequest): Promise<IAuthResponse> {
  return apiClient.post('/authentication/login', data);
}

async function signup(data: ISignupRequest): Promise<void> {
  await apiClient.post('/authentication', data);
}

async function getTfaSetup(): Promise<ITwoFactorSetupInfo> {
  const preAuthToken = localStorage.getItem('preAuthToken');
  return apiClient.get('/authentication/tfa-setup', {
    Authorization: `Bearer ${preAuthToken}`,
  });
}

async function postTfaSetup(code: string): Promise<IAuthResponse> {
  const preAuthToken = localStorage.getItem('preAuthToken');

  return apiClient.post(
    '/authentication/tfa-setup',
    { code },
    {
      Authorization: `Bearer ${preAuthToken}`,
    }
  );
}

async function verifyTfa(code: string): Promise<IAuthResponse> {
  const preAuthToken = localStorage.getItem('preAuthToken');

  return apiClient.post(
    '/authentication/verify-tfa',
    { code },
    {
      Authorization: `Bearer ${preAuthToken}`,
    }
  );
}