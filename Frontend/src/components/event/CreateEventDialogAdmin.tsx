"use client"

import { useForm, Controller } from "react-hook-form"
import { zodResolver } from "@hookform/resolvers/zod"
import * as z from "zod"
import { Calendar, DollarSign, Users, MapPin, Type, AlignLeft, AlertCircle } from "lucide-react"

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
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "../ui/select"

export const eventSchema = z.object({
    name: z.string()
        .min(3, "Event name must be at least 3 characters")
        .max(100, "Event name max length is 100"),
    description: z.string()
        .min(10, "Description must be at least 10 characters")
        .max(500, "Description max length is 500"),
    price: z.string().refine((val) => {
        const num = Number(val);
        return !isNaN(num) && num >= 0.01;
    }, {
        message: "Price must be at least 0.01 (Backend policy)",
    }),
    date: z.string().min(1, "Date is required").refine((val) => {
        const selectedDate = new Date(val);
        const now = new Date();
        return selectedDate >= now;
    }, {
        message: "Event date cannot be in the past",
    }),
    eventSeatCapacity: z.string().refine((val) => {
        const num = Number(val);
        return !isNaN(num) && num >= 1 && num <= 100;
    }, {
        message: "Capacity must be between 1 and 100",
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
    const getMinDateTime = () => {
        const now = new Date();
        now.setMinutes(now.getMinutes() - now.getTimezoneOffset());
        return now.toISOString().slice(0, 16);
    };

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
            minTicketPrice: Number(data.price),
            eventDate: data.date,
            capacity: Number(data.eventSeatCapacity),
            locationId: data.location
        });
        reset();
        onOpenChange(false);
    }

    return (
        <Dialog open={open} onOpenChange={onOpenChange}>
            <DialogContent className="max-w-2xl max-h-[90vh] overflow-y-auto rounded-3xl border-none shadow-2xl p-0 overflow-hidden outline-none">
                <div className="h-1.5 w-full bg-gradient-to-r from-yellow-500 via-black to-yellow-500" />
                
                <div className="p-8">
                    <DialogHeader className="mb-6">
                        <DialogTitle className="text-3xl font-black uppercase italic tracking-tighter">
                            Create <span className="text-yellow-500">New Event</span>
                        </DialogTitle>
                        <DialogDescription className="font-medium text-gray-500">
                            Technical specifications deployment for the new event.
                        </DialogDescription>
                    </DialogHeader>

                    <form onSubmit={handleSubmit(onSubmit)} className="space-y-5">
                        <div className="space-y-1.5">
                            <label className="text-[10px] font-black uppercase tracking-widest text-gray-400 flex items-center gap-2">
                                <Type className="h-3 w-3 text-yellow-500" /> Event Name
                            </label>
                            <Input 
                                {...register("name")}
                                placeholder="e.g. Techno Night Vol. 1"
                                className="rounded-xl border-2 border-gray-100 bg-gray-50/50 h-12 focus:border-yellow-500 transition-all font-semibold"
                            />
                            {errors.name && <p className="text-[10px] font-bold text-red-500 uppercase italic flex items-center gap-1"><AlertCircle className="w-3 h-3"/> {errors.name.message}</p>}
                        </div>

                        <div className="space-y-1.5">
                            <label className="text-[10px] font-black uppercase tracking-widest text-gray-400 flex items-center gap-2">
                                <AlignLeft className="h-3 w-3 text-yellow-500" /> Description
                            </label>
                            <Textarea
                                {...register("description")}
                                placeholder="Details about the line-up..."
                                className="min-h-24 rounded-xl border-2 border-gray-100 bg-gray-50/50 focus:border-yellow-500 transition-all"
                            />
                            {errors.description && <p className="text-[10px] font-bold text-red-500 uppercase italic flex items-center gap-1"><AlertCircle className="w-3 h-3"/> {errors.description.message}</p>}
                        </div>

                        <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                            <div className="space-y-1.5">
                                <label className="text-[10px] font-black uppercase tracking-widest text-gray-400 flex items-center gap-2">
                                    <Calendar className="h-3 w-3 text-yellow-500" /> Event Date
                                </label>
                                <Input 
                                    type="datetime-local" 
                                    min={getMinDateTime()} 
                                    className="rounded-xl border-2 border-gray-100 bg-gray-50/50 h-12"
                                    {...register("date")} 
                                />
                                {errors.date && <p className="text-[10px] font-bold text-red-500 uppercase italic flex items-center gap-1"><AlertCircle className="w-3 h-3"/> {errors.date.message}</p>}
                            </div>

                            {/* Price */}
                            <div className="space-y-1.5">
                                <label className="text-[10px] font-black uppercase tracking-widest text-gray-400 flex items-center gap-2">
                                    <DollarSign className="h-3 w-3 text-yellow-500" /> Entry Price ($)
                                </label>
                                <Input 
                                    type="number" 
                                    step="0.01"
                                    placeholder="0.01"
                                    className="rounded-xl border-2 border-gray-100 bg-gray-50/50 h-12"
                                    {...register("price")} 
                                />
                                {errors.price && <p className="text-[10px] font-bold text-red-500 uppercase italic flex items-center gap-1"><AlertCircle className="w-3 h-3"/> {errors.price.message}</p>}
                            </div>
                        </div>

                        <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                            <div className="space-y-1.5">
                                <label className="text-[10px] font-black uppercase tracking-widest text-gray-400 flex items-center gap-2">
                                    <Users className="h-3 w-3 text-yellow-500" /> Max Capacity (Max 100)
                                </label>
                                <Input 
                                    type="number" 
                                    placeholder="100"
                                    className="rounded-xl border-2 border-gray-100 bg-gray-50/50 h-12"
                                    {...register("eventSeatCapacity")} 
                                />
                                {errors.eventSeatCapacity && <p className="text-[10px] font-bold text-red-500 uppercase italic flex items-center gap-1"><AlertCircle className="w-3 h-3"/> {errors.eventSeatCapacity.message}</p>}
                            </div>

                            <div className="space-y-1.5">
                                <label className="text-[10px] font-black uppercase tracking-widest text-gray-400 flex items-center gap-2">
                                    <MapPin className="h-3 w-3 text-yellow-500" /> Location Hub
                                </label>
                                <Controller
                                    name="location"
                                    control={control}
                                    render={({ field }) => (
                                        <Select onValueChange={field.onChange} value={field.value}>
                                            <SelectTrigger className="rounded-xl border-2 border-gray-100 bg-gray-50/50 h-12">
                                                <SelectValue placeholder="Select venue" />
                                            </SelectTrigger>
                                            <SelectContent className="rounded-xl border-none shadow-xl">
                                                {locations.map((loc) => (
                                                    <SelectItem key={loc.id} value={loc.id} className="focus:bg-yellow-50 focus:text-black font-medium">
                                                        {loc.name}
                                                    </SelectItem>
                                                ))}
                                            </SelectContent>
                                        </Select>
                                    )}
                                />
                                {errors.location && <p className="text-[10px] font-bold text-red-500 uppercase italic flex items-center gap-1"><AlertCircle className="w-3 h-3"/> {errors.location.message}</p>}
                            </div>
                        </div>

                        <DialogFooter className="pt-6 border-t border-gray-50 gap-3">
                            <Button 
                                type="button" 
                                variant="ghost" 
                                onClick={() => onOpenChange(false)} 
                                className="font-bold uppercase text-[10px] tracking-widest hover:bg-gray-100 rounded-xl px-8 h-12"
                            >
                                Abort
                            </Button>
                            <Button 
                                type="submit" 
                                className="bg-black text-white hover:bg-yellow-500 hover:text-black font-black uppercase tracking-widest px-10 h-12 rounded-xl transition-all shadow-lg active:scale-95"
                            >
                                Broadcast Event
                            </Button>
                        </DialogFooter>
                    </form>
                </div>
            </DialogContent>
        </Dialog>
    )
}