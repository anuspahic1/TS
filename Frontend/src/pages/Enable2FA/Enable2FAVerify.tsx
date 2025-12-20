import { Input } from '../../components/common/Input';
import { Button } from '../../components/common/Button';
import { FormError } from '../../components/common/FormError';

type Props = {
  verificationCode: string;
  setVerificationCode: (v: string) => void;
  verifyCode: (code: string) => void;
  error: string | null;
  loading: boolean;
};

const Enable2FAVerify = ({
  verificationCode,
  setVerificationCode,
  verifyCode,
  error,
  loading,
}: Props) => {
  return (
    <div className="bg-white p-8 rounded-xl shadow max-w-md mx-auto">
      <h3 className="text-xl font-semibold mb-6 text-center">
        Verify your authenticator
      </h3>

      <Input
        name="verificationCode"
        value={verificationCode}
        onChange={(e) =>
          setVerificationCode(e.target.value.replace(/\D/g, '').slice(0, 6))
        }
        placeholder="000000"
        className="text-center text-2xl tracking-widest"
      />

      {error && <FormError message={error} />}

      <Button
        onClick={() => verifyCode(verificationCode)}
        disabled={loading || verificationCode.length !== 6}
        className="mt-6"
      >
        {loading ? 'Verifying…' : 'Enable 2FA'}
      </Button>
    </div>
  );
};

export default Enable2FAVerify;
