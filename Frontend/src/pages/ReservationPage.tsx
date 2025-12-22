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
      
      const eventData = await apiClient.get<EventDto>(`/locations/${locationId}/events/${eventId}`);
      setEvent(eventData);

      const ticketsData = await apiClient.get<any[]>(`/locations/${locationId}/events/${eventId}/tickets`);
      
      const mappedTickets = ticketsData.map(t => ({
        id: t.ticketId || t.id,
        seatNumber: t.seatNumber || t.SeatNumber,
        price: t.price || t.Price,
        isReserved: t.isReserved || t.IsReserved,
        eventId: t.eventId || t.EventId
      }));

      setTickets(mappedTickets);
    } catch (err) {
      console.error("Greška pri dohvaćanju:", err);
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
      state: { 
        selectedTickets, 
        event,
        totalPrice 
      } 
    });
  };

  if (loading) return <div className="min-h-screen flex items-center justify-center">Loading Seat Map...</div>;
  if (!event) return <div className="min-h-screen flex items-center justify-center">Event not found.</div>;

  const rows = tickets.reduce((acc, t) => {
    const rowName = t.seatNumber ? t.seatNumber[0] : '?';
    if (!acc[rowName]) acc[rowName] = [];
    acc[rowName].push(t);
    return acc;
  }, {} as Record<string, ITicket[]>);

  return (
    <div className="min-h-screen bg-white flex flex-col font-sans">
      <main className="container mx-auto max-w-5xl px-6 py-12 flex-grow">
        
        <div className="mb-12 text-center">
          <h1 className="text-4xl font-black text-neutral-900 uppercase">{event.name}</h1>
          <p className="text-neutral-500 mt-2 font-medium">Select your seats</p>
        </div>

        <div className="bg-neutral-50 rounded-[3rem] p-8 md:p-16 border border-neutral-100 shadow-sm mb-12">
          <div className="w-full h-1 bg-neutral-200 rounded-full mb-16 relative">
            <span className="absolute -top-6 left-1/2 -translate-x-1/2 text-[10px] font-black uppercase text-neutral-400">Stage</span>
          </div>

          <div className="flex flex-col gap-4">
            {Object.entries(rows).sort().map(([rowName, rowTickets]) => (
              <div key={rowName} className="flex items-center gap-4">
                <span className="w-6 text-xs font-black text-neutral-300">{rowName}</span>
                <div className="flex flex-wrap gap-2 justify-center flex-grow">
                  {rowTickets.map(ticket => {
                    const isSelected = selectedTickets.some(t => t.id === ticket.id);
                    return (
                      <button
                        key={ticket.id}
                        disabled={ticket.isReserved}
                        onClick={() => toggleSeat(ticket)}
                        className={`w-9 h-9 rounded-lg text-[10px] font-bold transition-all 
                          ${ticket.isReserved ? 'bg-neutral-200 text-neutral-400 cursor-not-allowed' : 
                            isSelected ? 'bg-yellow-500 text-black shadow-md' : 
                            'bg-white text-neutral-600 border border-neutral-200 hover:border-yellow-500'}
                        `}
                      >
                        {ticket.seatNumber}
                      </button>
                    );
                  })}
                </div>
              </div>
            ))}
          </div>
        </div>

        {selectedTickets.length > 0 && (
          <div className="fixed bottom-8 left-1/2 -translate-x-1/2 w-[90%] max-w-4xl bg-black text-white p-6 rounded-3xl shadow-2xl flex items-center justify-between">
            <div>
              <p className="text-[10px] font-black uppercase tracking-widest text-neutral-400">Tickets: {selectedTickets.length}</p>
              <p className="text-xl font-black text-yellow-500">${totalPrice.toFixed(2)}</p>
            </div>
            <button 
              onClick={handleConfirmSelection}
              className="bg-yellow-500 text-black px-8 py-4 rounded-2xl font-black uppercase tracking-widest text-xs hover:bg-yellow-400 transition-colors"
            >
              Checkout Now
            </button>
          </div>
        )}
      </main>
    </div>
  );
};

export default ReservationPage;