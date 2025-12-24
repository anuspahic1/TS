// src/pages/UserDashboard.tsx
import React, { useState, useEffect } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';

// Uvozi servis i tipove
import { 
  getUserDashboardData, 
  type IAppUser, 
  type IReservation, 
  type ITicket 
} from '../services/userDashboardService'; 

// Uvozi komponente
import ReservationHistory from '../components/dashboard/ReservationHistory';
import ActiveTickets from '../components/dashboard/ActiveTickets';
import UserProfile from '../components/dashboard/UserProfile';
import DashboardSidebar from '../components/dashboard/DashboardSidebar';

const UserDashboard: React.FC = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const { user } = useAuth();

  // State za navigaciju kroz tabove
  const [activeTab, setActiveTab] = useState<'reservations' | 'tickets' | 'profile'>(
    location.state?.activeTab || 'reservations'
  );

  // State za podatke
  const [reservations, setReservations] = useState<IReservation[]>([]);
  const [tickets, setTickets] = useState<ITicket[]>([]);
  const [userProfile, setUserProfile] = useState<IAppUser | null>(null);
  const [stats, setStats] = useState({
    totalReservations: 0,
    activeTicketsCount: 0,
    totalSpent: 0
  });

  // State za UI (loading i error)
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  // Funkcija za dobavljanje podataka sa API-ja
  const fetchData = async () => {
  try {
    setLoading(true);
    setError(null);
    
    const data = await getUserDashboardData();
    
    if (data) {
      const allTickets = data.tickets || [];
      
      // LOGIKA FILTRIRANJA: Brojimo samo karte čiji je datum u budućnosti ili danas
      const activeTicketsOnly = allTickets.filter(ticket => {
        const eventDate = new Date(ticket.eventDate);
        const today = new Date();
        
        // Postavljamo "danas" na početak dana (00:00) radi preciznijeg poređenja
        today.setHours(0, 0, 0, 0);
        
        return eventDate >= today;
      });

      setReservations(data.reservations || []);
      setTickets(allTickets); // Čuvamo sve karte za prikaz u listi (ili ih isto filtrirajte ako želite)
      setUserProfile(data.user || null);

      setStats({
        totalReservations: data.stats?.totalReservations || (data.reservations?.length || 0),
        // Ovdje sada koristimo filtrirani niz za broj aktivnih karata
        activeTicketsCount: activeTicketsOnly.length, 
        totalSpent: data.stats?.totalSpent || 0
      });
    }
  } catch (err: any) {
    // ... error handling ostaje isti
  } finally {
    setLoading(false);
  }
};
  useEffect(() => {
    fetchData();
  }, [navigate]);

  // Funkcija koju prosljeđujemo UserProfile komponenti da ažurira Dashboard bez refresha
  const handleUpdateProfile = (updatedUser: IAppUser) => {
    setUserProfile(updatedUser);
  };

  // Loader ekran
  if (loading) {
    return (
      <div className="flex flex-col items-center justify-center min-h-screen bg-gray-50">
        <div className="w-12 h-12 border-4 border-yellow-500 border-t-transparent rounded-full animate-spin mb-4"></div>
        <p className="text-gray-600 font-medium">Učitavanje vašeg Dashboard-a...</p>
      </div>
    );
  }

  return (
    <div className="min-h-screen bg-gray-50 flex flex-col lg:flex-row p-4 lg:p-8 gap-8">
      {/* Sidebar - Meni */}
      <DashboardSidebar 
        activeTab={activeTab} 
        onTabChange={setActiveTab} 
        displayName={userProfile?.username || userProfile?.firstName || user?.email?.split('@')[0]}
        // onDeleteAccount je uklonjen
      />

      {/* Glavni Sadržaj */}
      <div className="flex-1 space-y-8">
        
        {/* Prikaz greške ako postoji */}
        {error && (
          <div className="bg-red-50 border-l-4 border-red-500 p-4 rounded-xl">
            <p className="text-red-700 font-medium">{error}</p>
            <button 
              onClick={fetchData} 
              className="mt-2 text-sm text-red-600 underline hover:text-red-800"
            >
              Pokušaj ponovo
            </button>
          </div>
        )}

        {/* Tabovi - Dinamički prikaz */}
        <div className="transition-all duration-300">
          {activeTab === 'reservations' && (
            <ReservationHistory reservations={reservations} />
          )}

          {activeTab === 'tickets' && (
            <ActiveTickets tickets={tickets} />
          )}

          {activeTab === 'profile' && (
            userProfile ? (
              <UserProfile 
                profile={userProfile} 
                onUpdateProfile={handleUpdateProfile} 
              />
            ) : (
              <div className="bg-white p-8 rounded-2xl shadow text-center text-gray-500">
                Podaci o profilu nisu dostupni.
              </div>
            )
          )}
        </div>

        {/* Stats Kartice - Prikazuju se ispod sadržaja taba */}
        <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
          <StatCard 
            title="Total Reservations" 
            value={stats.totalReservations}
            color="bg-yellow-100 text-yellow-600" 
          />
          <StatCard 
            title="Active Tickets" 
            value={stats.activeTicketsCount}
            color="bg-green-100 text-green-600" 
          />
          <StatCard 
            title="Total Spent" 
            value={`$${stats.totalSpent.toFixed(2)}`}
            color="bg-blue-100 text-blue-600" 
          />
        </div>
      </div>
    </div>
  );
};

// Pomoćna komponenta za statistiku
const StatCard = ({ title, value, color }: { title: string; value: string | number; color: string }) => (
  <div className="bg-white rounded-2xl p-6 shadow-lg border border-gray-100 flex items-center justify-between hover:shadow-xl transition-shadow">
    <div>
      <p className="text-sm font-medium text-gray-500">{title}</p>
      <p className="text-3xl font-bold text-gray-900 mt-2">{value}</p>
    </div>
    <div className={`w-12 h-12 rounded-xl flex items-center justify-center ${color}`}>
      <svg className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M13 7h8m0 0v8m0-8l-8 8-4-4-6 6" />
      </svg>
    </div>
  </div>
);

export default UserDashboard;