import { Link } from 'react-router-dom';
import LoginForm from './LoginForm';
import { useLogin } from './useLogin';

const LoginPage = () => {
  const login = useLogin();

  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-50 p-4">
      <div className="w-full max-w-md bg-white rounded-xl shadow p-8">
        <h2 className="text-3xl font-bold text-center mb-2">
          Welcome Back
        </h2>
        <p className="text-gray-600 text-center mb-8">
          Sign in to your account
        </p>

        <LoginForm
          formData={login.formData}
          loading={login.loading}
          error={login.error}
          onChange={login.handleChange}
          onSubmit={login.submit}
        />

        <p className="text-center text-sm text-gray-600 mt-6">
          Don't have an account?
          <Link to="/signup" className="ml-2 text-yellow-600 font-semibold">
            Sign up
          </Link>
        </p>
      </div>
    </div>
  );
};

export default LoginPage;
