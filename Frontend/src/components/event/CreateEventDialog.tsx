"use client"

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


import * as z from "zod"
import { DropdownMenu } from "@radix-ui/react-dropdown-menu"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "../ui/select"

export const eventSchema = z.object({
    name: z.string().min(3, "Event name must be at least 3 characters"),
    description: z.string().min(10, "Description must be at least 10 characters"),
    price: z.string().refine((val) => !isNaN(Number(val)) && Number(val) >= 0, {
        message: "Price must be a positive number",
    }),
    date: z.string().min(1, "Date is required").refine((val) => {
        const selectedDate = new Date(val);
        const now = new Date();
        return selectedDate >= now;
    }, {
        message: "Event date cannot be in the past",
    }),    eventSeatCapacity: z.string().refine((val) => !isNaN(Number(val)) && Number(val) > 0, {
        message: "Seat capacity must be a positive number",
    }),
    location: z.string().min(3, "Location must be at least 3 characters"),
})

export type EventFormData = z.infer<typeof eventSchema>



interface CreateEventDialogProps {
    open: boolean
    onOpenChange: (open: boolean) => void
    onCreateEvent: any
    locations: any[]
}

export function CreateEventDialog({ locations, open, onOpenChange, onCreateEvent }: CreateEventDialogProps) {
    const {
        register,
        handleSubmit,
        control,
        reset,
        formState: { errors },
    } = useForm<EventFormData>({
        resolver: zodResolver(eventSchema),
        defaultValues: {
            name: "",
            description: "",
            price: "",
            date: "",
            eventSeatCapacity: "",
            location: "",
        },
    })

    const onSubmit = (data: EventFormData) => {
        onCreateEvent({
            name: data.name,
            description: data.description,
            price: data.price,
            date: data.date,
            eventSeatCapacity: Number(data.eventSeatCapacity),
            location: data.location,


        })
        console.log("Form submitted with data:", data);
        reset()
    }

    return (
        <Dialog open={open} onOpenChange={onOpenChange}>
            <DialogContent className="max-w-2xl max-h-[90vh] overflow-y-auto">
                <DialogHeader>
                    <DialogTitle>Create New Event</DialogTitle>
                    <DialogDescription>
                        Fill in the details below to create a new event. All fields are required.
                    </DialogDescription>
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
                            <Input id="date" type="datetime-local" min={new Date().toISOString().slice(0, 16)} {...register("date")} />
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
                                    <Select onValueChange={field.onChange} value={field.value}>
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
                            Create Event
                        </Button>
                    </DialogFooter>
                </form>
            </DialogContent>
        </Dialog>
    )
}
