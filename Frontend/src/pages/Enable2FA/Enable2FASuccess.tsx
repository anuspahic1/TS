import { Button } from '../../components/common/Button';
import { useNavigate } from 'react-router-dom';

const Enable2FASuccess = () => {
  const navigate = useNavigate();

  return (
    <div className="bg-white p-10 rounded-xl shadow max-w-md mx-auto text-center">
      <div className="w-16 h-16 mx-auto mb-6 bg-green-500 rounded-full flex items-center justify-center text-white text-2xl">
        ✓
      </div>

      <h2 className="text-2xl font-bold mb-4">
        Two-Factor Authentication Enabled
      </h2>

      <p className="text-gray-600 mb-8">
        Your account is now protected with an additional layer of security.
      </p>

      <div className="space-y-4">
        <Button onClick={() => navigate('/profile')}>
          Go to profile
        </Button>

        <Button
          variant="secondary"
          onClick={() => navigate('/')}
        >
          Back to home
        </Button>
      </div>
    </div>
  );
};

export default Enable2FASuccess;
