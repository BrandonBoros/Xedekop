import axios from "axios";

const api = axios.create({
    baseURL: "https://xedekop-e4fwgmbjage2gabv.eastus2-01.azurewebsites.net/api",
    headers: {
        "Content-Type": "application/json"
    }
});

export default api;
