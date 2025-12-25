"use client"
import React, { useEffect, useState } from 'react';
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '../components/ui/card';


import Header from '../components/layout/Header';
import Footer from '../components/layout/Footer';
import { Button } from '../components/ui/button';
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

  const { getUserEvents, createEvent, updateEvent, deleteEvent } = useEvents()
  const { getLocations } = useLocations();
  const [locations, setLocations] = useState<Location[]>([]);
  const [loadingLocations, setLoadingLocations] = useState(true);
  const [events, setEvents] = useState<IEvent[]>([]);
  const [eventsRefreshKey, setEventsRefreshKey] = useState(0)

  useEffect(() => {
    const fetchLocations = async () => {
      const data = await getLocations();
      setLocations(data);
      setLoadingLocations(false);
    };

    fetchLocations();
  }, []);



  //get user id from auth context
  const { user } = useAuth();
  const userId = user?.id;

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


  const handleCreateEvent = (eventData: any) => {
    if (!userId) {
      return;
    }
    console.log("Creating event with data:HALOBUDALO", eventData);
    createEvent(userId, eventData)
    setEventsRefreshKey(k => k + 1);
    setIsCreateDialogOpen(false)
  }

  const handleUpdateEvent = (eventId: string, locationId: string, updatedEvent: IEvent) => {
    console.log("Updating event with data:", updatedEvent.locationId);

    setEvents((prev) =>
      prev.map((e) => (e.id === eventId ? { ...e, ...updatedEvent } : e))
    );
    updateEvent(locationId, eventId, updatedEvent)
    setEventsRefreshKey(k => k + 1);
    setEditingEvent(null)
  }
  const handleDeleteEvent = async (eventId: string, locationId: string) => {


    await deleteEvent(eventId, locationId);
    setEventsRefreshKey(k => k + 1);
  };


  return (
    <div className="min-h-screen bg-white flex flex-col font-sans">


      <main className="container mx-auto max-w-7xl px-6 py-12 flex-grow">
        <div className="mb-8 flex items-center justify-between">
          <div>
            <h1 className="text-3xl font-black">Organizer Dashboard</h1>
            <p className="text-gray-600 mt-1">Welcome, Organizer!</p>
          </div>
        </div>

        <Card className="border-gray-200">
          <CardHeader>
            <div className="flex items-center justify-between">
              <div>
                <CardTitle className="text-black">Your Events</CardTitle>
                <CardDescription>Manage all your created events</CardDescription>
              </div>
              <Button onClick={() => setIsCreateDialogOpen(true)} className="bg-black text-white hover:bg-black/90">
                <Plus className="mr-2 h-4 w-4" />
                Create Event
              </Button>
            </div>
          </CardHeader>
          <CardContent>

            <EventsList
              events={events}
              onEdit={setEditingEvent}
              onDelete={handleDeleteEvent}
              onViewVisitors={setViewingVisitors}
            />
          </CardContent>
        </Card>


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

      {/* {viewingVisitors && (
        <ViewVisitorsDialog
          open={!!viewingVisitors}
          onOpenChange={(open) => !open && setViewingVisitors(null)}
          event={viewingVisitors}
        />
      )} */}
      <Footer />
    </div>




  );
};

export default OrganizerDashboard;