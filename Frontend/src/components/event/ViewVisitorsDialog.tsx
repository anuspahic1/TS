"use client"

import {
    Dialog,
    DialogContent,
    DialogDescription,
    DialogHeader,
    DialogTitle
} from "../ui/dialog"
import {
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableHeader,
    TableRow
} from "../ui/table"

import { Users, Mail, ShieldCheck, Search } from "lucide-react"

interface ViewVisitorsDialogProps {
    open: boolean
    onOpenChange: (open: boolean) => void
    event: any
}

export function ViewVisitorsDialog({ open, onOpenChange, event }: ViewVisitorsDialogProps) {
    if (!event) return null;

    return (
        <Dialog open={open} onOpenChange={onOpenChange}>
            <DialogContent className="max-w-3xl bg-white rounded-3xl border-none shadow-2xl p-0 overflow-hidden outline-none">
                {/* Dark Header - System Identity */}
                <DialogHeader className="bg-neutral-900 p-8 text-left border-none">
                    <span className="text-[10px] font-black uppercase tracking-[0.4em] text-yellow-500 block mb-2">
                        Visitor Registry Terminal
                    </span>
                    <DialogTitle className="text-3xl font-black italic uppercase tracking-tighter text-white">
                        {event.name}
                    </DialogTitle>
                    <DialogDescription className="text-neutral-400 font-bold uppercase text-[10px] tracking-widest mt-2">
                        Reviewing all registered operatives for this deployment.
                    </DialogDescription>
                </DialogHeader>

                <div className="p-8">
                    <div className="flex items-center justify-between mb-6">
                        <h3 className="text-[12px] font-black uppercase tracking-[0.2em] text-neutral-900 flex items-center gap-2">
                            <Search className="w-4 h-4 text-yellow-500" /> Authorized Personnel
                        </h3>
                        <div className="bg-neutral-100 px-3 py-1 rounded-full text-[10px] font-bold uppercase">
                            Total: {event.visitors?.length || 0}
                        </div>
                    </div>

                    {/* Visitors Table Content */}
                    <div className="max-h-[400px] overflow-y-auto rounded-xl border border-neutral-100">
                        {!event.visitors || event.visitors.length === 0 ? (
                            <div className="flex flex-col items-center justify-center py-20 text-center bg-neutral-50">
                                <Users className="h-12 w-12 text-neutral-200 mb-4" />
                                <p className="text-[10px] font-black uppercase tracking-widest text-neutral-400">
                                    No data detected in registry
                                </p>
                            </div>
                        ) : (
                            <Table>
                                <TableHeader className="bg-neutral-50 sticky top-0 z-10">
                                    <TableRow className="border-none hover:bg-transparent">
                                        <TableHead className="text-[10px] font-black uppercase tracking-widest text-neutral-400 h-10">
                                            Operative Name
                                        </TableHead>
                                        <TableHead className="text-[10px] font-black uppercase tracking-widest text-neutral-400 h-10">
                                            Contact Channel
                                        </TableHead>
                                        <TableHead className="text-right text-[10px] font-black uppercase tracking-widest text-neutral-400 h-10">
                                            Status
                                        </TableHead>
                                    </TableRow>
                                </TableHeader>
                                <TableBody>
                                    {event.visitors.map((visitor: any) => (
                                        <TableRow 
                                            key={visitor.id} 
                                            className="border-neutral-50 hover:bg-neutral-50/50 transition-colors"
                                        >
                                            <TableCell className="py-4">
                                                <span className="font-black text-neutral-900 uppercase italic text-xs">
                                                    {visitor.fullName}
                                                </span>
                                            </TableCell>
                                            <TableCell className="py-4">
                                                <div className="flex items-center gap-2 text-neutral-500 font-medium text-xs">
                                                    <Mail className="h-3 w-3 text-yellow-500" />
                                                    {visitor.email}
                                                </div>
                                            </TableCell>
                                            <TableCell className="py-4 text-right">
                                                <span className="inline-flex items-center gap-1 bg-green-50 text-green-700 text-[9px] font-black uppercase px-2 py-1 rounded-md">
                                                    <ShieldCheck className="w-3 h-3" /> Verified
                                                </span>
                                            </TableCell>
                                        </TableRow>
                                    ))}
                                </TableBody>
                            </Table>
                        )}
                    </div>

                    {/* Footer Info */}
                    <div className="mt-6 pt-6 border-t border-neutral-50 flex justify-between items-center">
                        <button 
                            onClick={() => onOpenChange(false)}
                            className="text-[10px] font-black uppercase tracking-widest text-neutral-400 hover:text-neutral-900 transition-colors"
                        >
                            Close Terminal
                        </button>
                        <p className="text-[9px] font-bold text-neutral-300 uppercase tracking-tighter">
                            EntrioX Security Protocol v2.5
                        </p>
                    </div>
                </div>
            </DialogContent>
        </Dialog>
    )
}