import axios from "axios";

const authenticatedAxiosInstance = axios.create({
    baseURL: `https://localhost:7227/`,
    timeout: 1000,
    headers: {'Authorization': 'Bearer ' + localStorage.getItem("accessToken")}
});

export default authenticatedAxiosInstance;