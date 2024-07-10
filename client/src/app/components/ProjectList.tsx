import React from "react";
import { useProjects } from '../api/api';

export default function ProjectList() {
    const { data: projects, error, isLoading } = useProjects();

    if (isLoading) return <div>Loading...</div>;
    if (error) return <div>Error loading projects</div>;
    
    return (
        <table className="table-fixed w-full">
            <thead className="bg-gray-200">
                <tr>
                    <th className="border px-4 py-2 w-12">Id</th>
                    <th className="border px-4 py-2">Name</th>
                    <th className="border px-4 py-2">Deadline</th>
                    <th className="border px-4 py-2">CustomerName</th>
                </tr>
            </thead>
            <tbody>
            {projects && projects.map((project: any) => (
            <tr key={`${project.id}${project.deadline}`}>
                    <td className="border px-4 py-2 w-12">{project.id}</td>
                    <td className="border px-4 py-2">{project.name} </td>
                    <td className="border px-4 py-2">{project.deadline}</td>
                    <td className="border px-4 py-2">{project.CustomerName}</td>
                </tr>
            ))}
            </tbody>
        </table>
    );
}
