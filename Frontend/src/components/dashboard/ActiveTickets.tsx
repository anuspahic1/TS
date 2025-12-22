import React, { useState } from 'react';
import { QRCodeSVG } from 'qrcode.react';

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
  const [showQrModal, setShowQrModal] = useState(false);
  const [currentTicket, setCurrentTicket] = useState<ITicket | null>(null);

  const formatDate = (dateString: string) => {
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

  const formatPrice = (price: number) => {
    return `$${price.toFixed(2)}`;
  };

  const openQrModal = (ticket: ITicket) => {
    setCurrentTicket(ticket);
    setShowQrModal(true);
  };

  const closeQrModal = () => {
    setShowQrModal(false);
    setCurrentTicket(null);
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
    <>
      <div className="bg-white rounded-2xl shadow-lg p-6">
        <div className="flex justify-between items-center mb-6">
          <h2 className="text-2xl font-bold text-gray-900">Active Tickets</h2>
          <span className="px-3 py-1 bg-green-100 text-green-800 rounded-full text-sm font-medium">
            {tickets.length} upcoming
          </span>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
          {tickets.map((ticket) => (
            <div key={ticket.id} className="border border-gray-200 rounded-2xl overflow-hidden hover:shadow-md transition-shadow">
              <div className="bg-gradient-to-r from-yellow-500 to-yellow-600 p-4">
                <h3 className="font-bold text-white text-lg">{ticket.eventName}</h3>
                <p className="text-yellow-100 text-sm mt-1">{formatDate(ticket.eventDate)}</p>
              </div>
              
              <div className="p-4">
                <div className="space-y-4">
                  <div className="flex justify-between items-center">
                    <div>
                      <p className="text-sm text-gray-500">Price</p>
                      <p className="text-xl font-bold text-gray-900">{formatPrice(ticket.price)}</p>
                    </div>
                    
                    {ticket.seatNumber && (
                      <div className="text-right">
                        <p className="text-sm text-gray-500">Seat Number</p>
                        <p className="text-lg font-bold text-gray-900">{ticket.seatNumber}</p>
                      </div>
                    )}
                  </div>

                  {ticket.qrCode ? (
                    <button 
                      onClick={() => openQrModal(ticket)}
                      className="w-full py-3 bg-gradient-to-r from-blue-500 to-blue-600 text-white rounded-lg hover:from-blue-600 hover:to-blue-700 transition-all font-medium flex items-center justify-center gap-2"
                    >
                      <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M12 4v1m6 11h2m-6 0h-2v4m0-11v3m0 0h.01M12 12h4.01M16 20h4M4 12h4m12 0h.01M5 8h2a1 1 0 001-1V5a1 1 0 00-1-1H5a1 1 0 00-1 1v2a1 1 0 001 1zm12 0h2a1 1 0 001-1V5a1 1 0 00-1-1h-2a1 1 0 00-1 1v2a1 1 0 001 1zM5 20h2a1 1 0 001-1v-2a1 1 0 00-1-1H5a1 1 0 00-1 1v2a1 1 0 001 1z" />
                      </svg>
                      Show QR Code
                    </button>
                  ) : (
                    <div className="w-full py-3 bg-gray-100 text-gray-500 rounded-lg font-medium text-center">
                      No QR Code Available
                    </div>
                  )}
                </div>
              </div>
            </div>
          ))}
        </div>
      </div>

      {showQrModal && currentTicket && (
        <div className="fixed inset-0 bg-white/40 backdrop-blur-md flex items-center justify-center z-50 p-4 transition-all">
        <div className="bg-white rounded-3xl max-w-md w-full shadow-2xl border border-white/20">
          
          <div className="flex justify-between items-center p-6 border-b border-gray-100">
            <div>
              <h3 className="text-xl font-bold text-gray-900">{currentTicket.eventName}</h3>
              <p className="text-sm text-gray-500 mt-1">{formatDate(currentTicket.eventDate)}</p>
            </div>
            <button 
              onClick={closeQrModal}
              className="p-2 hover:bg-gray-100 rounded-full transition-colors text-gray-400 hover:text-gray-600"
            >
              <svg className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M6 18L18 6M6 6l12 12" />
              </svg>
            </button>
          </div>
            
            <div className="p-6 text-center">
              <div className="mb-6">
                <p className="text-gray-600 mb-4">Scan this QR code at the event entrance</p>
                
                <div className="bg-gray-50 p-6 rounded-xl">
                  {currentTicket.qrCode ? (
                    <>
                      <div className="mb-4">
                        <div className="w-48 h-48 mx-auto bg-white p-4 rounded-lg flex items-center justify-center">
                          <QRCodeSVG 
                            value={currentTicket.qrCode}
                            size={160}
                            level="H"
                            includeMargin={true}
                            bgColor="#FFFFFF"
                            fgColor="#000000"
                          />
                        </div>
                        <p className="text-sm text-gray-500 mt-2">Scan for entry</p>
                      </div>
                      
                      <div className="mt-4 p-3 bg-white rounded-lg border">
                        <div className="grid grid-cols-2 gap-4 text-sm">
                          <div className="text-left">
                            <p className="text-gray-500">Event</p>
                            <p className="font-medium">{currentTicket.eventName}</p>
                          </div>
                          <div className="text-right">
                            <p className="text-gray-500">Price</p>
                            <p className="font-medium">{formatPrice(currentTicket.price)}</p>
                          </div>
                          {currentTicket.seatNumber && (
                            <div className="text-left col-span-2">
                              <p className="text-gray-500">Seat Number</p>
                              <p className="font-medium">{currentTicket.seatNumber}</p>
                            </div>
                          )}
                        </div>
                      </div>
                    </>
                  ) : (
                    <p className="text-gray-500">No QR code available</p>
                  )}
                </div>
              </div>
              
              <div className="text-sm text-gray-500 space-y-1">
                <p>• Present this code at the event entrance</p>
                <p>• Keep this code confidential</p>
                <p>• Valid only for this specific event</p>
              </div>
            </div>
            
            <div className="p-6 border-t">
              <button 
                onClick={closeQrModal}
                className="w-full py-3 bg-gradient-to-r from-yellow-500 to-yellow-600 text-white rounded-xl hover:from-yellow-600 hover:to-yellow-700 transition-all font-medium"
              >
                Close
              </button>
            </div>
          </div>
        </div>
      )}
    </>
  );
};

export default ActiveTickets;