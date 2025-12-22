import React, { useEffect, useState } from 'react';
import { apiClient } from '../services/apiClient';
import { useAuth } from '../context/AuthContext';

const UserDashboard: React.FC = () => {
  const { user } = useAuth();
  const [reservations, setReservations] = useState<any[]>([]);

  useEffect(() => {
    const fetchReservations = async () => {
      try {
        const data = await apiClient.get<any[]>(`/users/my-reservations`); 
        setReservations(data);
      } catch (err) {
        console.error(err);
      }
    };
    fetchReservations();
  }, []);

  return (
    <div className="min-h-screen bg-neutral-50">
      <main className="max-w-4xl mx-auto py-16 px-6">
        <h1 className="text-4xl font-black uppercase mb-8">My Experience Dashboard</h1>
        <div className="grid gap-6">
          {reservations.map((res) => (
            <div key={res.id} className="bg-white p-8 rounded-[2rem] border border-neutral-200 flex justify-between items-center">
              <div>
                <h2 className="text-xl font-black uppercase">{res.eventName}</h2>
                <p className="text-neutral-400 font-bold text-xs uppercase tracking-widest">{res.locationName}</p>
                <p className="mt-4 text-sm font-medium">Seat: <span className="font-black text-yellow-500">{res.seatNumber}</span></p>
              </div>
              <div className="text-right">
                <div className="bg-green-100 text-green-700 px-4 py-1 rounded-full text-[10px] font-black uppercase">Confirmed</div>
              </div>
            </div>
          ))}
        </div>
      </main>
    </div>
  );
};

export default UserDashboard;