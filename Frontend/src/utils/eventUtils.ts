export const getEventColor = (eventName: string) => {
  const colors = [
    'from-blue-500 via-blue-600 to-purple-600',
    'from-yellow-500 via-yellow-600 to-orange-600',
    'from-green-500 via-green-600 to-teal-600',
    'from-pink-500 via-pink-600 to-rose-600',
    'from-indigo-500 via-indigo-600 to-blue-600',
    'from-amber-500 via-amber-600 to-yellow-600',
    'from-emerald-500 via-emerald-600 to-green-600',
    'from-violet-500 via-violet-600 to-purple-600',
  ];
  const index = eventName.split('').reduce((acc, char) => acc + char.charCodeAt(0), 0) % colors.length;
  return colors[index];
};