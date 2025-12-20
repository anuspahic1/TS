import { Link } from 'react-router-dom';
import AuthActions from '../navigation/AuthActions';
import { useAuth } from '../../context/AuthContext';

const Header = () => {
  const { token, logout } = useAuth();

  return (
    <header className='bg-white shadow-md'>
      <div className='container mx-auto px-4 py-4 flex justify-between items-center'>
        <Link to='/' className='text-2xl font-bold text-gray-800'>
          EntrioX
        </Link>
        <nav className='hidden md:flex space-x-6'>
          <Link to='/2fa-setup' className='text-gray-600 hover:text-gray-900'>
            Home
          </Link>
          <Link to='/rewards' className='text-gray-600 hover:text-gray-900'>
            Rewards
          </Link>
        </nav>
        <AuthActions isAuthenticated={!!token} onLogout={logout} />{' '}
      </div>
    </header>
  );
};

export default Header;
