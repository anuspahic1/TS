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

  // Inicijalizacija forme praznim stringovima
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    email: '',
    username: ''
  });

  // Funkcija koja puni formu - dodana logika za splitovanje fullName-a ako zatreba
  const syncFormData = () => {
    if (!profile) return;

    let fName = profile.firstName || '';
    let lName = profile.lastName || '';

    // Ako su firstName i lastName prazni, a imamo fullName, pokušaj ih razdvojiti
    if (!fName && !lName && profile.fullName) {
      const parts = profile.fullName.trim().split(' ');
      fName = parts[0] || '';
      lName = parts.slice(1).join(' ') || '';
    }

    setFormData({
      firstName: fName,
      lastName: lName,
      email: profile.email || '',
      username: profile.username || ''
    });
  };

  // 1. Sinhronizacija čim se komponenta učita ili se profile promijeni
  useEffect(() => {
    syncFormData();
  }, [profile]);

  // 2. Kada korisnik klikne Edit, još jednom prisilno sinhronizujemo podatke
  const handleEditClick = () => {
    syncFormData();
    setIsEditing(true);
    setError(null);
  };

  const handleCancel = () => {
    syncFormData(); // Vrati na staro
    setIsEditing(false);
    setError(null);
  };

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
        UserName: formData.email, // Često backend zahtijeva email kao username
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
      setError(err.message || "Neuspješno spremanje podataka.");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="bg-white rounded-2xl shadow-sm border border-neutral-100 overflow-hidden">
      <div className="bg-neutral-900 p-8">
        <div className="flex flex-col md:flex-row md:items-end justify-between gap-6">
          <div>
            <span className="text-[10px] font-black uppercase tracking-[0.3em] text-yellow-500 block mb-2">
              Account Settings
            </span>
            <h2 className="text-4xl font-black italic uppercase tracking-tighter text-white leading-none">
              {profile?.fullName || `${formData.firstName} ${formData.lastName}` || "User Profile"}
            </h2>
          </div>
          
          <button
            onClick={isEditing ? handleCancel : handleEditClick}
            className={`px-8 py-3 font-black uppercase italic tracking-widest text-[11px] transition-all rounded-full border-2 ${
              isEditing 
                ? 'border-neutral-700 text-neutral-500 hover:bg-neutral-800' 
                : 'border-yellow-500 text-yellow-500 hover:bg-yellow-500 hover:text-neutral-900'
            }`}
          >
            {isEditing ? 'Cancel Edit' : 'Edit Profile'}
          </button>
        </div>
      </div>

      <div className="p-8">
        {error && (
          <div className="mb-8 p-4 bg-red-50 border-l-4 border-red-600 text-red-700 font-bold text-xs uppercase italic tracking-tight">
            {error}
          </div>
        )}

        {isEditing ? (
          <form onSubmit={handleSubmit} className="space-y-8 max-w-3xl">
            <div className="grid grid-cols-1 md:grid-cols-2 gap-8">
              <div className="space-y-2">
                <label className="text-[10px] font-black uppercase text-neutral-400 tracking-[0.2em] ml-1">First Name</label>
                <input
                  type="text"
                  name="firstName"
                  value={formData.firstName}
                  onChange={handleInputChange}
                  required
                  placeholder="Unesite ime"
                  className="w-full px-5 py-4 bg-neutral-50 border-2 border-neutral-100 rounded-xl focus:border-yellow-500 focus:bg-white outline-none transition-all font-bold text-neutral-900"
                />
              </div>
              <div className="space-y-2">
                <label className="text-[10px] font-black uppercase text-neutral-400 tracking-[0.2em] ml-1">Last Name</label>
                <input
                  type="text"
                  name="lastName"
                  value={formData.lastName}
                  onChange={handleInputChange}
                  required
                  placeholder="Unesite prezime"
                  className="w-full px-5 py-4 bg-neutral-50 border-2 border-neutral-100 rounded-xl focus:border-yellow-500 focus:bg-white outline-none transition-all font-bold text-neutral-900"
                />
              </div>
              <div className="space-y-2 md:col-span-2">
                <label className="text-[10px] font-black uppercase text-neutral-400 tracking-[0.2em] ml-1">Email (Locked)</label>
                <input
                  type="email"
                  name="email"
                  value={formData.email}
                  readOnly
                  className="w-full px-5 py-4 bg-neutral-100 border-2 border-neutral-100 rounded-xl text-neutral-400 cursor-not-allowed font-bold"
                />
              </div>
            </div>
            
            <div className="pt-6 border-t border-neutral-100">
              <button
                type="submit"
                disabled={loading}
                className={`px-12 py-4 rounded-xl font-black uppercase italic tracking-[0.2em] text-xs transition-all ${
                  loading 
                    ? 'bg-neutral-200 text-neutral-400' 
                    : 'bg-yellow-500 text-neutral-900 hover:bg-neutral-400 active:scale-95'
                }`}
              >
                {loading ? 'Processing...' : 'Save Changes'}
              </button>
            </div>
          </form>
        ) : (
          <div className="grid grid-cols-1 md:grid-cols-2 gap-8">
            <div className="pb-4 border-b-2 border-neutral-50 group transition-all">
              <p className="text-[9px] font-black uppercase text-neutral-400 tracking-[0.3em] mb-1">Full Name</p>
              <p className="text-2xl font-black italic text-neutral-900 uppercase tracking-tighter">
                {profile?.fullName || `${profile?.firstName} ${profile?.lastName}`}
              </p>
            </div>

            <div className="pb-4 border-b-2 border-neutral-50 group transition-all">
              <p className="text-[9px] font-black uppercase text-neutral-400 tracking-[0.3em] mb-1">Email Address</p>
              <p className="text-2xl font-black italic text-neutral-900 uppercase tracking-tighter">
                {profile?.email}
              </p>
            </div>

            <div className="md:col-span-2 pt-4">
              <p className="text-[9px] font-black uppercase text-neutral-400 tracking-[0.3em] mb-1">Internal Username</p>
              <p className="text-sm font-bold text-neutral-600">
                @{profile?.username || profile?.email?.split('@')[0]}
              </p>
            </div>
          </div>
        )}
      </div>
    </div>
  );
};

export default UserProfile;