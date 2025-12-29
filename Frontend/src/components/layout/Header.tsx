import { Link, useLocation } from 'react-router-dom';
import AuthActions from '../navigation/AuthActions';
import { useAuth } from '../../context/AuthContext';

const Header = () => {
  const { token, logout, user } = useAuth();
  const location = useLocation();

  const dashboardLink = user?.roles?.includes('Administrator')
    ? '/admin-dashboard'
    : user?.roles?.includes('Organizer')
    ? '/organizer-dashboard'
    : '/user-dashboard';

  const roleLabel = user?.roles?.includes('Administrator')
    ? 'System Admin'
    : user?.roles?.includes('Organizer')
    ? 'Organizer'
    : 'Welcome back';

  const displayName = user?.email ? user.email.split('@')[0] : 'User'; // to do

  return (
    <header className='bg-white border-b border-neutral-100 sticky top-0 z-50 backdrop-blur-md bg-white/90'>
      <div className='container mx-auto max-w-7xl px-6 py-4 flex justify-between items-center'>
        
        <div className="flex items-center gap-8">
          <Link to="/" className="group transition-all">
            <span className="text-2xl font-black tracking-tighter uppercase italic text-neutral-900">
              Entrio<span className="text-yellow-500 font-light group-hover:text-yellow-600 transition-colors">X</span>
            </span>
          </Link>

          {token && (
            <div className="hidden lg:block border-l border-neutral-200 pl-8">
              <p className="text-[10px] text-neutral-400 uppercase font-black tracking-[0.2em] leading-none mb-1">
                {roleLabel}
              </p>
              <p className="text-sm font-black text-neutral-800 tracking-tight leading-none">
                {displayName}
              </p>
            </div>
          )}
        </div>
        
        <nav className='hidden md:flex items-center space-x-8'>
          <Link 
            to="/" 
            className={`text-xs font-bold uppercase tracking-[0.15em] transition-all hover:scale-105 ${
              location.pathname === '/' ? 'text-yellow-600 border-b-2 border-yellow-500' : 'text-neutral-500 hover:text-black'
            }`}
          >
            Events
          </Link>

          {token && (
            <>
              <Link 
                to={dashboardLink} 
                className={`text-xs font-bold uppercase tracking-[0.15em] transition-all hover:scale-105 ${
                  location.pathname.includes('dashboard') ? 'text-yellow-600 border-b-2 border-yellow-500' : 'text-neutral-500 hover:text-black'
                }`}
              >
                Dashboard
              </Link>
              
              {user?.roles?.includes('User') && !user?.roles?.includes('Administrator') && !user?.roles?.includes('Organizer') && (
                <Link 
                  to='/rewards' 
                  className={`text-xs font-bold uppercase tracking-[0.15em] transition-all hover:scale-105 ${
                    location.pathname === '/rewards' ? 'text-yellow-600 border-b-2 border-yellow-500' : 'text-neutral-500 hover:text-black'
                  }`}
                >
                  Rewards
                </Link>
              )}
            </>
          )}
        </nav>
        
        <div className="flex items-center gap-4">
          <AuthActions isAuthenticated={!!token} onLogout={logout} />
        </div>
      </div>
    </header>
  );
};

export default Header;