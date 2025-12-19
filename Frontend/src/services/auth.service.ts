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
}

export interface ITwoFactorSetupInfo {
  qrCodeImageUrl: string;
  secretKey: string;
}

export const authService = {
  login,
  signup,
  getTfaSetup,
  postTfaSetup,
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

async function postTfaSetup(data: { totpCode: string }): Promise<IAuthResponse> {
  return apiClient.post('/authentication/tfa-setup', data);
}

async function refresh(): Promise<IAuthResponse> {
  return apiClient.post('/authentication/refresh');
}
