import { Input } from '../../components/common/Input';
import { Button } from '../../components/common/Button';
import { FormError } from '../../components/common/FormError';

type Props = {
  formData: {
    userName: string;
    password: string;
    totpCode: string;
  };
  loading: boolean;
  error: string | null;
  onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  onSubmit: () => void;
};

const LoginForm = ({
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
        name="userName"
        value={formData.userName}
        onChange={onChange}
        placeholder="Username or email"
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
      
      {/* <Input this should go on new page after submiting username and password
        name="totpCode"
        value={formData.totpCode}
        onChange={(e) =>
          onChange({
            ...e,
            target: {
              ...e.target,
              value: e.target.value.replace(/\D/g, '').slice(0, 6),
            },
          } as React.ChangeEvent<HTMLInputElement>)
        }
        placeholder="2FA code"
      /> */}

      {error && <FormError message={error} />}

      <Button type="submit" disabled={loading}>
        {loading ? 'Logging in…' : 'Log in'}
      </Button>
    </form>
  );
};

export default LoginForm;
