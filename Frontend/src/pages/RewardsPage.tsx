import React, { useEffect, useState } from 'react';
import { useAuth } from '../context/AuthContext';
import { apiClient } from '../services/apiClient';
import type { IAppUser } from '../services/userDashboardService';

const RewardsPage: React.FC = () => {
  const { user } = useAuth();
  const [userData, setUserData] = useState<IAppUser | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchRewardsData = async () => {
      if (!user?.id) return;
      try {
        const userRes = await apiClient.get<IAppUser>(`/users/${user.id}`);
        setUserData(userRes);
      } catch (err) {
        console.error("Error loading rewards data", err);
      } finally {
        setLoading(false);
      }
    };

    fetchRewardsData();
  }, [user?.id]);

  const currentPoints = userData?.loyaltyPoints || 0;
  const progress = currentPoints % 10; 
  const percentage = (progress / 10) * 100;
  const pointsNeeded = 10 - progress;

  if (loading) return <div className="p-20 text-center font-black uppercase tracking-widest animate-pulse">Loading Rewards...</div>;

  return (
    <div className="min-h-screen bg-white pb-20">
      <div className="bg-neutral-900 text-white pt-32 pb-20 px-6 rounded-b-[3rem] shadow-2xl">
        <div className="max-w-5xl mx-auto flex flex-col md:flex-row justify-between items-center gap-10">
          <div>
            <h1 className="text-5xl md:text-7xl font-black uppercase tracking-tighter leading-none mb-4">
              Your <span className="text-yellow-500">Status</span>
            </h1>
            <p className="text-neutral-400 max-w-md font-medium">
              Collect points with every ticket purchase and unlock exclusive discounts for your premium experiences.
            </p>
          </div>
          
          <div className="relative group">
            <div className="absolute -inset-1 bg-gradient-to-r from-yellow-400 to-yellow-600 rounded-[2.5rem] blur opacity-25 group-hover:opacity-50 transition duration-1000"></div>
            <div className="relative bg-neutral-800 border border-neutral-700 p-10 rounded-[2.5rem] text-center min-w-[280px]">
              <p className="text-[10px] font-black uppercase tracking-[0.3em] text-yellow-500 mb-2">Total Points Earned</p>
              <div className="text-6xl font-black">{currentPoints}</div>
              <p className="text-sm text-neutral-400 mt-2 font-bold tracking-widest uppercase">Loyalty Points</p>
            </div>
          </div>
        </div>
      </div>

      <div className="max-w-5xl mx-auto px-6 -mt-10">
        <div className="grid grid-cols-1 md:grid-cols-3 gap-6 mb-20">
          <div className="bg-white p-8 rounded-[2rem] shadow-xl border border-neutral-100">
            <div className="w-12 h-12 bg-yellow-500 rounded-2xl flex items-center justify-center mb-6 shadow-lg shadow-yellow-500/20">
              <span className="font-black text-xl">1</span>
            </div>
            <h3 className="font-black uppercase tracking-widest text-sm mb-2">Collect</h3>
            <p className="text-neutral-500 text-sm leading-relaxed">Every ticket you reserve brings you 1 loyalty point to your digital wallet.</p>
          </div>

          <div className="bg-white p-8 rounded-[2rem] shadow-xl border border-neutral-100">
            <div className="w-12 h-12 bg-neutral-900 text-white rounded-2xl flex items-center justify-center mb-6">
              <span className="font-black text-xl">2</span>
            </div>
            <h3 className="font-black uppercase tracking-widest text-sm mb-2">Unlock</h3>
            <p className="text-neutral-500 text-sm leading-relaxed">Once you reach 10 points, you unlock a 10% discount for your next purchase.</p>
          </div>

          <div className="bg-white p-8 rounded-[2rem] shadow-xl border border-neutral-100">
            <div className="w-12 h-12 bg-yellow-500 rounded-2xl flex items-center justify-center mb-6 shadow-lg shadow-yellow-500/20">
              <span className="font-black text-xl">3</span>
            </div>
            <h3 className="font-black uppercase tracking-widest text-sm mb-2">Enjoy</h3>
            <p className="text-neutral-500 text-sm leading-relaxed">Apply your points at the checkout and enjoy the event with a special price.</p>
          </div>
        </div>

        <div className="bg-neutral-50 rounded-[3rem] p-10 md:p-16 border border-neutral-200 shadow-inner">
          <div className="flex flex-col md:flex-row justify-between items-end mb-8 gap-4">
            <div>
              <h2 className="text-4xl font-black uppercase tracking-tighter mb-2">Reward <span className="text-yellow-500">Progress</span></h2>
              <p className="text-neutral-500 font-bold uppercase text-xs tracking-[0.2em]">
                {pointsNeeded > 0 
                  ? `You are ${pointsNeeded} tickets away from your next 10% discount` 
                  : "You have a discount ready to use!"}
              </p>
            </div>
            <div className="text-right">
              <span className="text-5xl font-black text-neutral-900">{progress}</span>
              <span className="text-2xl font-black text-neutral-300">/10</span>
            </div>
          </div>

          <div className="w-full h-8 bg-neutral-200 rounded-full overflow-hidden p-1 shadow-inner">
            <div 
              className="h-full bg-gradient-to-r from-yellow-400 via-yellow-500 to-yellow-600 rounded-full transition-all duration-1000 ease-out shadow-lg"
              style={{ width: `${percentage}%` }}
            >
              <div className="w-full h-full opacity-30 bg-[linear-gradient(45deg,rgba(255,255,255,.2)_25%,transparent_25%,transparent_50%,rgba(255,255,255,.2)_50%,rgba(255,255,255,.2)_75%,transparent_75%,transparent)] bg-[length:30px_30px] animate-[stripes_2s_linear_infinite]"></div>
            </div>
          </div>

          <div className="mt-8 flex justify-between items-center">
            <div className="flex gap-2">
              {[...Array(10)].map((_, i) => (
                <div 
                  key={i} 
                  className={`w-3 h-3 rounded-full transition-colors duration-500 ${i < progress ? 'bg-yellow-500' : 'bg-neutral-300'}`}
                />
              ))}
            </div>
            <p className="text-[10px] font-black uppercase tracking-widest text-neutral-400">
              Next Milestone: 10% OFF
            </p>
          </div>
        </div>
      </div>

      <style>{`
        @keyframes stripes {
          from { background-position: 0 0; }
          to { background-position: 60px 0; }
        }
      `}</style>
    </div>
  );
};

export default RewardsPage;