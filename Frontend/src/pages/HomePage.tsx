import React, { useState, useEffect, useCallback } from "react";
import { useNavigate } from "react-router-dom";
import { apiClient } from "../services/apiClient";
import type { EventDto } from "../types/IEvent";
import type { ILocation } from "../types/ILocation";
import Header from "../components/layout/Header";
import Footer from "../components/layout/Footer";
import HeroSection from "../components/home/Hero";
import EventCard from "../components/common/EventCard";

const HomePage: React.FC = () => {
  const [locations, setLocations] = useState<ILocation[]>([]);
  const [events, setEvents] = useState<EventDto[]>([]);
  const [selectedLocationId, setSelectedLocationId] = useState<string>("");
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

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
        setError("Unable to load locations. Please check your connection.");
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
    <div className="min-h-screen bg-white flex flex-col font-sans">
      <Header />

      <HeroSection
        locations={locations}
        selectedLocationId={selectedLocationId}
        selectedLocationName={selectedLocationName}
        onLocationChange={handleLocationChange}
      />

      <main className="container mx-auto max-w-7xl px-6 py-24">
        <div className="flex flex-col md:flex-row md:items-end justify-between mb-16 gap-6">
          <div>
            <h2 className="text-4xl md:text-5xl font-black text-neutral-900 mb-4 tracking-tight">
              Events in {selectedLocationName}
            </h2>
            <div className="w-20 h-1.5 bg-yellow-500 rounded-full"></div>
          </div>
          <p className="text-neutral-500 font-medium">
            Showing <span className="text-black font-bold">{events.length}</span> upcoming events
          </p>
        </div>

        {loading ? (
          <div className="flex flex-col items-center justify-center py-32">
            <div className="w-16 h-16 border-4 border-yellow-100 border-t-yellow-500 rounded-full animate-spin mb-6"></div>
            <p className="text-neutral-500 font-bold uppercase tracking-widest text-sm">Searching for events...</p>
          </div>
        ) : error ? (
          <div className="text-center py-20 bg-red-50 rounded-3xl border border-red-100">
            <p className="text-red-500 font-bold mb-4">{error}</p>
            <button
              onClick={fetchEvents}
              className="px-8 py-3 bg-red-600 text-white rounded-xl font-bold hover:bg-red-700 transition-colors"
            >
              Try Again
            </button>
          </div>
        ) : events.length === 0 ? (
          <div className="text-center py-32 bg-neutral-50 rounded-3xl border border-dashed border-neutral-300">
            <h3 className="text-2xl font-bold text-neutral-800 mb-2">No events found</h3>
            <p className="text-neutral-500">We couldn't find any events in this location at the moment.</p>
          </div>
        ) : (
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-10">
            {events.map((event) => (
              <div key={event.id} className="hover:scale-[1.02] transition-transform duration-300">
                <EventCard
                  event={event}
                  onDetailClick={() => handleEventClick(event.id)}
                />
              </div>
            ))}
          </div>
        )}
      </main>
      <Footer />
    </div>
  );
};

export default HomePage;