import type { Event, User } from "../types/IEvent"

// Mock logged in user (replace with real auth later)
export const CURRENT_USER: User = {
    id: "user_123",
    name: "nstrsevic1",
    email: "organizer@example.com",
}

// Mock initial events (replace with API call later)
export const INITIAL_EVENTS: Event[] = [
    {
        id: "1",
        name: "Summer Music Festival 2025",
        description: "Join us for an amazing summer music festival featuring top artists from around the world.",
        price: 89.99,
        date: "2025-07-15",
        eventSeatCapacity: 5000,
        location: "Central Park, New York",
        locationId: "loc_001",
        creatorId: CURRENT_USER.id,
        visitors: [
            { id: "v1", name: "John Doe", email: "john@example.com", registeredAt: "2025-01-10" },
            { id: "v2", name: "Jane Smith", email: "jane@example.com", registeredAt: "2025-01-12" },
            { id: "v3", name: "Mike Johnson", email: "mike@example.com", registeredAt: "2025-01-15" },
        ],
    },
    {
        id: "2",
        name: "Tech Conference 2025",
        locationId: "loc_002",
        description: "Annual technology conference showcasing the latest innovations in AI and web development.",
        price: 299.0,
        date: "2025-09-20",
        eventSeatCapacity: 1000,
        location: "Convention Center, San Francisco",
        creatorId: CURRENT_USER.id,
        visitors: [{ id: "v4", name: "Sarah Williams", email: "sarah@example.com", registeredAt: "2025-01-08" }],
    },
]
