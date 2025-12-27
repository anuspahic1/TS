import React from 'react';

interface ITicket {
  id: string;
  eventName: string;
  eventDate: string;
  price: number;
  seatNumber?: string;
  qrCode?: string;
}

interface ActiveTicketsProps {
  tickets: ITicket[];
}

const ActiveTickets: React.FC<ActiveTicketsProps> = ({ tickets }) => {
  const formatDate = (dateString: string) => {
    try {
      const date = new Date(dateString);
      return {
        day: date.toLocaleDateString('en-US', { day: 'numeric' }),
        month: date.toLocaleDateString('en-US', { month: 'short' }).toUpperCase(),
        full: date.toLocaleDateString('en-US', { 
          weekday: 'short', 
          hour: '2-digit', 
          minute: '2-digit' 
        })
      };
    } catch {
      return { day: '?', month: '?', full: 'Invalid date' };
    }
  };

  const formatPrice = (price: number) => {
    return `$${price.toFixed(2)}`;
  };

  if (tickets.length === 0) {
    return (
      <div className="bg-white rounded-2xl border border-dashed border-neutral-200 p-12 text-center">
        <div className="w-16 h-16 mx-auto mb-4 bg-neutral-50 rounded-full flex items-center justify-center text-neutral-300">
          <svg className="w-8 h-8" fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={1.5} d="M15 5v2m0 4v2m0 4v2M5 5a2 2 0 00-2 2v3a2 2 0 110 4v3a2 2 0 002 2h14a2 2 0 002-2v-3a2 2 0 110-4V7a2 2 0 00-2-2H5z" />
          </svg>
        </div>
        <h3 className="text-lg font-black uppercase italic text-neutral-800">No Active Tickets</h3>
        <p className="text-neutral-500 text-sm mb-6">Your ticket collection is empty.</p>
      </div>
    );
  }

  return (
    <div className="bg-white rounded-2xl shadow-sm border border-neutral-100 p-6">
      <div className="flex justify-between items-end mb-8">
        <div>
          <span className="text-[10px] font-black uppercase tracking-[0.2em] text-yellow-600 block mb-1">Upcoming Events</span>
          <h2 className="text-2xl font-black italic uppercase tracking-tighter text-neutral-900 leading-none">
            Active Tickets
          </h2>
        </div>
        <span className="px-3 py-1 bg-neutral-900 text-white text-[10px] font-black uppercase tracking-widest rounded-md">
          {tickets.length} Total
        </span>
      </div>

      <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
        {tickets.map((ticket) => {
          const dateInfo = formatDate(ticket.eventDate);
          return (
            <div key={ticket.id} className="group relative flex bg-neutral-50 rounded-xl overflow-hidden border border-neutral-200 hover:border-yellow-500 transition-all duration-300">
              
              <div className="w-20 bg-neutral-900 flex flex-col items-center justify-center text-white border-r border-dashed border-neutral-700">
                <span className="text-[10px] font-bold tracking-widest text-yellow-500">{dateInfo.month}</span>
                <span className="text-2xl font-black italic leading-none my-1">{dateInfo.day}</span>
              </div>

              <div className="flex-1 p-4 flex flex-col justify-between">
                <div>
                  <h3 className="font-black text-neutral-900 uppercase italic tracking-tight leading-tight group-hover:text-yellow-600 transition-colors">
                    {ticket.eventName}
                  </h3>
                  <p className="text-[11px] font-medium text-neutral-500 mt-1 uppercase tracking-wider">
                    {dateInfo.full}
                  </p>
                </div>

                <div className="flex justify-between items-end mt-4 pt-3 border-t border-neutral-200">
                  <div>
                    <p className="text-[9px] font-black uppercase text-neutral-400 tracking-widest mb-0.5">Price</p>
                    <p className="text-sm font-black text-neutral-900">{formatPrice(ticket.price)}</p>
                  </div>
                  
                  {ticket.seatNumber && (
                    <div className="text-right">
                      <p className="text-[9px] font-black uppercase text-neutral-400 tracking-widest mb-0.5">Seat</p>
                      <p className="text-sm font-black text-neutral-900 uppercase italic">{ticket.seatNumber}</p>
                    </div>
                  )}
                </div>
              </div>
              <div className="absolute top-1/2 -left-1 -translate-y-1/2 w-2 h-4 bg-white rounded-full border border-neutral-200"></div>
              <div className="absolute top-1/2 -right-1 -translate-y-1/2 w-2 h-4 bg-white rounded-full border border-neutral-200"></div>
            </div>
          );
        })}
      </div>
    </div>
  );
};

export default ActiveTickets;