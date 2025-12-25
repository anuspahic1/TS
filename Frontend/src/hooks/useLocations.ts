import axios from "axios";

export default function useLocations() {

    const getLocations = async () => {
        try {
            console.log(import.meta.env.VITE_API_URL);
            const response = await axios.get(`${import.meta.env.VITE_API_URL}/locations`);

            return response.data;
        } catch (error) {
            console.error("Error fetching locations:", error);
            return [];
        }
    }
    return { getLocations };
}