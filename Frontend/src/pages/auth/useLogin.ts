import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../../context/AuthContext';
import { jwtDecode } from 'jwt-decode'; 

export const useLogin = () => {
  const [formData, setFormData] = useState({
    userName: '',
    password: '',
   // totpCode: '',
  });

  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);
  const { login } = useAuth();

  const navigate = useNavigate();

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
        navigate('/2fa-setup');
        return; 
      } 

      if (result.twoFactorEnabled) {
        navigate('/two-step-verification');
        return; 
      } 

      const decoded: any = jwtDecode(result.accessToken);
      const rolesClaim = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
      const roles: string[] = Array.isArray(decoded[rolesClaim]) 
                              ? decoded[rolesClaim] 
                              : [decoded[rolesClaim]];

      if (roles.includes('Organizer')) {
        navigate('/organizer-dashboard');
      } else {
        navigate('/user-dashboard');
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
