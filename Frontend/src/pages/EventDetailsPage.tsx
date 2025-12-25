"use client"

import React, { useEffect, useState } from 'react';
import { useParams, useNavigate, useLocation } from 'react-router-dom';
import Swal from 'sweetalert2'; 
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
  const { token, user } = useAuth(); 
  const navigate = useNavigate();
  const routerLocation = useLocation(); 

  useEffect(() => {
    const fetchEventDetails = async () => {
      if (!locationId || !eventId) return;
      try {
        setLoading(true);
        const data = await apiClient.get<EventDto>(`/locations/${locationId}/events/${eventId}`);
        setEvent(data);
      } catch (err: any) {
        const message = err.response?.data || err.message || "Failed to load event details.";
        setError(message);
      } finally {
        setLoading(false);
      }
    };
    fetchEventDetails();
  }, [locationId, eventId]);

 const handleBooking = () => {
  console.log("Dugme kliknuto. Trenutni user:", user); 
  if (!token) {
    navigate('/login', { state: { from: routerLocation.pathname } });
    return;
  }
const isOrganizer = user?.roles?.includes('Organizer');
    const isAdmin = user?.roles?.includes('Administrator');

    if (isOrganizer || isAdmin) {
    Swal.fire({
      title: 'Access Denied',
      text: 'You are not allowed to purchase tickets. Please use a Customer account.',
      icon: 'warning',
      confirmButtonColor: '#000000', 
      confirmButtonText: 'Understood'
    });
    return;
  }

  navigate(`/locations/${locationId}/events/${eventId}/reservation`);
};

  if (loading) return (
    <div className="min-h-screen flex flex-col items-center justify-center bg-white">
      <div className="w-12 h-12 border-4 border-neutral-100 border-t-yellow-500 rounded-full animate-spin"></div>
      <p className="mt-4 text-neutral-400 font-bold uppercase tracking-widest text-[10px]">Loading Experience</p>
    </div>
  );

  if (error || !event) return (
    <div className="min-h-screen flex flex-col items-center justify-center text-center px-6">
      <h1 className="text-2xl font-black mb-6 uppercase">Event not found</h1>
      <button 
        onClick={() => navigate('/')} 
        className="px-8 py-3 bg-black text-white rounded-xl font-bold uppercase tracking-widest text-xs transition-transform active:scale-95"
      >
        Return Home
      </button>
    </div>
  );

  const eventDate = event.eventDate ? new Date(event.eventDate) : null;
  const dateText = eventDate && !isNaN(eventDate.getTime())
    ? eventDate.toLocaleDateString('en-US', { 
        weekday: 'long', 
        month: 'long', 
        day: 'numeric', 
        year: 'numeric',
        hour: '2-digit',
        minute: '2-digit'
      })
    : "Date To Be Announced";

  return (
    <div className="min-h-screen bg-white flex flex-col font-sans">
      <Header />
      
      <main className="container mx-auto max-w-7xl px-6 py-12 flex-grow">
        <button 
          onClick={() => navigate(-1)} 
          className="mb-10 flex items-center gap-2 text-neutral-400 hover:text-black transition-colors text-[10px] font-black uppercase tracking-[0.2em]"
        >
          <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={3} d="M10 19l-7-7m0 0l7-7m-7 7h18" />
          </svg>
          Back to Events
        </button>

        <div className="grid grid-cols-1 lg:grid-cols-2 gap-16 items-start">
          <EventHero name={event.name} />
          
          <EventInfo 
            locationName={event.locationName}
            description={event.description}
            price={event.minTicketPrice || 0}
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