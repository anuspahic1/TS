import React, { useState, useEffect } from 'react';
import type { IAppUser } from '../../services/userDashboardService';
import { updateUserProfile } from '../../services/userDashboardService';

interface UserProfileProps {
  profile: IAppUser;
  onUpdateProfile: (updatedProfile: IAppUser) => void;
}

const UserProfile: React.FC<UserProfileProps> = ({ profile, onUpdateProfile }) => {
  const [isEditing, setIsEditing] = useState(false);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const [formData, setFormData] = useState({
    firstName: profile?.firstName || '',
    lastName: profile?.lastName || '',
    email: profile?.email || '',
    username: profile?.username || ''
  });

  useEffect(() => {
    if (profile) {
      setFormData({
        firstName: profile.firstName || '',
        lastName: profile.lastName || '',
        email: profile.email || '',
        username: profile.username || ''
      });
    }
  }, [profile]);

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData(prev => ({ ...prev, [name]: value }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);
    setError(null);

    try {
      const dataToSave = {
        FirstName: formData.firstName,
        LastName: formData.lastName,
        FullName: `${formData.firstName} ${formData.lastName}`.trim(),
        UserName: formData.email,
        Email: formData.email
      };

      await updateUserProfile(profile.id, dataToSave);

      onUpdateProfile({
        ...profile,
        firstName: formData.firstName,
        lastName: formData.lastName,
        fullName: `${formData.firstName} ${formData.lastName}`.trim()
      });

      setIsEditing(false);
    } catch (err: any) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="bg-white rounded-2xl shadow-lg overflow-hidden border border-gray-100">
      <div className="bg-gradient-to-r from-yellow-500 to-yellow-600 p-6 text-white">
        <div className="flex items-center justify-between">
          <div>
            <h2 className="text-2xl font-bold">
              {profile?.fullName || profile?.email || "User Profile"}
            </h2>
            <p className="text-yellow-100">Manage your personal information</p>
          </div>
          <button
            onClick={() => {
              setIsEditing(!isEditing);
              setError(null);
            }}
            className="px-5 py-2.5 bg-white text-yellow-600 font-semibold rounded-xl hover:bg-yellow-50 transition-colors shadow-sm"
          >
            {isEditing ? 'Cancel' : 'Edit Profile'}
          </button>
        </div>
      </div>

      <div className="p-8">
        {error && (
          <div className="mb-6 p-4 bg-red-50 border-l-4 border-red-500 text-red-700 rounded-md">
            {error}
          </div>
        )}

        {isEditing ? (
          <form onSubmit={handleSubmit} className="max-w-2xl space-y-6">
            <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
              <div className="space-y-2">
                <label className="block text-sm font-semibold text-gray-700">First Name</label>
                <input
                  type="text"
                  name="firstName"
                  value={formData.firstName}
                  onChange={handleInputChange}
                  required
                  className="w-full px-4 py-3 border border-gray-300 rounded-xl focus:ring-2 focus:ring-yellow-500 outline-none transition-all"
                />
              </div>
              <div className="space-y-2">
                <label className="block text-sm font-semibold text-gray-700">Last Name</label>
                <input
                  type="text"
                  name="lastName"
                  value={formData.lastName}
                  onChange={handleInputChange}
                  required
                  className="w-full px-4 py-3 border border-gray-300 rounded-xl focus:ring-2 focus:ring-yellow-500 outline-none transition-all"
                />
              </div>
              <div className="space-y-2 md:col-span-2">
                <label className="block text-sm font-semibold text-gray-700">Email Address</label>
                <input
                  type="email"
                  name="email"
                  value={formData.email}
                  readOnly
                  className="w-full px-4 py-3 border border-gray-300 rounded-xl bg-gray-50 text-gray-500 cursor-not-allowed outline-none"
                />
              </div>
            </div>
            <div className="flex gap-4 pt-4 border-t border-gray-100">
              <button
                type="submit"
                disabled={loading}
                className={`px-8 py-3 rounded-xl font-bold text-white shadow-md transition-all ${
                  loading ? 'bg-gray-400 cursor-not-allowed' : 'bg-yellow-500 hover:bg-yellow-600 active:transform active:scale-95'
                }`}
              >
                {loading ? 'Saving Changes...' : 'Save Changes'}
              </button>
            </div>
          </form>
        ) : (
          <div className="space-y-8">
            <section>
              <h3 className="text-lg font-bold text-gray-900 mb-6 flex items-center gap-2">
                <svg className="w-5 h-5 text-yellow-500" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z" />
                </svg>
                Personal Details
              </h3>
              
              <div className="grid grid-cols-1 md:grid-cols-2 gap-6 mb-8">
                <div className="bg-gray-50 p-4 rounded-xl border border-gray-100">
                  <p className="text-xs font-bold text-gray-400 uppercase tracking-wider">Full Name</p>
                  <p className="text-gray-900 font-semibold mt-1">
                    {profile?.fullName || (profile?.firstName ? `${profile.firstName} ${profile.lastName}` : "Not provided")}
                  </p>
                </div>
                <div className="bg-gray-50 p-4 rounded-xl border border-gray-100">
                  <p className="text-xs font-bold text-gray-400 uppercase tracking-wider">Email Address</p>
                  <p className="text-gray-900 font-semibold mt-1">{profile?.email}</p>
                </div>
              </div>

              
            </section>
          </div>
        )}
      </div>
    </div>
  );
};

export default UserProfile;