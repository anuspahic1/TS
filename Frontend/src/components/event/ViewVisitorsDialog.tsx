"use client"

import { Dialog, DialogContent, DialogDescription, DialogHeader, DialogTitle } from "../ui/dialog"
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "../ui/table"

import { Users, Mail } from "lucide-react"

interface ViewVisitorsDialogProps {
    open: boolean
    onOpenChange: (open: boolean) => void
    event: any
}

export function ViewVisitorsDialog({ open, onOpenChange, event }: ViewVisitorsDialogProps) {


    return (
        <Dialog open={open} onOpenChange={onOpenChange}>
            <DialogContent className="max-w-3xl max-h-[90vh] overflow-y-auto">
                <DialogHeader>
                    <DialogTitle className="text-2xl">{event.name}</DialogTitle>
                    <DialogDescription>Registered visitors for this event</DialogDescription>
                </DialogHeader>

                <div className="space-y-6">

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
                                        </TableRow>
                                    </TableHeader>
                                    <TableBody>
                                        {event.visitors.map((visitor: any) => (
                                            <TableRow key={visitor.id}>
                                                <TableCell className="font-medium">{visitor.fullName}</TableCell>
                                                <TableCell>
                                                    <div className="flex items-center gap-2">
                                                        <Mail className="h-4 w-4 text-muted-foreground" />
                                                        {visitor.email}
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
