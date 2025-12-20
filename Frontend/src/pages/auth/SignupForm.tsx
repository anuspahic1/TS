import React from 'react';
import { Input } from '../../components/common/Input';
import { Button } from '../../components/common/Button';

interface SignupFormProps {
    formData: any;
    loading: boolean;
    onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
    onSubmit: () => void;
}

const SignupForm: React.FC<SignupFormProps> = ({ formData, loading, onChange, onSubmit }) => {
    const handleFormSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        onSubmit();
    };

    return (
        <form onSubmit={handleFormSubmit} className="space-y-5">
            <Input
                label="Full Name"
                name="fullName"
                value={formData.fullName}
                onChange={onChange}
                required
                placeholder="John Doe"
                icon={<svg className="w-5 h-5 text-gray-400" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z" /></svg>}
            />
            <Input
                label="Email Address"
                name="email"
                type="email"
                value={formData.email}
                onChange={onChange}
                required
                placeholder="you@example.com"
                icon={<svg className="w-5 h-5 text-gray-400" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M3 8l7.89 4.26a2 2 0 002.22 0L21 8M5 19h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z" /></svg>}
            />
            <Input
                label="Password"
                name="password"
                type="password"
                value={formData.password}
                onChange={onChange}
                required
                placeholder="Create a password"
                icon={<svg className="w-5 h-5 text-gray-400" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M12 15v2m-6 4h12a2 2 0 002-2v-6a2 2 0 00-2-2H6a2 2 0 00-2 2v6a2 2 0 002 2zm10-10V7a4 4 0 00-8 0v4h8z" /></svg>}
            />
            <Input
                label="Confirm Password"
                name="confirmPassword"
                type="password"
                value={formData.confirmPassword}
                onChange={onChange}
                required
                placeholder="Repeat password"
                icon={<svg className="w-5 h-5 text-gray-400" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z" /></svg>}
            />
            <Button type="submit" loading={loading}>
                Create Account
            </Button>
        </form>
    );
};

export default SignupForm;