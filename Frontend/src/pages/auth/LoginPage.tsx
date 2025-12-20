import { Link } from 'react-router-dom';
import LoginForm from './LoginForm';
import { useLogin } from './useLogin';
import { AuthCard } from '../../components/auth/AuthCard';
import { AuthHeader } from '../../components/auth/AuthHeader';

const LoginPage = () => {
  const login = useLogin();

  return (
    <AuthCard>
      <AuthHeader 
        title="Welcome Back" 
        subtitle="Sign in to your account" 
      />

      {login.error && (
        <div className="mb-4 p-3 bg-red-50 text-red-700 border-l-4 border-red-500 text-sm">
          {login.error}
        </div>
      )}

      <LoginForm
        formData={login.formData}
        loading={login.loading}
        onChange={login.handleChange}
        onSubmit={login.submit} 
      />

      <p className="text-center text-sm text-gray-600 mt-6">
        Don't have an account?
        <Link to="/signup" className="ml-2 text-yellow-600 font-semibold hover:underline">
          Sign up
        </Link>
      </p>
    </AuthCard>
  );
};

export default LoginPage;