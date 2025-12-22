import React from 'react';
import type { EventDto } from '../../types/IEvent';
import { getEventColor } from '../../utils/eventUtils';

interface EventCardProps {
  event: EventDto;
  onDetailClick: (eventId: string) => void;
}

const EventCard: React.FC<EventCardProps> = ({ event, onDetailClick }) => {
  const dateObj = new Date(event.eventDate);
  const eventColor = getEventColor(event.name);
  
  const isUpcoming = dateObj > new Date() && dateObj.getFullYear() > 1;
  const isToday = dateObj.toDateString() === new Date().toDateString();

  return (
    <div className="group bg-white rounded-2xl overflow-hidden shadow-lg hover:shadow-2xl transition-all duration-500 transform hover:-translate-y-2 border border-neutral-200/50 relative">
      
      <CardHeader 
        name={event.name} 
        color={eventColor} 
        price={event.minTicketPrice} 
        isToday={isToday} 
        isUpcoming={isUpcoming} 
      />

      <div className="p-5">
        <CardDateTime location={event.locationName} date={dateObj} />
        
        <p className="text-neutral-600 text-sm leading-relaxed line-clamp-2 mb-6">
          {event.description || 'Join us for an unforgettable event with amazing atmosphere and great performances.'}
        </p>

        <CardFooter onAction={() => onDetailClick(event.id)} />
      </div>

      <div className="absolute bottom-0 left-0 right-0 h-1 bg-gradient-to-r from-transparent via-yellow-500/30 to-transparent opacity-0 group-hover:opacity-100 transition-opacity duration-500"></div>
    </div>
  );
};


const CardHeader = ({ name, color, price, isToday, isUpcoming }: any) => (
  <div className={`relative h-56 overflow-hidden bg-gradient-to-br ${color}`}>
    <div className="absolute inset-0 bg-gradient-to-t from-black/50 via-black/20 to-transparent"></div>
    
    <div className="absolute top-4 left-4 z-10">
      {isToday ? (
        <span className="inline-flex items-center gap-1.5 px-3 py-1.5 bg-red-500 text-white text-[10px] font-black uppercase rounded-full shadow-lg">
          <div className="w-1 h-1 bg-white rounded-full animate-ping"></div> Happening Today
        </span>
      ) : (
        <span className="inline-flex items-center gap-1.5 px-3 py-1.5 bg-white/90 backdrop-blur text-black text-[10px] font-black uppercase rounded-full shadow-lg">
          {isUpcoming ? 'Upcoming' : 'Featured'}
        </span>
      )}
    </div>

    <div className="absolute top-4 right-4 z-10">
      <span className="px-3 py-1.5 bg-yellow-500 text-black text-xs font-black rounded-full shadow-lg">
        ${price}
      </span>
    </div>

    <h3 className="absolute bottom-4 left-4 right-4 text-2xl font-black text-white leading-tight drop-shadow-md line-clamp-2">
      {name}
    </h3>
  </div>
);

const CardDateTime = ({ location, date }: any) => {
  const formattedDate = date.toLocaleDateString('en-US', { month: 'short', day: 'numeric' });
  const eventTime = date.toLocaleTimeString('en-US', { hour: '2-digit', minute: '2-digit' });

  return (
    <div className="flex items-center justify-between mb-5">
      <div className="flex items-center gap-3">
        <div className="flex flex-col items-center justify-center w-12 h-12 rounded-xl bg-neutral-50 border border-neutral-100">
          <span className="text-sm font-black text-neutral-900">{date.getDate()}</span>
          <span className="text-[9px] text-neutral-500 font-bold uppercase">{date.toLocaleString('en-US', { month: 'short' })}</span>
        </div>
        <div>
          <p className="text-sm font-bold text-neutral-900">{location || 'Location TBD'}</p>
          <p className="text-xs text-neutral-500">{formattedDate} • {eventTime}</p>
        </div>
      </div>
    </div>
  );
};

const CardFooter = ({ onAction }: any) => (
  <div className="flex items-center justify-between">
    <div className="flex gap-2">
       <div className="w-8 h-8 rounded-full bg-blue-50 flex items-center justify-center text-blue-600">
          <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path d="M12 8v4l3 3m6-3a9 9 0 11-18 0 9 9 0 0118 0z" strokeWidth={2} /></svg>
       </div>
       <div className="w-8 h-8 rounded-full bg-green-50 flex items-center justify-center text-green-600">
          <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path d="M15 5v2m0 4v2m0 4v2M5 5a2 2 0 00-2 2v3a2 2 0 110 4v3a2 2 0 002 2h14a2 2 0 002-2v-3a2 2 0 110-4V7a2 2 0 00-2-2H5z" strokeWidth={2} /></svg>
       </div>
    </div>
    <button
      onClick={onAction}
      className="group/btn flex items-center gap-2 px-5 py-2.5 bg-black text-white text-xs font-black uppercase tracking-widest rounded-full hover:bg-neutral-800 transition-all"
    >
      Details
      <svg className="w-3 h-3 transform group-hover/btn:translate-x-1 transition-transform" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path d="M13 7l5 5m0 0l-5 5m5-5H6" strokeWidth={3} /></svg>
    </button>
  </div>
);

export default EventCard;