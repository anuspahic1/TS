import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { authService } from '../../services/auth.service';


type SignupFormState = {
  fullName: string;
  email: string;
  password: string;
  confirmPassword: string;
};

export const useSignup = () => {
  const [formData, setFormData] = useState<SignupFormState>({
    fullName: '',
    email: '',
    password: '',
    confirmPassword: '',
  });

  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);

  const navigate = useNavigate();

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData(prev => ({
      ...prev,
      [e.target.name]: e.target.value,
    }));
    setError(null);
  };

  const submit = async () => {
    if (formData.password !== formData.confirmPassword) {
      setError('Passwords do not match.');
      return;
    }

    setLoading(true);
    setError(null);

    const trimmedName = formData.fullName.trim();
    const [firstName, ...lastNameParts] = trimmedName.split(' ');
    const lastName = lastNameParts.join(' ');

    const payload = {
      userName: formData.email,
      email: formData.email,
      password: formData.password,
      firstName: firstName || undefined,
      lastName: lastName || undefined,
    };

    try {
      await authService.signup(payload);
      navigate('/login');
    } catch (err: any) {
      setError(err.message || 'Signup failed.');
    } finally {
      setLoading(false);
    }
  };

  return {
    formData,
    loading,
    error,
    handleChange,
    submit,
  };
};