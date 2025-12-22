
const API_BASE_URL = 'https://localhost:5001/api';

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

  const headers = {
    'Authorization': `Bearer ${token}`,
    'Content-Type': 'application/json'
  };

  try {
    const userId = "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa";
    
    console.log('Fetching dashboard data for user:', userId);
    
    const [userRes, reservationsRes, ticketsRes] = await Promise.all([
      fetch(`${API_BASE_URL}/users/${userId}`, { headers }),
      fetch(`${API_BASE_URL}/users/${userId}/reservations`, { headers }),
      fetch(`${API_BASE_URL}/users/${userId}/tickets`, { headers })
    ]);

    if (userRes.status === 404) {
      console.log('User not found, using mock data');
      return getMockData();
    }

    if (!userRes.ok) throw new Error(`User fetch failed: ${userRes.status}`);
    if (!reservationsRes.ok) throw new Error(`Reservations fetch failed: ${reservationsRes.status}`);
    if (!ticketsRes.ok) throw new Error(`Tickets fetch failed: ${ticketsRes.status}`);

    const user = await userRes.json();
    const reservations = await reservationsRes.json();
    const tickets = await ticketsRes.json();

    console.log('API Tickets response:', tickets);
    
    
    if (tickets.length > 0) {
      const sampleTicket = tickets[0];
      console.log('Sample ticket eventDate:', sampleTicket.eventDate);
      console.log('Parsed date:', new Date(sampleTicket.eventDate));
      console.log('Is valid date?', !isNaN(new Date(sampleTicket.eventDate).getTime()));
      console.log('Current date:', new Date());
      console.log('Is future?', new Date(sampleTicket.eventDate) > new Date());
    }

    
    const processedTickets = tickets.map((ticket: ITicket) => {
      const eventDate = new Date(ticket.eventDate);
      const now = new Date();
      const isActive = !isNaN(eventDate.getTime()) && eventDate > now;
      
      console.log(`Ticket ${ticket.id}: eventDate=${ticket.eventDate}, parsed=${eventDate}, isActive=${isActive}`);
      
      return {
        ...ticket,
        isActive
      };
    });

    
    const activeTickets = processedTickets.filter((t: ITicket) => t.isActive);
    
    console.log('Total tickets:', tickets.length);
    console.log('Active tickets:', activeTickets.length);
 
    console.log('Active tickets IDs:', activeTickets.map((t: ITicket) => t.id));

    return {
      user,
      reservations,
      tickets: processedTickets,
      stats: {
        totalReservations: reservations.length,
        activeTicketsCount: activeTickets.length,
        totalSpent: reservations.reduce((sum: number, r: IReservation) => sum + r.totalPrice, 0)
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