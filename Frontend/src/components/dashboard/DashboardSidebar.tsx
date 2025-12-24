import React from 'react';
import { useAuth } from '../../context/AuthContext';

interface DashboardSidebarProps {
  activeTab: 'reservations' | 'tickets' | 'profile';
  onTabChange: (tab: 'reservations' | 'tickets' | 'profile') => void;
  displayName: string;
}

const DashboardSidebar: React.FC<DashboardSidebarProps> = ({ activeTab, onTabChange }) => {
  const { user } = useAuth();

  const displayName = user?.email ? user.email.split('@')[0] : 'User';

  const tabs = [
    { id: 'reservations', label: 'My Reservations', icon: 'M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z' },
    { id: 'tickets', label: 'Active Tickets', icon: 'M15 5v2m0 4v2m0 4v2M5 5a2 2 0 00-2 2v3a2 2 0 110 4v3a2 2 0 002 2h14a2 2 0 002-2v-3a2 2 0 110-4V7a2 2 0 00-2-2H5z' },
    { id: 'profile', label: 'Profile Settings', icon: 'M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z' },
  ];

  return (
    <div className="lg:w-64">
      <div className="bg-white rounded-2xl shadow-lg overflow-hidden sticky top-8">
        <div className="p-6 bg-yellow-500 text-white text-center">
        <p className="text-lg font-bold truncate">
          {displayName}'s Dashboard
        </p>
      </div>

        <nav className="p-4 space-y-2">
          {tabs.map((tab) => (
            <button
              key={tab.id}
              onClick={() => onTabChange(tab.id as any)}
              className={`w-full flex items-center gap-3 px-4 py-3 rounded-xl transition-all ${
                activeTab === tab.id 
                  ? 'bg-yellow-50 text-yellow-700 border-l-4 border-yellow-500 font-bold' 
                  : 'text-gray-600 hover:bg-gray-50'
              }`}
            >
              <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d={tab.icon} />
              </svg>
              {tab.label}
            </button>
          ))}
        </nav>
      </div>
    </div>
  );
};

export default DashboardSidebar;