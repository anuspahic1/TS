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
  return (
    <div className="space-y-8">
      <div className="space-y-4">
        <Input
          name="verificationCode"
          value={code}
          onChange={(e) => onCodeChange(e.target.value)}
          placeholder="· · · · · ·"
          className="text-center text-4xl font-black tracking-[0.6em] h-20 rounded-2xl border-gray-100 bg-gray-50/50 focus:bg-white focus:ring-4 focus:ring-yellow-500/10 transition-all"
        />

        {error && <FormError message={error} />}
      </div>

      <Button
        onClick={onSubmit}
        disabled={loading || code.length !== 6}
        className="w-full h-14 rounded-2xl bg-black text-white font-black uppercase tracking-widest hover:bg-yellow-500 transition-all"
      >
        {loading ? 'Confirming...' : 'Verify Identity'}
      </Button>

      <div className="flex items-center gap-3 pt-4">
        <button 
          onClick={onBack}
          className="flex-1 text-[10px] font-black uppercase tracking-widest text-gray-400 hover:text-black transition-colors py-2"
        >
          ← Cancel
        </button>
        <div className="w-1 h-1 bg-gray-200 rounded-full"></div>
        <button 
          onClick={onReset}
          className="flex-1 text-[10px] font-black uppercase tracking-widest text-gray-400 hover:text-red-500 transition-colors py-2"
        >
          Clear Input
        </button>
      </div>
    </div>
  );
};

export default TwoStepVerificationView;