import { Link } from 'react-router-dom';

type Props = {
  isAuthenticated: boolean;
  userName?: string;
  onLogout?: () => void;
};

const AuthActions = ({ isAuthenticated, userName, onLogout }: Props) => {
  if (isAuthenticated) {
    return (
      <div className="flex items-center gap-4">
        <span className="text-gray-600">Welcome, {userName ?? 'User'}</span>
        <button
          onClick={onLogout}
          className="px-3 py-2 border rounded-lg hover:bg-gray-100"
        >
          Logout
        </button>
      </div>
    );
  }

  return (
    <div className="flex items-center gap-4">
      <Link to="/signup" className="text-gray-600 hover:text-gray-800">
        Sign Up
      </Link>
      <Link
        to="/login"
        className="px-4 py-2 bg-yellow-600 text-white rounded-lg hover:bg-yellow-700"
      >
        Log In
      </Link>
    </div>
  );
};

export default AuthActions;
