export interface EventDto {
    id: string;
    name: string;
    description: string | null;
    createdAt: string;
    minTicketPrice: number;
    eventDate: string;
    locationName: string;
    creatorId: string;
    capacity: number;
}