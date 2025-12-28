import React, { useMemo, useState } from 'react';
import { Input } from '../../components/common/Input';
import { Button } from '../../components/common/Button';
import { Select } from '../../components/common/Select';

interface SignupFormProps {
  formData: any;
  loading: boolean;
  onChange: (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => void;
  onSubmit: () => void;
}

const validatePassword = (password: string) => ({
  length: password.length >= 10,
  lowercase: /[a-z]/.test(password),
  uppercase: /[A-Z]/.test(password),
  digit: /\d/.test(password),
  special: /[^a-zA-Z0-9]/.test(password),
});

const SignupForm: React.FC<SignupFormProps> = ({ formData, loading, onChange, onSubmit }) => {
  const [passwordFocused, setPasswordFocused] = useState(false);

  const rules = useMemo(() => validatePassword(formData.password || ''), [formData.password]);

  const isPasswordValid = Object.values(rules).every(Boolean);
  const passwordsMatch = formData.password && formData.password === formData.confirmPassword;

  const canSubmit = isPasswordValid && passwordsMatch && !loading;

  const handleFormSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (canSubmit) {
      onSubmit();
    }
  };

  return (
    <form onSubmit={handleFormSubmit} className='space-y-5' noValidate>
      <Input
        label='Full Name'
        name='fullName'
        value={formData.fullName}
        onChange={onChange}
        required
        placeholder='John Doe'
      />

      <Input
        label='Email Address'
        name='email'
        type='email'
        value={formData.email}
        onChange={onChange}
        required
        placeholder='you@example.com'
      />

      <Input
        label='Password'
        name='password'
        type='password'
        value={formData.password}
        onChange={onChange}
        placeholder='Create a strong password'
        onFocus={() => setPasswordFocused(true)}
        onBlur={() => setPasswordFocused(false)}
      />

      {passwordFocused && (
        <ul className='text-xs mt-2 grid grid-cols-2 gap-x-4 gap-y-1 text-gray-500'>
          <li className={rules.length ? 'text-green-600' : ''}>• 10+ characters</li>
          <li className={rules.lowercase ? 'text-green-600' : ''}>• Lowercase</li>
          <li className={rules.uppercase ? 'text-green-600' : ''}>• Uppercase</li>
          <li className={rules.digit ? 'text-green-600' : ''}>• Number</li>
          <li className={rules.special ? 'text-green-600' : ''}>• Special</li>
        </ul>
      )}

      <Input
        label='Confirm Password'
        name='confirmPassword'
        type='password'
        value={formData.confirmPassword}
        onChange={onChange}
        required
        placeholder='Repeat password'
        error={formData.confirmPassword && !passwordsMatch && 'Passwords do not match'}
      />

      <Select
        label='I am a/an'
        name='role'
        value={formData.role}
        onChange={onChange}
        options={[
          { value: 'Customer', label: 'Customer' },
          { value: 'Organizer', label: 'Organizer' },
        ]}
      />

      <Button type='submit' loading={loading} disabled={!canSubmit}>
        Create Account
      </Button>
    </form>
  );
};

export default SignupForm;
