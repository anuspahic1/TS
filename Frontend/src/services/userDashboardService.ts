
const API_BASE_URL = 'https://localhost:5001/api';

import { jwtDecode } from 'jwt-decode'; 


export interface IAppUser {
  id: string;
  fullName: string;
  email: string;
}

export interface IReservation {
  id: string;
  userId: string;
  eventId: string;
  totalPrice: number;
  createdAt: string;
  eventName: string;
  eventDate: string;
  ticketsCount: number;
  status: 'completed' | 'upcoming';
}

export interface ITicket {
  id: string;
  reservationId?: string;
  eventId: string;
  price: number;
  seatNumber?: string;
  qrCode?: string;
  isReserved: boolean;
  eventName: string;
  eventDate: string;
  isActive?: boolean;
}

export const getUserDashboardData = async () => {
  const token = localStorage.getItem('authToken');
  
  if (!token) {
    console.warn('No token found, using mock data');
    return getMockData();
  }

  try {
    const decoded: any = jwtDecode(token);
    const userId = decoded.nameid || decoded.sub;

    const headers = {
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json'
    };

    const response = await fetch(`${API_BASE_URL}/users/${userId}/dashboard`, { headers });

    if (!response.ok) {
        if (response.status === 404) return getMockData();
        throw new Error(`Dashboard fetch failed: ${response.status}`);
    }

    const data = await response.json();

    const now = new Date();
    const processedTickets = data.tickets.map((ticket: ITicket) => ({
      ...ticket,
      isActive: ticket.eventDate ? new Date(ticket.eventDate) > now : false
     // qrCode: ticket.qrCode || ticket.id
    }));

    return {
      user: data.user,
      reservations: data.reservations,
      tickets: processedTickets,
      stats: {
        totalReservations: data.stats.totalReservations,
        activeTicketsCount: data.stats.activeTickets, 
        totalSpent: data.stats.totalSpent
      }
    };

  } catch (error: any) {
    console.error('Dashboard API error:', error);
    return getMockData();
  }
};


const getMockData = () => {
  const mockUser: IAppUser = {
    id: "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa",
    fullName: "Emin Džanko",
    email: "emin@example.com"
  };
  
  const mockReservations: IReservation[] = [
    {
      id: "res1",
      userId: mockUser.id,
      eventId: "event1",
      totalPrice: 120.50,
      createdAt: "2025-01-15T10:30:00Z",
      eventName: "Concert Night",
      eventDate: "2024-12-25T20:00:00Z",
      ticketsCount: 2,
      status: "upcoming"
    },
    {
      id: "res2", 
      userId: mockUser.id,
      eventId: "event2",
      totalPrice: 75.00,
      createdAt: "2024-01-10T14:20:00Z",
      eventName: "Theater Show",
      eventDate: "2025-01-20T19:30:00Z",
      ticketsCount: 1,
      status: "completed"
    }
  ];
  
  const mockTickets: ITicket[] = [
    {
      id: "ticket1",
      eventId: "event1",
      price: 60.25,
      seatNumber: "A12",
      isReserved: true,
      eventName: "Concert Night",
      eventDate: "2025-12-25T20:00:00Z",
      qrCode: "TICKET-12345-EMIN"
    },
    {
      id: "ticket2",
      eventId: "event1",
      price: 60.25,
      seatNumber: "A13",
      isReserved: true,
      eventName: "Concert Night", 
      eventDate: "2025-12-25T20:00:00Z",
      qrCode: "TICKET-67890-EMIN"
    }
  ];
  
  const processedTickets = mockTickets.map(ticket => ({
    ...ticket,
    isActive: new Date(ticket.eventDate) > new Date()
  }));
  
  
  const activeTicketsFromMock = processedTickets.filter((t: ITicket) => t.isActive);
  
  return {
    user: mockUser,
    reservations: mockReservations,
    tickets: processedTickets,
    stats: {
      totalReservations: mockReservations.length,
      activeTicketsCount: activeTicketsFromMock.length,
      totalSpent: mockReservations.reduce((sum: number, r: IReservation) => sum + r.totalPrice, 0)
    }
  };
};

export const updateUserProfile = async (userId: string, userData: Partial<IAppUser>): Promise<IAppUser> => {
  const token = localStorage.getItem('authToken');
  const headers = {
    'Authorization': `Bearer ${token}`,
    'Content-Type': 'application/json'
  };
  
  try {
    const response = await fetch(`${API_BASE_URL}/users/${userId}`, {
      method: 'PUT',
      headers,
      body: JSON.stringify(userData)
    });

    if (!response.ok) throw new Error('Failed to update profile');
    return await response.json();
  } catch (error) {
    console.error('Update profile error:', error);
    return {
      id: userId,
      fullName: userData.fullName || "Updated User",
      email: userData.email || "updated@example.com"
    };
  }
};