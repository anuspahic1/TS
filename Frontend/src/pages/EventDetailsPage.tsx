import React, { useEffect, useState } from 'react';
import { useParams, useNavigate, useLocation } from 'react-router-dom';
import { apiClient } from "../services/apiClient"; 
import type { EventDto } from "../types/IEvent";
import Header from '../components/layout/Header';
import { useAuth } from '../context/AuthContext'; 

const EventDetailsPage: React.FC = () => {
  const { locationId, eventId } = useParams<{ locationId: string; eventId: string }>();
  const [event, setEvent] = useState<EventDto | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  
  const navigate = useNavigate();
  const routerLocation = useLocation(); 
  const { token } = useAuth(); 

  useEffect(() => {
    const fetchEventDetails = async () => {
      if (!locationId || !eventId) return;
      
      try {
        setLoading(true);
        const data = await apiClient.get<EventDto>(`/locations/${locationId}/events/${eventId}`);
        setEvent(data);
      } catch (err: any) {
        setError(err.message || "Failed to load event details.");
      } finally {
        setLoading(false);
      }
    };

    fetchEventDetails();
  }, [locationId, eventId]);

  const handleBooking = () => {
    if (!token) {
      navigate('/login', { 
        state: { from: routerLocation.pathname } 
      });
    } else {
      navigate(`/locations/${locationId}/events/${eventId}/reserve`);
    }
  };

  if (loading) return (
    <div className="min-h-screen flex flex-col items-center justify-center">
      <div className="w-12 h-12 border-4 border-yellow-500 border-t-transparent rounded-full animate-spin mb-4"></div>
      <p className="text-neutral-500 font-medium">Loading details...</p>
    </div>
  );

  if (error || !event) return (
    <div className="min-h-screen flex flex-col items-center justify-center text-center px-4">
      <h1 className="text-2xl font-bold text-neutral-800 mb-2">Oops! Something went wrong.</h1>
      <p className="text-red-500 mb-6">{error || "Event not found."}</p>
      <button onClick={() => navigate('/')} className="px-6 py-2 bg-black text-white rounded-full">Back to Home</button>
    </div>
  );

  return (
    <div className="min-h-screen bg-white">
      <Header />
      
      <main className="container mx-auto px-4 py-12">
    <button 
        onClick={() => navigate('/')} 
        className="mb-8 flex items-center text-neutral-500 hover:text-black transition-colors font-medium"
      >
        <svg className="w-5 h-5 mr-2" fill="none" stroke="currentColor" viewBox="0 0 24 24">
          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M10 19l-7-7m0 0l7-7m-7 7h18" />
        </svg>
        Back to list
     </button>

        <div className="grid grid-cols-1 lg:grid-cols-2 gap-12">
          <div className="h-[400px] md:h-[600px] bg-gradient-to-br from-neutral-900 via-neutral-800 to-black rounded-3xl flex items-center justify-center text-white text-9xl font-black shadow-2xl overflow-hidden relative group">
            <div className="absolute inset-0 bg-yellow-500/10 opacity-0 group-hover:opacity-100 transition-opacity duration-500"></div>
            <span className="relative z-10 select-none tracking-tighter uppercase opacity-20">
              {event.name.substring(0, 1)}
            </span>
          </div>

          <div className="flex flex-col">
            <div className="mb-4">
               <span className="inline-block px-3 py-1 bg-yellow-100 text-yellow-700 text-xs font-bold uppercase rounded-full tracking-wider mb-2">
                 {event.locationName}
               </span>
            </div>
            
            <h1 className="text-5xl md:text-6xl font-black text-neutral-900 mb-6 uppercase tracking-tighter leading-[0.9]">
              {event.name}
            </h1>
            
            <div className="flex flex-wrap items-center gap-6 mb-8 p-6 bg-neutral-50 rounded-2xl border border-neutral-100 shadow-sm">
              <div className="flex-1 min-w-[140px]">
                <p className="text-xs text-neutral-400 uppercase font-black tracking-widest mb-1">Date and Time</p>
                <p className="text-lg font-bold text-neutral-800">
                    {new Date(event.eventDate).toLocaleDateString('en-US', { day: 'numeric', month: 'long', hour: '2-digit', minute: '2-digit' })}
                </p>
              </div>
              <div className="hidden md:block w-px h-12 bg-neutral-200" />
              <div className="flex-1 min-w-[140px]">
                <p className="text-xs text-neutral-400 uppercase font-black tracking-widest mb-1">Ticket Price</p>
                <p className="text-2xl font-black text-yellow-600">from ${event.minTicketPrice}</p>
              </div>
            </div>

            <div className="prose prose-neutral max-w-none mb-10">
              <h3 className="text-xl font-black uppercase tracking-tight mb-4 border-b-2 border-neutral-100 pb-2">About the event</h3>
              <p className="text-neutral-600 leading-relaxed text-lg">
                {event.description || "No detailed description is currently available for this event. Expect an unforgettable atmosphere and top-tier entertainment!"}
              </p>
            </div>

            <button 
              onClick={handleBooking}
              className={`w-full py-5 rounded-2xl font-black text-xl uppercase tracking-tighter transition-all shadow-xl active:scale-[0.98] ${
                token 
                ? 'bg-black text-white hover:bg-neutral-800' 
                : 'bg-yellow-500 text-black hover:bg-yellow-400'
              }`}
            >
              {token ? 'Book Tickets' : 'Login to Book'}
            </button>
            
            {!token && (
              <p className="text-center mt-4 text-sm text-neutral-400">
                You must be logged in to reserve tickets.
              </p>
            )}
          </div>
        </div>
      </main>
    </div>
  );
};

export default EventDetailsPage;