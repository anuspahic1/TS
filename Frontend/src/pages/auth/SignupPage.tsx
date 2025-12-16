import { Link } from 'react-router-dom';
import SignupForm from './SignupForm';
import { useSignup } from './useSignup';

const SignupPage = () => {
  const signup = useSignup();

  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-50 p-4">
      <div className="w-full max-w-md bg-white rounded-xl shadow p-8">
        <h2 className="text-3xl font-bold text-center mb-2">
          Create Account
        </h2>
        <p className="text-gray-600 text-center mb-8">
          Join us and get started
        </p>

        <SignupForm
          formData={signup.formData}
          loading={signup.loading}
          error={signup.error}
          onChange={signup.handleChange}
          onSubmit={signup.submit}
        />

        <p className="text-center text-sm text-gray-600 mt-6">
          Already have an account?
          <Link to="/login" className="ml-2 text-yellow-600 font-semibold">
            Log in
          </Link>
        </p>
      </div>
    </div>
  );
};

export default SignupPage;
