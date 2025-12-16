import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { authService } from '../../services/auth.service';

export const useLogin = () => {
  const [formData, setFormData] = useState({
    userName: '',
    password: '',
    totpCode: '',
  });

  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);

  const navigate = useNavigate();

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData((prev: any) => ({
      ...prev,
      [e.target.name]: e.target.value,
    }));
    setError(null);
  };

  const submit = async () => {
    setLoading(true);
    setError(null);

    try {
      const result = await authService.login(formData);

      localStorage.setItem('authToken', result.accessToken);

      navigate('/');
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
