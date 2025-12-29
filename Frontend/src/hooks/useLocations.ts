import { apiClient } from "../services/apiClient";

export default function useLocations() {

    const getLocations = async () => {
        try {
            return await apiClient.get<any[]>("/locations");
        } catch (error) {
            console.error("Error fetching locations:", error);
            return [];
        }
    };

    const createLocation = async (locationData: { name: string; address: string }) => {
        try {
            return await apiClient.post("/locations", locationData);
        } catch (error) {
            console.error("Error creating location:", error);
            throw error;
        }
    };

    const updateLocation = async (id: string, locationData: { name: string; address: string }) => {
        try {
            return await apiClient.put(`/locations/${id}`, locationData);
        } catch (error) {
            console.error("Error updating location:", error);
            throw error;
        }
    };

    const deleteLocation = async (id: string) => {
        try {
            await apiClient.delete(`/locations/${id}`);
            return true;
        } catch (error) {
            console.error("Error deleting location:", error);
            throw error;
        }
    };

    return { getLocations, createLocation, updateLocation, deleteLocation };
}