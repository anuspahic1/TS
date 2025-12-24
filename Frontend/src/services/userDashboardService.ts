// src/services/userDashboardService.ts
import { apiClient } from './apiClient';
import { jwtDecode } from 'jwt-decode';

// --- INTERFEJSI (ostaju isti) ---
export interface IAppUser {
  id: string;
  firstName?: string; 
  lastName?: string;  
  fullName?: string;
  email: string;
  username?: string;
}

export interface IReservation {
  id: string;
  eventName: string;
  eventDate: string;
  totalPrice: number;
  ticketsCount: number;
  status: 'completed' | 'upcoming';
  createdAt: string;
}

export interface ITicket {
  id: string;
  eventName: string;
  eventDate: string;
  price: number;
  seatNumber?: string;
  qrCode?: string;
  isActive?: boolean;
}

export interface IDashboardResponse {
  user: IAppUser;
  reservations: IReservation[];
  tickets: ITicket[];
  stats: {
    totalReservations: number;
    activeTicketsCount: number;
    totalSpent: number;
  };
}

// --- FUNKCIJE ---

export const getUserDashboardData = async (): Promise<IDashboardResponse> => {
  const token = localStorage.getItem('accessToken');

  if (!token) {
    throw new Error('Session timed out. Please log in again.');
  }

  try {
    const decoded: any = jwtDecode(token);
    const userId = decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];

    if (!userId) throw new Error('The user ID is not valid');

    // Koristimo apiClient koji već dodaje Authorization header
    return await apiClient.get<IDashboardResponse>(`/users/${userId}/dashboard`);
  } catch (err: any) {
    console.error("Dashboard Service Error:", err);
    throw err;
  }
};

export const updateUserProfile = async (userId: string, userData: any): Promise<IAppUser> => {
  // Promijenili smo tip sa Partial<IAppUser> na 'any' da dopustimo PascalCase za backend
  const updatedUser = await apiClient.put<IAppUser>(`/users/${userId}`, userData);
  return updatedUser;
};