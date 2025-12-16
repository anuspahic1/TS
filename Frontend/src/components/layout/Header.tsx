import { Link } from 'react-router-dom';
import AuthActions from '../navigation/AuthActions';

type HeaderProps = {
  isAuthenticated: boolean;
  userName?: string;
  onLogout?: () => void;
};

const Header = ({ isAuthenticated, userName, onLogout }: HeaderProps) => {
  return (
    <header className="bg-white shadow-md">
      <div className="container mx-auto px-4 py-4 flex justify-between items-center">
        <Link to="/" className="text-2xl font-bold text-gray-800">
          EntrioX
        </Link>

        <nav className="hidden md:flex space-x-6">
          <Link to="/" className="text-gray-600 hover:text-gray-900">
            Home
          </Link>
          <Link to="/rewards" className="text-gray-600 hover:text-gray-900">
            Rewards
          </Link>
        </nav>

        <AuthActions
          isAuthenticated={isAuthenticated}
          userName={userName}
          onLogout={onLogout}
        />
      </div>
    </header>
  );
};

export default Header;
