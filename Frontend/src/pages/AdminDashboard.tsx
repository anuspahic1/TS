"use client"

import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { apiClient } from '../services/apiClient';

interface AdminStats {
  totalUsers: number;
  totalEvents: number;
  totalBookings: number;
}

const AdminDashboard: React.FC = () => {
  const [stats, setStats] = useState<AdminStats | null>(null);
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(true);
  
  const navigate = useNavigate();

  useEffect(() => {
    const fetchStats = async () => {
      try {
        setLoading(true);
        const data = await apiClient.get<AdminStats>('/admin/statistics');
        setStats(data);
      } catch (err: any) {
        setError(err.message || "Failed to load statistics");
      } finally {
        setLoading(false);
      }
    };
    fetchStats();
  }, []);

  if (loading) {
    return (
      <div className="flex flex-col items-center justify-center min-h-screen bg-gray-50">
        <div className="w-12 h-12 border-4 border-yellow-500 border-t-transparent rounded-full animate-spin mb-4"></div>
        <p className="text-gray-600 font-medium font-sans">Loading Admin Dashboard...</p>
      </div>
    );
  }

  return (
    <div className="min-h-screen bg-gray-50 font-sans p-4 lg:p-12">
      <div className="max-w-7xl mx-auto space-y-10">
        
        <header className="flex flex-col md:flex-row md:items-center justify-between gap-4">
          <div>
            <h1 className="text-4xl font-black text-gray-900 tracking-tight uppercase">
              Admin <span className="text-yellow-500 underline decoration-4 underline-offset-8">Center</span>
            </h1>
            <p className="text-gray-500 mt-3 font-medium">Platform monitoring and resource management</p>
          </div>
          <div className="flex gap-2">
             <div className="px-4 py-2 bg-white rounded-full border border-gray-200 shadow-sm flex items-center gap-2 text-sm font-bold text-gray-600">
                <span className="w-2 h-2 bg-green-500 rounded-full animate-pulse"></span>
                System Live
             </div>
          </div>
        </header>

        {error && (
          <div className="bg-red-50 border-l-4 border-red-500 p-5 rounded-2xl shadow-sm">
            <p className="text-red-700 font-bold tracking-tight">{error}</p>
            <button onClick={() => window.location.reload()} className="mt-2 text-sm text-red-600 underline font-bold">Try to reconnect</button>
          </div>
        )}

        <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
          <StatCard 
            title="Total Users" 
            value={stats?.totalUsers || 0}
            color="bg-blue-50 text-blue-600" 
            iconPath="M17 21v-2a4 4 0 00-4-4H5a4 4 0 00-4 4v2"
          />
          <StatCard 
            title="Active Events" 
            value={stats?.totalEvents || 0}
            color="bg-green-50 text-green-600" 
            iconPath="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z"
          />
          <StatCard 
            title="Total Bookings" 
            value={stats?.totalBookings || 0}
            color="bg-purple-50 text-purple-600" 
            iconPath="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2"
          />
        </div>

        <section className="space-y-6">
          <h2 className="text-xs font-black text-gray-400 uppercase tracking-[0.2em]">Management Shortcuts</h2>
          <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
            <ActionCard 
              title="Manage Users"
              description="View, edit, and moderate registered accounts"
              icon="👥"
              onClick={() => navigate('/admin/users')}
            />
            <ActionCard 
              title="Manage Events"
              description="Review and approve platform events"
              icon="📅"
              onClick={() => navigate('/admin/events')}
            />
            <ActionCard 
              title="Manage Locations"
              description="Add and organize venues, clubs, and event spaces"
              icon="📍"
              onClick={() => navigate('/admin/locations')}
            />
            <ActionCard 
              title="Manage Reservations"
              description="Cancel bookings and view attendee lists for events"
              icon="🎟️"
              onClick={() => navigate('/admin/reservations')}
            />
          </div>
        </section>

        <footer className="bg-white p-8 rounded-3xl shadow-xl border border-gray-100">
           <div className="flex flex-col md:flex-row justify-between items-center gap-6">
              <div className="space-y-1">
                 <h3 className="font-black text-gray-900 uppercase tracking-tight">System Infrastructure</h3>
                 <p className="text-gray-400 text-sm">Real-time status of backend services</p>
              </div>
              <div className="flex flex-wrap gap-4">
                 <span className="flex items-center gap-2 px-4 py-2 bg-green-50 text-green-700 text-xs font-black rounded-lg uppercase">
                    <span className="w-2 h-2 bg-green-500 rounded-full"></span> Database
                 </span>
                 <span className="flex items-center gap-2 px-4 py-2 bg-green-50 text-green-700 text-xs font-black rounded-lg uppercase">
                    <span className="w-2 h-2 bg-green-500 rounded-full"></span> Auth Service
                 </span>
              </div>
           </div>
        </footer>

      </div>
    </div>
  );
};

const StatCard = ({ title, value, color, iconPath }: { title: string; value: string | number; color: string; iconPath: string }) => (
  <div className="bg-white rounded-3xl p-8 shadow-xl shadow-gray-200/50 border border-gray-100 flex items-center justify-between hover:-translate-y-1 transition-all duration-300">
    <div>
      <p className="text-xs font-black text-gray-400 uppercase tracking-widest">{title}</p>
      <p className="text-4xl font-black text-gray-900 mt-2">{value}</p>
    </div>
    <div className={`w-14 h-14 rounded-2xl flex items-center justify-center ${color}`}>
      <svg className="w-7 h-7" fill="none" stroke="currentColor" viewBox="0 0 24 24">
        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2.5} d={iconPath} />
      </svg>
    </div>
  </div>
);

const ActionCard = ({ title, description, icon, onClick, isDark = false }: any) => (
  <button 
    onClick={onClick}
    className={`group p-8 rounded-3xl border text-left transition-all duration-300 ${
      isDark 
      ? 'bg-gray-900 border-gray-800 hover:bg-black text-white' 
      : 'bg-white border-gray-100 hover:border-yellow-200 hover:shadow-2xl shadow-gray-100 text-gray-900'
    }`}
  >
    <div className="text-3xl mb-4 group-hover:scale-110 transition-transform inline-block">{icon}</div>
    <h4 className="text-xl font-black tracking-tight">{title}</h4>
    <p className={`mt-2 text-sm leading-relaxed ${isDark ? 'text-gray-400' : 'text-gray-500'}`}>{description}</p>
    <div className={`mt-6 inline-flex items-center gap-2 text-[10px] font-black uppercase tracking-widest ${isDark ? 'text-yellow-500' : 'text-gray-400 group-hover:text-black'}`}>
        Explore Now <span>→</span>
    </div>
  </button>
);

export default AdminDashboard;