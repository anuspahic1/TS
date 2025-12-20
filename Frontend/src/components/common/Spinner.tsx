export const Spinner = ({ label }: { label?: string }) => (
  <div className="text-center">
    <div className="animate-spin h-10 w-10 border-4 border-gray-200 border-t-yellow-500 rounded-full mx-auto mb-4" />
    {label && <p className="text-gray-600">{label}</p>}
  </div>
);
