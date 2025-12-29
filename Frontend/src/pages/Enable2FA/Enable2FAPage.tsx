import { useEnable2FA } from './useEnable2FA';
import Enable2FASetup from './Enable2FASetup';
import Enable2FAVerify from './Enable2FAVerify';
import Enable2FASuccess from './Enable2FASuccess';

const Enable2FAPage = () => {
  const state = useEnable2FA();

  return (
    <>
      {state.step === 1 && <Enable2FASetup {...state} />}
      {state.step === 2 && <Enable2FAVerify {...state} />}
      {state.step === 3 && <Enable2FASuccess />}
    </>
  );
};

export default Enable2FAPage;
