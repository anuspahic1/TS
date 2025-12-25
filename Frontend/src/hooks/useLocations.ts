import axios from "axios";

export default function useLocations() {
    const API_URL = import.meta.env.VITE_API_URL;

    const getLocations = async () => {
        try {
            const response = await axios.get(`${API_URL}/locations`);
            return response.data;
        } catch (error) {
            console.error("Error fetching locations:", error);
            return [];
        }
    };

    const createLocation = async (locationData: { name: string; address: string }) => {
        try {
            const response = await axios.post(`${API_URL}/locations`, locationData);
            return response.data;
        } catch (error) {
            console.error("Error creating location:", error);
            throw error;
        }
    };

    const updateLocation = async (id: string, locationData: { name: string; address: string }) => {
        try {
            const response = await axios.put(`${API_URL}/locations/${id}`, locationData);
            return response.data;
        } catch (error) {
            console.error("Error updating location:", error);
            throw error;
        }
    };

    const deleteLocation = async (id: string) => {
        try {
            await axios.delete(`${API_URL}/locations/${id}`);
            return true;
        } catch (error) {
            console.error("Error deleting location:", error);
            throw error;
        }
    };

    return { getLocations, createLocation, updateLocation, deleteLocation };
}