import TwoFactorSetupView from './TwoFactorSetupView';
import { useTwoFactorSetup } from './useTwoFactorSetup';

const TwoFactorSetupPage = () => {
  const state = useTwoFactorSetup();

  return (
    <div className='min-h-screen flex items-center justify-center bg-gray-50 p-4'>
      <div className='w-full max-w-xl bg-white rounded-xl shadow p-8'>
        <h2 className='text-3xl font-bold text-center mb-6'>Enable Two-Factor Authentication</h2>

        <TwoFactorSetupView
          setupInfo={state.setupInfo}
          verificationCode={state.verificationCode}
          error={state.error}
          loading={state.loading}
          pageLoading={state.pageLoading}
          copied={state.copied}
          onCodeChange={state.updateCode}
          onCopy={state.copySecret}
          onSubmit={state.submit}
        />
      </div>
    </div>
  );
};

export default TwoFactorSetupPage;
