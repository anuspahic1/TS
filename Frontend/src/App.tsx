import "./styles/index.css";
import "./App.css";

import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";

import AuthLayout from "./layouts/AuthLayout";
import AppLayout from "./layouts/AppLayout";

import LoginPage from "./pages/auth/LoginPage";
import SignupPage from "./pages/auth/SignupPage";
import TwoStepVerificationPage from "./pages/auth/TwoStepVerificationPage";
import TwoFactorSetupPage from "./pages/auth/TwoFactorSetupPage";

import Enable2FAPage from "./pages/Enable2FA/Enable2FAPage";

export default function App() {
  return (
    <BrowserRouter>
      <Routes>
        
        <Route element={<AuthLayout />}>
          <Route path="/" element={<Navigate to="/login" replace />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/signup" element={<SignupPage />} />
          <Route path="/two-step-verification" element={<TwoStepVerificationPage />} />
          <Route path="/2fa-setup" element={<TwoFactorSetupPage />} />
        </Route>

        <Route element={<AppLayout />}>
          <Route path="/rewards" element={<div>Rewards Page (TODO)</div>} />
          <Route path="/account/enable-2fa" element={<Enable2FAPage />} />
        </Route>

        <Route
          path="*"
          element={
            <div className="min-h-screen flex items-center justify-center bg-gray-100">
              <h1 className="text-4xl font-bold text-red-600">404 - Page Not Found</h1>
            </div>
          }
        />
      </Routes>
    </BrowserRouter>
  );
}
