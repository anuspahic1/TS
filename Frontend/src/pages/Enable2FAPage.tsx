import React, { useState, useEffect } from 'react';
import Header from '../components/Header';
import { useNavigate } from 'react-router-dom';

const Enable2FAPage: React.FC = () => {
    const [qrCodeUrl, setQrCodeUrl] = useState('');
    const [setupCode, setSetupCode] = useState('');
    const [verificationCode, setVerificationCode] = useState('');
    const [error, setError] = useState('');
    const [success, setSuccess] = useState(false);
    const [loading, setLoading] = useState(true);
    const [step, setStep] = useState(1); 
    const navigate = useNavigate();

    useEffect(() => {
        //simulation
        const fetchQrCode = async () => {
            setLoading(true);
            await new Promise(resolve => setTimeout(resolve, 1200));
            
            //mock 
            const mockSecret = 'JBSWY3DPEHPK3PXP'; 
            const mockQrCodeUrl = `https://api.qrserver.com/v1/create-qr-code/?size=200x200&data=otpauth://totp/EntrioX:john.doe@example.com?secret=${mockSecret}&issuer=EntrioX`;
            
            setQrCodeUrl(mockQrCodeUrl);
            setSetupCode(mockSecret);
            setLoading(false);
        };
        fetchQrCode();
    }, []);

    const handleConfirm2FA = async (e: React.FormEvent) => {
        e.preventDefault();
        setError('');
        
        if (verificationCode.length !== 6) {
            setError('The verification code must be 6 digits long.');
            return;
        }

        setLoading(true);
        await new Promise(resolve => setTimeout(resolve, 1000));
        
        if (verificationCode === '123456') { 
            setSuccess(true);
            setStep(3);
        } else {
            setError('Verification code is invalid. Please try again.');
        }
        setLoading(false);
    };

    const handleVerificationCodeChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const value = e.target.value.replace(/\D/g, '').slice(0, 6);
        setVerificationCode(value);
        setError('');
    };

    if (success && step === 3) {
        return (
            <div className="min-h-screen bg-gradient-to-br from-green-50 via-white to-emerald-50 flex flex-col">
                <Header />
                <div className="flex-1 flex items-center justify-center p-4">
                    <div className="relative w-full max-w-md">
                        <div className="absolute inset-0 bg-gradient-to-r from-green-500/10 to-emerald-500/10 rounded-3xl blur-2xl"></div>
                        <div className="relative bg-white rounded-2xl shadow-2xl overflow-hidden p-10 text-center">
                            <div className="relative mb-8">
                                <div className="absolute inset-0 bg-gradient-to-r from-green-500/20 to-emerald-500/20 rounded-full blur-xl animate-pulse"></div>
                                <div className="relative w-20 h-20 mx-auto bg-gradient-to-br from-green-500 to-emerald-600 rounded-2xl flex items-center justify-center shadow-lg">
                                    <svg className="w-10 h-10 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2.5} d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z" />
                                    </svg>
                                </div>
                            </div>
                            
                            <h2 className="text-3xl font-bold text-gray-900 mb-4">2FA Successfully Enabled!</h2>
                            <p className="text-gray-600 text-lg font-light mb-8 leading-relaxed">
                                Your account is now protected with Two-Factor Authentication. You'll be asked for a verification code whenever you sign in.
                            </p>
                            
                            <div className="space-y-4">
                                <button 
                                    onClick={() => navigate('/profile')}
                                    className="w-full py-4 px-6 bg-gradient-to-r from-green-500 to-emerald-600 text-white font-semibold rounded-xl shadow-lg hover:shadow-xl transform hover:-translate-y-0.5 transition-all duration-300"
                                >
                                    Go to Profile
                                </button>
                                <button 
                                    onClick={() => navigate('/')}
                                    className="w-full py-3 px-6 bg-gradient-to-r from-gray-100 to-gray-200 text-gray-700 font-semibold rounded-xl hover:bg-gradient-to-r hover:from-gray-200 hover:to-gray-300 transition-all duration-300"
                                >
                                    Back to Home
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }

    if (loading && step === 1) {
        return (
            <div className="min-h-screen bg-gradient-to-br from-gray-50 via-white to-yellow-50 flex flex-col">
                <Header />
                <div className="flex-1 flex items-center justify-center">
                    <div className="text-center">
                        <div className="relative mb-8">
                            <div className="absolute inset-0 bg-gradient-to-r from-yellow-500/10 to-yellow-600/10 blur-xl animate-pulse"></div>
                            <div className="relative animate-spin rounded-full h-20 w-20 border-[6px] border-neutral-200 border-t-yellow-500 border-r-yellow-500/50"></div>
                        </div>
                        <p className="text-xl text-neutral-600 font-light animate-pulse">
                            Setting up 2FA...
                        </p>
                    </div>
                </div>
            </div>
        );
    }

    return (
        <div className="min-h-screen bg-gradient-to-br from-gray-50 via-white to-yellow-50 flex flex-col">
            <Header />
            
            <div className="flex-1 flex items-center justify-center p-4">
                <div className="relative w-full max-w-2xl">
                    <div className="absolute inset-0 bg-gradient-to-r from-yellow-500/5 to-transparent rounded-3xl blur-2xl"></div>
                    
                    <div className="relative bg-white rounded-2xl shadow-2xl overflow-hidden">
                        <div className="px-8 pt-8">
                            <div className="flex items-center justify-between mb-10">
                                <div className="flex items-center gap-4">
                                    <div className={`flex items-center justify-center w-10 h-10 rounded-full ${
                                        step === 1 ? 'bg-gradient-to-br from-yellow-500 to-yellow-600 text-white' : 'bg-gray-100 text-gray-500'
                                    }`}>
                                        1
                                    </div>
                                    <span className={`font-semibold ${step === 1 ? 'text-gray-900' : 'text-gray-500'}`}>
                                        Setup
                                    </span>
                                </div>
                                
                                <div className="flex-1 h-1 mx-4 bg-gray-200">
                                    <div className={`h-full ${step >= 2 ? 'bg-gradient-to-r from-yellow-500 to-yellow-600' : 'bg-gray-300'}`}></div>
                                </div>
                                
                                <div className="flex items-center gap-4">
                                    <div className={`flex items-center justify-center w-10 h-10 rounded-full ${
                                        step === 2 ? 'bg-gradient-to-br from-yellow-500 to-yellow-600 text-white' : 'bg-gray-100 text-gray-500'
                                    }`}>
                                        2
                                    </div>
                                    <span className={`font-semibold ${step === 2 ? 'text-gray-900' : 'text-gray-500'}`}>
                                        Verify
                                    </span>
                                </div>
                            </div>
                        </div>

                        <div className="p-8">
                            <div className="mb-8 text-center">
                                <div className="inline-flex items-center justify-center w-14 h-14 mb-4 bg-gradient-to-br from-yellow-500 to-yellow-600 rounded-2xl shadow-lg">
                                    <svg className="w-7 h-7 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M12 15v2m-6 4h12a2 2 0 002-2v-6a2 2 0 00-2-2H6a2 2 0 00-2 2v6a2 2 0 002 2zm10-10V7a4 4 0 00-8 0v4h8z" />
                                    </svg>
                                </div>
                                <h1 className="text-3xl font-bold text-gray-900 mb-3">Enable Two-Factor Authentication</h1>
                                <p className="text-gray-600 text-lg font-light leading-relaxed">
                                    Add an extra layer of security to your account
                                </p>
                            </div>

                            <div className="mb-8 p-6 bg-gradient-to-r from-yellow-50 to-yellow-100/50 rounded-2xl border border-yellow-200/50">
                                <div className="flex items-start gap-4">
                                    <div className="flex-shrink-0 w-12 h-12 bg-gradient-to-br from-yellow-500 to-yellow-600 rounded-xl flex items-center justify-center shadow-md">
                                        <svg className="w-6 h-6 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
                                        </svg>
                                    </div>
                                    <div>
                                        <h3 className="text-lg font-semibold text-gray-900 mb-3">How to Set Up 2FA</h3>
                                        <ol className="space-y-3">
                                            {[
                                                'Install Google Authenticator, Authy, or Microsoft Authenticator',
                                                'Open the app and tap "Add Account"',
                                                'Scan the QR code below or enter the setup key',
                                                'Enter the 6-digit verification code from the app'
                                            ].map((instruction, index) => (
                                                <li key={index} className="flex items-start gap-3">
                                                    <div className="flex-shrink-0 w-6 h-6 bg-white border border-yellow-200 rounded-full flex items-center justify-center text-sm font-semibold text-yellow-600">
                                                        {index + 1}
                                                    </div>
                                                    <span className="text-gray-700">{instruction}</span>
                                                </li>
                                            ))}
                                        </ol>
                                    </div>
                                </div>
                            </div>

                            <div className="grid grid-cols-1 lg:grid-cols-2 gap-8">
                                <div className="space-y-6">
                                    <div className="bg-gradient-to-br from-gray-50 to-white p-6 rounded-2xl border border-gray-200/50">
                                        <h3 className="text-lg font-semibold text-gray-900 mb-4 text-center">Scan QR Code</h3>
                                        {qrCodeUrl ? (
                                            <div className="relative">
                                                <div className="absolute inset-0 bg-gradient-to-r from-yellow-500/10 via-transparent to-yellow-500/10 rounded-2xl blur-xl opacity-0 group-hover:opacity-100 transition-opacity duration-500"></div>
                                                <img 
                                                    src={qrCodeUrl} 
                                                    alt="QR Code for 2FA setup" 
                                                    className="relative w-48 h-48 mx-auto rounded-xl border-4 border-white shadow-lg"
                                                />
                                            </div>
                                        ) : (
                                            <div className="w-48 h-48 mx-auto bg-gradient-to-br from-gray-100 to-gray-200 rounded-xl flex items-center justify-center">
                                                <span className="text-gray-500">QR Code Loading...</span>
                                            </div>
                                        )}
                                    </div>

                                    <div className="bg-gradient-to-br from-gray-50 to-white p-6 rounded-2xl border border-gray-200/50">
                                        <h3 className="text-lg font-semibold text-gray-900 mb-3">Manual Setup Key</h3>
                                        <div className="bg-gradient-to-r from-gray-100 to-gray-50 p-4 rounded-xl border border-gray-200">
                                            <div className="flex items-center justify-between">
                                                <code className="text-lg font-mono tracking-wider text-gray-800 select-all">
                                                    {setupCode}
                                                </code>
                                                <button 
                                                    onClick={() => navigator.clipboard.writeText(setupCode)}
                                                    className="flex items-center gap-2 px-3 py-2 bg-gradient-to-r from-gray-200 to-gray-300 text-gray-700 rounded-lg hover:from-gray-300 hover:to-gray-400 transition-all duration-200"
                                                >
                                                    <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M8 16H6a2 2 0 01-2-2V6a2 2 0 012-2h8a2 2 0 012 2v2m-6 12h8a2 2 0 002-2v-8a2 2 0 00-2-2h-8a2 2 0 00-2 2v8a2 2 0 002 2z" />
                                                    </svg>
                                                    Copy
                                                </button>
                                            </div>
                                        </div>
                                        <p className="mt-3 text-sm text-gray-600">
                                            Use this key if you can't scan the QR code
                                        </p>
                                    </div>
                                </div>

                                <div className="space-y-6">
                                    <div className="bg-gradient-to-br from-gray-50 to-white p-6 rounded-2xl border border-gray-200/50">
                                        <h3 className="text-lg font-semibold text-gray-900 mb-4">Verify Setup</h3>
                                        
                                        <form onSubmit={handleConfirm2FA} className="space-y-6">
                                            <div>
                                                <label htmlFor="code" className="block text-sm font-semibold text-gray-800 mb-3">
                                                    Enter Verification Code
                                                </label>
                                                <div className="relative">
                                                    <input 
                                                        id="code"
                                                        type="text"
                                                        value={verificationCode}
                                                        onChange={handleVerificationCodeChange}
                                                        className="w-full px-6 py-4 border-2 border-gray-200 rounded-xl text-center text-2xl font-mono tracking-[0.5em] focus:outline-none focus:border-yellow-500 focus:ring-2 focus:ring-yellow-500/20 transition-all duration-200"
                                                        placeholder="000000"
                                                        maxLength={6}
                                                        required
                                                    />
                                                    <div className="absolute top-1/2 left-6 transform -translate-y-1/2">
                                                        <svg className="w-5 h-5 text-gray-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                                            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M12 15v2m-6 4h12a2 2 0 002-2v-6a2 2 0 00-2-2H6a2 2 0 00-2 2v6a2 2 0 002 2zm10-10V7a4 4 0 00-8 0v4h8z" />
                                                        </svg>
                                                    </div>
                                                </div>
                                                <div className="flex justify-between mt-3">
                                                    <span className="text-sm text-gray-500">6-digit code from your app</span>
                                                    <span className={`text-sm font-medium ${
                                                        verificationCode.length === 6 ? 'text-green-600' : 'text-yellow-600'
                                                    }`}>
                                                        {verificationCode.length}/6
                                                    </span>
                                                </div>
                                            </div>

                                            {error && (
                                                <div className="p-4 bg-red-50 border-l-4 border-red-500 rounded-r-lg animate-shake">
                                                    <div className="flex items-center gap-3">
                                                        <svg className="w-5 h-5 text-red-500 flex-shrink-0" fill="currentColor" viewBox="0 0 20 20">
                                                            <path fillRule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zM8.707 7.293a1 1 0 00-1.414 1.414L8.586 10l-1.293 1.293a1 1 0 101.414 1.414L10 11.414l1.293 1.293a1 1 0 001.414-1.414L11.414 10l1.293-1.293a1 1 0 00-1.414-1.414L10 8.586 8.707 7.293z" clipRule="evenodd" />
                                                        </svg>
                                                        <span className="text-sm text-red-800">{error}</span>
                                                    </div>
                                                </div>
                                            )}

                                            <button 
                                                type="submit"
                                                disabled={loading || verificationCode.length !== 6}
                                                className={`w-full py-4 px-6 rounded-xl font-semibold text-white shadow-lg transition-all duration-300 transform hover:scale-[1.02] ${
                                                    loading || verificationCode.length !== 6
                                                        ? 'bg-gradient-to-r from-yellow-400 to-yellow-500 cursor-not-allowed opacity-80' 
                                                        : 'bg-gradient-to-r from-yellow-500 to-yellow-600 hover:from-yellow-600 hover:to-yellow-700 focus:outline-none focus:ring-2 focus:ring-yellow-500 focus:ring-offset-2'
                                                }`}
                                            >
                                                {loading ? (
                                                    <div className="flex items-center justify-center gap-3">
                                                        <svg className="animate-spin h-5 w-5 text-white" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
                                                            <circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle>
                                                            <path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                                                        </svg>
                                                        Verifying...
                                                    </div>
                                                ) : (
                                                    'Enable 2FA Protection'
                                                )}
                                            </button>
                                        </form>
                                    </div>

                                    <div className="bg-gradient-to-br from-blue-50 to-blue-100/50 p-5 rounded-2xl border border-blue-200/50">
                                        <div className="flex items-start gap-3">
                                            <svg className="w-5 h-5 text-blue-600 mt-0.5 flex-shrink-0" fill="currentColor" viewBox="0 0 20 20">
                                                <path fillRule="evenodd" d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-7-4a1 1 0 11-2 0 1 1 0 012 0zM9 9a1 1 0 000 2v3a1 1 0 001 1h1a1 1 0 100-2v-3a1 1 0 00-1-1H9z" clipRule="evenodd" />
                                            </svg>
                                            <div>
                                                <p className="text-sm font-medium text-blue-800 mb-1">Security Tip</p>
                                                <p className="text-sm text-blue-700">
                                                    Make sure to save backup codes in a secure location. You'll need them if you lose access to your authenticator app.
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Enable2FAPage;