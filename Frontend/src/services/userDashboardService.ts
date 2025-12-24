
import { apiClient } from './apiClient';
import { jwtDecode } from 'jwt-decode';

export interface IAppUser {
  id: string;
  firstName?: string; 
  lastName?: string;  
  fullName?: string;
  email: string;
  username?: string;
  loyaltyPoints: number;
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


export const getUserDashboardData = async (): Promise<IDashboardResponse> => {
  const token = localStorage.getItem('authToken');

  if (!token) {
    throw new Error('Session timed out. Please log in again.');
  }

  try {
    const decoded: any = jwtDecode(token);
    const userId = decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];

    if (!userId) throw new Error('The user ID is not valid');

    return await apiClient.get<IDashboardResponse>(`/users/${userId}/dashboard`);
  } catch (err: any) {
    console.error("Dashboard Service Error:", err);
    throw err;
  }
};

export const updateUserProfile = async (userId: string, userData: any): Promise<IAppUser> => {
  const updatedUser = await apiClient.put<IAppUser>(`/users/${userId}`, userData);
  return updatedUser;
};