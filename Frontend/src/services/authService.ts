const API_BASE_URL = 'http://localhost:5000/api'; 
const LOGIN_URL = `${API_BASE_URL}/authentication/login`; 
const SIGNUP_URL = `${API_BASE_URL}/authentication`;     
const SETUP_2FA_URL = `${API_BASE_URL}/Account/Setup2FA`; 
const VERIFY_2FA_URL = `${API_BASE_URL}/Account/Verify2FA`; 


export interface ILoginRequest {
    userName: string; 
    password: string;
    totpCode: string; 
}

export interface ISignupRequest {
    firstName?: string;
    lastName?: string; 
    userName: string;
    password: string;
    email?: string; 
    phoneNumber?: string;
    roles?: string[];
}

export interface IAuthResponse {
    accessToken: string; 
    refreshToken: string;
}

export interface ITwoFactorSetupInfo {
    qrCodeImageUrl: string; 
    secretKey: string; 
}

export interface IVerify2FARequest {
    totpCode: string;
}


export const login = async (credentials: ILoginRequest): Promise<IAuthResponse> => {
    const response = await fetch(LOGIN_URL, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(credentials), 
});

if (response.ok) { 
    return await response.json(); 
} 

const errorData = await response.json().catch(() => ({}));
    let errorMessage: string;

if (response.status === 401) {
    errorMessage = 'Invalid username, password, or 2FA code.'; 
    } else {
    errorMessage = errorData.message || `Login failed with status ${response.status}`;
    }

throw new Error(errorMessage);
};

export const signup = async (data: ISignupRequest): Promise<boolean> => {

if (!data.roles || data.roles.length === 0) {
    data.roles = ["User"];
}

const response = await fetch(SIGNUP_URL, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(data), 
    });

if (response.status === 201) {
    return true;
}

const errorData = await response.json().catch(() => ({}));
const errorMessage = errorData.message || JSON.stringify(errorData);

throw new Error(errorMessage || `Signup failed with status ${response.status}`);
};

export const get2FASetupInfo = async (): Promise<ITwoFactorSetupInfo> => {

const token = localStorage.getItem('authToken'); 

if (!token) {
throw new Error('Authentication token is missing. Please log in or register again.');
}

const response = await fetch(SETUP_2FA_URL, {
    method: 'GET',
    headers: {
    'Content-Type': 'application/json',
    'Authorization': `Bearer ${token}` 
    },
});

if (response.ok) {
    return await response.json();
}

const errorData = await response.json().catch(() => ({}));
    throw new Error(errorData.message || `Failed to fetch 2FA setup info with status ${response.status}`);
};

export const verify2FASetup = async (data: IVerify2FARequest): Promise<IAuthResponse> => {
    const token = localStorage.getItem('authToken'); 

if (!token) {
    throw new Error('Authentication token is missing. Please log in or register again.');
}

const response = await fetch(VERIFY_2FA_URL, {
    method: 'POST',
    headers: {
    'Content-Type': 'application/json',
    'Authorization': `Bearer ${token}` 
    },
    body: JSON.stringify(data), 
});

if (response.ok) {
    return await response.json(); 
}

const errorData = await response.json().catch(() => ({}));
let errorMessage: string;

if (response.status === 400 || response.status === 401) {
    errorMessage = errorData.message || 'Verification failed. Invalid code or setup error.'; 
    } else {
    errorMessage = errorData.message || `Verification failed with status ${response.status}`;
}

throw new Error(errorMessage);
};