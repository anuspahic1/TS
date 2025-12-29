import { Link } from 'react-router-dom';

type Props = {
  isAuthenticated: boolean;
  onLogout?: () => void;
};

const AuthActions = ({ isAuthenticated, onLogout }: Props) => {
  if (isAuthenticated) {
    return (
      <button
        onClick={onLogout}
        className="px-5 py-2 text-xs font-black uppercase tracking-widest border-2 border-neutral-900 rounded-full hover:bg-neutral-900 hover:text-white transition-all active:scale-95"
      >
        Logout
      </button>
    );
  }

  return (
    <div className="flex items-center gap-6">
      <Link 
        to="/signup" 
        className="text-xs font-black uppercase tracking-widest text-neutral-500 hover:text-black transition-colors"
      >
        Sign Up
      </Link>
      <Link
        to="/login"
        className="px-6 py-2.5 bg-yellow-500 text-black text-xs font-black uppercase tracking-widest rounded-full hover:bg-yellow-400 shadow-lg shadow-yellow-500/20 transition-all active:scale-95"
      >
        Log In
      </Link>
    </div>
  );
};

export default AuthActions;