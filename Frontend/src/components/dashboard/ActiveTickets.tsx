// src/components/dashboard/ActiveTickets.tsx
import React from 'react';

interface ITicket {
  id: string;
  eventName?: string;
  eventDate?: string;
  price: number;
  seatNumber?: string;
  isActive?: boolean;
}

interface ActiveTicketsProps {
  tickets: ITicket[];
}

const ActiveTickets: React.FC<ActiveTicketsProps> = ({ tickets }) => {
  const formatDate = (dateString?: string) => {
    if (!dateString) return 'Date not set';
    
    try {
      return new Date(dateString).toLocaleDateString('en-US', {
        weekday: 'short',
        month: 'short',
        day: 'numeric',
        hour: '2-digit',
        minute: '2-digit'
      });
    } catch {
      return 'Invalid date';
    }
  };

  const getDaysUntilEvent = (dateString?: string) => {
    if (!dateString) return null;
    
    try {
      const eventDate = new Date(dateString);
      const today = new Date();
      const diffTime = eventDate.getTime() - today.getTime();
      const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
      
      if (diffDays < 0) return 'Past event';
      if (diffDays === 0) return 'Today';
      if (diffDays === 1) return 'Tomorrow';
      return `${diffDays} days`;
    } catch {
      return null;
    }
  };

  if (tickets.length === 0) {
    return (
      <div className="bg-white rounded-2xl shadow-lg p-8 text-center">
        <div className="w-16 h-16 mx-auto mb-4 text-gray-400">
          <svg fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={1.5} d="M15 5v2m0 4v2m0 4v2M5 5a2 2 0 00-2 2v3a2 2 0 110 4v3a2 2 0 002 2h14a2 2 0 002-2v-3a2 2 0 110-4V7a2 2 0 00-2-2H5z" />
          </svg>
        </div>
        <h3 className="text-lg font-semibold text-gray-700 mb-2">No Active Tickets</h3>
        <p className="text-gray-500 mb-6">You don't have any upcoming events.</p>
        <button className="px-6 py-3 bg-gradient-to-r from-yellow-500 to-yellow-600 text-white rounded-xl hover:from-yellow-600 hover:to-yellow-700 transition-all">
          Find Events
        </button>
      </div>
    );
  }

  return (
    <div className="bg-white rounded-2xl shadow-lg p-6">
      <div className="flex justify-between items-center mb-6">
        <h2 className="text-2xl font-bold text-gray-900">Active Tickets</h2>
        <span className="px-3 py-1 bg-green-100 text-green-800 rounded-full text-sm font-medium">
          {tickets.length} upcoming
        </span>
      </div>

      <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
        {tickets.map((ticket) => {
          const daysUntil = getDaysUntilEvent(ticket.eventDate);
          
          return (
            <div key={ticket.id} className="border border-gray-200 rounded-2xl overflow-hidden hover:shadow-md transition-shadow">
              {/* Header */}
              <div className="bg-gradient-to-r from-yellow-500 to-yellow-600 p-4">
                <div className="flex justify-between items-center">
                  <h3 className="font-bold text-white text-lg">{ticket.eventName || 'Event'}</h3>
                  {daysUntil && (
                    <span className="px-3 py-1 bg-white/20 text-white rounded-full text-sm">
                      {daysUntil}
                    </span>
                  )}
                </div>
                <p className="text-yellow-100 text-sm mt-1">{formatDate(ticket.eventDate)}</p>
              </div>
              
              {/* Ticket Details */}
              <div className="p-4">
                <div className="flex justify-between items-center mb-4">
                  <div>
                    <p className="text-sm text-gray-500">Ticket ID</p>
                    <p className="font-mono text-gray-900">{ticket.id.substring(0, 8)}...</p>
                  </div>
                  <div className="text-right">
                    <p className="text-sm text-gray-500">Price</p>
                    <p className="text-xl font-bold text-gray-900">${ticket.price.toFixed(2)}</p>
                  </div>
                </div>
                
                {ticket.seatNumber && (
                  <div className="mb-4 p-3 bg-gray-50 rounded-lg">
                    <div className="flex justify-between">
                      <span className="text-gray-600">Seat Number</span>
                      <span className="font-bold text-gray-900">{ticket.seatNumber}</span>
                    </div>
                  </div>
                )}
                
                {/* Actions */}
                <div className="flex gap-2">
                  <button className="flex-1 py-2 bg-gradient-to-r from-blue-500 to-blue-600 text-white rounded-lg hover:from-blue-600 hover:to-blue-700 transition-all text-sm">
                    View Details
                  </button>
                  <button className="flex-1 py-2 bg-gradient-to-r from-gray-100 to-gray-200 text-gray-700 rounded-lg hover:from-gray-200 hover:to-gray-300 transition-all text-sm">
                    Add to Calendar
                  </button>
                </div>
              </div>
            </div>
          );
        })}
      </div>
    </div>
  );
};

export default ActiveTickets;