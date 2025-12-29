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

export interface Visitor {
    id: string
    name: string
    email: string
    registeredAt: string
}

export interface User {
    id: string
    name: string
    email: string
}

export interface Event {
    id: string
    name: string
    description: string
    price: number
    date: string
    eventSeatCapacity: number
    location: string,
    locationId: string
    creatorId: string
    visitors: Visitor[]
}