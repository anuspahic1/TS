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
import { Calendar, DollarSign, Users, MapPin, Type, AlignLeft } from "lucide-react"

import * as z from "zod"
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
    }),
    eventSeatCapacity: z.string().refine((val) => !isNaN(Number(val)) && Number(val) > 0, {
        message: "Seat capacity must be a positive number",
    }),
    location: z.string().min(1, "Please select a location"),
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
        reset()
    }

    return (
        <Dialog open={open} onOpenChange={onOpenChange}>
            <DialogContent className="max-w-2xl max-h-[90vh] overflow-y-auto rounded-3xl border-none shadow-2xl">
                {/* Accent line at the top of the modal */}
                <div className="absolute top-0 left-0 w-full h-1.5 bg-gradient-to-r from-yellow-500 via-black to-yellow-500" />
                
                <DialogHeader className="pt-4">
                    <DialogTitle className="text-3xl font-black uppercase italic tracking-tighter">
                        Create <span className="text-yellow-500">New Event</span>
                    </DialogTitle>
                    <DialogDescription className="font-medium text-gray-500">
                        Fill in the technical specifications for the new global event.
                    </DialogDescription>
                </DialogHeader>

                <form onSubmit={handleSubmit(onSubmit)} className="space-y-6 py-4">
                    <div className="grid gap-2">
                        <label htmlFor="name" className="text-xs font-black uppercase tracking-widest text-gray-400 flex items-center">
                            <Type className="h-3 w-3 mr-2 text-yellow-500" /> Event Name
                        </label>
                        <Input 
                            id="name" 
                            className="rounded-xl border-gray-200 focus:ring-yellow-500 py-6 font-semibold"
                            placeholder="e.g. Techno Night Vol. 1" 
                            {...register("name")} 
                        />
                        {errors.name && <p className="text-[10px] font-bold text-red-500 uppercase italic">{errors.name.message}</p>}
                    </div>

                    <div className="grid gap-2">
                        <label htmlFor="description" className="text-xs font-black uppercase tracking-widest text-gray-400 flex items-center">
                            <AlignLeft className="h-3 w-3 mr-2 text-yellow-500" /> Description
                        </label>
                        <Textarea
                            id="description"
                            placeholder="Provide details about the line-up, VIP sections, etc."
                            className="min-h-24 rounded-xl border-gray-200 focus:ring-yellow-500"
                            {...register("description")}
                        />
                        {errors.description && <p className="text-[10px] font-bold text-red-500 uppercase italic">{errors.description.message}</p>}
                    </div>

                    <div className="grid gap-6 md:grid-cols-2">
                        <div className="grid gap-2">
                            <label htmlFor="date" className="text-xs font-black uppercase tracking-widest text-gray-400 flex items-center">
                                <Calendar className="h-3 w-3 mr-2 text-yellow-500" /> Event Date
                            </label>
                            <Input 
                                id="date" 
                                type="datetime-local" 
                                className="rounded-xl border-gray-200 py-6"
                                {...register("date")} 
                            />
                            {errors.date && <p className="text-[10px] font-bold text-red-500 uppercase italic">{errors.date.message}</p>}
                        </div>

                        <div className="grid gap-2">
                            <label htmlFor="price" className="text-xs font-black uppercase tracking-widest text-gray-400 flex items-center">
                                <DollarSign className="h-3 w-3 mr-2 text-yellow-500" /> Entry Price ($)
                            </label>
                            <Input 
                                id="price" 
                                type="number" 
                                step="0.01" 
                                className="rounded-xl border-gray-200 py-6"
                                placeholder="0.00" 
                                {...register("price")} 
                            />
                            {errors.price && <p className="text-[10px] font-bold text-red-500 uppercase italic">{errors.price.message}</p>}
                        </div>
                    </div>

                    <div className="grid gap-6 md:grid-cols-2">
                        <div className="grid gap-2">
                            <label htmlFor="eventSeatCapacity" className="text-xs font-black uppercase tracking-widest text-gray-400 flex items-center">
                                <Users className="h-3 w-3 mr-2 text-yellow-500" /> Seat Capacity
                            </label>
                            <Input 
                                id="eventSeatCapacity" 
                                type="number" 
                                className="rounded-xl border-gray-200 py-6"
                                placeholder="500" 
                                {...register("eventSeatCapacity")} 
                            />
                            {errors.eventSeatCapacity && <p className="text-[10px] font-bold text-red-500 uppercase italic">{errors.eventSeatCapacity.message}</p>}
                        </div>

                        <div className="grid gap-2">
                            <label htmlFor="location" className="text-xs font-black uppercase tracking-widest text-gray-400 flex items-center">
                                <MapPin className="h-3 w-3 mr-2 text-yellow-500" /> Location Hub
                            </label>
                            <Controller
                                name="location"
                                control={control}
                                render={({ field }) => (
                                    <Select onValueChange={field.onChange} value={field.value}>
                                        <SelectTrigger className="rounded-xl border-gray-200 py-6">
                                            <SelectValue placeholder="Select venue" />
                                        </SelectTrigger>
                                        <SelectContent className="rounded-xl">
                                            {locations.map((location) => (
                                                <SelectItem key={location.id} value={location.id}>
                                                    {location.name}
                                                </SelectItem>
                                            ))}
                                        </SelectContent>
                                    </Select>
                                )}
                            />
                            {errors.location && <p className="text-[10px] font-bold text-red-500 uppercase italic">{errors.location.message}</p>}
                        </div>
                    </div>

                    <DialogFooter className="pt-4">
                        <Button 
                            type="button" 
                            variant="ghost" 
                            onClick={() => onOpenChange(false)} 
                            className="font-bold hover:bg-gray-100 rounded-xl px-6"
                        >
                            Cancel
                        </Button>
                        <Button 
                            type="submit" 
                            className="bg-black text-white hover:bg-yellow-500 hover:text-black font-black uppercase tracking-widest px-8 py-6 rounded-xl transition-all shadow-lg shadow-black/10"
                        >
                            Broadcast Event
                        </Button>
                    </DialogFooter>
                </form>
            </DialogContent>
        </Dialog>
    )
}