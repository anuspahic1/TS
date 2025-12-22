import React, { useEffect, useState } from 'react';
import { useParams, useNavigate, useLocation } from 'react-router-dom';
import { apiClient } from "../services/apiClient"; 
import type { EventDto } from "../types/IEvent";
import { useAuth } from '../context/AuthContext'; 
import Header from '../components/layout/Header';
import Footer from '../components/layout/Footer';
import EventHero from '../components/event/EventHero';
import EventInfo from '../components/event/EventInfo';

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
      navigate('/login', { state: { from: routerLocation.pathname } });
    } else {
      navigate(`/locations/${locationId}/events/${eventId}/reserve`);
    }
  };

  if (loading) return (
    <div className="min-h-screen flex flex-col items-center justify-center bg-white">
      <div className="w-12 h-12 border-4 border-neutral-100 border-t-yellow-500 rounded-full animate-spin"></div>
    </div>
  );

  if (error || !event) return (
    <div className="min-h-screen flex flex-col items-center justify-center text-center px-6">
      <h1 className="text-2xl font-black mb-6">Event details not available.</h1>
      <button onClick={() => navigate('/')} className="px-8 py-3 bg-black text-white rounded-xl font-bold uppercase tracking-widest text-xs">
        Return Home
      </button>
    </div>
  );

  const eventDate = new Date(event.eventDate);
  const isValidDate = eventDate.getFullYear() > 1900; 

  const dateText = isValidDate 
    ? eventDate.toLocaleDateString('en-US', { 
        weekday: 'long', 
        month: 'long', 
        day: 'numeric', 
        year: 'numeric' 
      })
    : "Date To Be Determined";

  return (
    <div className="min-h-screen bg-white flex flex-col font-sans">
      <Header />
      
      <main className="container mx-auto max-w-7xl px-6 py-12 flex-grow">
        <button 
          onClick={() => navigate('/')} 
          className="mb-10 flex items-center gap-2 text-neutral-400 hover:text-black transition-colors text-[10px] font-black uppercase tracking-[0.2em]"
        >
          <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={3} d="M10 19l-7-7m0 0l7-7m-7 7h18" />
          </svg>
          Back to Explorers
        </button>

        <div className="grid grid-cols-1 lg:grid-cols-2 gap-16 items-start">
          <EventHero name={event.name} />
          
          <EventInfo 
            locationName={event.locationName}
            description={event.description}
            price={event.minTicketPrice}
            dateText={dateText}
            token={token}
            onBooking={handleBooking}
          />
        </div>
      </main>

      <Footer />
    </div>
  );
};

export default EventDetailsPage;