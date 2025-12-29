import { useEffect, useState } from 'react';

export const useEnable2FA = () => {
  const [qrCodeUrl, setQrCodeUrl] = useState('');
  const [setupCode, setSetupCode] = useState('');
  const [verificationCode, setVerificationCode] = useState('');
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(true);
  const [step, setStep] = useState<1 | 2 | 3>(1);

  useEffect(() => {
    const loadSetup = async () => {
      setLoading(true);
      await new Promise(r => setTimeout(r, 1000));

      const secret = 'JBSWY3DPEHPK3PXP';
      setSetupCode(secret);
      setQrCodeUrl(`https://api.qrserver.com/v1/create-qr-code/?data=${secret}`);
      setLoading(false);
    };

    loadSetup();
  }, []);

  const verifyCode = async (code: string) => {
    if (code.length !== 6) {
      setError('Code must be 6 digits');
      return;
    }

    setLoading(true);
    await new Promise(r => setTimeout(r, 800));

    if (code === '123456') {
      setStep(3);
    } else {
      setError('Invalid verification code');
    }

    setLoading(false);
  };

  return {
    step,
    loading,
    qrCodeUrl,
    setupCode,
    verificationCode,
    error,
    setVerificationCode,
    verifyCode,
  };
};
