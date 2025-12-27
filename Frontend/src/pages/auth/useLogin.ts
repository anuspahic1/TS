import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../../context/AuthContext';

export const useLogin = () => {
  const [formData, setFormData] = useState({
    userName: '',
    password: '',
  });

  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);
  const { login } = useAuth();

  const navigate = useNavigate();

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData((prev: any) => ({
      ...prev,
      [e.target.name]: e.target.value,
    }));
    setError(null);
  };

  const submit = async () => {
    setError(null);

    if (!formData.userName.includes('@')) {
      setError('Please enter a valid email address.');
      return;
    }

    setLoading(true);

    try {
      const result = await login(formData);
      if (!result.hasAuthenticatorKey) {
        localStorage.setItem('preAuthToken', result.preAuthToken || '');
        navigate('/2fa-setup');
      } else if (result.twoFactorEnabled) {
        localStorage.setItem('preAuthToken', result.preAuthToken || '');
        navigate('/two-step-verification');
      } else {
        navigate('/rewards');
      }
    } catch (err: any) {
      setError(err.message || 'Login failed.');
    } finally {
      setLoading(false);
    }
  };

  return {
    formData,
    error,
    loading,
    handleChange,
    submit,
  };
};
