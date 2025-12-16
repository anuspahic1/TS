import '././index.css'
import './App.css'
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import LoginPage from './pages/LoginPage';
import SignupPage from './pages/SignupPage';
import Enable2FAPage from './pages/Enable2FAPage';
import TwoStepVerificationPage from './pages/TwoStepVerificationPage'; 
import TwoFactorSetupPage from './pages/TwoFactorSetupPage'; 

export default function App() {
 return (
    <BrowserRouter>
      <Routes>
        
        
        
        <Route path="/login" element={<LoginPage />} />
        
        <Route path="/signup" element={<SignupPage />} />
        
        <Route path="/rewards" element={<div>Rewards Page (TODO)</div>} />

        <Route path="/account/enable-2fa" element={<Enable2FAPage />} />
        
        <Route path="/two-step-verification" element={<TwoStepVerificationPage />} />
        
        <Route path="/2fa-setup" element={<TwoFactorSetupPage />} />
        
        <Route path="*" element={
          <div className="min-h-screen flex items-center justify-center bg-gray-100">
            <h1 className="text-4xl font-bold text-red-600">404 - Page Not Found</h1>
          </div>
        } />
      </Routes>
    </BrowserRouter>
  );
}


