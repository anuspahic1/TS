import React from 'react';

interface EventHeroProps {
  name: string;
}

const EventHero: React.FC<EventHeroProps> = ({ name }) => {
  return (
    <div className="relative h-[600px] rounded-3xl overflow-hidden shadow-2xl bg-neutral-900">
      <div className="absolute inset-0 bg-gradient-to-br from-neutral-800 to-black animate-gradient-slow opacity-50"></div>
      
      <div className="absolute bottom-10 left-10 right-10 z-20">
        <span className="inline-block px-4 py-1 bg-yellow-500 text-black text-xs font-bold uppercase tracking-widest rounded-full mb-4">
          Upcoming Event
        </span>
        <h1 className="text-5xl font-black text-white leading-tight">
          {name}
        </h1>
      </div>
    </div>
  );
};

export default EventHero;