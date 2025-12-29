import { apiClient } from './apiClient';
import type { EventDto } from '../types/IEvent';

export const eventService = {
  getByLocation,
};

async function getByLocation(locationId: string): Promise<EventDto[]> {
  return apiClient.get<EventDto[]>(`/locations/${locationId}/events`);
}
