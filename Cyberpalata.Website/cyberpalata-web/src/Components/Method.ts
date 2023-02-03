
import axios from "axios";
import {GamingRoomInfo} from "../types/types";

const api = axios.create();

api.interceptors.response.use(
    response => response,
    error=>{
        if(error.response.status == 401)
        {
            console.error();
        }
});

api.defaults.url = "https://localhost:7227";
api.defaults.headers['Authorization'] = `Bearer ${localStorage.getItem('accessToken')}`;

export const Method = {
    getGamingRoomInfo(id)
    {
        return api.get<GamingRoomInfo>(`/gamingRooms/getRoomInfo?id=${id}`);
    },
    // axios.get(`https://localhost:7227/`).then(res => {
    //     console.dir(res);
    //     setDevices(res.data.pcInfos);
    //     setPrices(res.data.prices);
    //     setPeripheries(res.data.peripheries);
    // })
}