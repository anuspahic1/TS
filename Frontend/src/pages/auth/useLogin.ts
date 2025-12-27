import { useState } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import { useAuth } from '../../context/AuthContext';
import { jwtDecode } from 'jwt-decode'; 

export const useLogin = () => {
  const [formData, setFormData] = useState({
    userName: '',
    password: '',
  });

  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);
  const { login } = useAuth();

  const navigate = useNavigate();
  const location = useLocation();

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: value,
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
        return; 
        localStorage.setItem('preAuthToken', result.preAuthToken || '');

      if (result.twoFactorEnabled) {
        navigate('/two-step-verification', { state: location.state });
        return; 
      } 

      const decoded: any = jwtDecode(result.accessToken);
      const rolesClaim = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
      const roles: string[] = Array.isArray(decoded[rolesClaim]) 
                              ? decoded[rolesClaim] 
                              : [decoded[rolesClaim]];

      const from = location.state?.from;

      if (from) {
        navigate(from, { replace: true });
      } else {
        if (roles.includes('Administrator')) {
        navigate('/admin-dashboard', { replace: true });
        }
          else if (roles.includes('Organizer')) {
          navigate('/organizer-dashboard', { replace: true });
        } else {
          navigate('/user-dashboard', { replace: true });
        }
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
