import React from 'react';
import { Select } from './Select'; 
import type { ILocation } from '../../types/ILocation';

interface SearchBarProps {
  locations: ILocation[];
  selectedId: string;
  onChange: (id: string) => void;
}

const SearchBar: React.FC<SearchBarProps> = ({ locations, selectedId, onChange }) => {
  const options = locations.map(loc => ({
    value: loc.id,
    label: loc.name
  }));

  return (
    <div className="w-full max-w-3xl animate-fadeIn">
      <div className="bg-white/10 backdrop-blur-md p-2 rounded-2xl shadow-2xl border border-white/20">
        <div className="flex flex-col md:flex-row gap-3">
          <div className="flex-grow">
            <Select
              name="locationSelect"
              value={selectedId}
              onChange={(e) => onChange(e.target.value)}
              options={options}
              icon={
                <svg className="w-5 h-5 text-yellow-500" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M17.657 16.657L13.414 20.9a1.998 1.998 0 01-2.827 0l-4.244-4.243a8 8 0 1111.314 0z" />
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M15 11a3 3 0 11-6 0 3 3 0 016 0z" />
                </svg>
              }
              className="!border-none !shadow-none !rounded-xl !text-lg font-medium"
            />
          </div>
          <button 
            className="px-8 py-3 bg-gradient-to-r from-yellow-500 to-yellow-600 text-white font-bold rounded-xl shadow-lg hover:shadow-yellow-500/20 hover:scale-[1.02] transition-all duration-300 active:scale-95"
          >
            Search
          </button>
        </div>
      </div>
    </div>
  );
};

export default SearchBar;