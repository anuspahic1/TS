import React from 'react';

export const AuthCard: React.FC<{ children: React.ReactNode }> = ({ children }) => {
  return (
    <div className="w-full max-w-md">
      <div className="relative bg-white rounded-2xl shadow-2xl overflow-hidden p-8">
        {children}
      </div>
    </div>
  );
};