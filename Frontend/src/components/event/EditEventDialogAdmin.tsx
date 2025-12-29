"use client"

import { useEffect } from "react"
import { useForm, Controller } from "react-hook-form"
import type { SubmitHandler } from "react-hook-form"
import { zodResolver } from "@hookform/resolvers/zod"
import { Calendar, DollarSign, Users, MapPin, Save, AlertCircle } from "lucide-react"

import { Button } from "../ui/button"
import {
    Dialog,
    DialogContent,
    DialogFooter,
    DialogHeader,
    DialogTitle,
    DialogDescription, 
} from "../ui/dialog"
import { Input } from "../ui/input"
import { Textarea } from "../ui/textarea"
import { Select, SelectContent, SelectItem, SelectValue, SelectTrigger } from "../ui/select"
import { eventSchema, type EventFormData } from "./CreateEventDialog"

interface EditEventDialogProps {
    open: boolean
    onOpenChange: (open: boolean) => void
    event: any 
    onUpdateEvent: (locationId: string, eventId: string, data: any) => void
    locations: any[]
}

export function EditEventDialog({ locations, open, onOpenChange, event, onUpdateEvent }: EditEventDialogProps) {
    
    const getMinDateTime = () => {
        const now = new Date();
        now.setMinutes(now.getMinutes() - now.getTimezoneOffset());
        return now.toISOString().slice(0, 16);
    };

    const formatForInput = (dateString: string) => {
        if (!dateString) return "";
        const d = new Date(dateString);
        return new Date(d.getTime() - d.getTimezoneOffset() * 60000).toISOString().slice(0, 16);
    }

    const {
        register,
        handleSubmit,
        control,
        reset,
        formState: { errors, isSubmitting },
    } = useForm<EventFormData>({
        resolver: zodResolver(eventSchema) as any,
        mode: "onSubmit", 
    })

    useEffect(() => {
    if (open && event) {
        reset({
            name: event.name || "",
            description: event.description || "",
            minTicketPrice: Number((event.minTicketPrice ?? event.price) || 0),
            eventDate: formatForInput(event.eventDate || event.date || ""),
            capacity: Number((event.capacity ?? event.eventSeatCapacity) ?? 1),
            locationId: typeof event.locationId === 'string' 
                ? event.locationId 
                : (event.location?.id || ""),
        });
    }
}, [open, event, reset]);


const processUpdate: SubmitHandler<EventFormData> = async (formData) => {
    const eventId = event.id || event.eventId;

    const originalLocationId = event.locationId || event.location?.id || event.location?.locationId;

    if (!eventId || !originalLocationId) {
        console.error("Missing IDs. Check the 'event' object structure.");
        return;
    }

    try {
        await onUpdateEvent(originalLocationId, eventId, formData);
        onOpenChange(false);
    } catch (err) {
    }
};

const ErrorMessage = ({ message }: { message?: string }) => (
    message ? (
        <p className="text-[10px] font-black text-red-500 uppercase mt-1 flex items-center gap-1">
            <AlertCircle className="w-3 h-3" /> {message}
        </p>
    ) : null
);

    if (!event) return null;

    return (
        <Dialog open={open} onOpenChange={onOpenChange}>
            <DialogContent className="max-w-2xl bg-white rounded-3xl border-none shadow-2xl p-0 overflow-hidden outline-none">
                <DialogHeader className="bg-neutral-900 p-8 text-left border-none">
                    <span className="text-[10px] font-black uppercase tracking-[0.4em] text-yellow-500 block mb-2">
                        Configuration Mode
                    </span>
                    <DialogTitle className="text-3xl font-black italic uppercase tracking-tighter text-white">
                        Update Deployment
                    </DialogTitle>
                    <DialogDescription className="text-neutral-400 text-xs">
                        Adjust parameters for existing event deployment.
                    </DialogDescription>
                </DialogHeader>

                <form onSubmit={handleSubmit(processUpdate)} className="p-8 space-y-6">
                    <div className="space-y-1.5">
                        <label className="text-[10px] font-black uppercase tracking-widest text-neutral-400 ml-1">Event Title</label>
                        <Input 
                            {...register("name")}
                            className={`rounded-xl border-2 h-12 transition-all ${errors.name ? 'border-red-500 bg-red-50' : 'border-neutral-100 bg-neutral-50 focus:border-yellow-500'}`}
                        />
                        <ErrorMessage message={errors.name?.message} />
                    </div>

                    <div className="space-y-1.5">
                        <label className="text-[10px] font-black uppercase tracking-widest text-neutral-400 ml-1">Mission Description</label>
                        <Textarea
                            {...register("description")}
                            className={`min-h-[100px] rounded-xl border-2 transition-all ${errors.description ? 'border-red-500 bg-red-50' : 'border-neutral-100 bg-neutral-50 focus:border-yellow-500'}`}
                        />
                        <ErrorMessage message={errors.description?.message} />
                    </div>

                    <div className="grid grid-cols-2 gap-4">
                        <div className="space-y-1.5">
                            <label className="text-[10px] font-black uppercase tracking-widest text-neutral-400 ml-1 flex items-center gap-1">
                                <Calendar className="w-3 h-3 text-yellow-500" /> New Date
                            </label>
                            <Input 
                                type="datetime-local" 
                                min={getMinDateTime()}
                                {...register("eventDate")} 
                                className={`rounded-xl border-2 h-12 transition-all ${errors.eventDate ? 'border-red-500 bg-red-50' : 'bg-neutral-50 border-neutral-100'}`} 
                            />
                            <ErrorMessage message={errors.eventDate?.message} />
                        </div>
                        <div className="space-y-1.5">
                            <label className="text-[10px] font-black uppercase tracking-widest text-neutral-400 ml-1 flex items-center gap-1">
                                <DollarSign className="w-3 h-3 text-yellow-500" /> Ticket Price
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
                                <MapPin className="w-3 h-3 text-yellow-500" /> Target Venue
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
                            Cancel Changes
                        </Button>
                        <Button 
                            type="submit" 
                            disabled={isSubmitting}
                            className="bg-neutral-900 text-white hover:bg-yellow-500 hover:text-neutral-900 px-10 rounded-full font-black uppercase italic tracking-widest text-[11px] h-14 transition-all shadow-xl active:scale-95"
                        >
                            {isSubmitting ? "Syncing..." : (
                                <span className="flex items-center gap-2">
                                    <Save className="w-5 h-5" /> Commit Changes
                                </span>
                            )}
                        </Button>
                    </DialogFooter>
                </form>
            </DialogContent>
        </Dialog>
    )
}