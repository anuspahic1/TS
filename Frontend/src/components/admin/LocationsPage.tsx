"use client"
import React, { useEffect, useState } from 'react';
import { Card, CardContent, CardHeader, CardTitle } from '../ui/card';
import { Button } from '../ui/button';
import { Input } from "../ui/input";
import { MapPin, Plus, Trash2, Loader2, Edit2, Globe } from "lucide-react";
import useLocations from '../../hooks/useLocations';    
import Swal from 'sweetalert2';

import {
    Dialog,
    DialogContent,
    DialogHeader,
    DialogTitle,
    DialogTrigger,
    DialogFooter
} from "../ui/dialog";

const LocationsPage = () => {
    const { getLocations, createLocation, deleteLocation, updateLocation } = useLocations();
    const [locations, setLocations] = useState<any[]>([]);
    const [loading, setLoading] = useState(true);
    const [isDialogOpen, setIsDialogOpen] = useState(false);
    
    const [editingLocation, setEditingLocation] = useState<any | null>(null);
    const [newName, setNewName] = useState("");
    const [newAddress, setNewAddress] = useState("");

    const fetchLocations = async () => {
        setLoading(true);
        try {
            const data = await getLocations();
            setLocations(data);
        } catch (error) {
            console.error("Failed to fetch locations", error);
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        fetchLocations();
    }, []);

    const handleEditClick = (loc: any) => {
        setEditingLocation(loc);
        setNewName(loc.name);
        setNewAddress(loc.address);
        setIsDialogOpen(true);
    };

    const handleCloseDialog = () => {
        setIsDialogOpen(false);
        setEditingLocation(null);
        setNewName("");
        setNewAddress("");
    };

    const handleSave = async () => {
        if (!newName.trim() || !newAddress.trim()) return;

        try {
            if (editingLocation) {
                await updateLocation(editingLocation.id, { name: newName, address: newAddress });
            } else {
                await createLocation({ name: newName, address: newAddress });
            }
            
            handleCloseDialog();
            fetchLocations();

            Swal.fire({
                title: editingLocation ? 'Updated!' : 'Venue Added!',
                text: 'Location has been saved successfully.',
                icon: 'success',
                confirmButtonColor: '#EAB308',
                target: 'body',
                didOpen: () => { Swal.getContainer()!.style.zIndex = '9999'; }
            });
        } catch (error) {
            Swal.fire({
                title: 'Error',
                text: 'Something went wrong. Make sure the name is unique.',
                icon: 'error',
                target: 'body',
                didOpen: () => { Swal.getContainer()!.style.zIndex = '9999'; }
            });
        }
    };

    const handleDelete = async (id: string) => {
        Swal.fire({
            title: 'Are you sure?',
            text: "This venue will be removed. Caution: Events linked to this location might prevent deletion.",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#000',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!',
            target: 'body'
        }).then(async (result) => {
            if (result.isConfirmed) {
                try {
                    await deleteLocation(id);
                    fetchLocations();
                    Swal.fire({ title: 'Deleted!', icon: 'success', confirmButtonColor: '#EAB308' });
                } catch (error) {
                    Swal.fire({ 
                        title: 'Action Denied', 
                        text: 'Cannot delete location because it is linked to existing events.', 
                        icon: 'error' 
                    });
                }
            }
        });
    };

    return (
        <div className="p-6 space-y-8 bg-gray-50/50 min-h-screen">
            <div className="flex flex-col md:flex-row justify-between items-start md:items-center gap-4 bg-white p-6 rounded-2xl shadow-sm border border-gray-100">
                <div>
                    <h1 className="text-4xl font-black uppercase italic tracking-tighter">
                        Location <span className="text-yellow-500 underline decoration-black/10">Hub</span>
                    </h1>
                    <p className="text-gray-500 font-medium mt-1 flex items-center">
                        <Globe className="h-4 w-4 mr-2 text-gray-400" />
                        Manage venues and strategic event spaces
                    </p>
                </div>

                <Dialog open={isDialogOpen} onOpenChange={(open) => !open && handleCloseDialog()}>
                    <DialogTrigger asChild>
                        <Button onClick={() => setIsDialogOpen(true)} className="bg-black text-white hover:bg-black/90 px-8 py-6 rounded-xl font-bold transition-all hover:scale-105 active:scale-95 shadow-lg shadow-black/10">
                            <Plus className="mr-2 h-5 w-5" /> Add New Venue
                        </Button>
                    </DialogTrigger>
                    <DialogContent className="sm:max-w-[425px] rounded-3xl">
                        <DialogHeader>
                            <DialogTitle className="text-2xl font-black uppercase italic">
                                {editingLocation ? 'Edit Venue' : 'Create Venue'}
                            </DialogTitle>
                        </DialogHeader>
                        <div className="space-y-6 py-6">
                            <div className="space-y-2">
                                <label className="text-xs font-black uppercase tracking-widest text-gray-400">Venue Name</label>
                                <Input 
                                    className="rounded-xl border-gray-200 focus:ring-yellow-500"
                                    placeholder="e.g. Olympic Stadium" 
                                    value={newName} 
                                    onChange={(e) => setNewName(e.target.value)} 
                                />
                            </div>
                            <div className="space-y-2">
                                <label className="text-xs font-black uppercase tracking-widest text-gray-400">Address Details</label>
                                <Input 
                                    className="rounded-xl border-gray-200 focus:ring-yellow-500"
                                    placeholder="e.g. Street 123, Sarajevo" 
                                    value={newAddress} 
                                    onChange={(e) => setNewAddress(e.target.value)} 
                                />
                            </div>
                        </div>
                        <DialogFooter className="gap-2">
                            <Button variant="ghost" className="font-bold rounded-xl" onClick={handleCloseDialog}>Cancel</Button>
                            <Button 
                                onClick={handleSave} 
                                className="bg-yellow-500 hover:bg-yellow-600 text-black font-black px-8 rounded-xl disabled:opacity-30 transition-all"
                                disabled={!newName.trim() || !newAddress.trim()}
                            >
                                {editingLocation ? 'Update Venue' : 'Save Location'}
                            </Button>
                        </DialogFooter>
                    </DialogContent>
                </Dialog>
            </div>

            {loading ? (
                <div className="flex flex-col items-center justify-center py-32 space-y-4">
                    <Loader2 className="animate-spin h-12 w-12 text-yellow-500" />
                    <p className="text-gray-400 font-bold uppercase tracking-widest text-xs">Syncing Hub Data...</p>
                </div>
            ) : (
                <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
                    {locations.map((loc) => (
                        <Card key={loc.id} className="group relative overflow-hidden border-none bg-white shadow-md hover:shadow-2xl transition-all duration-300 rounded-3xl">
                            <div className="absolute left-0 top-0 h-full w-1.5 bg-yellow-500 group-hover:w-2.5 transition-all" />
                            
                            <CardHeader className="pb-2">
                                <div className="flex justify-between items-start">
                                    <div className="space-y-1">
                                        <CardTitle className="text-xl font-black tracking-tight uppercase text-gray-800 group-hover:text-yellow-600 transition-colors">
                                            {loc.name}
                                        </CardTitle>
                                        <div className="flex items-center text-gray-400 text-[10px] font-black uppercase tracking-widest">
                                            <MapPin className="h-3 w-3 mr-1 text-yellow-500" />
                                            Verified Location
                                        </div>
                                    </div>
                                </div>
                            </CardHeader>

                            <CardContent>
                                <div className="bg-gray-50 p-4 rounded-2xl border border-gray-100 mb-6 group-hover:bg-yellow-50 transition-colors">
                                    <p className="text-sm font-medium text-gray-600 leading-relaxed italic">
                                        {loc.address}
                                    </p>
                                </div>
                                
                                <div className="flex justify-between items-center pt-2">
                                    <span className="text-[10px] bg-black text-white px-3 py-1 rounded-full font-black uppercase tracking-tighter">
                                        Active Hub
                                    </span>

                                    <div className="flex gap-2">
                                        <Button 
                                            variant="ghost" 
                                            size="icon" 
                                            className="h-10 w-10 rounded-xl text-blue-600 hover:bg-blue-50 hover:text-blue-700 transition-all border border-transparent hover:border-blue-100"
                                            onClick={() => handleEditClick(loc)}
                                        >
                                            <Edit2 className="h-4 w-4" />
                                        </Button>
                                        
                                        <Button 
                                            variant="ghost" 
                                            size="icon" 
                                            className="h-10 w-10 rounded-xl text-red-500 hover:bg-red-50 hover:text-red-600 transition-all border border-transparent hover:border-red-100"
                                            onClick={() => handleDelete(loc.id)}
                                        >
                                            <Trash2 className="h-4 w-4" />
                                        </Button>
                                    </div>
                                </div>
                            </CardContent>
                        </Card>
                    ))}
                </div>
            )}
        </div>
    );
};

export default LocationsPage;