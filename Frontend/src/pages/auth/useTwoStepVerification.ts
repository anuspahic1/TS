import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { authService } from '../../services/auth.service';
import { useAuth } from '../../context/AuthContext'; 
import { jwtDecode } from 'jwt-decode'; 

export const useTwoStepVerification = () => {
  const [code, setCode] = useState('');
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);
const { updateToken } = useAuth(); 
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
      const result = await authService.verifyTfa(code);

      updateToken(result.accessToken);

      const decoded: any = jwtDecode(result.accessToken);
      const rolesClaim = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
      const roles = Array.isArray(decoded[rolesClaim]) 
                    ? decoded[rolesClaim] 
                    : [decoded[rolesClaim]];

      if (roles.includes('Organizer')) {
        navigate('/organizer-dashboard');
      } else {
        navigate('/user-dashboard');
      }
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
