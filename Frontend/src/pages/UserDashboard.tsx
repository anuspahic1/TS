import React, { useState, useEffect } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';


import {
  getUserDashboardData,
  type IAppUser,
  type IReservation,
  type ITicket
} from '../services/userDashboardService';


import ReservationHistory from '../components/dashboard/ReservationHistory';
import ActiveTickets from '../components/dashboard/ActiveTickets';
import UserProfile from '../components/dashboard/UserProfile';
import DashboardSidebar from '../components/dashboard/DashboardSidebar';

const UserDashboard: React.FC = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const { user } = useAuth();

  const [activeTab, setActiveTab] = useState<'reservations' | 'tickets' | 'profile'>(
    location.state?.activeTab || 'reservations'
  );


  const [reservations, setReservations] = useState<IReservation[]>([]);
  const [tickets, setTickets] = useState<ITicket[]>([]);
  const [userProfile, setUserProfile] = useState<IAppUser | null>(null);
  const [stats, setStats] = useState({
    totalReservations: 0,
    activeTicketsCount: 0,
    totalSpent: 0
  });

  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  const fetchData = async () => {
    try {
      setLoading(true);
      setError(null);

      const data = await getUserDashboardData();

      if (data) {
        const allTickets = data.tickets || [];

        const activeTicketsOnly = allTickets.filter(ticket => {
          const eventDate = new Date(ticket.eventDate);
          const today = new Date();

          today.setHours(0, 0, 0, 0);

          return eventDate >= today;
        });

        setReservations(data.reservations || []);
        setTickets(allTickets);
        setUserProfile(data.user || null);

        setStats({
          totalReservations: data.stats?.totalReservations || (data.reservations?.length || 0),
          activeTicketsCount: activeTicketsOnly.length,
          totalSpent: data.stats?.totalSpent || 0
        });
      }
    } catch (err: any) {
    } finally {
      setLoading(false);
    }
  };
  useEffect(() => {
    fetchData();
  }, [navigate]);

  const handleUpdateProfile = (updatedUser: IAppUser) => {
    setUserProfile(updatedUser);
  };


  if (loading) {
    return (
      <div className="flex flex-col items-center justify-center min-h-screen bg-gray-50">
        <div className="w-12 h-12 border-4 border-yellow-500 border-t-transparent rounded-full animate-spin mb-4"></div>
        <p className="text-gray-600 font-medium">Loading your Dashboard...</p>
      </div>
    );
  }

  return (
    <div className="min-h-screen bg-gray-50 flex flex-col lg:flex-row p-4 lg:p-8 gap-8">
      <DashboardSidebar
        activeTab={activeTab}
        onTabChange={setActiveTab}
        displayName={userProfile?.username || userProfile?.firstName || user?.email?.split('@')[0]}
      />

      <div className="flex-1 space-y-8">

        {error && (
          <div className="bg-red-50 border-l-4 border-red-500 p-4 rounded-xl">
            <p className="text-red-700 font-medium">{error}</p>
            <button
              onClick={fetchData}
              className="mt-2 text-sm text-red-600 underline hover:text-red-800"
            >
              Try again
            </button>
          </div>
        )}

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
                Profile data not available.
              </div>
            )
          )}
        </div>

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

function useAuth(): { user: any; } {
  throw new Error('Function not implemented.');
}
