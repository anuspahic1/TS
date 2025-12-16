import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const TwoStepVerificationPage: React.FC = () => {
    const [verificationCode, setVerificationCode] = useState('');
    const [error, setError] = useState('');
    const [loading, setLoading] = useState(false);
    const navigate = useNavigate();

    const handleVerification = async (e: React.FormEvent) => {
        e.preventDefault();
        setError('');
        setLoading(true);
        
        await new Promise(resolve => setTimeout(resolve, 800));
        
        if (verificationCode === '123456') { 
            console.log("2FA successful, logging in user.");
            navigate('/'); 
        } else {
            setError('Invalid verification code. Please check your authenticator app and try again.');
        }
        setLoading(false);
    };

    const handleCodeChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const value = e.target.value.replace(/\D/g, '').slice(0, 6);
        setVerificationCode(value);
        setError('');
    };

    return (
        <div className="min-h-screen bg-gradient-to-br from-gray-50 via-white to-yellow-50 flex items-center justify-center p-4">
            <div className="absolute inset-0 overflow-hidden">
                <div className="absolute top-1/4 left-1/4 w-64 h-64 bg-gradient-to-r from-yellow-500/5 to-transparent rounded-full blur-3xl"></div>
                <div className="absolute bottom-1/4 right-1/4 w-96 h-96 bg-gradient-to-l from-yellow-500/3 to-transparent rounded-full blur-3xl"></div>
            </div>

            <div className="relative w-full max-w-md">
                <div className="relative bg-white rounded-2xl shadow-2xl overflow-hidden p-8 md:p-10">
                    <div className="absolute top-0 left-0 right-0 h-1 bg-gradient-to-r from-yellow-500 via-yellow-400 to-yellow-500"></div>
                    
                    <div className="mb-8 text-center">
                        <div className="inline-flex items-center justify-center w-16 h-16 mb-6 bg-gradient-to-br from-yellow-500 to-yellow-600 rounded-2xl shadow-lg">
                            <svg className="w-8 h-8 text-white" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M12 15v2m-6 4h12a2 2 0 002-2v-6a2 2 0 00-2-2H6a2 2 0 00-2 2v6a2 2 0 002 2zm10-10V7a4 4 0 00-8 0v4h8z" />
                            </svg>
                        </div>
                        
                        <h1 className="text-3xl font-bold text-gray-900 mb-3">Two-Step Verification</h1>
                        <p className="text-gray-600 text-lg font-light leading-relaxed">
                            Enter the 6-digit code from your authenticator app
                        </p>
                    </div>

                    <div className="mb-8 p-4 bg-gradient-to-r from-yellow-50 to-yellow-100/50 rounded-xl border border-yellow-200/50">
                        <div className="flex items-center gap-3">
                            <div className="w-10 h-10 bg-white rounded-lg shadow-sm flex items-center justify-center">
                                <svg className="w-6 h-6 text-yellow-600" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                    <path fillRule="evenodd" d="M11.3 1.046A1 1 0 0112 2v5h4a1 1 0 01.82 1.573l-7 10A1 1 0 018 18v-5H4a1 1 0 01-.82-1.573l7-10a1 1 0 011.12-.38z" clipRule="evenodd" />
                                </svg>
                            </div>
                            <div>
                                <p className="text-sm font-semibold text-gray-800">Google Authenticator / Authy / Microsoft Authenticator</p>
                                <p className="text-xs text-gray-600">Code refreshes every 30 seconds</p>
                            </div>
                        </div>
                    </div>

                    <form onSubmit={handleVerification} className="space-y-6">
                        <div>
                            <label htmlFor="code" className="block text-sm font-semibold text-gray-800 mb-2">
                                Verification Code
                            </label>
                            <div className="relative">
                                <input 
                                    id="code"
                                    type="text"
                                    value={verificationCode}
                                    onChange={handleCodeChange}
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
                            <div className="flex justify-between mt-2">
                                <span className="text-xs text-gray-500">6-digit code</span>
                                <span className="text-xs font-medium text-yellow-600 animate-pulse">
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

                        <div className="text-center">
                            <div className="inline-flex items-center gap-2 px-4 py-2 bg-gray-100 rounded-full">
                                <svg className="w-4 h-4 text-gray-600" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                    <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M12 8v4l3 3m6-3a9 9 0 11-18 0 9 9 0 0118 0z" />
                                </svg>
                                <span className="text-sm font-medium text-gray-700">
                                    Code expires in: <span className="font-mono text-yellow-600">00:30</span>
                                </span>
                            </div>
                        </div>

                        <div className="space-y-4">
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
                                    'Verify and Continue'
                                )}
                            </button>

                            <div className="flex gap-4">
                                <button 
                                    type="button"
                                    onClick={() => navigate('/login')} 
                                    className="flex-1 py-3 px-4 bg-gray-100 text-gray-700 font-semibold rounded-xl hover:bg-gray-200 transition-all duration-300 transform hover:-translate-y-0.5"
                                >
                                    <div className="flex items-center justify-center gap-2">
                                        <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M10 19l-7-7m0 0l7-7m-7 7h18" />
                                        </svg>
                                        Back to Login
                                    </div>
                                </button>
                                
                                <button 
                                    type="button"
                                    onClick={() => setVerificationCode('')}
                                    className="flex-1 py-3 px-4 bg-gradient-to-r from-gray-200 to-gray-300 text-gray-700 font-semibold rounded-xl hover:from-gray-300 hover:to-gray-400 transition-all duration-300 transform hover:-translate-y-0.5"
                                >
                                    <div className="flex items-center justify-center gap-2">
                                        <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M4 4v5h.582m15.356 2A8.001 8.001 0 004.582 9m0 0H9m11 11v-5h-.581m0 0a8.003 8.003 0 01-15.357-2m15.357 2H15" />
                                        </svg>
                                        Clear Code
                                    </div>
                                </button>
                            </div>
                        </div>
                    </form>

                    <div className="mt-8 pt-6 border-t border-gray-200">
                        <p className="text-center text-sm text-gray-600">
                            Having trouble?{' '}
                            <button className="font-semibold text-yellow-600 hover:text-yellow-700 hover:underline transition-colors duration-200">
                                Resend code
                            </button>{' '}
                            or{' '}
                            <button className="font-semibold text-yellow-600 hover:text-yellow-700 hover:underline transition-colors duration-200">
                                Use backup codes
                            </button>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default TwoStepVerificationPage;