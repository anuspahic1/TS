"use client"

import { useEffect, useState } from 'react';
import { Card, CardContent } from '../ui/card';
import { Button } from '../ui/button';
import { Plus, Search, Calendar, Globe, Loader2 } from "lucide-react";
import { Input } from "../ui/input";
import { EventsList } from '../event/EventListAdmin';
import { useEvents } from '../../hooks/useEvents';
import { EditEventDialog } from '../event/EditEventDialogAdmin';
import { CreateEventDialog } from '../event/CreateEventDialogAdmin';
import { ViewVisitorsDialog } from '../event/ViewVisitorsDialog';
import useLocations from '../../hooks/useLocations';
import { useAuth } from '../../context/AuthContext';
import type { Event as IEvent } from '../../types/IEvent';
import Swal from 'sweetalert2';

const AdminEventsPage = () => {
  const { user } = useAuth();
  // Dodano getEventVisitors iz hook-a
  const { getAllEvents, createEvent, updateEvent, deleteEvent, getEventVisitors } = useEvents(); 
  const { getLocations } = useLocations();
  
  const [locations, setLocations] = useState<any[]>([]);
  const [events, setEvents] = useState<IEvent[]>([]);
  const [filteredEvents, setFilteredEvents] = useState<IEvent[]>([]);
  const [searchTerm, setSearchTerm] = useState("");
  const [eventsRefreshKey, setEventsRefreshKey] = useState(0);
  const [loading, setLoading] = useState(true);

  // State za dijaloge i posjetitelje
  const [isCreateDialogOpen, setIsCreateDialogOpen] = useState(false);
  const [editingEvent, setEditingEvent] = useState<IEvent | null>(null);
  const [viewingVisitors, setViewingVisitors] = useState<IEvent | null>(null);
  const [visitors, setVisitors] = useState<any[]>([]);

  // 1. Učitavanje lokacija
  useEffect(() => {
    getLocations().then(setLocations);
  }, []);

  // 2. Učitavanje svih evenata
  useEffect(() => {
    const fetchAll = async () => {
      setLoading(true);
      try {
        const data = await getAllEvents(); 
        const mappedEvents: IEvent[] = data.map((e: any) => ({
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
        setFilteredEvents(mappedEvents);
      } catch (err) {
        console.error("Error fetching events", err);
      } finally {
        setLoading(false);
      }
    };
    fetchAll();
  }, [eventsRefreshKey]);

  // 3. Pretraga (Filter)
  useEffect(() => {
    const filtered = events.filter(e => 
      e.name.toLowerCase().includes(searchTerm.toLowerCase()) || 
      e.location.toLowerCase().includes(searchTerm.toLowerCase())
    );
    setFilteredEvents(filtered);
  }, [searchTerm, events]);

  // 4. Funkcija za dohvaćanje posjetitelja
  const handleViewVisitors = async (event: IEvent) => {
    if (!event) return;
    try {
      // Pozivamo API preko hook-a
      const visitorsData = await getEventVisitors(event.locationId, event.id);
      setVisitors(visitorsData);
      setViewingVisitors(event);
    } catch (error) {
      console.error("Failed to fetch visitors:", error);
      Swal.fire({
        title: 'Error!',
        text: 'Could not load visitors for this event.',
        icon: 'error',
        confirmButtonColor: '#000000'
      });
    }
  };

  return (
    <div className="p-6 space-y-8 bg-gray-50/50 min-h-screen">
      
      {/* Header Sekcija */}
      <div className="flex flex-col md:flex-row justify-between items-start md:items-center gap-4 bg-white p-6 rounded-2xl shadow-sm border border-gray-100">
        <div>
          <h1 className="text-4xl font-black uppercase italic tracking-tighter">
            Events <span className="text-yellow-500 underline decoration-black/10">Control</span>
          </h1>
          <p className="text-gray-500 font-medium mt-1 flex items-center">
            <Calendar className="h-4 w-4 mr-2 text-gray-400" />
            Monitor and manage all system-wide global events.
          </p>
        </div>
        <Button 
          onClick={() => setIsCreateDialogOpen(true)} 
          className="bg-black text-white hover:bg-black/90 px-8 py-6 rounded-xl font-bold transition-all hover:scale-105 active:scale-95 shadow-lg shadow-black/10"
        >
          <Plus className="mr-2 h-5 w-5" /> Create Global Event
        </Button>
      </div>

      {/* Search Bar */}
      <div className="relative group max-w-2xl">
        <div className="absolute inset-y-0 left-0 pl-4 flex items-center pointer-events-none transition-colors group-focus-within:text-yellow-500">
          <Search className="h-5 w-5 text-gray-400 group-focus-within:text-yellow-500" />
        </div>
        <Input 
          placeholder="Search events by name or location hub..." 
          className="pl-11 pr-4 py-6 bg-white border-none rounded-2xl shadow-sm focus-visible:ring-2 focus-visible:ring-yellow-500 font-medium transition-all" 
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
      </div>

      {loading ? (
        <div className="flex flex-col items-center justify-center py-32 space-y-4">
            <Loader2 className="animate-spin h-12 w-12 text-yellow-500" />
            <p className="text-gray-400 font-black uppercase tracking-widest text-xs font-mono">Loading Event Stream...</p>
        </div>
      ) : (
        <Card className="border-none shadow-xl rounded-3xl overflow-hidden bg-white">
          <div className="h-1.5 w-full bg-gradient-to-r from-yellow-500 via-black to-yellow-500" />
          <CardContent className="p-0">
            <div className="overflow-x-auto">
              <EventsList
                events={filteredEvents}
                onEdit={setEditingEvent}
                onViewVisitors={handleViewVisitors} // Ovdje koristimo novu funkciju
                onDelete={async (id: string, locId: string) => {
                  Swal.fire({
                    title: 'Are you sure?',
                    text: "This will permanently delete the event and all associated tickets!",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#000000', 
                    cancelButtonColor: '#ef4444',  
                    confirmButtonText: 'Yes, delete it!',
                    cancelButtonText: 'No, keep it',
                  }).then(async (result) => {
                    if (result.isConfirmed) {
                      try {
                        await deleteEvent(id, locId);
                        setEventsRefreshKey(k => k + 1);
                        Swal.fire({
                          title: 'Deleted!',
                          text: 'Event successfully removed.',
                          icon: 'success',
                          confirmButtonColor: '#EAB308' 
                        });
                      } catch (error) {
                        Swal.fire({ title: 'Error!', text: 'Critical error during deletion.', icon: 'error' });
                      }
                    }
                  });
                }}
              />
            </div>
            {filteredEvents.length === 0 && (
              <div className="py-20 text-center">
                <Globe className="h-12 w-12 text-gray-200 mx-auto mb-4" />
                <p className="text-gray-400 font-bold uppercase tracking-widest text-xs font-mono">No matching events found.</p>
              </div>
            )}
          </CardContent>
        </Card>
      )}

      {/* Dialog: Create Event */}
      <CreateEventDialog
        locations={locations}
        open={isCreateDialogOpen}
        onOpenChange={setIsCreateDialogOpen}
        onCreateEvent={async (data: any) => {
          if (user?.id) {
            try {
              await createEvent(user.id, data);
              setEventsRefreshKey((k: number) => k + 1);
              setIsCreateDialogOpen(false);
              Swal.fire({ title: 'Created!', text: 'Event broadcasted successfully.', icon: 'success', confirmButtonColor: '#EAB308' });
            } catch (error) {
              Swal.fire({ title: 'Error!', text: 'Failed to create event.', icon: 'error' });
            }
          }
        }}
      />

      {/* Dialog: Edit Event */}
      {editingEvent && (
        <EditEventDialog
          locations={locations}
          open={!!editingEvent}
          onOpenChange={(open) => !open && setEditingEvent(null)}
          event={editingEvent}
          onUpdateEvent={async (locationId: string, eventId: string, updated: any) => {
            try {
              await updateEvent(locationId, eventId, updated);
              setEventsRefreshKey(k => k + 1);
              setEditingEvent(null);
              Swal.fire({ title: 'Updated!', text: 'Event metrics refreshed.', icon: 'success', confirmButtonColor: '#EAB308' });
            } catch (error) {
              Swal.fire({ title: 'Failed!', text: 'Update failed. Check date constraints.', icon: 'error' });
            }
          }}
        />
      )}

      {/* Dialog: View Visitors (Sada s učitanim podacima) */}
      {viewingVisitors && (
        <ViewVisitorsDialog
          open={!!viewingVisitors}
          onOpenChange={(open) => {
            if (!open) {
              setViewingVisitors(null);
              setVisitors([]); // Čistimo state pri zatvaranju
            }
          }}
          // Ovdje spajamo podatke o eventu sa listom posjetitelja koju smo dohvatili
          event={{ ...viewingVisitors, visitors }}
        />
      )}
    </div>
  );
};

export default AdminEventsPage;