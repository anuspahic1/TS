import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

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
  const [activeTab, setActiveTab] = useState<'reservations' | 'tickets' | 'profile'>('reservations');
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
  const navigate = useNavigate();

  useEffect(() => {
    const fetchData = async () => {
      setLoading(true);
      setError(null);
      
      try {
        const data = await getUserDashboardData();
        
        setReservations(data.reservations);
        setTickets(data.tickets);
        setUserProfile(data.user || null);
        setStats(data.stats);
        
      } catch (err: any) {
        setError(err.message || 'Failed to load dashboard data');
        console.error('Dashboard error:', err);
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, []);

  const handleLogout = () => {
    localStorage.removeItem('authToken');
    navigate('/login');
  };

  const handleDeleteAccount = async () => {
    if (window.confirm('Are you sure you want to delete your account?')) {
      handleLogout();
    }
  };

  const handleUpdateProfile = (updatedProfile: IAppUser) => {
    setUserProfile(updatedProfile);
    alert('Profile updated successfully!');
  };

  if (error && !loading) {
    return (
      <div className="min-h-screen bg-gradient-to-br from-gray-50 via-white to-yellow-50 flex items-center justify-center">
        <div className="bg-red-50 border-l-4 border-red-500 p-6 rounded-r-lg max-w-md">
          <h3 className="text-lg font-medium text-red-800">Error Loading Dashboard</h3>
          <p className="text-red-700 mt-1">{error}</p>
          <button
            onClick={() => window.location.reload()}
            className="mt-4 px-4 py-2 bg-red-600 text-white rounded-lg hover:bg-red-700"
          >
            Retry
          </button>
        </div>
      </div>
    );
  }

  return (
    <div className="min-h-screen bg-gradient-to-br from-gray-50 via-white to-yellow-50">
      <div className="container mx-auto px-4 py-8 max-w-7xl">
        <div className="mb-8">
          <h1 className="text-4xl font-bold text-gray-900 mb-2">
            Welcome back, {userProfile?.fullName?.split(' ')[0] || 'User'}!
          </h1>
          <p className="text-gray-600 text-lg">
            Manage your reservations, tickets, and account settings
          </p>
        </div>

        <div className="flex flex-col lg:flex-row gap-8">
          <DashboardSidebar
            activeTab={activeTab}
            onTabChange={setActiveTab}
            onLogout={handleLogout}
            onDeleteAccount={handleDeleteAccount}
          />

          <div className="flex-1">
            {loading ? (
              <div className="flex items-center justify-center py-20">
                <div className="animate-spin rounded-full h-12 w-12 border-4 border-yellow-500 border-t-transparent"></div>
              </div>
            ) : (
              <>
                {activeTab === 'reservations' && (
                  <ReservationHistory reservations={reservations} />
                )}
                
                {activeTab === 'tickets' && (
                  <ActiveTickets tickets={tickets} />
                )}
                
                {activeTab === 'profile' && userProfile && (
                  <UserProfile 
                    profile={userProfile} 
                    onUpdateProfile={handleUpdateProfile}
                  />
                )}
              </>
            )}
          </div>
        </div>

        {!loading && (
          <div className="grid grid-cols-1 md:grid-cols-3 gap-6 mt-8">
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
        )}
      </div>
    </div>
  );
};

const StatCard = ({ title, value, color }: { title: string; value: string | number; color: string }) => (
  <div className="bg-white rounded-2xl p-6 shadow-lg border border-gray-200 flex items-center justify-between">
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