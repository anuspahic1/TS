"use client"

import { useForm, Controller } from "react-hook-form"
import type { SubmitHandler } from "react-hook-form"
import { zodResolver } from "@hookform/resolvers/zod"
import * as z from "zod"
import { Calendar, DollarSign, Users, MapPin, PlusCircle, AlertCircle } from "lucide-react"

import { Button } from "../ui/button"
import {
    Dialog,
    DialogContent,
    DialogHeader,
    DialogTitle,
    DialogFooter,
} from "../ui/dialog"
import { Input } from "../ui/input"
import { Textarea } from "../ui/textarea"
import { Select, SelectContent, SelectItem, SelectValue, SelectTrigger } from "../ui/select"

export const eventSchema = z.object({
    name: z.string()
        .min(3, "Title must be at least 3 characters")
        .max(50, "Title too long"),
    description: z.string()
        .min(11, "Description must be longer than 10 characters"),
    minTicketPrice: z.coerce.number()
        .min(0, "Price cannot be negative"),
    eventDate: z.string()
        .min(1, "Date and time are required")
        .refine((val) => {
            const selectedDate = new Date(val);
            const now = new Date();
            return selectedDate > now;
        }, { message: "Event date must be in the future" }),
    capacity: z.coerce.number()
        .int("Must be a whole number")
        .positive("Capacity must be at least 1"),
    locationId: z.string()
        .min(1, "Please select a venue"),
})

export type EventFormData = z.infer<typeof eventSchema>

interface CreateEventDialogProps {
    open: boolean
    onOpenChange: (open: boolean) => void
    onCreateEvent: (data: EventFormData) => void
    locations: any[]
}

