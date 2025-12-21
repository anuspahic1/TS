import React from 'react';
import type { EventDto } from '../../types/IEvent';

interface EventCardProps {
  event: EventDto;
  onDetailClick: (eventId: string) => void;
}

const EventCard: React.FC<EventCardProps> = ({ event, onDetailClick }) => {
  const dateObj = new Date(event.eventDate);
  
  const formattedDate = dateObj.toLocaleDateString('en-US', {
    year: 'numeric',
    month: 'short',
    day: 'numeric',
    weekday: 'short',
  });

  const eventTime = dateObj.toLocaleTimeString('en-US', {
    hour: '2-digit',
    minute: '2-digit',
  });

  const getEventColor = (eventName: string) => {
    const colors = [
      'from-blue-500 to-purple-600',
      'from-yellow-500 to-orange-600',
      'from-green-500 to-teal-600',
      'from-pink-500 to-rose-600',
      'from-indigo-500 to-blue-600',
    ];
    const index = eventName.split('').reduce((acc, char) => acc + char.charCodeAt(0), 0) % colors.length;
    return colors[index];
  };

  return (
    <div className="group bg-white rounded-2xl overflow-hidden shadow-lg hover:shadow-2xl transition-all duration-500 transform hover:-translate-y-2 border border-neutral-200/50">
      <div className={`relative h-56 overflow-hidden bg-gradient-to-br ${getEventColor(event.name)}`}>
        <div className="absolute inset-0 bg-gradient-to-t from-black/40 via-transparent to-transparent"></div>
        
        <div className="absolute top-4 left-4">
          <span className="inline-flex items-center gap-1.5 px-3 py-1.5 bg-white/90 backdrop-blur-sm text-neutral-800 text-xs font-semibold rounded-full shadow-sm">
              ⭐ New
          </span>
        </div>

        <div className="absolute bottom-4 left-4 right-4">
          <h3 className="text-2xl font-bold text-white drop-shadow-lg line-clamp-2">
            {event.name}
          </h3>
        </div>

        <div className="absolute inset-0 bg-gradient-to-r from-transparent via-white/10 to-transparent translate-x-[-100%] group-hover:translate-x-[100%] transition-transform duration-1000"></div>
      </div>

      <div className="p-5">
        <div className="flex items-center justify-between mb-4">
          <div className="flex items-center gap-2">
            <div className="flex flex-col items-center justify-center w-12 h-12 bg-neutral-50 rounded-xl border border-neutral-200/50 shadow-sm">
              <span className="text-sm font-bold text-neutral-800">{dateObj.getDate()}</span>
              <span className="text-[10px] text-neutral-500 font-bold uppercase">
                {dateObj.toLocaleString('en-US', { month: 'short' })}
              </span>
            </div>
            <div className="flex flex-col">
              <span className="text-sm font-semibold text-neutral-900">{formattedDate.split(',')[0]}</span>
              <span className="text-xs text-neutral-500">{eventTime} • {event.locationName}</span>
            </div>
          </div>
          
          <div className="px-3 py-1 bg-yellow-50 rounded-lg border border-yellow-100">
            <span className="text-sm font-bold text-yellow-700">${event.minTicketPrice}</span>
          </div>
        </div>

        <p className="text-neutral-600 text-sm leading-relaxed line-clamp-2 mb-6">
          {event.description || 'Join us for an unforgettable event in your city!'}
        </p>

        <div className="flex justify-end">
          <button
            onClick={() => onDetailClick(event.id)}
            className="group/btn relative overflow-hidden flex items-center gap-2 px-6 py-2.5 bg-neutral-900 text-white text-sm font-bold rounded-full shadow-md transition-all duration-300 hover:bg-neutral-800"
          >
            <div className="absolute inset-0 bg-gradient-to-r from-transparent via-white/10 to-transparent translate-x-[-100%] group-hover/btn:translate-x-[100%] transition-transform duration-700"></div>
            <span>Details</span>
            <svg className="w-4 h-4 transform group-hover/btn:translate-x-1 transition-transform" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2.5} d="M13 7l5 5m0 0l-5 5m5-5H6" />
            </svg>
          </button>
        </div>
      </div>
    </div>
  );
};

export default EventCard;