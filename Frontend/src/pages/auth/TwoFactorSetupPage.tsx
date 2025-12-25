import TwoFactorSetupView from './TwoFactorSetupView';
import { useTwoFactorSetup } from './useTwoFactorSetup';

const TwoFactorSetupPage = () => {
  const state = useTwoFactorSetup();

  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-50 p-6 font-sans">
      <div className="w-full max-w-xl bg-white rounded-[2.5rem] shadow-2xl shadow-gray-200/50 p-10 lg:p-14 border border-gray-50">
        
        <header className="text-center mb-10">
          <div className="w-16 h-16 bg-yellow-50 rounded-2xl flex items-center justify-center mx-auto mb-6">
            <span className="text-2xl">🔐</span>
          </div>
          <h2 className="text-3xl font-black text-gray-900 uppercase tracking-tight">
            Enable <span className="text-yellow-500">Security</span>
          </h2>
          <div className="mt-6 space-y-3">
            <p className="text-gray-500 font-bold text-xs uppercase tracking-[0.2em]">
              Two-Factor Authentication Setup
            </p>
            <p className="text-gray-400 text-sm leading-relaxed max-w-xs mx-auto">
              Scan the secure QR code below using Google Authenticator or Microsoft Authenticator app.
            </p>
          </div>
        </header>

        <div className="bg-gray-50/50 rounded-[2rem] p-8 border border-gray-100">
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

        <footer className="mt-10 pt-6 border-t border-gray-50 text-center">
          <p className="text-[10px] text-gray-300 font-black uppercase tracking-[0.3em]">
            EntrioX Identity Protection Protocol
          </p>
        </footer>
      </div>
    </div>
  );
};

export default TwoFactorSetupPage;