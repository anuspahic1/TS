import React from 'react';

interface IReservation {
  id: string;
  eventName: string;
  eventDate?: string;
  totalPrice: number;
  ticketsCount?: number;
  status?: 'completed' | 'cancelled' | 'upcoming';
  createdAt: string;
}

interface ReservationHistoryProps {
  reservations: IReservation[];
}

const ReservationHistory: React.FC<ReservationHistoryProps> = ({ reservations }) => {
  const formatDate = (dateString: string) => {
    try {
      return new Date(dateString).toLocaleDateString('en-US', {
        year: 'numeric',
        month: 'short',
        day: 'numeric'
      });
    } catch {
      return 'Invalid date';
    }
  };

  const formatDateTime = (dateString: string) => {
    try {
      return new Date(dateString).toLocaleString('en-US', {
        month: 'short',
        day: 'numeric',
        hour: '2-digit',
        minute: '2-digit'
      });
    } catch {
      return 'Invalid date';
    }
  };

  const getStatusColor = (status?: string) => {
    if (!status) return 'bg-gray-100 text-gray-800';
    
    switch (status.toLowerCase()) {
      case 'completed': return 'bg-green-100 text-green-700';
      case 'cancelled': return 'bg-red-100 text-red-700';
      case 'upcoming': return 'bg-yellow-100 text-yellow-700';
      default: return 'bg-gray-100 text-gray-800';
    }
  };

  if (reservations.length === 0) {
    return (
      <div className="bg-white rounded-2xl shadow-sm border border-neutral-100 p-8 text-center">
        <div className="w-16 h-16 mx-auto mb-4 text-neutral-300">
          <svg fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={1.5} d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2" />
          </svg>
        </div>
        <h3 className="text-lg font-black uppercase italic tracking-tighter text-neutral-800 mb-2">No Reservations Yet</h3>
        <p className="text-gray-500">You haven't made any reservations yet.</p>
      </div>
    );
  }

  return (
    <div className="bg-white rounded-2xl shadow-sm border border-neutral-100 p-6">
      <div className="flex justify-between items-center mb-6">
        <h2 className="text-xl font-black italic uppercase tracking-tighter text-neutral-900">Reservation History</h2>
        <span className="px-3 py-1 bg-neutral-100 text-neutral-500 rounded-full text-xs font-black uppercase tracking-wider">
          {reservations.length} total
        </span>
      </div>

      <div className="space-y-4">
        {reservations.map((reservation) => (
          <div key={reservation.id} className="p-5 border border-neutral-200 rounded-2xl hover:border-yellow-500 transition-colors">
            <div className="flex flex-col gap-4">
              <div className="flex justify-between items-center">
                <h3 className="font-black text-neutral-900 uppercase italic tracking-tight leading-none">
                  {reservation.eventName || 'Event'}
                </h3>
                {reservation.status && (
                  <span className={`px-2 py-1 rounded-md text-[10px] font-black uppercase tracking-widest ${getStatusColor(reservation.status)}`}>
                    {reservation.status}
                  </span>
                )}
              </div>
              
              <div className="grid grid-cols-2 md:grid-cols-4 gap-6">
                <div>
                  <p className="text-[10px] font-black uppercase text-neutral-400 tracking-widest leading-none mb-2">Event Date</p>
                  <p className="text-sm font-bold text-neutral-900">
                    {reservation.eventDate ? formatDate(reservation.eventDate) : formatDate(reservation.createdAt)}
                  </p>
                </div>
                <div>
                  <p className="text-[10px] font-black uppercase text-neutral-400 tracking-widest leading-none mb-2">Tickets</p>
                  <p className="text-sm font-bold text-neutral-900">{reservation.ticketsCount || 0} Tickets</p>
                </div>
                <div>
                  <p className="text-[10px] font-black uppercase text-neutral-400 tracking-widest leading-none mb-2">Total Paid</p>
                  <p className="text-sm font-black text-yellow-600 uppercase tracking-tight">${reservation.totalPrice.toFixed(2)}</p>
                </div>
                <div>
                  <p className="text-[10px] font-black uppercase text-neutral-400 tracking-widest leading-none mb-2">Booked On</p>
                  <p className="text-sm font-bold text-neutral-900">{formatDateTime(reservation.createdAt)}</p>
                </div>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default ReservationHistory;