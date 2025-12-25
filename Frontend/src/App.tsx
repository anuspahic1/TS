import './styles/index.css';
import './App.css';

import { BrowserRouter, Routes, Route } from 'react-router-dom';

import AuthLayout from './layouts/AuthLayout';
import AppLayout from './layouts/AppLayout';

import LoginPage from './pages/auth/LoginPage';
import SignupPage from './pages/auth/SignupPage';
import TwoStepVerificationPage from './pages/auth/TwoStepVerificationPage';
import TwoFactorSetupPage from './pages/auth/TwoFactorSetupPage';
import UserDashboard from './pages/UserDashboard';
import OrganizerDashboard from './pages/OrganizerDashboard';
import ReservationPage from './pages/ReservationPage';
import CheckoutPage from './pages/CheckoutPage';
import RewardsPage from './pages/RewardsPage';

import Enable2FAPage from './pages/Enable2FA/Enable2FAPage';
import ProtectedRoute from './routes/ProtectedRoute';

import HomePage from './pages/HomePage';
import EventDetailsPage from './pages/EventDetailsPage';

import AdminDashboard from './pages/AdminDashboard'; 
import AdminUserManagement from './components/admin/AdminUserManagement';
import AdminEventsPage from './components/admin/AdminEventsPage'; 
import LocationsPage from './components/admin/LocationsPage'; 
import AdminTicketsPage from './components/admin/AdminTicketsPage';

export default function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/locations/:locationId/events/:eventId" element={<EventDetailsPage />} />

        <Route element={<AuthLayout />}>
          <Route path='/login' element={<LoginPage />} />
          <Route path='/signup' element={<SignupPage />} />
          <Route path='/two-step-verification' element={<TwoStepVerificationPage />} />
          <Route path='/2fa-setup' element={<TwoFactorSetupPage />} />
        </Route>

        <Route element={<ProtectedRoute />}>
          <Route element={<AppLayout />}>
            <Route path='/account/enable-2fa' element={<Enable2FAPage />} />
            
            <Route element={<ProtectedRoute allowedRoles={["User"]} />}>
              <Route path="/user-dashboard" element={<UserDashboard />} />
              <Route path="/rewards" element={<RewardsPage />} />
              <Route path="/locations/:locationId/events/:eventId/reservation" element={<ReservationPage />} />
              <Route path="/locations/:locationId/events/:eventId/checkout" element={<CheckoutPage />} />
            </Route>

            <Route element={<ProtectedRoute allowedRoles={["Organizer"]} />}>
              <Route path="/organizer-dashboard" element={<OrganizerDashboard />} />
            </Route>

            <Route element={<ProtectedRoute allowedRoles={["Administrator"]} />}>
              <Route path="/admin-dashboard" element={<AdminDashboard />} />
              <Route path="/admin/users" element={<AdminUserManagement />} />
              
              <Route path="/admin/events" element={<AdminEventsPage />} />
              <Route path="/admin/locations" element={<LocationsPage />} />
              <Route path="/admin/tickets" element={<AdminTicketsPage />} />
            </Route>
          </Route>
        </Route>

        <Route
          path='*'
          element={
            <div className='min-h-screen flex items-center justify-center bg-gray-100'>
              <h1 className='text-4xl font-bold text-red-600'>404 - Page Not Found</h1>
            </div>
          }
        />
      </Routes>
    </BrowserRouter>
  );
}
