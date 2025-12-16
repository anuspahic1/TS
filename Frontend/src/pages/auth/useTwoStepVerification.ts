import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { authService } from '../../services/auth.service';

export const useTwoStepVerification = () => {
  const [code, setCode] = useState('');
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);

  const navigate = useNavigate();

  const updateCode = (value: string) => {
    setCode(value.replace(/\D/g, '').slice(0, 6));
    setError(null);
  };

  const submit = async () => {
    if (code.length !== 6) {
      setError('Verification code must be 6 digits.');
      return;
    }

    try {
      setLoading(true);

      const result = await authService.verify2FA(code);

      localStorage.setItem('authToken', result.accessToken);

      navigate('/');
    } catch (err: any) {
      setError(err.message || 'Invalid verification code.');
    } finally {
      setLoading(false);
    }
  };

  const reset = () => {
    setCode('');
    setError(null);
  };

  return {
    code,
    error,
    loading,
    updateCode,
    submit,
    reset,
  };
};
