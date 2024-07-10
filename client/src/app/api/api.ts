// src/api/api.ts
import axios from 'axios';
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query';

const api = axios.create({
  baseURL: 'http://localhost:3001/api',
  headers: { 'Content-Type': 'application/json' , 'Accept': '*/*', 'Access-Control-Allow-Origin':'*' },
});

export const useProjects = () => {
  return useQuery(['projects'], async () => {
    const { data } = await api.get('/projects');
    return data;
  });
};

export const useProject = (id: number) => {
  return useQuery(['project', id], async () => {
    const { data } = await api.get(`/projects/${id}`);
    return data;
  });
};

export const useAddProject = () => {
  const queryClient = useQueryClient();
  return useMutation(
    async (newProject: { name: string; deadline: string; customerId: number }) => {
      const { data } = await api.post('/projects', newProject);
      return data;
    },
    {
      onSuccess: () => {
        queryClient.invalidateQueries(['projects']);
      },
    }
  );
};

export const useTimeRegistrations = () => {
  return useQuery(['timeRegistrations'], async () => {
    const { data } = await api.get('/timeregistrations');
    return data;
  });
};

export const useAddTimeRegistration = () => {
  const queryClient = useQueryClient();
  return useMutation(
    async (newTimeRegistration: { projectId: number; date: string; hours: number }) => {
      const { data } = await api.post('/timeregistrations', newTimeRegistration);
      return data;
    },
    {
      onSuccess: () => {
        queryClient.invalidateQueries(['timeRegistrations']);
      },
    }
  );
};
