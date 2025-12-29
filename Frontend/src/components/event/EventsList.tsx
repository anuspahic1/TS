"use client"

import { Calendar, MapPin, Users, DollarSign, Edit, Trash2, Eye } from "lucide-react"
import { format } from "date-fns"
import {
    AlertDialog,
    AlertDialogAction,
    AlertDialogCancel,
    AlertDialogContent,
    AlertDialogDescription,
    AlertDialogFooter,
    AlertDialogHeader,
    AlertDialogTitle,
    AlertDialogTrigger,
} from "./../ui/alert-dialog"
import { Button } from "../ui/button"
import { Badge } from "../ui/badge"
import { Card, CardContent } from "../ui/card"
import type { Event as IEvent } from '../../types/IEvent'

interface EventsListProps {
    events: IEvent[]
    onEdit: (event: IEvent) => void
    onDelete: (eventId: string, locationId: string) => void
    onViewVisitors: (event: IEvent) => void
}

export function EventsList({ events, onEdit, onDelete, onViewVisitors }: EventsListProps) {
    if (events.length === 0) {
        return (
            <div className="flex flex-col items-center justify-center py-20 text-center bg-neutral-50 rounded-3xl border-2 border-dashed border-neutral-200">
                <div className="w-16 h-16 bg-neutral-100 rounded-full flex items-center justify-center mb-4">
                    <Calendar className="h-8 w-8 text-neutral-400" />
                </div>
                <h3 className="text-xl font-black italic uppercase tracking-tighter text-neutral-900">No events found</h3>
                <p className="text-sm text-neutral-500 font-bold uppercase tracking-widest mt-1">Start by creating your first masterpiece</p>
            </div>
        )
    }

    return (
        <div className="grid gap-6 md:grid-cols-2 p-6">
            {events.map((event) => {
                const eventDate = new Date(event.date)
                const isPast = eventDate < new Date()
                const occupancy = event.visitors.length
                const occupancyPercentage = Math.min((occupancy / event.eventSeatCapacity) * 100, 100)

                return (
                    <Card key={event.id} className="group relative overflow-hidden border-neutral-100 shadow-sm hover:shadow-xl transition-all duration-500 rounded-2xl bg-white">
                        {/* Status Badge u uglu */}
                        <div className="absolute top-4 right-4 z-10">
                            <Badge
                                className={`font-black uppercase italic tracking-widest text-[9px] px-3 py-1 rounded-full border-none shadow-sm ${
                                    isPast 
                                    ? "bg-neutral-200 text-neutral-500" 
                                    : "bg-yellow-500 text-neutral-900"
                                }`}
                            >
                                {isPast ? "Archive" : "Active"}
                            </Badge>
                        </div>

                        <CardContent className="p-6">
                            {/* Header: Naslov i Opis */}
                            <div className="mb-6">
                                <h3 className="text-2xl font-black italic uppercase tracking-tighter text-neutral-900 group-hover:text-yellow-600 transition-colors line-clamp-1">
                                    {event.name}
                                </h3>
                                <p className="text-neutral-500 text-xs font-bold uppercase tracking-tight line-clamp-2 mt-1 min-h-[32px]">
                                    {event.description}
                                </p>
                            </div>

                            {/* Info Grid */}
                            <div className="grid grid-cols-2 gap-4 mb-6">
                                <div className="flex items-center gap-3">
                                    <div className="w-8 h-8 rounded-lg bg-neutral-50 flex items-center justify-center text-neutral-900">
                                        <Calendar className="h-4 w-4" />
                                    </div>
                                    <div>
                                        <p className="text-[9px] font-black uppercase text-neutral-400 leading-none mb-1">Date</p>
                                        <p className="text-xs font-bold text-neutral-900">{format(eventDate, "MMM dd, yyyy")}</p>
                                    </div>
                                </div>
                                <div className="flex items-center gap-3">
                                    <div className="w-8 h-8 rounded-lg bg-neutral-50 flex items-center justify-center text-neutral-900">
                                        <MapPin className="h-4 w-4" />
                                    </div>
                                    <div>
                                        <p className="text-[9px] font-black uppercase text-neutral-400 leading-none mb-1">Location</p>
                                        <p className="text-xs font-bold text-neutral-900 truncate max-w-[100px]">{event.location}</p>
                                    </div>
                                </div>
                                <div className="flex items-center gap-3">
                                    <div className="w-8 h-8 rounded-lg bg-neutral-50 flex items-center justify-center text-neutral-900">
                                        <DollarSign className="h-4 w-4" />
                                    </div>
                                    <div>
                                        <p className="text-[9px] font-black uppercase text-neutral-400 leading-none mb-1">Price</p>
                                        <p className="text-xs font-bold text-neutral-900">${event.price.toFixed(2)}</p>
                                    </div>
                                </div>
                                <div className="flex items-center gap-3">
                                    <div className="w-8 h-8 rounded-lg bg-neutral-50 flex items-center justify-center text-neutral-900">
                                        <Users className="h-4 w-4" />
                                    </div>
                                    <div>
                                        <p className="text-[9px] font-black uppercase text-neutral-400 leading-none mb-1">Capacity</p>
                                        <p className="text-xs font-bold text-neutral-900">{event.eventSeatCapacity}</p>
                                    </div>
                                </div>
                            </div>

                            {/* Capacity Progress Bar */}
                            <div className="mb-8">
                                <div className="flex justify-between items-end mb-2">
                                    <p className="text-[10px] font-black uppercase tracking-widest text-neutral-900">Occupancy</p>
                                    <p className="text-xs font-black italic text-neutral-900">{occupancyPercentage.toFixed(0)}%</p>
                                </div>
                                <div className="h-2 bg-neutral-100 rounded-full overflow-hidden">
                                    <div 
                                        className={`h-full transition-all duration-1000 ${
                                            occupancyPercentage > 80 ? 'bg-red-500' : 'bg-yellow-500'
                                        }`}
                                        style={{ width: `${occupancyPercentage}%` }}
                                    />
                                </div>
                                <p className="text-[9px] font-bold text-neutral-400 mt-2 uppercase">
                                    {occupancy} visitors registered so far
                                </p>
                            </div>

                            {/* Actions */}
                            <div className="flex gap-2 pt-4 border-t border-neutral-50">
                                <Button
                                    variant="outline"
                                    size="sm"
                                    className="flex-1 rounded-xl border-2 border-neutral-900 bg-neutral-900 text-white font-black uppercase italic text-[10px] tracking-widest hover:bg-white hover:text-neutral-900 transition-all gap-2"
                                    onClick={() => onViewVisitors(event)}
                                >
                                    <Eye className="h-3.5 w-3.5 stroke-[3px]" />
                                    Visitors
                                </Button>
                                
                                <Button
                                    variant="outline"
                                    size="sm"
                                    className="rounded-xl border-2 border-neutral-100 hover:border-yellow-500 hover:bg-yellow-50 transition-all"
                                    onClick={() => onEdit(event)}
                                >
                                    <Edit className="h-4 w-4 text-neutral-900" />
                                </Button>

                                <AlertDialog>
                                    <AlertDialogTrigger asChild>
                                        <Button
                                            variant="outline"
                                            size="sm"
                                            className="rounded-xl border-2 border-neutral-100 hover:border-red-500 hover:bg-red-50 transition-all"
                                        >
                                            <Trash2 className="h-4 w-4 text-neutral-900 hover:text-red-600" />
                                        </Button>
                                    </AlertDialogTrigger>
                                    <AlertDialogContent className="rounded-3xl border-none">
                                        <AlertDialogHeader>
                                            <AlertDialogTitle className="text-2xl font-black italic uppercase tracking-tighter">Terminate Event?</AlertDialogTitle>
                                            <AlertDialogDescription className="font-medium text-neutral-500">
                                                Are you sure you want to delete <span className="text-neutral-900 font-bold">"{event.name}"</span>? 
                                                This action is irreversible and all visitor data will be purged.
                                            </AlertDialogDescription>
                                        </AlertDialogHeader>
                                        <AlertDialogFooter>
                                            <AlertDialogCancel className="rounded-xl font-bold uppercase tracking-widest text-[10px]">Back</AlertDialogCancel>
                                            <AlertDialogAction
                                                onClick={() => onDelete(event.id, event.locationId)}
                                                className="bg-red-600 text-white hover:bg-red-700 rounded-xl font-black uppercase tracking-widest text-[10px]"
                                            >
                                                Confirm Delete
                                            </AlertDialogAction>
                                        </AlertDialogFooter>
                                    </AlertDialogContent>
                                </AlertDialog>
                            </div>
                        </CardContent>
                    </Card>
                )
            })}
        </div>
    )
}