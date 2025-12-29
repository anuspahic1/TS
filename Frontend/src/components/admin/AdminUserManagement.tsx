"use client"


import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { apiClient } from '../../services/apiClient';
import Swal from 'sweetalert2';

interface User {
  id: string;
  fullName: string;
  email: string;
  roles: string[] | null;
  twoFactorEnabled: boolean;
}

export default function AdminUserManagement() {
  const [users, setUsers] = useState<User[]>([]);
  const [searchTerm, setSearchTerm] = useState('');
  const [loading, setLoading] = useState(true);
  const navigate = useNavigate();

  useEffect(() => {
    fetchUsers();
  }, []);

  const fetchUsers = async () => {
    try {
      setLoading(true);
      const data = await apiClient.get<User[]>('/users');
      setUsers(data);
    } catch (error) {
      console.error("Error:", error);
    } finally {
      setLoading(false);
    }
  };

  const handleUpdateRole = async (user: User) => {
    const { value: role } = await Swal.fire({
      title: 'Update User Role',
      input: 'select',
      inputOptions: {
        'User': 'User',
        'Organizer': 'Organizer',
        'Administrator': 'Administrator'
      },
      inputPlaceholder: 'Select a role',
      showCancelButton: true,
      confirmButtonColor: '#EAB308',
      inputValue: user.roles && user.roles.length > 0 ? user.roles[0] : 'User'
    });

    if (role) {
      try {
        await apiClient.post(`/users/${user.id}/roles`, role);
        Swal.fire('Updated!', `User role changed to ${role}`, 'success');
        fetchUsers();
      } catch (error) {
        Swal.fire('Error', 'Could not update role', 'error');
      }
    }
  };

 const handleEditUser = async (user: User) => {
  const { value: formValues } = await Swal.fire({
    title: 'Edit User Profile',
    html:
      `<div class="text-left">
        <label class="block text-xs font-black uppercase tracking-widest text-gray-400 mb-2">Full Name</label>
        <input id="swal-input1" class="swal2-input w-full m-0" placeholder="Full Name" value="${user.fullName}">
        
        <label class="block text-xs font-black uppercase tracking-widest text-gray-400 mt-4 mb-2">Email (Disabled)</label>
        <input id="swal-input2" class="swal2-input w-full m-0 bg-gray-50" value="${user.email}" disabled>
      </div>`,
    focusConfirm: false,
    showCancelButton: true,
    confirmButtonColor: '#EAB308',
    preConfirm: () => {
      const fullName = (document.getElementById('swal-input1') as HTMLInputElement).value;
      
      return {
        fullName: fullName,
        email: user.email,
        userName: user.email, 
        firstName: fullName.split(' ')[0] || "", 
        lastName: fullName.split(' ').slice(1).join(' ') || "" 
      }
    }
  });

  if (formValues) {
    try {
      await apiClient.put(`/users/${user.id}`, formValues);
      Swal.fire('Saved!', 'User information updated.', 'success');
      fetchUsers();
    } catch (error: any) {
      Swal.fire('Error', error.response?.data || 'Failed to update user', 'error');
    }
  }
};

  const handleDelete = async (id: string) => {
    const result = await Swal.fire({
      title: 'Are you sure?',
      text: "This user will be permanently removed from the system.",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#EF4444',
      cancelButtonColor: '#6B7280',
      confirmButtonText: 'Yes, delete user'
    });

    if (result.isConfirmed) {
      try {
        await apiClient.delete(`/users/${id}`);
        setUsers(users.filter(u => u.id !== id));
        Swal.fire('Deleted!', 'User has been removed.', 'success');
      } catch (error) {
        Swal.fire('Error!', 'Failed to delete user.', 'error');
      }
    }
  };

  const filteredUsers = users.filter(user => {
    const name = user.fullName || "";
    const email = user.email || "";
    const search = searchTerm.toLowerCase();
    return name.toLowerCase().includes(search) || email.toLowerCase().includes(search);
  });

  if (loading) return (
    <div className="flex flex-col items-center justify-center min-h-screen bg-gray-50">
      <div className="w-12 h-12 border-4 border-yellow-500 border-t-transparent rounded-full animate-spin mb-4"></div>
      <p className="text-gray-600 font-medium font-sans">Loading users...</p>
    </div>
  );

  return (
    <div className="min-h-screen bg-gray-50 font-sans p-4 lg:p-12">
      <div className="max-w-7xl mx-auto space-y-10">
        
        <header className="flex flex-col md:flex-row md:items-center justify-between gap-6">
          <div>
            <button 
              onClick={() => navigate('/admin-dashboard')}
              className="mb-4 flex items-center gap-2 text-neutral-400 hover:text-black transition-colors text-[10px] font-black uppercase tracking-[0.2em]"
            >
              ← Back to Overview
            </button>
            <h1 className="text-4xl font-black text-gray-900 tracking-tight uppercase">
              User <span className="text-yellow-500">Management</span>
            </h1>
          </div>

          <div className="relative group">
            <span className="absolute left-4 top-1/2 -translate-y-1/2 text-gray-400">🔍</span>
            <input
              type="text"
              placeholder="Search users..."
              className="pl-12 pr-6 py-4 bg-white border border-gray-100 rounded-2xl shadow-xl outline-none w-full md:w-80 focus:ring-2 focus:ring-yellow-500/20 transition-all font-medium"
              value={searchTerm}
              onChange={(e) => setSearchTerm(e.target.value)}
            />
          </div>
        </header>

        <div className="bg-white rounded-3xl shadow-2xl shadow-gray-200/60 border border-gray-50 overflow-hidden">
          <div className="overflow-x-auto">
            <table className="w-full text-left border-collapse">
              <thead>
                <tr className="bg-gray-50/50 border-b border-gray-100">
                  <th className="p-6 text-[10px] font-black uppercase tracking-widest text-gray-400">User Identity</th>
                  <th className="p-6 text-[10px] font-black uppercase tracking-widest text-gray-400">Email Address</th>
                  <th className="p-6 text-[10px] font-black uppercase tracking-widest text-gray-400">Access Roles</th>
                  <th className="p-6 text-[10px] font-black uppercase tracking-widest text-gray-400 text-center">Actions</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-gray-50">
                {filteredUsers.map(user => (
                  <tr key={user.id} className="hover:bg-yellow-50/30 transition-colors">
                    <td className="p-6">
                      <div className="flex items-center gap-4">
                        <div className="w-10 h-10 bg-neutral-900 rounded-full flex items-center justify-center font-black text-yellow-500 text-xs shadow-lg">
                          {user.fullName?.charAt(0) || 'U'}
                        </div>
                        <div>
                            <span className="font-bold text-gray-900 tracking-tight block">{user.fullName || "No Name"}</span>
                            <button 
                                onClick={() => handleEditUser(user)}
                                className="text-[9px] text-yellow-600 font-black uppercase tracking-widest hover:text-black transition-colors"
                            >
                                Edit Profile ✎
                            </button>
                        </div>
                      </div>
                    </td>
                    <td className="p-6 text-gray-500 font-medium">{user.email}</td>
                    <td className="p-6">
                      <div className="flex flex-wrap gap-2 items-center">
                        {user.roles && user.roles.length > 0 ? (
                          user.roles.map(role => (
                            <span 
                              key={role}
                              onClick={() => handleUpdateRole(user)}
                              className={`cursor-pointer px-3 py-1 rounded-lg text-[9px] font-black uppercase tracking-wider border transition-all hover:scale-105 ${
                                role === 'Administrator' ? 'bg-red-50 text-red-600 border-red-100' :
                                role === 'Organizer' ? 'bg-green-50 text-green-600 border-green-100' :
                                'bg-blue-50 text-blue-600 border-blue-100'
                              }`}
                            >
                              {role} ✎
                            </span>
                          ))
                        ) : (
                          <span onClick={() => handleUpdateRole(user)} className="cursor-pointer text-gray-300 text-[10px] font-bold uppercase tracking-widest italic hover:text-gray-600 transition-colors">No Role +</span>
                        )}
                      </div>
                    </td>
                    <td className="p-6 text-center">
                      <button 
                        onClick={() => handleDelete(user.id)}
                        className="px-4 py-2 bg-red-50 text-red-600 rounded-xl font-black text-[10px] uppercase tracking-widest hover:bg-red-600 hover:text-white transition-all shadow-sm border border-red-100"
                      >
                        Terminate
                      </button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>

        <div className="flex justify-between items-center text-[10px] font-black uppercase tracking-[0.2em] text-gray-300 px-4">
           <span>Total Database Users: {users.length}</span>
           <span>Filtered Results: {filteredUsers.length}</span>
        </div>
      </div>
    </div>
  );
}