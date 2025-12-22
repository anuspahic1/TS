import React from 'react';

interface EventInfoProps {
  locationName: string | null | undefined;
  description: string | null | undefined;
  price: number;
  dateText: string;
  token: string | null;
  onBooking: () => void;
}

const EventInfo: React.FC<EventInfoProps> = ({ 
  locationName, 
  description, 
  price, 
  dateText, 
  token, 
  onBooking 
}) => {
  const displayLocation = locationName && locationName.trim() !== "" 
    ? locationName 
    : "Location To Be Determined";

  return (
    <div className="flex flex-col justify-center space-y-8">
      <div>
        <h3 className="text-neutral-400 uppercase text-[10px] font-black tracking-[0.2em] mb-2">
          Location & Date
        </h3>
        <p className="text-2xl font-black text-neutral-900 leading-tight">
          {displayLocation}
        </p>
        <p className="text-lg text-neutral-500 font-medium">
          {dateText}
        </p>
      </div>

      <div>
        <h3 className="text-neutral-400 uppercase text-[10px] font-black tracking-[0.2em] mb-2">
          About Event
        </h3>
        <p className="text-neutral-600 leading-relaxed text-lg">
          {description || "Prepare for an unforgettable experience! This event brings together amazing atmosphere and top-tier entertainment."}
        </p>
      </div>

      <div className="flex items-center justify-between p-8 bg-neutral-50 rounded-3xl border border-neutral-100">
        <div>
          <p className="text-neutral-400 text-[10px] font-black uppercase tracking-widest mb-1">
            Price per ticket
          </p>
          <p className="text-4xl font-black text-neutral-900">
            ${price.toFixed(2)}
          </p>
        </div>
        <div className="text-right">
          <span className="px-3 py-1 bg-green-100 text-green-700 text-[10px] font-black uppercase rounded-full">
            Available
          </span>
        </div>
      </div>

      <button 
        onClick={onBooking}
        className={`w-full py-5 rounded-2xl font-black uppercase tracking-[0.2em] text-sm shadow-xl transition-all transform hover:-translate-y-1 active:scale-95 ${
          token 
          ? "bg-yellow-500 text-black hover:bg-yellow-400 shadow-yellow-500/20" 
          : "bg-black text-white hover:bg-neutral-800 shadow-neutral-900/20"
        }`}
      >
        {token ? "Book Your Tickets Now" : "Login to Book"}
      </button>
      
      {!token && (
        <p className="text-center text-xs text-neutral-400 font-medium">
          Secure your spot by logging into your account.
        </p>
      )}
    </div>
  );
};

export default EventInfo;