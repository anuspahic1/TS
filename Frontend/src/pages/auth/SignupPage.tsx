import { Link } from 'react-router-dom';
import SignupForm from './SignupForm';
import { useSignup } from './useSignup';
import { AuthCard } from '../../components/auth/AuthCard';
import { AuthHeader } from '../../components/auth/AuthHeader';

const SignupPage = () => {
    const signup = useSignup();

    return (
        <AuthCard>
            <AuthHeader 
                title="Create Account" 
                subtitle="Join our community and get started today" 
            />

            {signup.error && (
                <div className="mb-6 p-4 bg-red-50 border-l-4 border-red-500 text-red-800 text-sm font-medium rounded-r-lg">
                    {signup.error}
                </div>
            )}

            <SignupForm
                formData={signup.formData}
                loading={signup.loading}
                onChange={signup.handleChange}
                onSubmit={signup.submit}
            />

            <div className="mt-8 pt-6 border-t border-gray-200 text-center text-sm">
                <span className="text-gray-600">Already have an account?</span>
                <Link to="/login" className="ml-2 font-semibold text-yellow-600 hover:text-yellow-700 hover:underline">
                    Log in here
                </Link>
            </div>
        </AuthCard>
    );
};

export default SignupPage;