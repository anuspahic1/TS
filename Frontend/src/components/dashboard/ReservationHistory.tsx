// src/components/dashboard/ReservationHistory.tsx
import React from 'react';

interface IReservation {
  id: string;
  eventName?: string;
  eventDate?: string;
  totalPrice: number;
  ticketsCount?: number;
  status?: 'completed' | 'cancelled' | 'upcoming'; // Specific type
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
      case 'completed': return 'bg-green-100 text-green-800';
      case 'cancelled': return 'bg-red-100 text-red-800';
      case 'upcoming': return 'bg-yellow-100 text-yellow-800';
      default: return 'bg-gray-100 text-gray-800';
    }
  };

  if (reservations.length === 0) {
    return (
      <div className="bg-white rounded-2xl shadow-lg p-8 text-center">
        <div className="w-16 h-16 mx-auto mb-4 text-gray-400">
          <svg fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={1.5} d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2" />
          </svg>
        </div>
        <h3 className="text-lg font-semibold text-gray-700 mb-2">No Reservations Yet</h3>
        <p className="text-gray-500 mb-6">You haven't made any reservations yet.</p>
        <button className="px-6 py-3 bg-gradient-to-r from-yellow-500 to-yellow-600 text-white rounded-xl hover:from-yellow-600 hover:to-yellow-700 transition-all">
          Browse Events
        </button>
      </div>
    );
  }

  return (
    <div className="bg-white rounded-2xl shadow-lg p-6">
      <div className="flex justify-between items-center mb-6">
        <h2 className="text-2xl font-bold text-gray-900">Reservation History</h2>
        <span className="px-3 py-1 bg-gray-100 text-gray-600 rounded-full text-sm">
          {reservations.length} total
        </span>
      </div>

      <div className="space-y-4">
        {reservations.map((reservation) => (
          <div key={reservation.id} className="p-4 border border-gray-200 rounded-xl hover:border-yellow-300 transition-colors">
            <div className="flex justify-between items-start">
              <div className="flex-1">
                <div className="flex items-center gap-3 mb-2">
                  <h3 className="font-semibold text-gray-900">{reservation.eventName || 'Event'}</h3>
                  {reservation.status && (
                    <span className={`px-2 py-1 rounded-full text-xs font-medium ${getStatusColor(reservation.status)}`}>
                      {reservation.status.charAt(0).toUpperCase() + reservation.status.slice(1)}
                    </span>
                  )}
                </div>
                
                <div className="grid grid-cols-2 md:grid-cols-4 gap-4 text-sm">
                  <div>
                    <p className="text-gray-500">Date</p>
                    <p className="font-medium">
                      {reservation.eventDate ? formatDate(reservation.eventDate) : formatDate(reservation.createdAt)}
                    </p>
                  </div>
                  <div>
                    <p className="text-gray-500">Tickets</p>
                    <p className="font-medium">{reservation.ticketsCount || 0}</p>
                  </div>
                  <div>
                    <p className="text-gray-500">Total</p>
                    <p className="font-bold text-gray-900">${reservation.totalPrice.toFixed(2)}</p>
                  </div>
                  <div>
                    <p className="text-gray-500">Booked</p>
                    <p className="font-medium">{formatDateTime(reservation.createdAt)}</p>
                  </div>
                </div>
              </div>
              
              <button className="ml-4 p-2 text-gray-400 hover:text-yellow-600 hover:bg-yellow-50 rounded-lg">
                <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
                </svg>
              </button>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default ReservationHistory;