"use client"

import type { Event } from "../../types/IEvent"

import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "../ui/card"

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
import type { Event as IEvent } from '../../types/IEvent'

interface EventsListProps {
    events: IEvent[]
    onEdit: any
    onDelete: any
    onViewVisitors: any
}

export function EventsList({ events, onEdit, onDelete }: EventsListProps) {
    if (events.length === 0) {
        return (
            <div className="flex flex-col items-center justify-center py-12 text-center">
                <Calendar className="h-12 w-12 text-gray-400 mb-4" />
                <h3 className="text-lg font-semibold mb-2 text-black">No events found</h3>
                <p className="text-sm text-gray-600 mb-4">Get started by creating your first event</p>
            </div>
        )
    }

    return (
        <div className="grid gap-4 md:grid-cols-2">
            {events.map((event) => {
                const eventDate = new Date(event.date)
                const isPast = eventDate < new Date()
                const occupancy = event.visitors.length
                const occupancyPercentage = (occupancy / event.eventSeatCapacity) * 100

                return (
                    <Card key={event.id} className="relative overflow-hidden border-gray-200 hover:shadow-md transition-shadow">
                        <CardHeader>
                            <div className="flex items-start justify-between gap-4">
                                <div className="flex-1">
                                    <CardTitle className="text-xl mb-2 text-black">{event.name}</CardTitle>
                                    <CardDescription className="line-clamp-2">{event.description}</CardDescription>
                                </div>
                                <Badge
                                    variant={isPast ? "secondary" : "default"}
                                    className={isPast ? "bg-gray-200 text-gray-700" : "bg-black text-white"}
                                >
                                    {isPast ? "Past" : "Upcoming"}
                                </Badge>
                            </div>
                        </CardHeader>
                        <CardContent>
                            <div className="space-y-3 mb-4">
                                <div className="flex items-center gap-2 text-sm text-gray-700">
                                    <Calendar className="h-4 w-4 text-muted-foreground" />
                                    <span>{format(eventDate, "PPP")}</span>
                                </div>
                                <div className="flex items-center gap-2 text-sm text-gray-700">
                                    <MapPin className="h-4 w-4 text-muted-foreground" />
                                    <span>{event.location}</span>
                                </div>
                                <div className="flex items-center gap-2 text-sm text-gray-700">
                                    <DollarSign className="h-4 w-4 text-muted-foreground" />
                                    <span>${event.price.toFixed(2)}</span>
                                </div>
                                <div className="flex items-center gap-2 text-sm text-gray-700">
                                    <Users className="h-4 w-4 text-gray-500" />
                                    <span>
                                        {occupancy} / {event.eventSeatCapacity} seats
                                        <span className="text-gray-500 ml-1">({occupancyPercentage.toFixed(0)}% full)</span>
                                    </span>
                                </div>
                            </div>

                            <div className="flex gap-2">
                                <Button
                                    variant="outline"
                                    size="sm"
                                    className="flex-1 border-gray-300 hover:bg-gray-50 bg-transparent"
                                //onClick={() => onViewVisitors(event)}
                                >
                                    <Eye className="mr-2 h-4 w-4" />
                                    View Visitors
                                </Button>
                                <Button
                                    variant="outline"
                                    size="sm"
                                    className="border-gray-300 hover:bg-gray-50 bg-transparent"
                                    onClick={() => onEdit(event)}
                                >
                                    <Edit className="h-4 w-4" />
                                </Button>
                                <AlertDialog>
                                    <AlertDialogTrigger asChild>
                                        <Button
                                            variant="outline"
                                            size="sm"
                                            className="border-gray-300 hover:bg-red-50 hover:text-red-600 hover:border-red-300 bg-transparent"
                                        >
                                            <Trash2 className="h-4 w-4" />
                                        </Button>
                                    </AlertDialogTrigger>
                                    <AlertDialogContent>
                                        <AlertDialogHeader>
                                            <AlertDialogTitle>Delete Event?</AlertDialogTitle>
                                            <AlertDialogDescription>
                                                Are you sure you want to delete "{event.name}"? This action cannot be undone. All visitor
                                                registrations will also be deleted.
                                            </AlertDialogDescription>
                                        </AlertDialogHeader>
                                        <AlertDialogFooter>
                                            <AlertDialogCancel>Cancel</AlertDialogCancel>
                                            <AlertDialogAction
                                                onClick={() => onDelete(event.id, event.locationId)}
                                                className="bg-red-600 text-white hover:bg-red-700"
                                            >
                                                Delete
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
