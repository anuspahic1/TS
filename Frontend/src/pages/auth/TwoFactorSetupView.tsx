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
    return (
      <div className='py-12 flex justify-center'>
        <Spinner label='Generating your unique security keys...' />
      </div>
    );
  }

  if (!setupInfo) {
    return <FormError message='2FA setup data not available. Please refresh the page.' />;
  }

  return (
    <form
      className='space-y-10'
      onSubmit={e => {
        e.preventDefault();
        onSubmit();
      }}
    >
      <div className='relative group'>
        <div className='absolute -inset-1 bg-gradient-to-r from-yellow-400 to-yellow-100 rounded-2xl blur opacity-20 group-hover:opacity-40 transition duration-1000'></div>
        <div className='relative bg-white p-4 rounded-2xl shadow-inner flex justify-center'>
          <QRCode value={setupInfo.formattedKey} size={200} className='w-48 h-48' />
        </div>
      </div>

      <div className='text-center space-y-4'>
        <p className='text-[10px] font-black text-gray-400 uppercase tracking-widest'>
          Trouble scanning? Use this key:
        </p>

        <div className='flex flex-col items-center gap-3'>
          <code className='px-4 py-2 bg-white border border-gray-200 rounded-xl font-mono text-sm text-gray-800 shadow-sm'>
            {setupInfo.authenticatorKey}
          </code>

          <button
            type='button'
            onClick={() => onCopy(setupInfo.authenticatorKey)}
            className={`text-[10px] font-black uppercase tracking-widest transition-colors ${
              copied ? 'text-green-500' : 'text-yellow-600 hover:text-yellow-700'
            }`}
          >
            {copied ? '✓ Secret Copied' : '❐ Copy Secret Key'}
          </button>
        </div>
      </div>

      <div className='space-y-4 pt-4 border-t border-gray-100'>
        <p className='text-xs font-bold text-gray-500 text-center uppercase tracking-tight'>
          Enter 6-digit code to verify:
        </p>

        <Input
          name='verificationCode'
          value={verificationCode}
          onChange={(e: any) => onCodeChange(e.target.value)}
          placeholder='· · · · · ·'
          className='text-center text-3xl font-black tracking-[0.5em] h-16 rounded-2xl border-gray-200 focus:border-yellow-500 transition-all'
        />

        {error && <FormError message={error} />}

        <Button
          type='submit'
          disabled={loading || verificationCode.length !== 6}
          className='w-full h-14 rounded-2xl bg-black text-white font-black uppercase tracking-[0.2em] hover:bg-yellow-500 transition-all disabled:opacity-30'
        >
          {loading ? 'Verifying...' : 'Activate 2FA'}
        </Button>
      </div>
    </form>
  );
};

export default TwoFactorSetupView;