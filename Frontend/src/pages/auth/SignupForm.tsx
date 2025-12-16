import { Input } from '../../components/common/Input';
import { Button } from '../../components/common/Button';
import { FormError } from '../../components/common/FormError';

type Props = {
  formData: {
    fullName: string;
    email: string;
    password: string;
    confirmPassword: string;
  };
  loading: boolean;
  error: string | null;
  onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  onSubmit: () => void;
};

const SignupForm = ({
  formData,
  loading,
  error,
  onChange,
  onSubmit,
}: Props) => {
  return (
    <form
      onSubmit={(e) => {
        e.preventDefault();
        onSubmit();
      }}
      className="space-y-5"
    >
      <Input
        name="fullName"
        value={formData.fullName}
        onChange={onChange}
        placeholder="Full name"
        required
      />

      <Input
        name="email"
        type="email"
        value={formData.email}
        onChange={onChange}
        placeholder="Email address"
        required
      />

      <Input
        name="password"
        type="password"
        value={formData.password}
        onChange={onChange}
        placeholder="Password"
        required
      />

      <Input
        name="confirmPassword"
        type="password"
        value={formData.confirmPassword}
        onChange={onChange}
        placeholder="Confirm password"
        required
      />

      {error && <FormError message={error} />}

      <Button type="submit" disabled={loading}>
        {loading ? 'Creating account…' : 'Create account'}
      </Button>
    </form>
  );
};

export default SignupForm;
