export interface TicketDto {
    id: string;
    price: number;
    seatNumber?: string;
    isReserved: boolean;
    qrCode?: string;
    eventId: string;
    eventName: string;
    eventDate: string; 
    reservationId?: string;
}