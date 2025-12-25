import { useEffect, useState } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import { authService } from '../../services/auth.service';
import Swal from 'sweetalert2';


export const useTwoFactorSetup = () => {
  const [setupInfo, setSetupInfo] = useState<{
    formattedKey: string;      
    authenticatorKey: string;  
  } | null>(null);

  const [verificationCode, setVerificationCode] = useState('');
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);
  const [pageLoading, setPageLoading] = useState(true);
  const [copied, setCopied] = useState(false);
  const navigate = useNavigate();
  const location = useLocation();
  
  useEffect(() => {
    const loadSetup = async () => {
      try {
        setPageLoading(true);
        const res = await authService.getTfaSetup();
        setSetupInfo({
          formattedKey: res.formattedKey,
          authenticatorKey: res.authenticatorKey,
        });
      } catch (err: any) {
        setError(err.message || 'Failed to load 2FA setup.');
      } finally {
        setPageLoading(false);
      }
    };

    loadSetup();
  }, []);

  const updateCode = (value: string) => {
    setVerificationCode(value.replace(/\D/g, '').slice(0, 6));
    setError(null);
  };

  const copySecret = async (secret: string) => {
    await navigator.clipboard.writeText(secret);
    setCopied(true);
    setTimeout(() => setCopied(false), 2000);
  };

  const submit = async () => {
    if (verificationCode.length !== 6) {
      setError('Verification code must be 6 digits.');
      return;
    }

    try {
      setLoading(true);

      await authService.postTfaSetup(verificationCode, 'admin@entriox.com'); 
      await Swal.fire({
      title: '2FA Activated!',
      text: 'Two-Factor Authentication has been successfully enabled. Please login again to finalize.',
      icon: 'success',
      confirmButtonColor: '#EAB308',
      confirmButtonText: 'Back to Login'
    });

      navigate('/login', { state: location.state }); 

    } catch (err: any) {
      setError(err.message || '2FA verification failed.');
    } finally {
      setLoading(false);
    }
  };

  return {
    setupInfo,
    verificationCode,
    error,
    loading,
    pageLoading,
    copied,
    updateCode,
    copySecret,
    submit,
  };
};
