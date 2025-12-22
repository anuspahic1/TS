import React, { useState } from 'react';
import { useLocation, useNavigate, useParams } from 'react-router-dom';
import { apiClient } from '../services/apiClient';
import { useAuth } from '../context/AuthContext';
import Swal from 'sweetalert2';

const CheckoutPage: React.FC = () => {
  const { state } = useLocation();
  const { locationId, eventId } = useParams<{ locationId: string; eventId: string }>();
  const navigate = useNavigate();
  const { user } = useAuth(); 
  
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const { selectedTickets, event, totalPrice } = state || { 
    selectedTickets: [], 
    event: null, 
    totalPrice: 0 
  };

  const handleConfirmReservation = async () => {
    console.log("Slanje ID-a korisnika:", user?.id);
    if (!user?.id) {
      setError("User identity not found. Please log in again.");
      return;
    }

    const termsChecked = (document.getElementById('terms') as HTMLInputElement).checked;
    if (!termsChecked) {
      setError("You must agree to the Terms of Service.");
      return;
    }

    const reservationData = {
      userId: user.id, 
      totalPrice: totalPrice, 
      tickets: selectedTickets.map((t: any) => ({
        price: t.price, 
        seatNumber: t.seatNumber
      }))
    };

    try {
      setIsSubmitting(true);
      setError(null);
      
      await apiClient.post(`/locations/${locationId}/events/${eventId}/reservations`, reservationData);
      
      Swal.fire({
        title: 'Reserved!',
        text: 'Your reservation has been successfully created.',
        icon: 'success',
        confirmButtonColor: '#000000',
        confirmButtonText: 'Go to Dashboard'
      }).then((result) => {
        if (result.isConfirmed) {
          navigate('/dashboard'); 
        }
      });
      
    } catch (err: any) {
      console.error("Reservation Error:", err);
      setError(err.response?.data || "An error occurred while processing your reservation.");
    } finally {
      setIsSubmitting(false);
    }
  };

  if (!event || selectedTickets.length === 0) {
    return (
      <div className="min-h-screen flex flex-col items-center justify-center p-10">
        <h2 className="text-xl font-black uppercase mb-4">No tickets selected.</h2>
        <button 
          onClick={() => navigate(-1)} 
          className="bg-black text-white px-8 py-3 rounded-xl font-black uppercase text-xs tracking-widest"
        >
          Go Back
        </button>
      </div>
    );
  }

  return (
    <div className="min-h-screen bg-white flex flex-col font-sans">
      <main className="container mx-auto max-w-3xl px-6 py-16 flex-grow">
        <div className="flex items-center gap-4 mb-10">
          <div className="w-12 h-12 bg-yellow-500 rounded-2xl flex items-center justify-center font-black text-xl">
            3
          </div>
          <div>
            <h1 className="text-3xl font-black uppercase tracking-tight text-neutral-900">Final Confirmation</h1>
            <p className="text-neutral-500 font-medium">Review your order before completing the reservation</p>
          </div>
        </div>

        {error && (
          <div className="mb-8 p-4 bg-red-50 border-l-4 border-red-500 text-red-700 text-sm font-bold">
            {error}
          </div>
        )}

        <div className="grid grid-cols-1 gap-8">
          <div className="bg-neutral-50 rounded-[2.5rem] p-10 border border-neutral-100 shadow-sm">
            <h2 className="text-[10px] font-black uppercase tracking-[0.2em] text-neutral-400 mb-6">Reservation Details</h2>
            
            <div className="mb-8">
              <h3 className="text-2xl font-black text-neutral-900">{event.name}</h3>
              <p className="text-neutral-500 font-medium italic">Standard Entrance</p>
            </div>

            <div className="space-y-4 mb-10">
              {selectedTickets.map((ticket: any) => (
                <div key={ticket.id} className="flex justify-between items-center py-3 border-b border-neutral-200/50 last:border-0">
                  <div className="flex items-center gap-3">
                    <span className="w-8 h-8 bg-white border border-neutral-200 rounded-lg flex items-center justify-center text-[10px] font-black">
                      {ticket.seatNumber}
                    </span>
                    <span className="text-sm font-bold text-neutral-700">Seat Reservation</span>
                  </div>
                  <span className="font-black text-neutral-900">${ticket.price.toFixed(2)}</span>
                </div>
              ))}
            </div>

            <div className="bg-white rounded-3xl p-6 flex justify-between items-center border border-neutral-100 shadow-inner">
              <div>
                <p className="text-[10px] font-black uppercase tracking-widest text-neutral-400">Total Price</p>
                <p className="text-4xl font-black text-neutral-900">${totalPrice.toFixed(2)}</p>
              </div>
              <div className="text-right text-neutral-400 text-[10px] font-bold uppercase leading-tight">
                Tax Included <br /> 17% PDV
              </div>
            </div>
          </div>

          <div className="px-4">
            <div className="flex items-start gap-4 mb-8">
              <input 
                type="checkbox" 
                id="terms" 
                className="mt-1 w-5 h-5 accent-yellow-500 rounded border-neutral-300 cursor-pointer" 
              />
              <label htmlFor="terms" className="text-xs text-neutral-500 leading-relaxed cursor-pointer">
                I agree to the <strong>Terms of Service</strong> and understand that tickets are non-refundable 24 hours before the event starts.
              </label>
            </div>

            <button
              onClick={handleConfirmReservation}
              disabled={isSubmitting}
              className={`w-full py-6 rounded-2xl font-black uppercase tracking-[0.2em] text-sm shadow-xl transition-all transform active:scale-95 ${
                isSubmitting 
                ? "bg-neutral-200 text-neutral-400 cursor-not-allowed" 
                : "bg-black text-white hover:bg-neutral-800 shadow-neutral-900/20"
              }`}
            >
              {isSubmitting ? "Processing..." : "Reserve Now"}
            </button>
            
            <p className="text-center mt-6 text-[10px] font-black uppercase tracking-widest text-neutral-400">
              Secure Checkout Powered by EntrioX
            </p>
          </div>
        </div>
      </main>
    </div>
  );
};

export default CheckoutPage;