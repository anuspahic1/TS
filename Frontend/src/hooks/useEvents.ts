"use client"
import { useState } from "react";
import type { Event } from "../types/IEvent"
import axios from "axios"

export function useEvents() {


    const [events, setEvents] = useState<Event[]>([]);


    const getUserEvents = async (userId: string) => {
        try {
            const response = await axios.get(`${import.meta.env.VITE_API_URL}/users/${userId}/events`);
            // setEvents(response.data);
            return response.data;
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
        if (!locId) {
            throw new Error("Location ID is missing. Cannot create event.");
        }

        const response = await axios.post(
            `${import.meta.env.VITE_API_URL}/locations/${locId}/events`, 
            newEvent
        );
        setEvents((prev) => [...prev, response.data]);
        return response.data;
    } catch (error) {
        console.error("Error creating event:", error);
        throw error; 
    }
};

// useEvents.ts

const updateEvent = async (locationId: string, eventId: string, data: any) => {
    try {
        // This matches your confirmed PUT /api/locations/{locationId}/events/{id}
        const response = await axios.put(
            `${import.meta.env.VITE_API_URL}/locations/${locationId}/events/${eventId}`, 
            data
        );

        setEvents((prev) =>
            prev.map((e: any) => {
                // Check against both possible ID names to be safe
                const isMatch = e.id === eventId || e.eventId === eventId;
                return isMatch ? response.data : e;
            })
        );
        
        return response.data;
    } catch (error) {
        console.error("Error updating event:", error);
        throw error; // Re-throw so the component knows it failed
    }
};

    const deleteEvent = async (eventId: string, location: string) => {
        try {
            await axios.delete(`${import.meta.env.VITE_API_URL}/locations/${location}/events/${eventId}`);
            setEvents((prev) => prev.filter((e) => e.id !== eventId));
        } catch (error) {
            console.error("Error deleting event:", error);
        }
    }

    const getEventVisitors = async (locationid: string, eventId: string) => {
        try {
            const response = await axios.get(`${import.meta.env.VITE_API_URL}/locations/${locationid}/events/${eventId}/reservations/visitors`);
            return response.data;
        } catch (error) {
            console.error("Error fetching event visitors:", error);
            return [];
        }
    }

    const getAllEvents = async () => {
    try {
        const response = await axios.get(`${import.meta.env.VITE_API_URL}/admin/events`);
        return response.data;
    } catch (error) {
        console.error("Error fetching all events:", error);
        return [];
    }
};

return {
    getAllEvents,
    getUserEvents,
    createEvent,
    updateEvent,
    deleteEvent,
    getEventVisitors,
}
}
