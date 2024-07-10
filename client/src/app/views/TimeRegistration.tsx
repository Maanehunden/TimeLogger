import React from "react";
import TimeRegistrationForm from '../components/TimeRegistrationForm';
import TimeRegistrationList from '../components/TimeRegistrationList';

export default function TimeRegistration() {
    return (
        <>
             <h1 className="mb-4 text-4xl font-extrabold leading-none tracking-tight text-gray-900 md:text-5xl lg:text-6xl dark:text-zinc-900">
                TimeRegistration
            </h1>
            <TimeRegistrationForm/>
            <TimeRegistrationList />
        </>
    );
}
