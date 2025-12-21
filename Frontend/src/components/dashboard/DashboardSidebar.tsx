// src/components/dashboard/DashboardSidebar.tsx
import React from 'react';

interface DashboardSidebarProps {
  activeTab: 'reservations' | 'tickets' | 'profile';
  onTabChange: (tab: 'reservations' | 'tickets' | 'profile') => void;
  onLogout: () => void;
  onDeleteAccount: () => void;
}

const DashboardSidebar: React.FC<DashboardSidebarProps> = ({
  activeTab,
  onTabChange,
  onLogout,
  onDeleteAccount
}) => {
  return (
    <div className="lg:w-64">
      <div className="bg-white rounded-2xl shadow-lg overflow-hidden sticky top-8">
        {/* User Avatar */}
        <div className="p-6 bg-gradient-to-r from-yellow-500 to-yellow-600 text-white text-center">
          <div className="w-20 h-20 mx-auto mb-4 bg-white/20 rounded-full flex items-center justify-center">
            <svg className="w-10 h-10" fill="currentColor" viewBox="0 0 20 20">
              <path fillRule="evenodd" d="M10 9a3 3 0 100-6 3 3 0 000 6zm-7 9a7 7 0 1114 0H3z" clipRule="evenodd" />
            </svg>
          </div>
          <p className="font-semibold">My Account</p>
        </div>

        {/* Navigation */}
        <nav className="p-4 space-y-2">
          <button
            onClick={() => onTabChange('reservations')}
            className={`w-full flex items-center gap-3 px-4 py-3 rounded-xl transition-all duration-200 ${
              activeTab === 'reservations'
                ? 'bg-yellow-50 text-yellow-700 border-l-4 border-yellow-500'
                : 'text-gray-700 hover:bg-gray-50'
            }`}
          >
            <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2" />
            </svg>
            <span>Reservation History</span>
          </button>

          <button
            onClick={() => onTabChange('tickets')}
            className={`w-full flex items-center gap-3 px-4 py-3 rounded-xl transition-all duration-200 ${
              activeTab === 'tickets'
                ? 'bg-yellow-50 text-yellow-700 border-l-4 border-yellow-500'
                : 'text-gray-700 hover:bg-gray-50'
            }`}
          >
            <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M15 5v2m0 4v2m0 4v2M5 5a2 2 0 00-2 2v3a2 2 0 110 4v3a2 2 0 002 2h14a2 2 0 002-2v-3a2 2 0 110-4V7a2 2 0 00-2-2H5z" />
            </svg>
            <span>Active Tickets</span>
          </button>

          <button
            onClick={() => onTabChange('profile')}
            className={`w-full flex items-center gap-3 px-4 py-3 rounded-xl transition-all duration-200 ${
              activeTab === 'profile'
                ? 'bg-yellow-50 text-yellow-700 border-l-4 border-yellow-500'
                : 'text-gray-700 hover:bg-gray-50'
            }`}
          >
            <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z" />
            </svg>
            <span>Profile Settings</span>
          </button>
        </nav>

        {/* Actions */}
        <div className="p-4 border-t border-gray-200 space-y-3">
          <button
            onClick={onLogout}
            className="w-full flex items-center justify-center gap-2 px-4 py-3 bg-gradient-to-r from-gray-100 to-gray-200 text-gray-700 font-medium rounded-xl hover:from-gray-200 hover:to-gray-300 transition-all"
          >
            <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M17 16l4-4m0 0l-4-4m4 4H7m6 4v1a3 3 0 01-3 3H6a3 3 0 01-3-3V7a3 3 0 013-3h4a3 3 0 013 3v1" />
            </svg>
            Logout
          </button>
        </div>
      </div>
    </div>
  );
};

export default DashboardSidebar;