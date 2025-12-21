import { useState } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
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

      // 1. Provjera 2FA setupa
      if (!result.hasAuthenticatorKey) {
        navigate('/2fa-setup');
        return; 
      } 

      // 2. Provjera 2FA verifikacije
      if (result.twoFactorEnabled) {
        // Proslijedi state dalje kako bi i nakon 2FA znao gdje treba ići
        navigate('/two-step-verification', { state: location.state });
        return; 
      } 

      // 3. Dekodiranje uloga
      const decoded: any = jwtDecode(result.accessToken);
      const rolesClaim = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
      const roles: string[] = Array.isArray(decoded[rolesClaim]) 
                              ? decoded[rolesClaim] 
                              : [decoded[rolesClaim]];

      // 4. PAMETNA NAVIGACIJA
      // Provjeravamo da li u location.state postoji "from" (to smo poslali iz EventDetails)
      const from = location.state?.from;

      if (from) {
        navigate(from, { replace: true });
      } else {
        // Ako nema "from", ide na standardni dashboard zavisno od uloge
        if (roles.includes('Organizer')) {
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
