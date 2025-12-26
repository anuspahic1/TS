import { Link } from 'react-router-dom';
import LoginForm from './LoginForm';
import { useLogin } from './useLogin';
import { AuthCard } from '../../components/auth/AuthCard';
import { AuthHeader } from '../../components/auth/AuthHeader';
import { FormError } from '../../components/common/FormError'; 

const LoginPage = () => {
  const login = useLogin();

  return (
    <AuthCard>
      <AuthHeader 
        title="Welcome Back" 
        subtitle="Sign in to your account" 
      />

      <FormError message={login.error} />
      
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