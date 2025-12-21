import React, { useState, useEffect, useCallback } from "react";
import { useNavigate } from "react-router-dom";
import type { EventDto } from "../types/IEvent";
import type { ILocation } from "../types/ILocation";
import { apiClient } from "../services/apiClient"; 

import Header from "../components/layout/Header";
import SearchBar from "../components/common/SearchBar"; 
import EventCard from "../components/common/EventCard";
import backgroundImage from "../assets/homepage.jpg";

const HomePage: React.FC = () => {
  const [locations, setLocations] = useState<ILocation[]>([]);
  const [events, setEvents] = useState<EventDto[]>([]);
  const [selectedLocationId, setSelectedLocationId] = useState<string>("");
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [stats, setStats] = useState({
    totalEvents: 0,
    uniqueCategories: 0,
    upcomingEvents: 0
  });

  const navigate = useNavigate();

  useEffect(() => {
    const fetchLocations = async () => {
      try {
        const data = await apiClient.get<ILocation[]>("/locations");
        setLocations(data);
        
        if (data.length > 0) {
          setSelectedLocationId(data[0].id);
        }
      } catch (err: any) {
        setError("Unable to load locations.");
      }
    };
    fetchLocations();
  }, []);

  const fetchEvents = useCallback(async () => {
    if (!selectedLocationId) return;

    setLoading(true);
    setError(null);
    try {
      const data = await apiClient.get<EventDto[]>(`/locations/${selectedLocationId}/events`);
      setEvents(data);
      
      // Calculate stats - Use available properties from EventDto
      const uniqueCategories = new Set(data.map(event => {
        // Use category, type, or default to 'General' based on your EventDto structure
        return (event as any).category || (event as any).type || 'General';
      })).size;
      
      // Count upcoming events - Use available date property (created, date, startDateTime, etc.)
      const upcomingEvents = data.filter(event => {
        // Try different possible date properties
        const eventDateStr = (event as any).startDateTime || 
                             (event as any).date || 
                             (event as any).startDate || 
                             event.createdAt;
        try {
          const eventDate = new Date(eventDateStr);
          return eventDate > new Date();
        } catch {
          return false; // If date parsing fails, don't count as upcoming
        }
      }).length;
      
      setStats({
        totalEvents: data.length,
        uniqueCategories,
        upcomingEvents
      });
    } catch (err: any) {
      setError(err.message || "Failed to load events.");
    } finally {
      setLoading(false);
    }
  }, [selectedLocationId]);

  useEffect(() => {
    fetchEvents();
  }, [fetchEvents]);

  const handleLocationChange = (id: string) => {
    setSelectedLocationId(id);
  };

  const handleEventClick = (eventId: string) => {
    navigate(`/locations/${selectedLocationId}/events/${eventId}`);
  };

  const selectedLocationName = locations.find(l => l.id === selectedLocationId)?.name || "...";

  return (
    <div className="min-h-screen bg-gradient-to-b from-neutral-50 via-white to-white flex flex-col font-sans overflow-hidden">
      {/* Animated Background Particles */}
      <div className="fixed inset-0 pointer-events-none">
        {[...Array(15)].map((_, i) => (
          <div
            key={i}
            className="absolute w-[1px] h-[1px] bg-gradient-to-r from-yellow-500/20 to-orange-500/20 rounded-full animate-pulse"
            style={{
              left: `${Math.random() * 100}%`,
              top: `${Math.random() * 100}%`,
              animationDelay: `${Math.random() * 3}s`,
              animationDuration: `${2 + Math.random() * 2}s`,
            }}
          />
        ))}
      </div>

      <Header />
      
      {/* Hero Section */}
      <section className="relative h-[90vh] flex items-center justify-center text-white overflow-hidden">
        {/* Background Overlays */}
        <div className="absolute inset-0 bg-gradient-to-br from-black/85 via-black/70 to-transparent z-10" />
        <div className="absolute inset-0 bg-gradient-to-t from-black/90 via-transparent to-transparent z-10" />
        <div className="absolute inset-0 bg-gradient-to-r from-black/30 via-transparent to-black/30 z-10" />
        
        {/* Animated Background Image */}
        <img 
          src={backgroundImage} 
          className="absolute inset-0 w-full h-full object-cover scale-110 animate-zoom-slow" 
          alt="Event stage" 
        />
        
        {/* Floating Elements */}
        <div className="absolute top-1/4 left-1/4 w-64 h-64 bg-gradient-to-r from-yellow-500/10 to-orange-500/10 rounded-full blur-3xl animate-pulse-slow"></div>
        <div className="absolute bottom-1/4 right-1/4 w-96 h-96 bg-gradient-to-l from-yellow-500/5 to-orange-500/5 rounded-full blur-3xl animate-pulse-slow" style={{ animationDelay: '1s' }}></div>
        
        <div className="relative z-20 text-center px-6 max-w-6xl">
          {/* Premium Badge */}
          <div className="inline-flex items-center gap-3 mb-8 px-6 py-3 bg-gradient-to-r from-yellow-500/20 to-orange-500/20 backdrop-blur-xl rounded-full border border-yellow-400/30 shadow-2xl">
            <div className="w-2 h-2 bg-gradient-to-r from-yellow-400 to-orange-400 rounded-full animate-ping"></div>
            <span className="text-yellow-300 text-sm font-bold tracking-wider uppercase">PREMIUM EXPERIENCES</span>
            <div className="w-2 h-2 bg-gradient-to-r from-yellow-400 to-orange-400 rounded-full animate-ping" style={{ animationDelay: '0.5s' }}></div>
          </div>
          
          {/* Main Title */}
          <div className="relative mb-8">
            <div className="absolute -inset-x-8 -inset-y-8 bg-gradient-to-r from-yellow-500/10 via-orange-500/10 to-yellow-500/10 rounded-full blur-3xl opacity-60"></div>
            <h1 className="relative text-6xl md:text-7xl lg:text-8xl xl:text-9xl font-black mb-4 tracking-tighter leading-[0.85]">
              <span className="bg-clip-text text-transparent bg-gradient-to-r from-yellow-300 via-yellow-400 to-orange-400 drop-shadow-2xl">
                Don't
              </span>
              <span className="block bg-clip-text text-transparent bg-gradient-to-r from-yellow-400 via-orange-400 to-red-400 mt-4 drop-shadow-2xl">
                Miss Out
              </span>
            </h1>
          </div>
          
          {/* Subtitle with Location */}
          <p className="text-xl md:text-2xl lg:text-3xl mb-12 text-neutral-100 font-light max-w-3xl mx-auto leading-relaxed">
            Discover unforgettable experiences happening in
            <span className="relative inline-block ml-3 group">
              <span className="relative z-10 font-bold text-yellow-300 group-hover:text-yellow-200 transition-colors duration-300">
                {selectedLocationName}
              </span>
              <span className="absolute bottom-0 left-0 w-full h-3 bg-gradient-to-r from-yellow-500/30 to-orange-500/30 -rotate-1 group-hover:scale-105 transition-transform duration-300"></span>
            </span>
          </p>
          
          {/* Search Bar Container */}
          <div className="relative w-full max-w-2xl mx-auto mb-16">
            <div className="absolute -inset-4 bg-gradient-to-r from-yellow-500/20 via-orange-500/10 to-yellow-500/20 rounded-full blur-xl opacity-0 group-hover:opacity-100 transition-opacity duration-700"></div>
            <div className="relative group">
              <div className="absolute inset-0 bg-gradient-to-r from-yellow-500/30 via-orange-500/20 to-yellow-500/30 rounded-2xl blur-lg opacity-0 group-hover:opacity-50 transition-opacity duration-500"></div>
              <SearchBar 
                locations={locations} 
                selectedId={selectedLocationId} 
                onChange={handleLocationChange} 
              />
            </div>
          </div>
          
          {/* Animated Scroll Indicator */}
          <div className="absolute bottom-12 left-1/2 transform -translate-x-1/2 animate-bounce-slow">
            <div className="flex flex-col items-center gap-3">
              <span className="text-neutral-300 text-sm tracking-wider uppercase font-medium">Explore Events</span>
              <div className="w-[1px] h-20 bg-gradient-to-b from-yellow-500/80 via-orange-400/40 to-transparent rounded-full"></div>
            </div>
          </div>
        </div>
      </section>

      {/* Events Section */}
      <main className="flex-grow px-6 relative z-20">
        {/* Section Background */}
        <div className="absolute top-0 left-0 right-0 h-48 bg-gradient-to-b from-transparent via-white/90 to-white -z-10"></div>
        
        <div className="container mx-auto max-w-7xl relative">
          <div className="py-20 md:py-28">
            {/* Section Header */}
            <div className="relative mb-16">
              <div className="absolute top-1/2 left-1/2 transform -translate-x-1/2 -translate-y-1/2 w-96 h-96 bg-gradient-to-r from-yellow-500/5 to-orange-500/5 rounded-full blur-3xl"></div>
              
              <div className="relative z-10">
                <div className="flex flex-col lg:flex-row lg:items-end justify-between mb-14 gap-8">
                  <div className="max-w-3xl">
                    <div className="inline-flex items-center gap-3 px-5 py-2.5 bg-gradient-to-r from-yellow-500/10 to-orange-500/10 text-yellow-700 rounded-full border border-yellow-500/20 shadow-sm mb-6">
                      <div className="w-2 h-2 bg-gradient-to-r from-yellow-500 to-orange-500 rounded-full animate-pulse"></div>
                      <span className="text-sm font-bold tracking-wider uppercase">Featured Events</span>
                    </div>
                    <h2 className="text-5xl md:text-6xl lg:text-7xl font-black text-neutral-900 mb-5 leading-tight">
                      What's happening in{" "}
                      <span className="text-transparent bg-clip-text bg-gradient-to-r from-yellow-500 via-orange-500 to-red-500">
                        {selectedLocationName}
                      </span>
                    </h2>
                    <p className="text-neutral-600 text-xl font-light max-w-2xl leading-relaxed">
                      Explore the best concerts, festivals, and gatherings happening near you. From intimate shows to massive festivals.
                    </p>
                  </div>
                  
                  {events.length > 0 && !loading && (
                    <div className="px-8 py-4 bg-gradient-to-r from-yellow-50 via-orange-50 to-yellow-50 rounded-2xl border border-yellow-100 shadow-lg">
                      <div className="text-center">
                        <div className="text-5xl font-black bg-gradient-to-r from-yellow-600 to-orange-600 bg-clip-text text-transparent">
                          {events.length}
                        </div>
                        <div className="text-sm font-bold text-yellow-700 uppercase tracking-wider mt-2">
                          {events.length === 1 ? 'Premium Event' : 'Premium Events'} Available
                        </div>
                      </div>
                    </div>
                  )}
                </div>

                {/* Live Stats */}
                {events.length > 0 && !loading && (
                  <div className="grid grid-cols-1 md:grid-cols-3 gap-6 mb-16">
                    {[
                      { label: 'Total Events', value: stats.totalEvents, color: 'from-yellow-500 to-yellow-600' },
                      { label: 'Categories', value: stats.uniqueCategories, color: 'from-orange-500 to-orange-600' },
                      { label: 'Upcoming', value: stats.upcomingEvents, color: 'from-red-500 to-red-600' },
                    ].map((stat, index) => (
                      <div 
                        key={stat.label} 
                        className="relative overflow-hidden rounded-2xl p-6 bg-gradient-to-br from-white to-neutral-50 border border-neutral-200/50 shadow-lg"
                        style={{ animationDelay: `${index * 100}ms` }}
                      >
                        <div className="absolute inset-0 bg-gradient-to-r opacity-5 via-transparent to-opacity-5 rounded-2xl blur-xl"></div>
                        <div className="relative z-10">
                          <div className="flex items-center justify-between mb-4">
                            <span className="text-sm font-semibold text-neutral-500 uppercase tracking-wide">{stat.label}</span>
                            <div className={`w-10 h-10 rounded-full bg-gradient-to-br ${stat.color} flex items-center justify-center`}>
                              <span className="text-white font-bold">{stat.value}</span>
                            </div>
                          </div>
                          <div className="text-3xl font-black text-neutral-900">{stat.value}</div>
                          <div className="h-2 bg-gradient-to-r from-neutral-200 to-neutral-100 rounded-full mt-4 overflow-hidden">
                            <div 
                              className={`h-full bg-gradient-to-r ${stat.color} rounded-full transition-all duration-1000 ease-out`}
                              style={{ width: `${(stat.value / Math.max(...[stats.totalEvents, stats.uniqueCategories, stats.upcomingEvents])) * 100}%` }}
                            ></div>
                          </div>
                        </div>
                      </div>
                    ))}
                  </div>
                )}
              </div>
            </div>

            {/* Content States */}
            {loading ? (
              <div className="flex flex-col items-center justify-center py-40">
                <div className="relative mb-10">
                  <div className="absolute inset-0 bg-gradient-to-r from-yellow-500/10 to-orange-500/10 blur-xl animate-pulse"></div>
                  <div className="relative animate-spin rounded-full h-24 w-24 border-[6px] border-yellow-100 border-t-yellow-500 border-r-orange-500"></div>
                </div>
                <p className="text-2xl font-light text-neutral-600 mb-3 animate-pulse">
                  Discovering amazing events...
                </p>
                <p className="text-neutral-400 text-lg">Fetching the best experiences in {selectedLocationName}</p>
              </div>
            ) : error ? (
              <div className="text-center py-40 relative overflow-hidden rounded-3xl">
                <div className="absolute inset-0 bg-gradient-to-br from-red-50/80 via-white to-red-50/80 border-2 border-red-200/30"></div>
                <div className="absolute inset-0 bg-[radial-gradient(circle_at_30%_20%,rgba(239,68,68,0.1),transparent_50%)]"></div>
                
                <div className="relative px-8">
                  <div className="w-24 h-24 mx-auto mb-8 bg-gradient-to-br from-red-100 to-red-50 rounded-2xl flex items-center justify-center shadow-xl">
                    <div className="relative">
                      <div className="absolute inset-0 bg-red-500/20 blur-md rounded-full"></div>
                      <svg className="relative w-12 h-12 text-red-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-3L13.732 4c-.77-1.333-2.694-1.333-3.464 0L3.34 16c-.77 1.333.192 3 1.732 3z" />
                      </svg>
                    </div>
                  </div>
                  <h3 className="text-3xl font-bold text-neutral-900 mb-6">Unable to Load Events</h3>
                  <p className="text-neutral-700 leading-relaxed mb-8 px-4 text-lg max-w-2xl mx-auto">{error}</p>
                  <div className="flex flex-col sm:flex-row gap-4 justify-center">
                    <button 
                      onClick={fetchEvents} 
                      className="px-8 py-4 bg-gradient-to-r from-red-500 to-red-600 text-white font-bold rounded-xl shadow-lg hover:shadow-xl transform hover:-translate-y-1 transition-all duration-300"
                    >
                      <div className="flex items-center gap-3">
                        <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M4 4v5h.582m15.356 2A8.001 8.001 0 004.582 9m0 0H9m11 11v-5h-.581m0 0a8.003 8.003 0 01-15.357-2m15.357 2H15" />
                        </svg>
                        Try Again
                      </div>
                    </button>
                    <button 
                      onClick={() => setSelectedLocationId(locations[0]?.id || '')}
                      className="px-8 py-4 bg-gradient-to-r from-neutral-900 to-neutral-800 text-white font-bold rounded-xl shadow-lg hover:shadow-xl transform hover:-translate-y-1 transition-all duration-300"
                    >
                      Change Location
                    </button>
                  </div>
                </div>
              </div>
            ) : events.length === 0 ? (
              <div className="text-center py-40 relative overflow-hidden rounded-3xl">
                <div className="absolute inset-0 bg-gradient-to-br from-neutral-50/80 via-white to-neutral-50/80 border-2 border-neutral-200/30"></div>
                <div className="absolute inset-0 bg-[radial-gradient(circle_at_50%_30%,rgba(234,179,8,0.1),transparent_60%)]"></div>
                
                <div className="relative px-8">
                  <div className="w-28 h-28 mx-auto mb-10 bg-gradient-to-br from-yellow-50 to-orange-50 rounded-2xl flex items-center justify-center shadow-xl">
                    <div className="relative">
                      <div className="absolute inset-0 bg-gradient-to-r from-yellow-500/10 to-orange-500/10 blur-md rounded-full"></div>
                      <svg className="relative w-14 h-14 text-yellow-500" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={1.5} d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z" />
                      </svg>
                    </div>
                  </div>
                  <h3 className="text-3xl font-bold text-neutral-900 mb-6">
                    No events scheduled in {selectedLocationName}
                  </h3>
                  <p className="text-neutral-600 text-lg font-light max-w-md mx-auto mb-10 leading-relaxed">
                    Check back soon for upcoming events or explore other amazing locations nearby.
                  </p>
                  {locations.length > 1 && (
                    <button 
                      onClick={() => setSelectedLocationId(locations.find(l => l.id !== selectedLocationId)?.id || locations[0].id)}
                      className="inline-flex items-center gap-3 px-8 py-4 bg-gradient-to-r from-yellow-500 to-orange-500 text-white font-bold rounded-xl shadow-lg hover:shadow-xl transform hover:-translate-y-1 transition-all duration-300"
                    >
                      <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M17.657 16.657L13.414 20.9a1.998 1.998 0 01-2.827 0l-4.244-4.243a8 8 0 1111.314 0z" />
                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M15 11a3 3 0 11-6 0 3 3 0 016 0z" />
                      </svg>
                      Explore Other Cities
                    </button>
                  )}
                </div>
              </div>
            ) : (
              <>
                {/* Events Grid */}
                <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8 lg:gap-10">
                  {events.map((event, index) => (
                    <div 
                      key={event.id} 
                      className="group transform transition-all duration-700 hover:-translate-y-4 animate-fade-in-up"
                      style={{
                        animationDelay: `${index * 100}ms`,
                        animationFillMode: 'both',
                      }}
                    >
                      <div className="relative">
                        {/* Hover Glow Effect */}
                        <div className="absolute -inset-4 bg-gradient-to-r from-yellow-500/10 via-orange-500/5 to-yellow-500/10 rounded-3xl blur-xl opacity-0 group-hover:opacity-100 transition-opacity duration-500 -z-10"></div>
                        <EventCard 
                          event={event} 
                          onDetailClick={() => handleEventClick(event.id)} 
                        />
                      </div>
                    </div>
                  ))}
                </div>
              </>
            )}
          </div>
        </div>
      </main>

      {/* Footer */}
      <footer className="bg-gradient-to-b from-white via-white to-neutral-50 border-t border-neutral-200/50">
        <div className="container mx-auto px-6 py-14">
          <div className="flex flex-col lg:flex-row justify-between items-center gap-8">
            {/* Brand */}
            <div className="flex items-center gap-4">
              <div className="relative">
                <div className="absolute inset-0 bg-gradient-to-r from-yellow-500 to-orange-500 rounded-xl blur-lg opacity-50"></div>
                <div className="relative w-12 h-12 bg-gradient-to-br from-yellow-500 to-orange-500 rounded-xl flex items-center justify-center shadow-lg">
                  <span className="text-white font-black text-2xl">E</span>
                </div>
              </div>
              <div>
                <p className="font-bold text-2xl text-neutral-900">EntrioX Events</p>
                <p className="text-neutral-500 text-sm font-light">Where unforgettable experiences begin</p>
              </div>
            </div>
            
            {/* Social Links */}
            <div className="flex items-center gap-8">
              {['Twitter', 'Instagram', 'Facebook', 'LinkedIn'].map((social) => (
                <a
                  key={social}
                  href="#"
                  className="text-neutral-500 hover:text-yellow-600 transition-colors duration-300 font-medium text-sm uppercase tracking-wider"
                >
                  {social}
                </a>
              ))}
            </div>
            
            {/* Copyright */}
            <div className="text-center lg:text-right">
              <p className="text-neutral-400 font-light">
                © {new Date().getFullYear()} EntrioX Events. All rights reserved.
              </p>
              <p className="text-neutral-400 text-sm font-light mt-1">
                Crafted with passion for amazing experiences
              </p>
            </div>
          </div>
        </div>
      </footer>

      {/* Custom Animations */}
      <style>{`
        @keyframes zoom-slow {
          0%, 100% { transform: scale(1.05) rotate(0.5deg); }
          50% { transform: scale(1.1) rotate(-0.5deg); }
        }
        @keyframes pulse-slow {
          0%, 100% { opacity: 0.5; }
          50% { opacity: 0.8; }
        }
        @keyframes fade-in-up {
          from {
            opacity: 0;
            transform: translateY(20px);
          }
          to {
            opacity: 1;
            transform: translateY(0);
          }
        }
        .animate-zoom-slow {
          animation: zoom-slow 20s ease-in-out infinite;
        }
        .animate-pulse-slow {
          animation: pulse-slow 3s ease-in-out infinite;
        }
        .animate-fade-in-up {
          animation: fade-in-up 0.6s ease-out forwards;
          opacity: 0;
        }
        .animate-bounce-slow {
          animation: bounce 2.5s ease-in-out infinite;
        }
      `}</style>
    </div>
  );
};

export default HomePage;