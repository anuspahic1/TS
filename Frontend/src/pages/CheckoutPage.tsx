import React, { useState, useEffect } from 'react';
import { useLocation, useNavigate, useParams } from 'react-router-dom';
import { apiClient } from '../services/apiClient';
import { useAuth } from '../context/AuthContext';
import Swal from 'sweetalert2';


const CheckoutPage: React.FC = () => {
  const { state } = useLocation();
  const { locationId, eventId } = useParams<{ locationId: string; eventId: string }>();
  const navigate = useNavigate();
  const { user } = useAuth(); 
  const [usePoints, setUsePoints] = useState(false);
  
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const [profile, setProfile] = useState<any>(null);

  const { selectedTickets, event, totalPrice } = state || { 
    selectedTickets: [], 
    event: null, 
    totalPrice: 0 
  };

  useEffect(() => {
    const fetchUserProfile = async () => {
      if (user?.id) {
        try {
          const response = await apiClient.get(`/users/${user.id}`);
          setProfile(response); 
        } catch (err) {
          console.error("Could not fetch user profile", err);
        }
      }
    };
    fetchUserProfile();
  }, [user?.id]);

  const handleConfirmReservation = async () => {
    if (!user?.id) {
      setError("User identity not found. Please log in again.");
      return;
    }

    const termsChecked = (document.getElementById('terms') as HTMLInputElement).checked;
    if (!termsChecked) {
      setError("You must agree to the Terms of Service to proceed.");
      return;
    }

    const reservationData = {
      userId: user.id, 
      totalPrice: totalPrice, 
      useLoyaltyPoints: usePoints,
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
        title: 'Success!',
        text: 'Your seats have been successfully reserved.',
        icon: 'success',
        confirmButtonColor: '#EAB308', 
        confirmButtonText: 'Go to My Tickets'
      }).then((result) => {
        if (result.isConfirmed) {
          navigate('/user-dashboard', { state: { activeTab: 'tickets' } }); 
        }
      });
      
    } catch (err: any) {
      console.error("Reservation Error:", err);
      setError(err.response?.data || "An unexpected error occurred. Please try again.");
    } finally {
      setIsSubmitting(false);
    }
  };

  if (!event || selectedTickets.length === 0) {
    return (
      <div className="min-h-screen flex flex-col items-center justify-center p-10 bg-neutral-50">
        <div className="w-20 h-20 bg-neutral-200 rounded-full flex items-center justify-center mb-6">
          <svg className="w-10 h-10 text-neutral-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M16 11V7a4 4 0 00-8 0v4M5 9h14l1 12H4L5 9z" />
          </svg>
        </div>
        <h2 className="text-xl font-black uppercase mb-2">Your cart is empty</h2>
        <p className="text-neutral-500 mb-8">Please select tickets before checking out.</p>
        <button 
          onClick={() => navigate(-1)} 
          className="bg-black text-white px-10 py-4 rounded-2xl font-black uppercase text-xs tracking-[0.2em] transition-transform active:scale-95"
        >
          Return to Events
        </button>
      </div>
    );
  }

  return (
    <div className="min-h-screen bg-white flex flex-col font-sans">
      <main className="container mx-auto max-w-3xl px-6 py-16 flex-grow">
        
        <div className="flex items-center gap-6 mb-12">
          <div className="w-14 h-14 bg-yellow-500 rounded-2xl flex items-center justify-center font-black text-2xl shadow-lg shadow-yellow-500/20">
            3
          </div>
          <div>
            <h1 className="text-4xl font-black uppercase tracking-tighter text-neutral-900 leading-none">Checkout</h1>
            <p className="text-neutral-500 font-medium mt-1">Finalize your premium experience</p>
          </div>
        </div>

        {error && (
          <div className="mb-8 p-5 bg-red-50 border border-red-100 rounded-2xl flex items-center gap-4 text-red-600 text-sm font-bold animate-shake">
            <svg className="w-5 h-5 flex-shrink-0" fill="currentColor" viewBox="0 0 20 20">
              <path fillRule="evenodd" d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-7 4a1 1 0 11-2 0 1 1 0 012 0zm-1-9a1 1 0 00-1 1v4a1 1 0 102 0V6a1 1 0 00-1-1z" clipRule="evenodd" />
            </svg>
            {error}
          </div>
        )}

        <div className="grid grid-cols-1 gap-10">
          <div className="bg-neutral-50 rounded-[3rem] p-10 border border-neutral-100 shadow-sm relative overflow-hidden">
            <div className="absolute top-0 right-0 w-32 h-32 bg-yellow-500/5 rounded-full -mr-16 -mt-16 blur-3xl"></div>
            
            <h2 className="text-[10px] font-black uppercase tracking-[0.3em] text-neutral-400 mb-8">Order Summary</h2>
            
            <div className="mb-10">
              <span className="px-3 py-1 bg-neutral-900 text-white text-[9px] font-black uppercase rounded-md mb-3 inline-block">Event</span>
              <h3 className="text-3xl font-black text-neutral-900 tracking-tight leading-tight">{event.name}</h3>
              <p className="text-neutral-500 font-medium mt-1 uppercase text-xs tracking-widest italic">Standard Admission</p>
            </div>

            <div className="space-y-4 mb-10">
              {selectedTickets.map((ticket: any) => (
                <div key={ticket.id} className="flex justify-between items-center py-4 border-b border-neutral-200/50 last:border-0 group">
                  <div className="flex items-center gap-4">
                    <span className="w-10 h-10 bg-white border border-neutral-200 rounded-xl flex items-center justify-center text-xs font-black shadow-sm group-hover:border-yellow-500 transition-colors">
                      {ticket.seatNumber}
                    </span>
                    <div>
                      <span className="text-sm font-bold text-neutral-800 block leading-none">Seat Reservation</span>
                      <span className="text-[10px] text-neutral-400 font-bold uppercase tracking-tighter">Row {ticket.seatNumber.charAt(0)}</span>
                    </div>
                  </div>
                  <span className="font-black text-neutral-900 text-lg">${ticket.price.toFixed(2)}</span>
                </div>
              ))}
            </div>

            <div className="bg-white rounded-[2rem] p-8 flex justify-between items-center border border-neutral-200 shadow-sm">
              <div>
                <p className="text-[10px] font-black uppercase tracking-widest text-neutral-400 mb-1">Total Amount</p>
                <p className="text-5xl font-black text-neutral-900 tracking-tighter">
                  <span className="text-2xl mr-1 text-yellow-500">$</span>
                  {totalPrice.toFixed(2)}
                </p>
              </div>
              <div className="text-right text-neutral-300 text-[10px] font-black uppercase leading-tight tracking-[0.1em]">
                VAT Included <br /> 17% Sarajevo Tax
              </div>
            </div>
          </div>

          <div className="px-2">
            <div className="flex items-start gap-4 mb-10 bg-neutral-50 p-6 rounded-2xl border border-dashed border-neutral-200">
              <input 
                type="checkbox" 
                id="terms" 
                className="mt-1 w-6 h-6 accent-yellow-500 rounded-lg border-neutral-300 cursor-pointer transition-transform active:scale-90" 
              />
              <label htmlFor="terms" className="text-[11px] text-neutral-500 leading-relaxed cursor-pointer font-medium uppercase tracking-tight">
                I agree to the <strong className="text-black">Terms of Service</strong> and I understand that this purchase is non-refundable 24 hours prior to the event launch.
              </label>
            </div>

            <div className="flex items-center gap-3 p-4 bg-yellow-50 rounded-2xl mb-6 border border-yellow-200">
            <input 
              type="checkbox" 
              id="loyalty"
              checked={usePoints}
              disabled={!profile || profile.loyaltyPoints < 10}
              onChange={(e) => setUsePoints(e.target.checked)}
              className={`w-5 h-5 accent-yellow-600 ${(!profile || profile.loyaltyPoints < 10) ? 'opacity-50 cursor-not-allowed' : 'cursor-pointer'}`}
          />
            <label htmlFor="loyalty" className="text-sm font-bold text-neutral-800 cursor-pointer">
            Use 10 Loyalty Points for 10% discount 
            <span className="block text-[10px] text-neutral-500 font-normal">
                (Current balance: {profile?.loyaltyPoints || 0} pts)
            </span>
</label>
        </div>

            <button
            onClick={handleConfirmReservation}
            disabled={isSubmitting}
            className={`w-full py-7 rounded-[2rem] font-black uppercase tracking-[0.3em] text-sm shadow-2xl transition-all transform active:scale-95 mb-8 ${
              isSubmitting 
              ? "bg-neutral-200 text-neutral-400 cursor-not-allowed scale-95" 
              : "bg-neutral-900 text-white hover:bg-black shadow-neutral-900/40"
            }`}
          >
            {isSubmitting ? (
              <div className="flex items-center justify-center gap-3">
                <div className="w-4 h-4 border-2 border-white/30 border-t-white rounded-full animate-spin"></div>
                <span>Processing...</span>
              </div>
            ) : (
              usePoints 
                ? `Pay ${(totalPrice * 0.9).toFixed(2)} USD` 
                : "Complete Purchase"
            )}
          </button>
            
            <div className="flex items-center justify-center gap-3 opacity-40 grayscale">
              <div className="h-px w-10 bg-neutral-300"></div>
              <p className="text-[9px] font-black uppercase tracking-[0.3em] text-neutral-900">
                Secure SSL Encrypted Checkout
              </p>
              <div className="h-px w-10 bg-neutral-300"></div>
            </div>
          </div>
        </div>
      </main>
    </div>
  );
};

export default CheckoutPage;