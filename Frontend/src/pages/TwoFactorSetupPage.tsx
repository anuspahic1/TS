import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { 
    get2FASetupInfo, 
    verify2FASetup, 
    type ITwoFactorSetupInfo, 
    type IAuthResponse 
} from '../services/authService';

const TwoFactorSetupPage: React.FC = () => {
    const [setupInfo, setSetupInfo] = useState<ITwoFactorSetupInfo | null>(null);
    const [verificationCode, setVerificationCode] = useState('');
    const [error, setError] = useState<string | null>(null);
    const [loading, setLoading] = useState(false);
    const [pageLoading, setPageLoading] = useState(true);
    const [copied, setCopied] = useState(false);

    const navigate = useNavigate();

    useEffect(() => {
        const fetchSetupInfo = async () => {
            setError(null);
            setPageLoading(true);
            try {
                const info = await get2FASetupInfo();
                setSetupInfo(info);
            } catch (err: any) {
                setError(err.message || 'Failed to load 2FA setup data.');
            } finally {
                setPageLoading(false);
            }
        };

        fetchSetupInfo();
    }, [navigate]);

    const handleCodeChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const value = e.target.value.replace(/\D/g, '').slice(0, 6);
        setVerificationCode(value);
        setError(null);
    };

    const copyToClipboard = (text: string) => {
        navigator.clipboard.writeText(text);
        setCopied(true);
        setTimeout(() => setCopied(false), 2000);
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setError(null);
        
        if (verificationCode.length !== 6) {
            setError('The code must be 6 digits long.');
            return;
        }

        setLoading(true);

        try {
            const result: IAuthResponse = await verify2FASetup({ totpCode: verificationCode }); 
            localStorage.setItem('authToken', result.accessToken); 
            console.log('2FA Setup successful, full access token stored.');
            navigate('/'); 
        } catch (err: any) {
            setError(err.message || '2FA verification failed due to an unexpected server error.');
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="min-h-screen bg-gradient-to-br from-gray-50 via-white to-yellow-50 flex items-center justify-center p-4">
            <div className="absolute inset-0 overflow-hidden">
                <div className="absolute top-1/4 left-1/4 w-64 h-64 bg-gradient-to-r from-yellow-500/5 to-transparent rounded-full blur-3xl"></div>
                <div className="absolute bottom-1/3 right-1/3 w-96 h-96 bg-gradient-to-l from-yellow-500/3 to-transparent rounded-full blur-3xl"></div>
            </div>

            <div className="relative w-full max-w-2xl">
                <div className="relative bg-white rounded-2xl shadow-2xl overflow-hidden">
                    <div className="absolute top-0 left-0 right-0 h-2 bg-gradient-to-r from-yellow-500 via-yellow-400 to-yellow-500"></div>
                    
                    <div className="p-8 md:p-10">
                        <div className="text-center mb-10">
                            <div className="inline-flex items-center justify-center w-16 h-16 mb-6 bg-gradient-to-br from-yellow-500 to-yellow-600 rounded-2xl shadow-lg">
                                <svg className="w-8 h-8 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                                    <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M12 15v2m-6 4h12a2 2 0 002-2v-6a2 2 0 00-2-2H6a2 2 0 00-2 2v6a2 2 0 002 2zm10-10V7a4 4 0 00-8 0v4h8z" />
                                </svg>
                            </div>
                            <h2 className="text-3xl font-bold text-gray-900 mb-3">Secure Your Account</h2>
                            <p className="text-gray-600 text-lg font-light max-w-2xl mx-auto">
                                Enable Two-Factor Authentication for enhanced security
                            </p>
                        </div>

                        {pageLoading && (
                            <div className="flex flex-col items-center justify-center py-20">
                                <div className="relative mb-6">
                                    <div className="absolute inset-0 bg-gradient-to-r from-yellow-500/10 to-yellow-600/10 blur-xl animate-pulse"></div>
                                    <div className="relative animate-spin rounded-full h-16 w-16 border-4 border-gray-200 border-t-yellow-500"></div>
                                </div>
                                <p className="text-xl text-gray-600 font-light animate-pulse">
                                    Preparing your 2FA setup...
                                </p>
                            </div>
                        )}

                        {error && !pageLoading && (
                            <div className="mb-8 p-5 bg-red-50 border-l-4 border-red-500 rounded-r-lg animate-shake">
                                <div className="flex items-center gap-3">
                                    <svg className="w-5 h-5 text-red-500 flex-shrink-0" fill="currentColor" viewBox="0 0 20 20">
                                        <path fillRule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zM8.707 7.293a1 1 0 00-1.414 1.414L8.586 10l-1.293 1.293a1 1 0 101.414 1.414L10 11.414l1.293 1.293a1 1 0 001.414-1.414L11.414 10l1.293-1.293a1 1 0 00-1.414-1.414L10 8.586 8.707 7.293z" clipRule="evenodd" />
                                    </svg>
                                    <span className="text-red-800 font-medium">{error}</span>
                                </div>
                            </div>
                        )}

                        {!pageLoading && setupInfo && (
                            <div className="space-y-10">
                                <div className="relative overflow-hidden rounded-2xl p-8 bg-gradient-to-br from-gray-50 to-white border border-gray-200/50">
                                    <div className="absolute -top-4 -left-4 w-8 h-8 bg-gradient-to-br from-yellow-500 to-yellow-600 rounded-full flex items-center justify-center text-white text-sm font-bold shadow-lg">
                                        1
                                    </div>
                                    
                                    <div className="text-center mb-8">
                                        <h3 className="text-xl font-bold text-gray-900 mb-3">Scan QR Code</h3>
                                        <p className="text-gray-600 max-w-md mx-auto">
                                            Open your authenticator app (Google Authenticator, Authy, Microsoft Authenticator) and scan this QR code
                                        </p>
                                    </div>

                                    <div className="flex flex-col lg:flex-row items-center justify-center gap-10">
                                        <div className="relative">
                                            <div className="absolute inset-0 bg-gradient-to-r from-yellow-500/10 via-transparent to-yellow-500/10 rounded-2xl blur-xl opacity-0 group-hover:opacity-100 transition-opacity duration-500"></div>
                                            <img 
                                                src={setupInfo.qrCodeImageUrl} 
                                                alt="2FA QR Code" 
                                                className="relative w-56 h-56 rounded-xl border-8 border-white shadow-2xl"
                                            />
                                            <div className="absolute -top-2 -right-2 w-6 h-6 bg-gradient-to-br from-yellow-500 to-yellow-600 rounded-full animate-ping"></div>
                                        </div>

                                        <div className="space-y-6">
                                            <div className="flex items-center gap-4 p-4 bg-white rounded-xl border border-gray-200/50 shadow-sm">
                                                <div className="w-12 h-12 bg-gradient-to-br from-blue-500 to-blue-600 rounded-lg flex items-center justify-center">
                                                    <svg className="w-6 h-6 text-white" fill="currentColor" viewBox="0 0 24 24">
                                                        <path d="M12 0C5.372 0 0 5.372 0 12s5.372 12 12 12 12-5.372 12-12S18.628 0 12 0zm0 2a10 10 0 0110 10c0 5.523-4.477 10-10 10S2 17.523 2 12 6.477 2 12 2zm0 4a6 6 0 00-6 6 6 6 0 006 6 6 6 0 006-6 6 6 0 00-6-6z"/>
                                                    </svg>
                                                </div>
                                                <div>
                                                    <p className="font-semibold text-gray-900">Google Authenticator</p>
                                                    <p className="text-sm text-gray-600">Recommended</p>
                                                </div>
                                            </div>

                                            <div className="flex items-center gap-4 p-4 bg-white rounded-xl border border-gray-200/50 shadow-sm">
                                                <div className="w-12 h-12 bg-gradient-to-br from-green-500 to-green-600 rounded-lg flex items-center justify-center">
                                                    <svg className="w-6 h-6 text-white" fill="currentColor" viewBox="0 0 24 24">
                                                        <path d="M12 0a12 12 0 100 24 12 12 0 000-24zm0 2a10 10 0 0110 10c0 5.523-4.477 10-10 10S2 17.523 2 12 6.477 2 12 2zm0 4a6 6 0 00-6 6 6 6 0 006 6 6 6 0 006-6 6 6 0 00-6-6z"/>
                                                    </svg>
                                                </div>
                                                <div>
                                                    <p className="font-semibold text-gray-900">Authy</p>
                                                    <p className="text-sm text-gray-600">Multi-device sync</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div className="relative overflow-hidden rounded-2xl p-8 bg-gradient-to-br from-gray-50 to-white border border-gray-200/50">
                                    <div className="absolute -top-4 -left-4 w-8 h-8 bg-gradient-to-br from-yellow-500 to-yellow-600 rounded-full flex items-center justify-center text-white text-sm font-bold shadow-lg">
                                        2
                                    </div>
                                    
                                    <div className="text-center mb-6">
                                        <h3 className="text-xl font-bold text-gray-900 mb-3">Manual Setup Key</h3>
                                        <p className="text-gray-600 max-w-md mx-auto">
                                            If you can't scan the QR code, manually enter this secret key into your authenticator app
                                        </p>
                                    </div>

                                    <div className="relative">
                                        <div className="bg-gradient-to-r from-gray-900 to-gray-800 rounded-xl p-6">
                                            <div className="flex items-center justify-between mb-4">
                                                <div className="flex items-center gap-3">
                                                    <div className="w-10 h-10 bg-gradient-to-br from-yellow-500 to-yellow-600 rounded-lg flex items-center justify-center">
                                                        <svg className="w-5 h-5 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                                            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M15 7a2 2 0 012 2m4 0a6 6 0 01-7.743 5.743L11 17H9v2H7v2H4a1 1 0 01-1-1v-2.586a1 1 0 01.293-.707l5.964-5.964A6 6 0 1121 9z" />
                                                        </svg>
                                                    </div>
                                                    <span className="text-white font-semibold">Secret Key</span>
                                                </div>
                                                <button
                                                    onClick={() => copyToClipboard(setupInfo.secretKey)}
                                                    className={`flex items-center gap-2 px-4 py-2 rounded-lg transition-all duration-200 ${
                                                        copied 
                                                            ? 'bg-gradient-to-r from-green-500 to-green-600 text-white' 
                                                            : 'bg-gradient-to-r from-yellow-500 to-yellow-600 text-white hover:from-yellow-600 hover:to-yellow-700'
                                                    }`}
                                                >
                                                    {copied ? (
                                                        <>
                                                            <svg className="w-4 h-4" fill="currentColor" viewBox="0 0 20 20">
                                                                <path fillRule="evenodd" d="M16.707 5.293a1 1 0 010 1.414l-8 8a1 1 0 01-1.414 0l-4-4a1 1 0 011.414-1.414L8 12.586l7.293-7.293a1 1 0 011.414 0z" clipRule="evenodd" />
                                                            </svg>
                                                            Copied!
                                                        </>
                                                    ) : (
                                                        <>
                                                            <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                                                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M8 16H6a2 2 0 01-2-2V6a2 2 0 012-2h8a2 2 0 012 2v2m-6 12h8a2 2 0 002-2v-8a2 2 0 00-2-2h-8a2 2 0 00-2 2v8a2 2 0 002 2z" />
                                                            </svg>
                                                            Copy Key
                                                        </>
                                                    )}
                                                </button>
                                            </div>
                                            <code className="block font-mono text-lg tracking-wider text-yellow-300 break-all text-center select-all py-3 bg-black/30 rounded-lg">
                                                {setupInfo.secretKey}
                                            </code>
                                        </div>
                                    </div>
                                </div>

                                <div className="relative overflow-hidden rounded-2xl p-8 bg-gradient-to-br from-gray-50 to-white border border-gray-200/50">
                                    <div className="absolute -top-4 -left-4 w-8 h-8 bg-gradient-to-br from-yellow-500 to-yellow-600 rounded-full flex items-center justify-center text-white text-sm font-bold shadow-lg">
                                        3
                                    </div>
                                    
                                    <div className="text-center mb-8">
                                        <h3 className="text-xl font-bold text-gray-900 mb-3">Enter Verification Code</h3>
                                        <p className="text-gray-600 max-w-md mx-auto">
                                            Enter the 6-digit code generated by your authenticator app to complete the setup
                                        </p>
                                    </div>

                                    <form onSubmit={handleSubmit} className="space-y-8">
                                        <div className="max-w-md mx-auto">
                                            <div className="relative">
                                                <input
                                                    id="verificationCode"
                                                    name="verificationCode"
                                                    type="text"
                                                    required
                                                    value={verificationCode}
                                                    onChange={handleCodeChange}
                                                    placeholder="000000"
                                                    maxLength={6}
                                                    className="w-full px-8 py-5 border-2 border-gray-200 rounded-xl text-center text-3xl font-mono tracking-[0.8em] focus:outline-none focus:border-yellow-500 focus:ring-2 focus:ring-yellow-500/20 transition-all duration-200"
                                                />
                                                <div className="absolute top-1/2 left-8 transform -translate-y-1/2">
                                                    <svg className="w-6 h-6 text-gray-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M12 15v2m-6 4h12a2 2 0 002-2v-6a2 2 0 00-2-2H6a2 2 0 00-2 2v6a2 2 0 002 2zm10-10V7a4 4 0 00-8 0v4h8z" />
                                                    </svg>
                                                </div>
                                            </div>
                                            <div className="flex justify-between mt-4 px-2">
                                                <span className="text-sm text-gray-500">6-digit verification code</span>
                                                <span className={`text-sm font-medium ${
                                                    verificationCode.length === 6 ? 'text-green-600' : 'text-yellow-600 animate-pulse'
                                                }`}>
                                                    {verificationCode.length}/6 characters
                                                </span>
                                            </div>
                                        </div>

                                        <div className="text-center">
                                            <button
                                                type="submit"
                                                disabled={loading || verificationCode.length !== 6}
                                                className={`relative overflow-hidden group inline-flex items-center gap-3 px-12 py-5 rounded-xl font-bold text-white shadow-xl transition-all duration-300 transform hover:-translate-y-0.5 ${
                                                    loading || verificationCode.length !== 6
                                                        ? 'bg-gradient-to-r from-yellow-400 to-yellow-500 cursor-not-allowed opacity-80' 
                                                        : 'bg-gradient-to-r from-yellow-500 to-yellow-600 hover:from-yellow-600 hover:to-yellow-700 focus:outline-none focus:ring-2 focus:ring-yellow-500 focus:ring-offset-2'
                                                }`}
                                            >
                                                <div className="absolute inset-0 bg-gradient-to-r from-transparent via-white/20 to-transparent translate-x-[-100%] group-hover:translate-x-[100%] transition-transform duration-700"></div>
                                                
                                                {loading ? (
                                                    <>
                                                        <svg className="animate-spin h-5 w-5 text-white" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
                                                            <circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle>
                                                            <path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                                                        </svg>
                                                        Verifying...
                                                    </>
                                                ) : (
                                                    <>
                                                        <span className="text-lg">Complete Setup & Continue</span>
                                                        <svg className="w-5 h-5 transform group-hover:translate-x-1 transition-transform duration-300" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                                            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={3} d="M13 7l5 5m0 0l-5 5m5-5H6" />
                                                        </svg>
                                                    </>
                                                )}
                                            </button>
                                        </div>
                                    </form>
                                </div>

                                <div className="text-center pt-6 border-t border-gray-200">
                                    <p className="text-gray-600 text-sm">
                                        Need help?{' '}
                                        <button className="font-semibold text-yellow-600 hover:text-yellow-700 hover:underline transition-colors duration-200">
                                            View detailed instructions
                                        </button>{' '}
                                        or{' '}
                                        <button className="font-semibold text-yellow-600 hover:text-yellow-700 hover:underline transition-colors duration-200">
                                            Get support
                                        </button>
                                    </p>
                                </div>
                            </div>
                        )}
                    </div>
                </div>
            </div>
        </div>
    );
};

export default TwoFactorSetupPage;