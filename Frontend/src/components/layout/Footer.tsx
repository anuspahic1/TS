import React from 'react';

const Footer: React.FC = () => {
  return (
    <footer className="bg-neutral-950 text-white py-16 px-6 mt-auto">
      <div className="container mx-auto max-w-7xl">
        <div className="grid grid-cols-1 md:grid-cols-3 gap-12 items-center border-b border-white/10 pb-12 mb-12">
          <div className="text-center md:text-left">
            <span className="text-2xl font-black tracking-tighter uppercase italic">
              Entrio<span className="text-yellow-500 font-light">X</span>
            </span>
          </div>
          <div className="text-center md:text-right text-neutral-500 text-sm col-span-2">
            © {new Date().getFullYear()} EntrioX. All rights reserved.
          </div>
        </div>
      </div>
    </footer>
  );
};

export default Footer;