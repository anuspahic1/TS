import { apiClient } from './apiClient';
import type { ILocation } from '../types/ILocation';

export const locationService = {
  getAll,
  getById,
};

async function getAll(): Promise<ILocation[]> {
  return apiClient.get<ILocation[]>('/locations');
}

async function getById(id: string): Promise<ILocation> {
  return apiClient.get<ILocation>(`/locations/${id}`);
}
