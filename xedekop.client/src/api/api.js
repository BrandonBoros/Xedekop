import axios from "axios";

const api = axios.create({
    baseURL: "https://localhost:7135/api",
    headers: {
        "Content-Type": "application/json"
    }
});

// Optional: auto-attach token if stored
api.interceptors.request.use((config) => {
    const token = localStorage.getItem("token");
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});

export default api;