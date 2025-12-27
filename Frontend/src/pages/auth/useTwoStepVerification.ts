import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { authService } from '../../services/auth.service';
import { useAuth } from '../../context/AuthContext';
import { jwtDecode } from 'jwt-decode'; 
import { useLocation } from 'react-router-dom'; 

export const useTwoStepVerification = () => {
  const [code, setCode] = useState('');
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);
  const { updateToken } = useAuth(); 
  const { completeLogin } = useAuth();

  const navigate = useNavigate();
  const location = useLocation(); 

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

      completeLogin(result.accessToken);
      localStorage.removeItem("preAuthToken");
      const roles = Array.isArray(decoded[rolesClaim]) 
                    ? decoded[rolesClaim] 
                    : [decoded[rolesClaim]];

      const from = location.state?.from; 

      if (from) {
      navigate(from, { replace: true });
    } else if (roles.includes('Administrator')) { 
      navigate('/admin-dashboard', { replace: true });
    } else if (roles.includes('Organizer')) {
      navigate('/organizer-dashboard', { replace: true });
    } else {
      navigate('/user-dashboard', { replace: true });
    }
    } catch (err: any) {
  console.error('TFA verification error:', err);
  
  // Provjerite da li je greška sa statusom
  if (err.isApiError) {
    if (err.status === 400) {
      setError("Invalid verification code. Please try again.");
    } 
    else if (err.status === 401) {
      setError("Authentication failed. Please try again.");
    }
    else if (err.status === 0 || err.status === undefined) {
      setError("Network error. Please check your connection.");
    }
    else {
      setError(err.message || "An error occurred. Please try again later.");
    }
  } 
  else {
    // Regular JavaScript error
    if (err.message.includes("Network") || err.message.includes("Failed to fetch")) {
      setError("Network error. Please check your connection.");
    } else {
      setError(err.message || "An unexpected error occurred.");
    }
  }

  setCode('');
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
