"use client"
import { useState } from "react";
import type { Event } from "../types/IEvent"
import axios from "axios"

export function useEvents() {


    const [events, setEvents] = useState<Event[]>([]);


    const getUserEvents = async (userId: string) => {
        try {
            console.log("Fetching events for user ID:", userId);
            const response = await axios.get(`${import.meta.env.VITE_API_URL}/users/${userId}/events`);
            console.log("Fetched events:", response.data);
            // setEvents(response.data);
            return response.data;
        } catch (error) {
            console.error("Error fetching user events:", error);
            return [];
        }
    }


const createEvent = async (creatorId: string, data: any) => {

    const locId = data.locationId || data.location; 

    console.log("Location ID in useEvents:", locId);
    
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

    console.log("Creating event object for API:", newEvent);

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

const updateEvent = async (locationId: string, eventId: string, updatedEvent: any) => {
    try {
        console.log("Data received in updateEvent:", updatedEvent);

        const rawDate = updatedEvent.eventDate || updatedEvent.date;
        const dateObject = new Date(rawDate);

        if (isNaN(dateObject.getTime())) {
            throw new Error(`Invalid date provided: ${rawDate}`);
        }

        const response = await axios.put(
            `${import.meta.env.VITE_API_URL}/locations/${locationId}/events/${eventId}`, 
            {
                name: updatedEvent.name,
                description: updatedEvent.description,
                minTicketPrice: Number(updatedEvent.minTicketPrice || updatedEvent.price || 0),
                eventDate: dateObject.toISOString(), 
                capacity: Number(updatedEvent.capacity || updatedEvent.eventSeatCapacity || 0),
                locationId: locationId,
            }
        );

        setEvents((prev) =>
            prev.map((e) => (e.id === eventId ? response.data : e))
        );
    } catch (error) {
        console.error("Error updating event:", error);
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
