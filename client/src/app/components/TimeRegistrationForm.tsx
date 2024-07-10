import React, { useState } from 'react';
import { useAddTimeRegistration } from '../api/api';

const TimeRegistrationForm: React.FC = () => {
  const [projectId, setProjectId] = useState(0);
  const [date, setDate] = useState('');
  const [hours, setHours] = useState(0);
  const addTimeRegistration = useAddTimeRegistration();

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    addTimeRegistration.mutate({ projectId, date, hours });
  };

  return (
    <form onSubmit={handleSubmit} className="max-w-xl mx-auto mt-8 p-4 border rounded-lg shadow-lg">
      <h2 className="text-2xl font-bold mb-4">Add Time Registration</h2>
      <div className='flex space-x-4'>
        <div className="mb-4">
          <label htmlFor="projectId" className="block text-sm font-medium text-gray-700">
            Project ID:
          </label>
          <input
            type="number"
            id="projectId"
            value={projectId}
            onChange={(e) => setProjectId(Number(e.target.value))}
            className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
          />
        </div>
        <div className="mb-4">
          <label htmlFor="date" className="block text-sm font-medium text-gray-700">
            Date:
          </label>
          <input
            type="date"
            id="date"
            value={date}
            onChange={(e) => setDate(e.target.value)}
            className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
          />
        </div>
        <div className="mb-4">
          <label htmlFor="hours" className="block text-sm font-medium text-gray-700">
            Hours:
          </label>
          <input
            type="number"
            id="hours"
            value={hours}
            onChange={(e) => setHours(Number(e.target.value))}
            className="mt-1 block w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
          />
        </div>
      </div>
      <button
        type="submit"
        className="w-full py-2 px-4 bg-indigo-600 text-white font-semibold rounded-md shadow-md hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2"
      >
        Add Time Registration
      </button>
    </form>
  );
};

export default TimeRegistrationForm;
