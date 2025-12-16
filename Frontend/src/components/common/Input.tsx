import React from 'react';

type InputProps = {
  name: string;
  value: string;
  onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  placeholder?: string;
  type?: React.HTMLInputTypeAttribute;
  required?: boolean;
  disabled?: boolean;
  className?: string;
};

export const Input: React.FC<InputProps> = ({
  name,
  value,
  onChange,
  placeholder,
  type = 'text',
  required = false,
  disabled = false,
  className = '',
}) => {
  return (
    <input
      name={name}
      value={value}
      onChange={onChange}
      type={type}
      required={required}
      disabled={disabled}
      placeholder={placeholder}
      className={`
        mt-1 block w-full px-4 py-3
        border border-gray-300 rounded-xl shadow-sm
        focus:ring-2 focus:ring-yellow-500 focus:border-transparent
        transition-all duration-200
        disabled:opacity-50 disabled:cursor-not-allowed
        ${className}
      `}
    />
  );
};
