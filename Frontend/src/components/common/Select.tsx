import React from 'react';

type SelectOption = {
  value: string;
  label: string;
};

type SelectProps = {
  name: string;
  value: string;
  onChange: (e: React.ChangeEvent<HTMLSelectElement>) => void;
  options: SelectOption[];
  label?: string;
  icon?: React.ReactNode;
  disabled?: boolean;
  className?: string;
};

export const Select: React.FC<SelectProps> = ({
  name,
  value,
  onChange,
  options,
  label,
  icon,
  disabled = false,
  className = '',
}) => {
  return (
    <div className="w-full">
      {label && (
        <label htmlFor={name} className="block text-sm font-semibold text-gray-800 mb-1.5">
          {label}
        </label>
      )}
      <div className="relative group">
        {icon && (
          <div className="absolute inset-y-0 left-0 pl-3 flex items-center pointer-events-none">
            {icon}
          </div>
        )}

        <select
          id={name}
          name={name}
          value={value}
          onChange={onChange}
          disabled={disabled}
          className={`
            block w-full px-4 py-3 border border-gray-300 rounded-xl shadow-sm 
            text-gray-900 bg-white cursor-pointer appearance-none
            focus:ring-2 focus:ring-yellow-500 focus:border-transparent 
            transition-all duration-200 
            ${icon ? 'pl-10' : ''} 
            ${className}
          `}
        >
          {options.map((option) => (
            <option key={option.value} value={option.value}>
              {option.label}
            </option>
          ))}
        </select>

        <div className="absolute inset-y-0 right-0 pr-3 flex items-center pointer-events-none text-gray-400 group-hover:text-yellow-600 transition-colors">
          <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M19 9l-7 7-7-7" />
          </svg>
        </div>
      </div>
    </div>
  );
};