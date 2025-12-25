"use client"

import { useEffect } from "react"
import type { Event } from "../../types/IEvent"
import { Button } from "../ui/button"
import {
    Dialog,
    DialogContent,
    DialogDescription,
    DialogFooter,
    DialogHeader,
    DialogTitle,
} from "../ui/dialog"
import { Input } from "../ui/input"
import { Textarea } from "../ui/textarea"
import { Controller, useForm } from "react-hook-form"
import { zodResolver } from "@hookform/resolvers/zod"
import { eventSchema, type EventFormData } from "./CreateEventDialog"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "../ui/select"

interface EditEventDialogProps {
    open: boolean
    onOpenChange: (open: boolean) => void
    event: Event
    onUpdateEvent: any,
    locations: any[]
}

function formatForDateInput(dateStr?: string) {
    if (!dateStr) return ""
    const tIndex = dateStr.indexOf("T")
    if (tIndex === -1) return dateStr
    return dateStr.slice(0, tIndex)
}

export function EditEventDialog({ locations, open, onOpenChange, event, onUpdateEvent }: EditEventDialogProps) {
    const {
        register,
        handleSubmit,
        control,
        reset,
        formState: { errors },
    } = useForm<EventFormData>({
        resolver: zodResolver(eventSchema),
        defaultValues: {
            name: event.name,
            description: event.description,
            price: event.price.toString(),
            date: formatForDateInput(event.date),
            eventSeatCapacity: event.eventSeatCapacity.toString(),
            location: event.locationId ?? event.location,
        },
    })

    useEffect(() => {
        reset({
            name: event.name,
            description: event.description,
            price: event.price.toString(),
            date: formatForDateInput(event.date),
            eventSeatCapacity: event.eventSeatCapacity.toString(),
            location: event.locationId,
        })
    }, [event, reset])

    const onSubmit = (data: EventFormData) => {

        const updated = {
            id: event.id,
            name: data.name,
            description: data.description,
            price: Number(data.price),
            date: data.date,
            eventSeatCapacity: Number(data.eventSeatCapacity),
            location: event.locationId ?? data.location,
            locationId: data.location,
        }

        onUpdateEvent(event.id, event.locationId ?? data.location, updated)

        console.log("Updated event data:", updated)
    }

    return (
        <Dialog open={open} onOpenChange={onOpenChange}>
            <DialogContent className="max-w-2xl max-h-[90vh] overflow-y-auto">
                <DialogHeader>
                    <DialogTitle>Edit Event</DialogTitle>
                    <DialogDescription>Update the event details below. All fields are required.</DialogDescription>
                </DialogHeader>

                <form onSubmit={handleSubmit(onSubmit)} className="space-y-4">
                    <div className="grid gap-2">
                        <label htmlFor="name" className="text-sm font-medium">
                            Event Name
                        </label>
                        <Input id="name" placeholder="Summer Music Festival 2025" {...register("name")} />
                        {errors.name && <p className="text-sm text-red-500">{errors.name.message}</p>}
                    </div>

                    <div className="grid gap-2">
                        <label htmlFor="description" className="text-sm font-medium">
                            Description
                        </label>
                        <Textarea
                            id="description"
                            placeholder="Describe your event..."
                            className="min-h-24"
                            {...register("description")}
                        />
                        {errors.description && <p className="text-sm text-red-500">{errors.description.message}</p>}
                    </div>

                    <div className="grid gap-4 md:grid-cols-2">
                        <div className="grid gap-2">
                            <label htmlFor="date" className="text-sm font-medium">
                                Event Date
                            </label>
                            <Input id="date" type="date" {...register("date")} />
                            {errors.date && <p className="text-sm text-red-500">{errors.date.message}</p>}
                        </div>

                        <div className="grid gap-2">
                            <label htmlFor="price" className="text-sm font-medium">
                                Ticket Price ($)
                            </label>
                            <Input id="price" type="number" step="0.01" placeholder="99.99" {...register("price")} />
                            {errors.price && <p className="text-sm text-red-500">{errors.price.message}</p>}
                        </div>
                    </div>

                    <div className="grid gap-4 md:grid-cols-2">
                        <div className="grid gap-2">
                            <label htmlFor="eventSeatCapacity" className="text-sm font-medium">
                                Seat Capacity
                            </label>
                            <Input id="eventSeatCapacity" type="number" placeholder="1000" {...register("eventSeatCapacity")} />
                            {errors.eventSeatCapacity && <p className="text-sm text-red-500">{errors.eventSeatCapacity.message}</p>}
                        </div>

                        <div className="grid gap-2">
                            <label htmlFor="location" className="text-sm font-medium">
                                Location
                            </label>
                            <Controller
                                name="location"
                                control={control}
                                render={({ field }) => (
                                    <Select value={field.value} onValueChange={field.onChange}>
                                        <SelectTrigger>
                                            <SelectValue placeholder="Select location" />
                                        </SelectTrigger>
                                        <SelectContent>
                                            {locations.map((location) => (
                                                <SelectItem key={location.id} value={location.id}>
                                                    {location.name}
                                                </SelectItem>
                                            ))}
                                        </SelectContent>
                                    </Select>
                                )}
                            />

                            {errors.location && <p className="text-sm text-red-500">{errors.location.message}</p>}
                        </div>
                    </div>

                    <DialogFooter>
                        <Button type="button" variant="outline" onClick={() => onOpenChange(false)} className="border-gray-300">
                            Cancel
                        </Button>
                        <Button type="submit" className="bg-black text-white hover:bg-black/90">
                            Update Event
                        </Button>
                    </DialogFooter>
                </form>
            </DialogContent>
        </Dialog>
    )
}
