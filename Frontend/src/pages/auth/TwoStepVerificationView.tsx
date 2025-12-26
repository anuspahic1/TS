import { Input } from '../../components/common/Input';
import { Button } from '../../components/common/Button';
import { FormError } from '../../components/common/FormError';

type Props = {
  code: string;
  error: string | null;
  loading: boolean;
  onCodeChange: (value: string) => void;
  onSubmit: () => void;
  onReset: () => void;
  onBack: () => void;
};

const TwoStepVerificationView = ({
  code,
  error,
  loading,
  onCodeChange,
  onSubmit,
  onReset,
  onBack,
}: Props) => {
  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onSubmit();
  };

  return (
    <form onSubmit={handleSubmit} className="space-y-6">
      <button type="submit" hidden />

      <Input
        name="verificationCode"
        value={code}
        onChange={(e) => onCodeChange(e.target.value)}
        placeholder="000000"
        className="text-center text-2xl tracking-widest"
      />

      {error && <FormError message={error} />}

      <Button
        type="submit"
        disabled={loading || code.length !== 6}
      >
        {loading ? 'Verifying…' : 'Verify & Continue'}
      </Button>

      <div className="flex gap-4">
        <Button type="button" variant="secondary" onClick={onBack}>
          Back to login
        </Button>

        <Button type="button" variant="ghost" onClick={onReset}>
          Clear code
        </Button>
      </div>
    </form>
  );
};

export default TwoStepVerificationView;
