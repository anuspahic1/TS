import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { apiClient } from "../services/apiClient";
import type { EventDto } from "../types/IEvent";

interface ITicket {
  id: string; 
  seatNumber: string;
  price: number;
  isReserved: boolean;
  eventId: string;
}

const ReservationPage: React.FC = () => {
  const { locationId, eventId } = useParams<{ locationId: string; eventId: string }>();
  const navigate = useNavigate();
  
  const [event, setEvent] = useState<EventDto | null>(null);
  const [tickets, setTickets] = useState<ITicket[]>([]);
  const [selectedTickets, setSelectedTickets] = useState<ITicket[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchData = async () => {
      if (!locationId || !eventId) return;
      try {
        setLoading(true);
        const [eventData, ticketsData] = await Promise.all([
          apiClient.get<EventDto>(`/locations/${locationId}/events/${eventId}`),
          apiClient.get<any[]>(`/locations/${locationId}/events/${eventId}/tickets`)
        ]);

        setEvent(eventData);
        setTickets(ticketsData.map(t => ({
          id: t.ticketId || t.id,
          seatNumber: t.seatNumber || t.SeatNumber,
          price: t.price || t.Price,
          isReserved: t.isReserved || t.IsReserved,
          eventId: t.eventId || t.EventId
        })));
      } catch (err) {
        console.error("Fetch error:", err);
      } finally {
        setLoading(false);
      }
    };
    fetchData();
  }, [locationId, eventId]);

  const toggleSeat = (ticket: ITicket) => {
    if (ticket.isReserved) return;
    setSelectedTickets(prev => 
      prev.find(t => t.id === ticket.id) 
        ? prev.filter(t => t.id !== ticket.id) 
        : [...prev, ticket]
    );
  };

  const totalPrice = selectedTickets.reduce((sum, t) => sum + t.price, 0);

  const handleConfirmSelection = () => {
    navigate(`/locations/${locationId}/events/${eventId}/checkout`, { 
      state: { selectedTickets, event, totalPrice } 
    });
  };

  if (loading) return (
    <div className="min-h-screen flex flex-col items-center justify-center bg-white">
      <div className="w-12 h-12 border-4 border-yellow-500 border-t-transparent rounded-full animate-spin mb-4"></div>
      <p className="text-neutral-500 font-bold uppercase tracking-widest text-xs">Loading Seat Map...</p>
    </div>
  );

  if (!event) return <div className="min-h-screen flex items-center justify-center">Event not found.</div>;

  const rows = tickets.reduce((acc, t) => {
    const rowName = t.seatNumber ? t.seatNumber.charAt(0) : '?';
    if (!acc[rowName]) acc[rowName] = [];
    acc[rowName].push(t);
    return acc;
  }, {} as Record<string, ITicket[]>);

  return (
    <div className="min-h-screen bg-white flex flex-col font-sans pb-32">
      <main className="container mx-auto max-w-5xl px-6 py-12 flex-grow">
        
        <div className="mb-12 text-center">
          <button 
            onClick={() => navigate(-1)}
            className="text-xs font-bold text-neutral-400 uppercase tracking-widest hover:text-black mb-4 transition-colors"
          >
            ← Back to Event
          </button>
          <h1 className="text-4xl md:text-5xl font-black text-neutral-900 uppercase tracking-tighter">{event.name}</h1>
          <p className="text-neutral-500 mt-2 font-medium">Select your preferred seats from the map below</p>
        </div>

        <div className="flex justify-center gap-6 mb-12">
          <div className="flex items-center gap-2">
            <div className="w-4 h-4 rounded bg-white border border-neutral-200"></div>
            <span className="text-[10px] font-bold uppercase text-neutral-500">Available</span>
          </div>
          <div className="flex items-center gap-2">
            <div className="w-4 h-4 rounded bg-yellow-500"></div>
            <span className="text-[10px] font-bold uppercase text-neutral-500">Selected</span>
          </div>
          <div className="flex items-center gap-2">
            <div className="w-4 h-4 rounded bg-neutral-200"></div>
            <span className="text-[10px] font-bold uppercase text-neutral-500">Reserved</span>
          </div>
        </div>

        <div className="bg-neutral-50 rounded-[3rem] p-8 md:p-20 border border-neutral-100 shadow-inner overflow-x-auto">
          <div className="relative mb-20 mx-auto max-w-md">
            <div className="h-2 bg-gradient-to-r from-neutral-200 via-neutral-400 to-neutral-200 rounded-full shadow-[0_10px_20px_rgba(0,0,0,0.05)]"></div>
            <div className="absolute -top-8 left-1/2 -translate-x-1/2 text-[10px] font-black uppercase tracking-[0.3em] text-neutral-400">
              Stage / Screen
            </div>
          </div>

          <div className="flex flex-col gap-6 min-w-max items-center">
            {Object.entries(rows).sort().map(([rowName, rowTickets]) => (
              <div key={rowName} className="flex items-center gap-6">
                <span className="w-6 text-[10px] font-black text-neutral-300">{rowName}</span>
                <div className="flex gap-3">
                  {rowTickets.sort((a,b) => a.seatNumber.localeCompare(b.seatNumber)).map(ticket => {
                    const isSelected = selectedTickets.some(t => t.id === ticket.id);
                    return (
                      <button
                        key={ticket.id}
                        disabled={ticket.isReserved}
                        onClick={() => toggleSeat(ticket)}
                        className={`w-10 h-10 rounded-xl text-[10px] font-bold transition-all duration-300 transform active:scale-90
                          ${ticket.isReserved ? 'bg-neutral-200 text-neutral-400 cursor-not-allowed' : 
                            isSelected ? 'bg-yellow-500 text-black shadow-lg shadow-yellow-500/40 scale-110' : 
                            'bg-white text-neutral-600 border border-neutral-200 hover:border-yellow-500 hover:shadow-md'}
                        `}
                      >
                        {ticket.seatNumber.replace(/^\D+/g, '')} 
                      </button>
                    );
                  })}
                </div>
                <span className="w-6 text-[10px] font-black text-neutral-300 text-right">{rowName}</span>
              </div>
            ))}
          </div>
        </div>

        {selectedTickets.length > 0 && (
          <div className="fixed bottom-8 left-1/2 -translate-x-1/2 w-[95%] max-w-4xl bg-neutral-900 text-white p-5 md:p-6 rounded-[2rem] shadow-2xl flex items-center justify-between z-50 animate-in fade-in slide-in-from-bottom-8 duration-500">
            <div className="flex items-center gap-6 pl-4">
              <div className="hidden sm:block">
                <p className="text-[10px] font-black uppercase tracking-widest text-neutral-500">Selection</p>
                <p className="text-sm font-bold">{selectedTickets.length} Seat(s)</p>
              </div>
              <div className="w-px h-8 bg-neutral-800 hidden sm:block"></div>
              <div>
                <p className="text-[10px] font-black uppercase tracking-widest text-yellow-500/80">Total Price</p>
                <p className="text-2xl font-black text-yellow-500">
                  {totalPrice.toFixed(2)} <span className="text-xs uppercase ml-1">KM</span>
                </p>
              </div>
            </div>
            <button 
              onClick={handleConfirmSelection}
              className="bg-yellow-500 text-black px-10 py-4 rounded-2xl font-black uppercase tracking-widest text-xs hover:bg-yellow-400 hover:shadow-xl hover:shadow-yellow-500/20 transition-all active:scale-95"
            >
              Confirm Selection
            </button>
          </div>
        )}
      </main>
    </div>
  );
};

export default ReservationPage;