import React from 'react';
import { Input } from '../../components/common/Input';
import { Button } from '../../components/common/Button';

interface LoginFormProps {
  formData: any;
  loading: boolean;
  onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  onSubmit: () => void; 
}

const LoginForm: React.FC<LoginFormProps> = ({ formData, loading, onChange, onSubmit }) => {
  const handleFormSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onSubmit();
  };

  return (
    <form onSubmit={handleFormSubmit} className="space-y-5">
      <Input
        label="Email"
        name="userName"
        value={formData.userName}
        onChange={onChange}
        required
        placeholder="Enter your email"
        icon={<svg className="w-5 h-5 text-gray-400" fill="none" viewBox="0 0 24 24" stroke="currentColor"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z" /></svg>}
      />
      
      <Input
        label="Password"
        name="password"
        type="password"
        value={formData.password}
        onChange={onChange}
        required
        placeholder="••••••••"
        icon={<svg className="w-5 h-5 text-gray-400" fill="none" viewBox="0 0 24 24" stroke="currentColor"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M12 15v2m-6 4h12a2 2 0 002-2v-6a2 2 0 00-2-2H6a2 2 0 00-2 2v6a2 2 0 002 2zm10-10V7a4 4 0 00-8 0v4h8z" /></svg>}
      />

      {/* <Input
        label="2FA Code"
        name="totpCode"
        value={formData.totpCode}
        onChange={onChange}
        required
        maxLength={6}
        placeholder="000000"
        className="text-center tracking-widest"
      /> */}
      

      <Button type="submit" loading={loading} variant="primary">
        Sign In
      </Button>
    </form>
  );
};

export default LoginForm;