export function CreateEventDialog({ locations, open, onOpenChange, onCreateEvent }: CreateEventDialogProps) {
    const {
        register,
        handleSubmit,
        control,
        reset,
        formState: { errors, isSubmitting },
    } = useForm<EventFormData>({
        resolver: zodResolver(eventSchema) as any,
        mode: "onChange", 
        defaultValues: {
            name: "",
            description: "",
            minTicketPrice: 0,
            eventDate: "",
            capacity: 0,
            locationId: "",
        },
    })

   const processData: SubmitHandler<EventFormData> = async (data) => { 
    await onCreateEvent(data); 
    reset();
    onOpenChange(false); 
}

    const ErrorMessage = ({ message }: { message?: string }) => (
        message ? (
            <p className="text-[10px] font-bold text-red-500 uppercase mt-1 flex items-center gap-1 animate-in fade-in slide-in-from-top-1">
                <AlertCircle className="w-3 h-3" /> {message}
            </p>
        ) : null
    );

    return (
        <Dialog open={open} onOpenChange={onOpenChange}>
            <DialogContent className="max-w-2xl bg-white rounded-3xl border-none shadow-2xl p-0 overflow-hidden outline-none">
                <DialogHeader className="bg-neutral-900 p-8 text-left border-none">
                    <span className="text-[10px] font-black uppercase tracking-[0.4em] text-yellow-500 block mb-2">
                        System Terminal
                    </span>
                    <DialogTitle className="text-3xl font-black italic uppercase tracking-tighter text-white">
                        Deploy New Event
                    </DialogTitle>
                </DialogHeader>

                <form onSubmit={handleSubmit(processData)} className="p-8 space-y-6">
                    <div className="space-y-1.5">
                        <label className="text-[10px] font-black uppercase tracking-widest text-neutral-400 ml-1">Event Title</label>
                        <Input 
                            {...register("name")}
                            placeholder="Enter catchy name..."
                            className={`rounded-xl border-2 h-12 transition-all ${errors.name ? 'border-red-500 bg-red-50' : 'border-neutral-100 bg-neutral-50 focus:border-yellow-500'}`}
                        />
                        <ErrorMessage message={errors.name?.message} />
                    </div>

                    <div className="space-y-1.5">
                        <label className="text-[10px] font-black uppercase tracking-widest text-neutral-400 ml-1">Description</label>
                        <Textarea
                            {...register("description")}
                            placeholder="Must be longer than 10 characters..."
                            className={`min-h-[100px] rounded-xl border-2 transition-all ${errors.description ? 'border-red-500 bg-red-50' : 'border-neutral-100 bg-neutral-50 focus:border-yellow-500'}`}
                        />
                        <ErrorMessage message={errors.description?.message} />
                    </div>

                    <div className="grid grid-cols-2 gap-4">
                        <div className="space-y-1.5">
                            <label className="text-[10px] font-black uppercase tracking-widest text-neutral-400 ml-1 flex items-center gap-1">
                                <Calendar className="w-3 h-3 text-yellow-500" /> Future Date
                            </label>
                            <Input 
                                type="datetime-local" 
                                {...register("eventDate")} 
                                className={`rounded-xl border-2 h-12 transition-all ${errors.eventDate ? 'border-red-500 bg-red-50' : 'bg-neutral-50 border-neutral-100'}`} 
                            />
                            <ErrorMessage message={errors.eventDate?.message} />
                        </div>
                        <div className="space-y-1.5">
                            <label className="text-[10px] font-black uppercase tracking-widest text-neutral-400 ml-1 flex items-center gap-1">
                                <DollarSign className="w-3 h-3 text-yellow-500" /> Price ($)
                            </label>
                            <Input 
                                type="number" 
                                step="0.01" 
                                {...register("minTicketPrice")} 
                                className={`rounded-xl border-2 h-12 transition-all ${errors.minTicketPrice ? 'border-red-500 bg-red-50' : 'bg-neutral-50 border-neutral-100'}`} 
                            />
                            <ErrorMessage message={errors.minTicketPrice?.message} />
                        </div>
                    </div>

                    <div className="grid grid-cols-2 gap-4">
                        <div className="space-y-1.5">
                            <label className="text-[10px] font-black uppercase tracking-widest text-neutral-400 ml-1 flex items-center gap-1">
                                <Users className="w-3 h-3 text-yellow-500" /> Max Capacity
                            </label>
                            <Input 
                                type="number" 
                                {...register("capacity")} 
                                className={`rounded-xl border-2 h-12 transition-all ${errors.capacity ? 'border-red-500 bg-red-50' : 'bg-neutral-50 border-neutral-100'}`} 
                            />
                            <ErrorMessage message={errors.capacity?.message} />
                        </div>
                        <div className="space-y-1.5">
                            <label className="text-[10px] font-black uppercase tracking-widest text-neutral-400 ml-1 flex items-center gap-1">
                                <MapPin className="w-3 h-3 text-yellow-500" /> Venue
                            </label>
                            <Controller
                                name="locationId"
                                control={control}
                                render={({ field }) => (
                                    <Select onValueChange={field.onChange} value={field.value}>
                                        <SelectTrigger className={`rounded-xl border-2 h-12 transition-all ${errors.locationId ? 'border-red-500 bg-red-50' : 'bg-neutral-50 border-neutral-100'}`}>
                                            <SelectValue placeholder="Select venue" />
                                        </SelectTrigger>
                                        <SelectContent>
                                            {locations.map((loc) => (
                                                <SelectItem key={loc.id} value={loc.id}>{loc.name}</SelectItem>
                                            ))}
                                        </SelectContent>
                                    </Select>
                                )}
                            />
                            <ErrorMessage message={errors.locationId?.message} />
                        </div>
                    </div>

                    <DialogFooter className="pt-6 border-t border-neutral-50 gap-2">
                        <Button 
                            type="button" 
                            variant="ghost" 
                            onClick={() => onOpenChange(false)} 
                            className="font-bold uppercase tracking-widest text-[10px] hover:bg-neutral-50"
                        >
                            Abort
                        </Button>
                        <Button 
                            type="submit" 
                            disabled={isSubmitting}
                            className="bg-neutral-900 text-white hover:bg-yellow-500 hover:text-neutral-900 px-10 rounded-full font-black uppercase italic tracking-widest text-[11px] h-14 transition-all shadow-xl active:scale-95"
                        >
                            {isSubmitting ? "Processing..." : (
                                <span className="flex items-center gap-2">
                                    <PlusCircle className="w-5 h-5" /> Launch Event
                                </span>
                            )}
                        </Button>
                    </DialogFooter>
                </form>
            </DialogContent>
        </Dialog>
    )
}