import React from 'react';

type ButtonVariant = 'primary' | 'secondary' | 'danger' | 'ghost';

type ButtonProps = {
  children: React.ReactNode;
  onClick?: () => void;
  type?: 'button' | 'submit';
  variant?: ButtonVariant;
  disabled?: boolean;
  className?: string;
};

const VARIANT_CLASSES: Record<ButtonVariant, string> = {
  primary:
    'bg-gradient-to-r from-green-500 to-emerald-600 text-white',
  secondary:
    'bg-gray-100 text-gray-800 hover:bg-gray-200',
  danger:
    'bg-red-500 text-white hover:bg-red-600',
  ghost: 
    'bg-transparent text-gray-600 hover:bg-gray-100',
};

export const Button: React.FC<ButtonProps> = ({
  children,
  onClick,
  type = 'button',
  variant = 'primary',
  disabled = false,
  className = '',
}) => {
  return (
    <button
      type={type}
      onClick={onClick}
      disabled={disabled}
      className={`
        w-full py-4 px-6 font-semibold rounded-xl
        shadow-lg hover:shadow-xl
        transform hover:-translate-y-0.5
        transition-all duration-300
        disabled:opacity-50 disabled:cursor-not-allowed
        ${VARIANT_CLASSES[variant]}
        ${className}
      `}
    >
      {children}
    </button>
  );
};
