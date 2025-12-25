"use client"

import type { Event } from "../../types/IEvent"
import { Dialog, DialogContent, DialogDescription, DialogHeader, DialogTitle } from "../ui/dialog"
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "../ui/table"
import { Badge } from "../ui/badge"
import { format } from "date-fns"
import { Users, Mail, Calendar } from "lucide-react"

interface ViewVisitorsDialogProps {
    open: boolean
    onOpenChange: (open: boolean) => void
    event: any
}

export function ViewVisitorsDialog({ open, onOpenChange, event }: ViewVisitorsDialogProps) {
    const occupancyPercentage = (event.visitors.length / event.eventSeatCapacity) * 100

    return (
        <Dialog open={open} onOpenChange={onOpenChange}>
            <DialogContent className="max-w-3xl max-h-[90vh] overflow-y-auto">
                <DialogHeader>
                    <DialogTitle className="text-2xl">{event.name}</DialogTitle>
                    <DialogDescription>Registered visitors for this event</DialogDescription>
                </DialogHeader>

                <div className="space-y-6">
                    {/* Event Stats */}
                    <div className="grid gap-4 md:grid-cols-3">
                        <div className="flex items-center gap-3 p-4 rounded-lg bg-gray-50 border border-gray-200">
                            <Users className="h-8 w-8 text-primary" />
                            <div>
                                <p className="text-2xl font-bold text-black">{event.visitors.length}</p>
                                <p className="text-sm text-gray-600">Total Visitors</p>
                            </div>
                        </div>
                        <div className="flex items-center gap-3 p-4 rounded-lg bg-gray-50 border border-gray-200">
                            <Users className="h-8 w-8 text-gray-500" />
                            <div>
                                <p className="text-2xl font-bold text-black">{event.eventSeatCapacity}</p>
                                <p className="text-sm text-gray-600">Total Capacity</p>
                            </div>
                        </div>
                        <div className="flex items-center gap-3 p-4 rounded-lg bg-gray-50 border border-gray-200">
                            <div className="flex-1">
                                <p className="text-2xl font-bold text-black">{occupancyPercentage.toFixed(0)}%</p>
                                <p className="text-sm text-gray-600">Occupancy</p>
                            </div>
                            <Badge
                                variant={occupancyPercentage > 80 ? "default" : "secondary"}
                                className={occupancyPercentage > 80 ? "bg-black text-white" : "bg-gray-200 text-gray-700"}
                            >
                                {occupancyPercentage > 80 ? "High" : "Available"}
                            </Badge>
                        </div>
                    </div>

                    {/* Visitors Table */}
                    <div>
                        <h3 className="text-lg font-semibold mb-4 text-black">Visitor List</h3>
                        {event.visitors.length === 0 ? (
                            <div className="flex flex-col items-center justify-center py-12 text-center border border-gray-200 rounded-lg bg-gray-50">
                                <Users className="h-12 w-12 text-gray-400 mb-4" />
                                <p className="text-sm text-gray-600">No visitors registered yet</p>
                            </div>
                        ) : (
                            <div className="border border-gray-200 rounded-lg">
                                <Table>
                                    <TableHeader>
                                        <TableRow>
                                            <TableHead>Name</TableHead>
                                            <TableHead>Email</TableHead>
                                            <TableHead>Registered Date</TableHead>
                                        </TableRow>
                                    </TableHeader>
                                    <TableBody>
                                        {event.visitors.map((visitor: any) => (
                                            <TableRow key={visitor.id}>
                                                <TableCell className="font-medium">{visitor.name}</TableCell>
                                                <TableCell>
                                                    <div className="flex items-center gap-2">
                                                        <Mail className="h-4 w-4 text-muted-foreground" />
                                                        {visitor.email}
                                                    </div>
                                                </TableCell>
                                                <TableCell>
                                                    <div className="flex items-center gap-2">
                                                        <Calendar className="h-4 w-4 text-muted-foreground" />
                                                        {format(new Date(visitor.registeredAt), "PPP")}
                                                    </div>
                                                </TableCell>
                                            </TableRow>
                                        ))}
                                    </TableBody>
                                </Table>
                            </div>
                        )}
                    </div>
                </div>
            </DialogContent>
        </Dialog>
    )
}
