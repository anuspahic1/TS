import type { TicketDto } from '../types/TicketDto';
import { apiClient } from './apiClient';

export const adminTicketService = {
  getAll,
  getById,
};

async function getAll(): Promise<TicketDto[]> {
  return apiClient.get<TicketDto[]>('/admin/tickets');
}

async function getById(id: string): Promise<TicketDto> {
  return apiClient.get<TicketDto>(`/admin/tickets/${id}`);
}
