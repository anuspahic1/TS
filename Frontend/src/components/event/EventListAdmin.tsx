"use client"

import type { Event as IEvent } from "../../types/IEvent"
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "../ui/card"
import { Calendar, MapPin, Users, DollarSign, Edit, Trash2, Eye, LayoutGrid, AlertCircle } from "lucide-react"
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

interface EventsListProps {
    events: IEvent[]
    onEdit: (event: IEvent) => void
    onDelete: (id: string, locationId: string) => void
    onViewVisitors: (event: IEvent) => void
}

export function EventsList({ events, onEdit, onDelete, onViewVisitors }: EventsListProps) {
    
    if (events.length === 0) {
        return (
            <div className="flex flex-col items-center justify-center py-20 text-center border-2 border-dashed border-gray-100 rounded-[2rem] bg-gray-50/30 m-4">
                <div className="bg-white p-4 rounded-2xl shadow-sm mb-4">
                    <LayoutGrid className="h-10 w-10 text-yellow-500" />
                </div>
                <h3 className="text-xl font-black uppercase italic tracking-tighter text-black">
                    Event Hub Empty
                </h3>
                <p className="text-sm text-gray-400 font-medium max-w-[250px] mt-2">
                    No active transmissions found. Use the "Create Event" button to broadcast your first entry.
                </p>
            </div>
        )
    }

    return (
        <div className="grid gap-6 p-4 md:grid-cols-2 lg:grid-cols-2">
            {events.map((event) => {
                const eventDate = new Date(event.date)
                const isPast = eventDate < new Date()
                
                const occupancy = event.visitors?.length || 0
                const capacity = event.eventSeatCapacity || 1
                const occupancyPercentage = Math.min((occupancy / capacity) * 100, 100)

                return (
                    <Card key={event.id} className="group relative overflow-hidden border-none shadow-sm hover:shadow-xl transition-all duration-300 bg-white rounded-[2rem]">
                        <div className={`h-1.5 w-full ${isPast ? 'bg-gray-200' : 'bg-yellow-500'}`} />
                        
                        <CardHeader className="pb-2">
                            <div className="flex items-start justify-between gap-4">
                                <div className="space-y-1">
                                    <div className="flex items-center gap-2">
                                        <Badge 
                                            variant="outline" 
                                            className={`rounded-md uppercase tracking-widest text-[9px] font-black px-2 py-0.5 ${
                                                isPast ? "border-gray-200 text-gray-400" : "border-yellow-500/30 text-yellow-600 bg-yellow-50"
                                            }`}
                                        >
                                            {isPast ? "Archived" : "Live Transmission"}
                                        </Badge>
                                        <span className="text-[9px] font-black uppercase tracking-widest text-gray-300">
                                            SN: {event.id.slice(0, 8)}
                                        </span>
                                    </div>
                                    <CardTitle className="text-2xl font-black uppercase italic tracking-tighter group-hover:text-yellow-600 transition-colors">
                                        {event.name}
                                    </CardTitle>
                                    <CardDescription className="line-clamp-1 font-medium text-gray-400">
                                        {event.description}
                                    </CardDescription>
                                </div>
                            </div>
                        </CardHeader>

                        <CardContent className="space-y-6">
                            <div className="grid grid-cols-2 gap-4 py-4 border-y border-gray-50">
                                <div className="flex items-center gap-3 text-sm font-bold text-gray-600">
                                    <div className="p-2 bg-gray-50 rounded-xl group-hover:bg-yellow-100 transition-colors">
                                        <Calendar className="h-4 w-4 text-black" />
                                    </div>
                                    <span className="truncate">{format(eventDate, "PPP")}</span>
                                </div>
                                <div className="flex items-center gap-3 text-sm font-bold text-gray-600">
                                    <div className="p-2 bg-gray-50 rounded-xl group-hover:bg-yellow-100 transition-colors">
                                        <MapPin className="h-4 w-4 text-black" />
                                    </div>
                                    <span className="truncate">{event.location}</span>
                                </div>
                                <div className="flex items-center gap-3 text-sm font-bold text-gray-600">
                                    <div className="p-2 bg-gray-50 rounded-xl group-hover:bg-yellow-100 transition-colors">
                                        <DollarSign className="h-4 w-4 text-black" />
                                    </div>
                                    <span>${event.price.toFixed(2)}</span>
                                </div>
                                <div className="flex items-center gap-3 text-sm font-bold text-gray-600">
                                    <div className="p-2 bg-gray-50 rounded-xl group-hover:bg-yellow-100 transition-colors">
                                        <Users className="h-4 w-4 text-black" />
                                    </div>
                                    <span>{capacity} Cap</span>
                                </div>
                            </div>

                            <div className="space-y-2">
                                <div className="flex justify-between items-end px-1">
                                    <span className="text-[10px] font-black uppercase tracking-widest text-gray-400 flex items-center gap-1">
                                        <AlertCircle className="h-3 w-3" /> Booking Load
                                    </span>
                                    <span className="text-sm font-black italic">
                                        {occupancy}/{capacity} 
                                        <span className="text-gray-400 text-[10px] ml-1 not-italic">
                                            ({occupancyPercentage.toFixed(0)}%)
                                        </span>
                                    </span>
                                </div>
                                <div className="h-2.5 w-full bg-gray-100 rounded-full overflow-hidden shadow-inner">
                                    <div 
                                        className={`h-full transition-all duration-1000 ease-out ${
                                            occupancyPercentage >= 90 ? 'bg-red-500' : 
                                            occupancyPercentage >= 70 ? 'bg-yellow-500' : 'bg-black'
                                        }`} 
                                        style={{ width: `${occupancyPercentage}%` }}
                                    />
                                </div>
                            </div>

                            <div className="flex gap-2 pt-2">
                                <Button
                                    onClick={() => onViewVisitors(event)}
                                    className="flex-1 bg-black text-white hover:bg-yellow-500 hover:text-black font-black uppercase tracking-widest text-[10px] rounded-2xl h-12 shadow-sm transition-all border-none"
                                >
                                    <Eye className="mr-2 h-4 w-4" /> View Visitors
                                </Button>
                                
                                <Button
                                    variant="outline"
                                    onClick={() => onEdit(event)}
                                    className="border-gray-200 hover:border-black hover:bg-black hover:text-white rounded-2xl h-12 w-12 p-0 transition-all shadow-sm"
                                >
                                    <Edit className="h-4 w-4" />
                                </Button>

                                <AlertDialog>
                                    <AlertDialogTrigger asChild>
                                        <Button
                                            variant="outline"
                                            className="border-gray-200 hover:bg-red-50 hover:text-red-600 hover:border-red-200 rounded-2xl h-12 w-12 p-0 shadow-sm"
                                        >
                                            <Trash2 className="h-4 w-4" />
                                        </Button>
                                    </AlertDialogTrigger>
                                    <AlertDialogContent className="rounded-[2rem] border-none shadow-2xl">
                                        <AlertDialogHeader>
                                            <AlertDialogTitle className="text-2xl font-black uppercase italic tracking-tighter">
                                                Terminate <span className="text-red-600">Event?</span>
                                            </AlertDialogTitle>
                                            <AlertDialogDescription className="font-medium text-gray-500">
                                                Confirming this will erase <span className="text-black font-bold">"{event.name}"</span> from the database. This action is irreversible.
                                            </AlertDialogDescription>
                                        </AlertDialogHeader>
                                        <AlertDialogFooter className="gap-2">
                                            <AlertDialogCancel className="rounded-xl font-bold border-gray-200">Abort</AlertDialogCancel>
                                            <AlertDialogAction
                                                onClick={() => onDelete(event.id, event.locationId || "")}
                                                className="bg-red-600 text-white hover:bg-red-700 rounded-xl font-bold"
                                            >
                                                Execute Delete
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