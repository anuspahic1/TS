import { useNavigate } from 'react-router-dom';
import { useTwoStepVerification } from './useTwoStepVerification';
import TwoStepVerificationView from './TwoStepVerificationView';

const TwoStepVerificationPage = () => {
  const navigate = useNavigate();
  const state = useTwoStepVerification();

  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-50 p-4">
      <div className="w-full max-w-md bg-white rounded-xl shadow p-8">
        <h1 className="text-3xl font-bold text-center mb-4">
          Two-Step Verification
        </h1>

        <p className="text-gray-600 text-center mb-8">
          Enter the 6-digit code from your authenticator app
        </p>

        <TwoStepVerificationView
          code={state.code}
          error={state.error}
          loading={state.loading}
          onCodeChange={state.updateCode}
          onSubmit={state.submit}
          onReset={state.reset}
          onBack={() => navigate('/login')}
        />
      </div>
    </div>
  );
};

export default TwoStepVerificationPage;
