import React from 'react';
import SearchBar from '../common/SearchBar';
import backgroundImage from "../../assets/homepage.jpg";
import type{ ILocation } from '../../types/ILocation';

interface HeroSectionProps {
  locations: ILocation[];
  selectedLocationId: string;
  selectedLocationName: string;
  onLocationChange: (id: string) => void;
}

const HeroSection: React.FC<HeroSectionProps> = ({ 
  locations, 
  selectedLocationId, 
  selectedLocationName, 
  onLocationChange 
}) => {
  return (
    <section className="relative h-[85vh] flex items-center justify-center text-white overflow-hidden">
      <div className="absolute inset-0 bg-black/60 z-10" />
      <img 
        src={backgroundImage} 
        className="absolute inset-0 w-full h-full object-cover scale-105 animate-zoom-slow" 
        alt="Events" 
      />
      
      <div className="relative z-20 text-center px-6 max-w-5xl">
        <div className="inline-block mb-6 px-4 py-1.5 bg-yellow-500/20 backdrop-blur-md rounded-full border border-yellow-500/30 shadow-xl">
          <span className="text-yellow-400 text-xs font-bold tracking-[0.2em] uppercase">Premium Ticket Experience</span>
        </div>
        
        <h1 className="text-6xl md:text-8xl font-black mb-6 tracking-tighter leading-tight">
          Discover Your <br />
          <span className="text-transparent bg-clip-text bg-gradient-to-r from-yellow-300 to-orange-500">
            Next Adventure
          </span>
        </h1>
        
        <p className="text-xl md:text-2xl mb-10 text-neutral-200 font-light max-w-2xl mx-auto leading-relaxed">
          Find the most exclusive events happening in <span className="font-bold text-white underline decoration-yellow-500 underline-offset-8">{selectedLocationName}</span>
        </p>
        
        <div className="relative w-full max-w-2xl mx-auto">
          <SearchBar 
            locations={locations} 
            selectedId={selectedLocationId} 
            onChange={onLocationChange} 
          />
        </div>
      </div>

      <div className="absolute bottom-10 left-1/2 -translate-x-1/2 z-20 animate-bounce">
        <svg className="w-6 h-6 text-white/50" fill="none" stroke="currentColor" viewBox="0 0 24 24">
          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M19 14l-7 7m0 0l-7-7m7 7V3" />
        </svg>
      </div>
    </section>
  );
};

export default HeroSection;