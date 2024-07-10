import * as React from "react";
import Projects from "./views/Projects";
import "./style.css";
import { Link, Route,  BrowserRouter as Router, Routes } from 'react-router-dom';
import TimeRegistration from './views/TimeRegistration';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';

export default function App(){
  const queryClient = new QueryClient();
  
    return (
      <QueryClientProvider client={queryClient}>
      <Router>
        <div className="min-h-screen bg-gray-100">
          <nav className="bg-blue-600 p-4">
            <ul className="flex justify-around text-white">
              <li>
                <Link to="/">Projects</Link>
              </li>
              <li>
                <Link to="/timeregistrations">Time Registrations</Link>
              </li>
              <li  className="w-1/2 flex justify-end">
                    <form>
                        <input
                            className="border rounded-full py-2 px-4"
                            type="search"
                            placeholder="Search"
                            aria-label="Search"
                        />
                        <button
                            className="bg-blue-500 hover:bg-blue-700 text-white rounded-full py-2 px-4 ml-2"
                            type="submit"
                        >
                            Search
                        </button>
                    </form>
              </li>
            </ul>
          </nav>
          <div className="container mx-auto p-4">
            <Routes>
              <Route path="/" element={<Projects />} />
              <Route path="/timeregistrations" element={<TimeRegistration />} />
            </Routes>
          </div>
        </div>
      </Router>
      </QueryClientProvider>
    );
  };
