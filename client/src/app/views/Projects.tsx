import React from "react";
import ProjectList from '../components/ProjectList';
import ProjectForm from '../components/ProjectForm';

export default function Projects() {
    return (
        <>
             <h1 className="mb-4 text-4xl font-extrabold leading-none tracking-tight text-gray-900 md:text-5xl lg:text-6xl dark:text-zinc-900">
             Projects
            </h1>
            <ProjectForm/>
            <ProjectList />
        </>
    );
}
