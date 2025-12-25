"use client"
import  { useEffect, useState } from 'react';
import { Card, CardContent, CardHeader, CardTitle } from '../ui/card';
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from '../ui/table';
import { Badge } from '../ui/badge';
import { apiClient } from '../../services/apiClient';
import type{ TicketDto } from '../../types/TicketDto';

const AdminTicketsPage = () => {
  const [tickets, setTickets] = useState<TicketDto[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchTickets = async () => {
      try {
        const data = await apiClient.get<TicketDto[]>('/admin/tickets');
        setTickets(data);
      } catch (err) {
        console.error("Error fetching tickets:", err);
      } finally {
        setLoading(false);
      }
    };
    fetchTickets();
  }, []);

  return (
    <div className="p-6 space-y-6 font-sans">
      <div className="flex justify-between items-center">
        <div>
          <h1 className="text-3xl font-black uppercase tracking-tight">Ticket <span className="text-yellow-500">Registry</span></h1>
          <p className="text-gray-500 font-medium">Overview of all issued and reserved tickets system-wide.</p>
        </div>
      </div>

      <Card className="rounded-3xl border-gray-100 shadow-xl overflow-hidden">
        <CardContent className="p-0">
          <Table>
            <TableHeader className="bg-gray-50">
              <TableRow>
                <TableHead className="font-black uppercase text-[10px] tracking-widest">Event</TableHead>
                <TableHead className="font-black uppercase text-[10px] tracking-widest">Seat</TableHead>
                <TableHead className="font-black uppercase text-[10px] tracking-widest">Price</TableHead>
                <TableHead className="font-black uppercase text-[10px] tracking-widest text-center">Status</TableHead>
              </TableRow>
            </TableHeader>
            <TableBody>
              {tickets.map((ticket) => (
                <TableRow key={ticket.id} className="hover:bg-gray-50/50 transition-colors">
                  <TableCell className="font-bold">{ticket.eventName}</TableCell>
                  <TableCell className="font-mono text-xs">{ticket.seatNumber || "General Admission"}</TableCell>
                  <TableCell className="font-black text-green-600">{ticket.price} KM</TableCell>
                  <TableCell className="text-center">
                    <Badge className={ticket.isReserved ? "bg-blue-100 text-blue-700" : "bg-gray-100 text-gray-500"}>
                      {ticket.isReserved ? "RESERVED" : "AVAILABLE"}
                    </Badge>
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </CardContent>
      </Card>
    </div>
  );
};

export default AdminTicketsPage;