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
import { Calendar, DollarSign, Users, MapPin, Type, AlignLeft, RefreshCcw } from "lucide-react"

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
    }

    return (
        <Dialog open={open} onOpenChange={onOpenChange}>
            <DialogContent className="max-w-2xl max-h-[90vh] overflow-y-auto rounded-3xl border-none shadow-2xl">
                <div className="absolute top-0 left-0 w-full h-1.5 bg-gradient-to-r from-yellow-500 via-black to-yellow-500" />
                
                <DialogHeader className="pt-4">
                    <DialogTitle className="text-3xl font-black uppercase italic tracking-tighter">
                        Edit <span className="text-yellow-500">Event Details</span>
                    </DialogTitle>
                    <DialogDescription className="font-medium text-gray-500">
                        Modify existing parameters for <span className="text-black font-bold">"{event.name}"</span>.
                    </DialogDescription>
                </DialogHeader>

                <form onSubmit={handleSubmit(onSubmit)} className="space-y-6 py-4">
                    <div className="grid gap-2">
                        <label className="text-xs font-black uppercase tracking-widest text-gray-400 flex items-center">
                            <Type className="h-3 w-3 mr-2 text-yellow-500" /> Event Name
                        </label>
                        <Input 
                            className="rounded-xl border-gray-200 focus:ring-yellow-500 py-6 font-semibold"
                            {...register("name")} 
                        />
                        {errors.name && <p className="text-[10px] font-bold text-red-500 uppercase italic">{errors.name.message}</p>}
                    </div>

                    <div className="grid gap-2">
                        <label className="text-xs font-black uppercase tracking-widest text-gray-400 flex items-center">
                            <AlignLeft className="h-3 w-3 mr-2 text-yellow-500" /> Description
                        </label>
                        <Textarea
                            className="min-h-24 rounded-xl border-gray-200 focus:ring-yellow-500"
                            {...register("description")}
                        />
                        {errors.description && <p className="text-[10px] font-bold text-red-500 uppercase italic">{errors.description.message}</p>}
                    </div>

                    <div className="grid gap-6 md:grid-cols-2">
                        <div className="grid gap-2">
                            <label className="text-xs font-black uppercase tracking-widest text-gray-400 flex items-center">
                                <Calendar className="h-3 w-3 mr-2 text-yellow-500" /> Event Date
                            </label>
                            <Input 
                                type="date" 
                                className="rounded-xl border-gray-200 py-6 font-medium"
                                {...register("date")} 
                            />
                            {errors.date && <p className="text-[10px] font-bold text-red-500 uppercase italic">{errors.date.message}</p>}
                        </div>

                        <div className="grid gap-2">
                            <label className="text-xs font-black uppercase tracking-widest text-gray-400 flex items-center">
                                <DollarSign className="h-3 w-3 mr-2 text-yellow-500" /> Ticket Price ($)
                            </label>
                            <Input 
                                type="number" 
                                step="0.01" 
                                className="rounded-xl border-gray-200 py-6 font-medium"
                                {...register("price")} 
                            />
                            {errors.price && <p className="text-[10px] font-bold text-red-500 uppercase italic">{errors.price.message}</p>}
                        </div>
                    </div>

                    <div className="grid gap-6 md:grid-cols-2">
                        <div className="grid gap-2">
                            <label className="text-xs font-black uppercase tracking-widest text-gray-400 flex items-center">
                                <Users className="h-3 w-3 mr-2 text-yellow-500" /> Seat Capacity
                            </label>
                            <Input 
                                type="number" 
                                className="rounded-xl border-gray-200 py-6 font-medium"
                                {...register("eventSeatCapacity")} 
                            />
                            {errors.eventSeatCapacity && <p className="text-[10px] font-bold text-red-500 uppercase italic">{errors.eventSeatCapacity.message}</p>}
                        </div>

                        <div className="grid gap-2">
                            <label className="text-xs font-black uppercase tracking-widest text-gray-400 flex items-center">
                                <MapPin className="h-3 w-3 mr-2 text-yellow-500" /> Location Hub
                            </label>
                            <Controller
                                name="location"
                                control={control}
                                render={({ field }) => (
                                    <Select value={field.value} onValueChange={field.onChange}>
                                        <SelectTrigger className="rounded-xl border-gray-200 py-6">
                                            <SelectValue placeholder="Select location" />
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

                    <DialogFooter className="pt-4 gap-2">
                        <Button 
                            type="button" 
                            variant="ghost" 
                            onClick={() => onOpenChange(false)} 
                            className="font-bold hover:bg-gray-100 rounded-xl"
                        >
                            Discard Changes
                        </Button>
                        <Button 
                            type="submit" 
                            className="bg-black text-white hover:bg-yellow-500 hover:text-black font-black uppercase tracking-widest px-8 py-6 rounded-xl transition-all shadow-lg shadow-black/10"
                        >
                            <RefreshCcw className="mr-2 h-4 w-4" /> Sync Updates
                        </Button>
                    </DialogFooter>
                </form>
            </DialogContent>
        </Dialog>
    )
}