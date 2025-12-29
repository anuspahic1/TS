"use client" // zasto

import { useEffect, useState } from 'react';
import { Trash2, Search, UserCheck, Calendar, Ticket, Mail, Loader2, Globe } from 'lucide-react';
import { apiClient } from '../../services/apiClient';
import { Input } from "../ui/input";
import { Card, CardContent } from '../ui/card';
import Swal from 'sweetalert2';

interface Visitor {
  reservationId: string;
  userId: string;
  fullName: string;
  email: string;
  ticketsCount: number;
}

interface EventItem {
  id: string;
  locationId: string;
  name: string;
  eventDate: string;
}

const ManageReservations = () => {
  const [events, setEvents] = useState<EventItem[]>([]);
  const [selectedEvent, setSelectedEvent] = useState<{locationId: string, eventId: string} | null>(null);
  const [visitors, setVisitors] = useState<Visitor[]>([]);
  const [searchTerm, setSearchTerm] = useState("");
  const [loading, setLoading] = useState(false);
  const [eventsLoading, setEventsLoading] = useState(true);

  useEffect(() => {
    const fetchEvents = async () => {
      setEventsLoading(true);
      try {
        const data = await apiClient.get<EventItem[]>('/admin/events');
        setEvents(data);
      } catch (err) {
        console.error("Failed to load events list.");
      } finally {
        setEventsLoading(false);
      }
    };
    fetchEvents();
  }, []);

  const loadEventDetails = async (locationId: string, eventId: string) => {
    setLoading(true);
    setSearchTerm("");
    try {
      const visitorData = await apiClient.get<Visitor[]>(`/locations/${locationId}/events/${eventId}/reservations/visitors`);
      setVisitors(visitorData);
      setSelectedEvent({ locationId, eventId });
    } catch (err) {
      console.error("Could not load attendees.");
    } finally {
      setLoading(false);
    }
  };

  const handleCancelReservation = async (reservationId: string) => {
    if (!selectedEvent) return;
    
    Swal.fire({
      title: 'Cancel Reservation?',
      text: "This will deduct loyalty points and release tickets immediately!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#000000',
      cancelButtonColor: '#ef4444',
      confirmButtonText: 'Yes, cancel it!',
      target: 'body'
    }).then(async (result) => {
      if (result.isConfirmed) {
        try {
          await apiClient.delete(`/locations/${selectedEvent.locationId}/events/${selectedEvent.eventId}/reservations/${reservationId}`);
          await loadEventDetails(selectedEvent.locationId, selectedEvent.eventId);
          Swal.fire({
            title: 'Cancelled!',
            text: 'Reservation has been successfully removed.',
            icon: 'success',
            confirmButtonColor: '#EAB308'
          });
        } catch (err) {
          Swal.fire('Error!', 'Failed to cancel reservation.', 'error');
        }
      }
    });
  };

  const filteredVisitors = visitors.filter(v => 
    v.fullName.toLowerCase().includes(searchTerm.toLowerCase()) ||
    v.email.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <div className="p-6 space-y-8 bg-gray-50/50 min-h-screen font-sans">
      
      {/* HEADER - Usklađen sa tvojim AdminEventsPage */}
      <div className="flex flex-col md:flex-row justify-between items-start md:items-center gap-4 bg-white p-6 rounded-2xl shadow-sm border border-gray-100">
        <div>
          <h1 className="text-4xl font-black uppercase italic tracking-tighter">
            Reservation <span className="text-yellow-500 underline decoration-black/10">Control</span>
          </h1>
          <p className="text-gray-500 font-medium mt-1 flex items-center">
            <UserCheck className="h-4 w-4 mr-2 text-gray-400" />
            Manage attendees and real-time seat availability across all events.
          </p>
        </div>
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-3 gap-10">
        
        {/* LIJEVA STRANA: LISTA EVENATA */}
        <div className="space-y-4">
          <div className="flex items-center justify-between px-2">
            <h2 className="text-xs font-black text-gray-400 uppercase tracking-[0.2em]">Select Event</h2>
            <span className="px-2 py-1 bg-gray-200 rounded text-[10px] font-bold">{events.length} Total</span>
          </div>
          
          <div className="max-h-[70vh] overflow-y-auto pr-2 space-y-3 custom-scrollbar">
            {eventsLoading ? (
              <div className="py-10 text-center"><Loader2 className="animate-spin mx-auto text-yellow-500" /></div>
            ) : (
              events.map(ev => (
                <button 
                  key={ev.id} 
                  onClick={() => loadEventDetails(ev.locationId, ev.id)}
                  className={`w-full p-5 rounded-2xl border text-left transition-all duration-300 ${
                    selectedEvent?.eventId === ev.id 
                    ? 'bg-black text-white border-black shadow-xl scale-[1.02]' 
                    : 'bg-white border-gray-100 shadow-sm hover:border-yellow-400 hover:shadow-md'
                  }`}
                >
                  <p className="font-black text-md tracking-tight leading-tight">{ev.name}</p>
                  <div className={`mt-2 flex items-center gap-2 text-[10px] font-bold ${selectedEvent?.eventId === ev.id ? 'text-yellow-500' : 'text-gray-400'}`}>
                    <Calendar size={12} />
                    {new Date(ev.eventDate).toLocaleDateString('de-DE')}
                  </div>
                </button>
              ))
            )}
          </div>
        </div>

        {/* DESNA STRANA: POSJETITELJI */}
        <div className="lg:col-span-2 space-y-6">
          {selectedEvent ? (
            <>
              <div className="relative group max-w-full">
                <div className="absolute inset-y-0 left-0 pl-4 flex items-center pointer-events-none transition-colors group-focus-within:text-yellow-500">
                  <Search className="h-5 w-5 text-gray-400 group-focus-within:text-yellow-500" />
                </div>
                <Input 
                  placeholder="Filter attendees by name or email hub..." 
                  className="pl-11 pr-4 py-6 bg-white border-none rounded-2xl shadow-sm focus-visible:ring-2 focus-visible:ring-yellow-500 font-medium transition-all" 
                  value={searchTerm}
                  onChange={(e) => setSearchTerm(e.target.value)}
                />
              </div>

              <Card className="border-none shadow-xl rounded-3xl overflow-hidden bg-white">
                <div className="h-1.5 w-full bg-gradient-to-r from-yellow-500 via-black to-yellow-500" />
                <CardContent className="p-0">
                  {loading ? (
                    <div className="p-20 flex flex-col items-center justify-center space-y-4">
                      <Loader2 className="animate-spin h-10 w-10 text-yellow-500" />
                      <p className="text-gray-400 font-black uppercase text-[10px] tracking-widest font-mono">Syncing Stream...</p>
                    </div>
                  ) : (
                    <div className="overflow-x-auto">
                      <table className="w-full text-left border-collapse">
                        <thead>
                          <tr className="border-b border-gray-50">
                            <th className="p-6 text-[10px] font-black text-gray-400 uppercase tracking-widest">Visitor Info</th>
                            <th className="p-6 text-[10px] font-black text-gray-400 uppercase tracking-widest text-center">Tickets</th>
                            <th className="p-6 text-[10px] font-black text-gray-400 uppercase tracking-widest text-right">Actions</th>
                          </tr>
                        </thead>
                        <tbody className="divide-y divide-gray-50">
                          {filteredVisitors.map((v) => (
                            <tr key={v.reservationId} className="group hover:bg-yellow-50/30 transition-colors">
                              <td className="p-6">
                                <p className="font-black text-gray-900">{v.fullName}</p>
                                <div className="flex items-center gap-1 text-[10px] text-gray-400 font-bold mt-1 uppercase">
                                  <Mail size={10} /> {v.email}
                                </div>
                              </td>
                              <td className="p-6 text-center">
                                <span className="inline-flex items-center gap-1.5 px-4 py-1.5 bg-gray-100 rounded-full text-[10px] font-black uppercase">
                                  <Ticket size={12} className="text-yellow-600" /> {v.ticketsCount}
                                </span>
                              </td>
                              <td className="p-6 text-right">
                                <button 
                                  onClick={() => handleCancelReservation(v.reservationId)}
                                  className="inline-flex items-center justify-center w-10 h-10 bg-red-50 text-red-500 rounded-xl hover:bg-red-500 hover:text-white transition-all duration-300"
                                >
                                  <Trash2 size={18} />
                                </button>
                              </td>
                            </tr>
                          ))}
                        </tbody>
                      </table>
                    </div>
                  )}
                  {filteredVisitors.length === 0 && !loading && (
                    <div className="py-20 text-center">
                      <Globe className="h-10 w-10 text-gray-200 mx-auto mb-4" />
                      <p className="text-gray-400 font-bold uppercase tracking-widest text-[10px] font-mono">No matching records found.</p>
                    </div>
                  )}
                </CardContent>
              </Card>
            </>
          ) : (
            <div className="h-[450px] flex flex-col items-center justify-center border-4 border-dashed border-gray-200 rounded-[3rem] text-gray-300 bg-white/50">
              <Search size={60} className="mb-4 opacity-10" />
              <p className="font-black uppercase tracking-[0.3em] text-xs font-mono">Select event to view stream</p>
            </div>
          )}
        </div>
      </div>
    </div>
  );
};

export default ManageReservations;