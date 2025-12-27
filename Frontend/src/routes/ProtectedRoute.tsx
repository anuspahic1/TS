import { Navigate, Outlet } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';

interface ProtectedRouteProps {
  allowedRoles?: string[]; 
}

export default function ProtectedRoute({ allowedRoles }: ProtectedRouteProps) {
  const { token, user } = useAuth();

  if (!token) {
    return <Navigate to='/login' replace />;
  }

  if (allowedRoles && user === null) {
    return <div>Loading access...</div>; 
  }

  if (allowedRoles && user) {
    const hasAccess = user.roles.some((role: string) => allowedRoles.includes(role));
    
    if (!hasAccess) {
      const defaultPath = user.roles.includes("Organizer") ? "/organizer-dashboard" : "/user-dashboard";
      return <Navigate to={defaultPath} replace />;
    }
  }

  return <Outlet />;
}
