import React, { useState } from 'react';


type InputProps = {
  name: string;
  value: string;
  onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  placeholder?: string;
  type?: React.HTMLInputTypeAttribute;
  label?: string;
  icon?: React.ReactNode;
  required?: boolean;
  disabled?: boolean;
  className?: string;
  maxLength?: number;
};

export const Input: React.FC<InputProps> = ({
  name,
  value,
  onChange,
  placeholder,
  type = 'text',
  label,
  icon,
  required = false,
  disabled = false,
  className = '',
  maxLength,
}) => {
  const [showPassword, setShowPassword] = useState(false);

  const inputType = type === 'password' && showPassword ? 'text' : type;

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
        
        <input
          id={name}
          name={name}
          value={value}
          onChange={onChange}
          type={inputType}
          required={required}
          disabled={disabled}
          placeholder={placeholder}
          maxLength={maxLength}
          className={`
            block w-full px-4 py-3 border border-gray-300 rounded-xl shadow-sm 
            focus:ring-2 focus:ring-yellow-500 focus:border-transparent 
            transition-all duration-200 
            ${icon ? 'pl-10' : ''} 
            ${type === 'password' ? 'pr-10' : ''} 
            ${className}
          `}
        />

        {type === 'password' && (
          <button
            type="button"
            onClick={() => setShowPassword(!showPassword)}
            className="absolute inset-y-0 right-0 pr-3 flex items-center text-gray-400 hover:text-yellow-600 transition-colors"
          >
            {showPassword ? (
              <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M13.875 18.825A10.05 10.05 0 0112 19c-4.478 0-8.268-2.943-9.543-7a9.97 9.97 0 011.563-3.029m5.858.908a3 3 0 114.243 4.243M9.878 9.878l4.242 4.242M9.88 9.88l-3.29-3.29m7.532 7.532l3.29 3.29M3 3l18 18" />
              </svg>
            ) : (
              <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z" />
              </svg>
            )}
          </button>
        )}
      </div>
    </div>
  );
};