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
}

export interface ITwoFactorSetupInfo {
  qrCodeImageUrl: string;
  secretKey: string;
}

export const authService = {
  login,
  signup,
  get2FASetup,
  verify2FA,
};

async function login(data: ILoginRequest): Promise<IAuthResponse> {
  return apiClient.post('/authentication/login', data);
}

async function signup(data: ISignupRequest): Promise<void> {
  await apiClient.post('/authentication', data);
}

async function get2FASetup(): Promise<ITwoFactorSetupInfo> {
  return apiClient.get('/account/setup2fa');
}

async function verify2FA(totpCode: string): Promise<IAuthResponse> {
  return apiClient.post('/account/verify2fa', { totpCode });
}
