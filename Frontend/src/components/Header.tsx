import React from 'react';
import { Link } from 'react-router-dom'; 

const Header: React.FC = () => {
  //Application state: whether the user is logged in. Fixed for now, real logic comes later.
  const isAuthenticated = false; 
  
  const navItems = [
    { name: 'Home', path: '/' },
    { name: 'Rewards', path: '/rewards' },
  ];

  return (
    <header className="bg-white shadow-md">
      <div className="container mx-auto px-4 py-4 flex justify-between items-center">
        <Link to="/" className="text-2xl font-bold text-gray-800">
          EntrioX
        </Link>

        <nav className="hidden md:flex space-x-6">
          {navItems.map((item) => (
            <Link
              key={item.name}
              to={item.path}
              className="text-gray-600 hover:text-gray-900 transition duration-150 font-medium"
            >
              {item.name}
            </Link>
          ))}
        </nav>

        <div>
          {isAuthenticated ? (
            //Display for logged-in user
            <div className="flex items-center space-x-4">
              <span className="text-gray-600">Welcome, User</span>
              <button className="p-2 border rounded-full hover:bg-gray-100">
                <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5" viewBox="0 0 20 20" fill="currentColor">
                  <path fillRule="evenodd" d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-6-3a2 2 0 11-4 0 2 2 0 014 0zm-2 4a5 5 0 00-4.546 2.916A5.98 5.98 0 0010 16a5.979 5.979 0 004.546-2.084A5 5 0 0010 11z" clipRule="evenodd" />
                </svg>
              </button>
            </div>
          ) : (
            //Display for logged-out user
            <div className="space-x-4 flex items-center">
              <Link
                to="/signup"
                className="text-gray-600 hover:text-gray-800 font-medium transition duration-150"
              >
                Sign Up
              </Link>
              <Link
                to="/login"
                className="py-2 px-5 bg-yellow-600 text-white font-semibold rounded-lg shadow-md hover:bg-yellow-700 transition duration-150"
              >
                Log In
              </Link>
            </div>
          )}
        </div>
      </div>
    </header>
  );
};

export default Header;