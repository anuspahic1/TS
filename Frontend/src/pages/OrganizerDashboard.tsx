"use client"
import { useEffect, useState } from 'react';
import { CardContent } from '../components/ui/card';

import Footer from '../components/layout/Footer';
import { Plus } from "lucide-react"
import { EventsList } from '../components/event/EventsList';
import { useEvents } from '../hooks/useEvents';
import { EditEventDialog } from '../components/event/EditEventDialog';
import { CreateEventDialog } from '../components/event/CreateEventDialog';
import { ViewVisitorsDialog } from '../components/event/ViewVisitorsDialog';
import useLocations from '../hooks/useLocations';
import { useAuth } from '../context/AuthContext';
import type { Event as IEvent } from '../types/IEvent';

const OrganizerDashboard = () => {
  const { getUserEvents, createEvent, updateEvent, deleteEvent, getEventVisitors } = useEvents()
  const { getLocations } = useLocations();
  const [locations, setLocations] = useState<any[]>([]);
  const [events, setEvents] = useState<IEvent[]>([]);
  const [eventsRefreshKey, setEventsRefreshKey] = useState(0)

  const { user } = useAuth();
  const userId = user?.id;

  const organizerName = user?.firstName || user?.email?.split('@')[0] || 'Organizer';

  useEffect(() => {
    const fetchLocations = async () => {
      const data = await getLocations();
      setLocations(data);
    };
    fetchLocations();
  }, []);

  useEffect(() => {
    if (!userId) return;
    const fetchEvents = async () => {
      const userEventsDto = await getUserEvents(userId);
      const mappedEvents: IEvent[] = userEventsDto.map((e: any) => ({
        id: e.id,
        name: e.name,
        description: e.description ?? "",
        price: e.minTicketPrice,
        date: e.eventDate,
        eventSeatCapacity: e.capacity,
        location: e.locationName,
        locationId: e.locationId,
        creatorId: e.creatorId,
        visitors: e.visitors ?? [],
      }));
      setEvents(mappedEvents);
    };
    fetchEvents();
  }, [eventsRefreshKey, userId]);

  const [isCreateDialogOpen, setIsCreateDialogOpen] = useState(false)
  const [editingEvent, setEditingEvent] = useState<IEvent | null>(null)
  const [viewingVisitors, setViewingVisitors] = useState<IEvent | null>(null)
  const [visitors, setVisitors] = useState<any[]>([]);

  const handleViewVisitors = async (event: IEvent) => {
    if (!event) return;
    const visitorsData = await getEventVisitors(event.locationId, event.id);
    setVisitors(visitorsData);
    setViewingVisitors(event);
  }

 const handleCreateEvent = async (eventData: any) => { 
  if (!userId) return;
  
  try {
    await createEvent(userId, eventData); 
    setEventsRefreshKey(k => k + 1);
    setIsCreateDialogOpen(false);
  } catch (error) {
    console.error("Failed to create event:", error);
  }
};

const handleUpdateEvent = async (locationId: string, eventId: string, updatedEvent: IEvent) => { 
  try {
    // Now locationId is actually the locationId, and eventId is the eventId
    await updateEvent(locationId, eventId, updatedEvent);
    setEventsRefreshKey(k => k + 1);
    setEditingEvent(null);
  } catch (error) {
    console.error("Failed to update event:", error);
  }
};

  const handleDeleteEvent = async (eventId: string, locationId: string) => {
    await deleteEvent(eventId, locationId);
    setEventsRefreshKey(k => k + 1);
  };

  return (
    <div className="min-h-screen bg-neutral-50 flex flex-col font-sans">
      
      <div className="bg-neutral-900 pt-16 pb-24 px-6">
        <div className="container mx-auto max-w-7xl">
          <div className="flex flex-col md:flex-row md:items-end justify-between gap-8">
            <div>
              <span className="text-[10px] font-black uppercase tracking-[0.4em] text-yellow-500 block mb-3">
                Management Control Panel
              </span>
              <h1 className="text-4xl md:text-6xl font-black italic uppercase tracking-tighter text-white leading-none">
                {organizerName}
                <span className="text-yellow-500 not-italic font-light">'</span>
                <span className="text-yellow-500">s</span> HUB
              </h1>
              <p className="text-neutral-500 text-xs font-bold uppercase tracking-widest mt-4 flex items-center gap-2">
                <span className="w-2 h-2 bg-green-500 rounded-full animate-pulse"></span>
                Organizer Status Active
              </p>
            </div>

            <button 
              onClick={() => setIsCreateDialogOpen(true)}
              className="px-10 py-4 bg-yellow-500 text-neutral-900 rounded-full font-black uppercase italic tracking-widest text-[12px] hover:bg-white transition-all active:scale-95 flex items-center gap-2 shadow-xl shadow-yellow-500/10"
            >
              <Plus className="h-4 w-4 stroke-[4px]" />
              Create New Event
            </button>
          </div>
        </div>
      </div>

      <main className="container mx-auto max-w-7xl px-6 -mt-12 flex-grow pb-20">
        <div className="bg-white rounded-3xl shadow-xl shadow-neutral-200/50 border border-neutral-100 overflow-hidden">
          
          <div className="p-8 border-b border-neutral-50 flex flex-col md:flex-row md:items-center justify-between gap-4">
            <div>
              <h3 className="text-xl font-black italic uppercase tracking-tight text-neutral-900">
                Your Live Events
              </h3>
              <p className="text-neutral-400 text-xs font-bold uppercase tracking-wider">
                Total events managed: {events.length}
              </p>
            </div>
            
            <div className="flex gap-2">
               <div className="h-1 w-12 bg-yellow-500 rounded-full"></div>
            </div>
          </div>

          <CardContent className="p-0">
            <div className="overflow-x-auto">
              <EventsList
                events={events}
                onEdit={setEditingEvent}
                onDelete={handleDeleteEvent}
                onViewVisitors={handleViewVisitors}
              />
            </div>
          </CardContent>
        </div>
      </main>

      <CreateEventDialog
        locations={locations}
        open={isCreateDialogOpen}
        onOpenChange={setIsCreateDialogOpen}
        onCreateEvent={handleCreateEvent}
      />

      {editingEvent && (
        <EditEventDialog
          locations={locations}
          open={!!editingEvent}
          onOpenChange={(open) => !open && setEditingEvent(null)}
          event={editingEvent}
          onUpdateEvent={handleUpdateEvent}
        />
      )}

      {viewingVisitors && (
        <ViewVisitorsDialog
          open={!!viewingVisitors}
          onOpenChange={(open) => {
            if (!open) {
              setViewingVisitors(null);
              setVisitors([]);
            }
          }}
          event={{ ...viewingVisitors, visitors }}
        />
      )}
      
      <Footer />
    </div>
  );
};

export default OrganizerDashboard;