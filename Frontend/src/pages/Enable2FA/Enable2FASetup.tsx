import { Spinner } from '../../components/common/Spinner';

type Props = {
  loading: boolean;
  qrCodeUrl: string;
  setupCode: string;
};

const Enable2FASetup = ({ loading, qrCodeUrl, setupCode }: Props) => {
  if (loading) {
    return (
      <div className="flex justify-center items-center min-h-[300px]">
        <Spinner label="Setting up 2FA..." />
      </div>
    );
  }

  return (
    <div className="grid grid-cols-1 md:grid-cols-2 gap-8">
      <div className="bg-white p-6 rounded-xl shadow">
        <h3 className="font-semibold mb-4 text-center">Scan QR Code</h3>
        <img
          src={qrCodeUrl}
          alt="2FA QR Code"
          className="w-48 h-48 mx-auto"
        />
      </div>

      <div className="bg-white p-6 rounded-xl shadow">
        <h3 className="font-semibold mb-4">Manual setup key</h3>
        <code className="block p-4 bg-gray-100 rounded font-mono text-lg">
          {setupCode}
        </code>
        <p className="text-sm text-gray-600 mt-2">
          Use this key if you cannot scan the QR code.
        </p>
      </div>
    </div>
  );
};

export default Enable2FASetup;
