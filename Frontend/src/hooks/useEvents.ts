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


        console.log("Location ID in useEvents:", data.location);
        console.log("PRDEKOKE", data);
        console.log(data.price)
        const newEvent = {
            name: data.name,
            description: data.description ?? "",
            minTicketPrice: Number(data.price),
            eventDate: new Date(data.date),
            capacity: Number(data.eventSeatCapacity),
            locationId: data.location,
            creatorId: creatorId
        }


        console.log("Creating event:", newEvent);
        try {
            const response = await axios.post(`${import.meta.env.VITE_API_URL}/locations/${data.location}/events`, newEvent)
            setEvents((prev) => [...prev, response.data])

        }
        catch (error) {
            console.error("Error creating event:", error);
        }

        return newEvent
    }


    const updateEvent = async (locationId: string, eventId: string, updatedEvent: any) => {
        try {
            console.log("Updating event: slanje u. fju", updatedEvent);
            const response = await axios.put(`${import.meta.env.VITE_API_URL}/locations/${locationId}/events/${eventId}`, {
                name: updatedEvent.name,
                description: updatedEvent.description,
                minTicketPrice: Number(updatedEvent.price),
                eventDate: new Date(updatedEvent.date),
                capacity: Number(updatedEvent.eventSeatCapacity),
                locationId: updatedEvent.locationId,
            });
            setEvents((prev) =>
                prev.map((e) => (e.id === updatedEvent.id ? response.data : e))
            );
        } catch (error) {
            console.error("Error updating event:", error);
        }
    }

    const deleteEvent = async (eventId: string, location: string) => {
        try {
            await axios.delete(`${import.meta.env.VITE_API_URL}/locations/${location}/events/${eventId}`);
            setEvents((prev) => prev.filter((e) => e.id !== eventId));
        } catch (error) {
            console.error("Error deleting event:", error);
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
    deleteEvent
}
}
