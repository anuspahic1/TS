// src/services/userDashboardService.ts
const API_BASE_URL = 'http://localhost:5001/api';

export type ReservationStatus = 'completed' | 'cancelled' | 'upcoming';

export interface IAppUser {
  id: string;
  fullName: string;
  email: string;
  bankAccountNumber?: string;
}

export interface IReservation {
  id: string;
  userId: string;
  eventId: string;
  createdAt: string;
  totalPrice: number;
  eventName?: string;
  eventDate?: string;
  locationName?: string;
  ticketsCount?: number;
  status?: ReservationStatus;
}

export interface ITicket {
  id: string;
  reservationId?: string;
  eventId: string;
  price: number;
  seatNumber?: string;
  qrCode?: string;
  isReserved: boolean;
  eventName?: string;
  eventDate?: string;
  isActive?: boolean;
}

export interface IEvent {
  id: string;
  name: string;
  description?: string;
  eventDate: string;
  locationId: string;
  minTicketPrice?: number;
  createdAt: string;
}

// --- POMOĆNE FUNKCIJE ---

export const getUserIdFromToken = (): string | null => {
  // Ovde bi trebala ići prava logika dekodiranja JWT-a
  return 'user123'; 
};

const determineStatus = (eventDate?: string): ReservationStatus => {
  if (!eventDate) return 'completed';
  try {
    const date = new Date(eventDate);
    const now = new Date();
    return date < now ? 'completed' : 'upcoming';
  } catch {
    return 'completed';
  }
};

// --- API POZIVI ---

const getHeaders = () => ({
  'Authorization': `Bearer ${localStorage.getItem('authToken')}`,
  'Content-Type': 'application/json'
});

export const getAllUsers = async (): Promise<IAppUser[]> => {
  try {
    const response = await fetch(`${API_BASE_URL}/users`, { headers: getHeaders() });
    return response.ok ? await response.json() : [];
  } catch (error) {
    console.error('Error fetching users:', error);
    return [];
  }
};

export const getAllReservations = async (): Promise<IReservation[]> => {
  try {
    const response = await fetch(`${API_BASE_URL}/reservations`, { headers: getHeaders() });
    return response.ok ? await response.json() : [];
  } catch (error) {
    console.error('Error fetching reservations:', error);
    return [];
  }
};

export const getAllTickets = async (): Promise<ITicket[]> => {
  try {
    const response = await fetch(`${API_BASE_URL}/tickets`, { headers: getHeaders() });
    return response.ok ? await response.json() : [];
  } catch (error) {
    console.error('Error fetching tickets:', error);
    return [];
  }
};

export const getAllEvents = async (): Promise<IEvent[]> => {
  try {
    const response = await fetch(`${API_BASE_URL}/events`, { headers: getHeaders() });
    return response.ok ? await response.json() : [];
  } catch (error) {
    console.error('Error fetching events:', error);
    return [];
  }
};

// --- GLAVNA FUNKCIJA ZA DASHBOARD ---

/**
 * Prikuplja sve podatke, filtrira ih za trenutnog korisnika 
 * i spaja (join) podatke iz različitih tabela/endpointa.
 */
export const getUserDashboardData = async () => {
  const userId = getUserIdFromToken();
  if (!userId) throw new Error('User not authenticated');

  // Paralelno uzimanje svih potrebnih sirovih podataka
  const [allUsers, allReservations, allTickets, allEvents] = await Promise.all([
    getAllUsers(),
    getAllReservations(),
    getAllTickets(),
    getAllEvents()
  ]);

  // 1. Trenutni korisnik
  const currentUser = allUsers.find(user => user.id === userId);

  // 2. Filtriranje i obogaćivanje rezervacija
  const userReservations = allReservations
    .filter(res => res.userId === userId)
    .map(res => {
      const event = allEvents.find(e => e.id === res.eventId);
      return {
        ...res,
        eventName: event?.name || 'Unknown Event',
        eventDate: event?.eventDate,
        ticketsCount: allTickets.filter(t => t.reservationId === res.id).length,
        status: determineStatus(event?.eventDate)
      };
    });

  // 3. Filtriranje i obogaćivanje karata (samo aktivne)
  const userTickets = allTickets
    .filter(ticket => {
      const res = allReservations.find(r => r.id === ticket.reservationId);
      return res?.userId === userId;
    })
    .map(ticket => {
      const event = allEvents.find(e => e.id === ticket.eventId);
      const isActive = event ? determineStatus(event.eventDate) === 'upcoming' : false;
      return {
        ...ticket,
        eventName: event?.name,
        eventDate: event?.eventDate,
        isActive
      };
    })
    .filter(t => t.isActive); // Prikazujemo samo one koje tek dolaze

  return {
    user: currentUser,
    reservations: userReservations,
    tickets: userTickets,
    stats: {
      totalSpent: userReservations.reduce((sum, r) => sum + r.totalPrice, 0),
      activeTicketsCount: userTickets.length,
      totalReservations: userReservations.length
    }
  };
};

export const updateUserProfile = async (userId: string, userData: Partial<IAppUser>): Promise<IAppUser> => {
  const response = await fetch(`${API_BASE_URL}/users/${userId}`, {
    method: 'PUT',
    headers: getHeaders(),
    body: JSON.stringify(userData)
  });

  if (!response.ok) throw new Error('Failed to update profile');
  return await response.json();
};