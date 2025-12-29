"use client"
import { useState } from "react";
import type { Event } from "../types/IEvent"
// Import your custom apiClient instead of axios
import { apiClient } from "../services/apiClient"; 

export function useEvents() {
    const [events, setEvents] = useState<Event[]>([]);

    // Helper to get relative paths (Vite proxy handles the /api prefix)
    const getUserEvents = async (userId: string) => {
        try {
            // apiClient already prepends '/api', so just provide the rest
            const data = await apiClient.get<Event[]>(`/users/${userId}/events`);
            return data;
        } catch (error) {
            console.error("Error fetching user events:", error);
            return [];
        }
    }

    const createEvent = async (creatorId: string, data: any) => {
        const locId = data.locationId || data.location; 
        
        const newEvent = {
            name: data.name,
            description: data.description ?? "",
            minTicketPrice: Number(data.minTicketPrice || 0), 
            eventDate: data.eventDate ? new Date(data.eventDate).toISOString() : new Date().toISOString(),
            capacity: Number(data.capacity || 0),
            locationId: locId,
            creatorId: creatorId,
            reservations: null,
            tickets: null
        };

        try {
            if (!locId) throw new Error("Location ID is missing.");

            // This now includes your Bearer token automatically!
            const responseData = await apiClient.post<Event>(
                `/locations/${locId}/events`, 
                newEvent
            );
            
            setEvents((prev) => [...prev, responseData]);
            return responseData;
        } catch (error) {
            console.error("Error creating event:", error);
            throw error; 
        }
    };

    const updateEvent = async (locationId: string, eventId: string, data: any) => {
        try {
            const responseData = await apiClient.put<Event>(
                `/locations/${locationId}/events/${eventId}`, 
                data
            );

            setEvents((prev) =>
                prev.map((e: any) => (e.id === eventId ? responseData : e))
            );
            return responseData;
        } catch (error) {
            console.error("Error updating event:", error);
            throw error;
        }
    };

    const deleteEvent = async (eventId: string, location: string) => {
        try {
            await apiClient.delete(`/locations/${location}/events/${eventId}`);
            setEvents((prev) => prev.filter((e) => e.id !== eventId));
        } catch (error) {
            console.error("Error deleting event:", error);
        }
    }

    const getAllEvents = async () => {
        try {
            return await apiClient.get<Event[]>(`/admin/events`);
        } catch (error) {
            console.error("Error fetching all events:", error);
            return [];
        }
    };

    return {
        events,
        getAllEvents,
        getUserEvents,
        createEvent,
        updateEvent,
        deleteEvent,
    }
}