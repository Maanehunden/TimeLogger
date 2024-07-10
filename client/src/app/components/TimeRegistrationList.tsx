
import React from 'react';
import { useTimeRegistrations } from '../api/api';

export default function TimeRegistrationList() {
  const { data: timeRegistrations, error, isLoading } = useTimeRegistrations();

  if (isLoading) return <div>Loading...</div>;
  if (error) return <div>Error loading time registrations</div>;

  return (

      <table className="table-fixed w-full">
            <thead className="bg-gray-200">
                <tr>
                    <th className="border px-4 py-2">Project Id</th>
                    <th className="border px-4 py-2">Date</th>
                    <th className="border px-4 py-2">Hours</th>
                </tr>
            </thead>
            <tbody>
            {timeRegistrations && timeRegistrations.map((registration: any) => (
            <tr key={`${registration.id}${registration.deadline}`}>
                    <td className="border px-4 py-2 w-12">{registration.projectId}</td>
                    <td className="border px-4 py-2">{registration.date} </td>
                    <td className="border px-4 py-2">{registration.hours}</td>
                </tr>
            ))}
            </tbody>
        </table>

  );
};