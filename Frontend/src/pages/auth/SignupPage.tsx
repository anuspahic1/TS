import { Link } from 'react-router-dom';
import SignupForm from './SignupForm';
import { useSignup } from './useSignup';
import { AuthCard } from '../../components/auth/AuthCard';
import { AuthHeader } from '../../components/auth/AuthHeader';
import { FormError } from '../../components/common/FormError'; 

const SignupPage = () => {
    const signup = useSignup();

    return (
        <AuthCard>
            <AuthHeader 
                title="Create Account" 
                subtitle="Join our community and get started today" 
            />

           
            <FormError message={signup.error} />

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