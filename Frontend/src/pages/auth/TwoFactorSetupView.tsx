import { Input } from '../../components/common/Input';
import { Button } from '../../components/common/Button';
import { FormError } from '../../components/common/FormError';
import { Spinner } from '../../components/common/Spinner';
import QRCode from 'react-qr-code';

type Props = {
  setupInfo: {
    formattedKey: string;
    authenticatorKey: string;
  } | null;
  verificationCode: string;
  error: string | null;
  loading: boolean;
  pageLoading: boolean;
  copied: boolean;
  onCodeChange: (value: string) => void;
  onCopy: (secret: string) => void;
  onSubmit: () => void;
};

const TwoFactorSetupView = ({
  setupInfo,
  verificationCode,
  error,
  loading,
  pageLoading,
  copied,
  onCodeChange,
  onCopy,
  onSubmit,
}: Props) => {
  if (pageLoading) {
    return <Spinner label='Preparing your 2FA setup...' />;
  }

  if (!setupInfo) {
    return <FormError message='2FA setup data not available.' />;
  }

  return (
    <form
      className='space-y-8'
      onSubmit={e => {
        e.preventDefault();
        onSubmit();
      }}
    >
      <QRCode value={setupInfo.formattedKey} size={224} className='mx-auto w-56 h-56' />

      <div className='text-center'>
        <code className='block font-mono text-lg mb-2'>{setupInfo.authenticatorKey}</code>

        <Button type='button' variant='secondary' onClick={() => onCopy(setupInfo.authenticatorKey)}>
          {copied ? 'Copied!' : 'Copy key'}
        </Button>
      </div>

      <Input
        name='verificationCode'
        value={verificationCode}
        onChange={(e: { target: { value: string } }) => onCodeChange(e.target.value)}
        placeholder='000000'
        className='text-center text-2xl tracking-widest'
      />

      {error && <FormError message={error} />}

      <Button type='submit' disabled={loading || verificationCode.length !== 6}>
        {loading ? 'Verifying…' : 'Complete setup'}
      </Button>
    </form>
  );
};

export default TwoFactorSetupView;
