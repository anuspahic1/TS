import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { authService } from '../../services/auth.service';


type SignupFormState = {
  fullName: string;
  email: string;
  password: string;
  confirmPassword: string;
};

export const useSignup = () => {
  const [formData, setFormData] = useState<SignupFormState>({
    fullName: '',
    email: '',
    password: '',
    confirmPassword: '',
  });

  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);

  const navigate = useNavigate();

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData(prev => ({
      ...prev,
      [e.target.name]: e.target.value,
    }));
    setError(null);
  };

const submit = async () => {
    setError(null);

    if (!formData.fullName || !formData.email || !formData.password) {
      setError('All fields are required.');
      return;
    }

    const trimmedName = formData.fullName.trim();
    const nameParts = trimmedName.split(/\s+/); 

    if (nameParts.length < 2) {
      setError('Please enter both your first and last name (e.g., John Doe).');
      return;
    }

    if (formData.password !== formData.confirmPassword) {
      setError('Passwords do not match.');
      return;
    }

    if (formData.password.length < 10) {
      setError('Password must be at least 10 characters long.');
      return;
    }

    setLoading(true);

    const firstName = nameParts[0];
    const lastName = nameParts.slice(1).join(' ');

    const payload = {
      userName: formData.email, 
      email: formData.email,
      password: formData.password,
      firstName: firstName,
      lastName: lastName,
    };

    try {
      await authService.signup(payload);
      navigate('/login');
    } catch (err: any) {
      setError(err.message || 'Signup failed.');
    } finally {
      setLoading(false);
    }
  };

  return {
    formData,
    loading,
    error,
    handleChange,
    submit,
  };
};