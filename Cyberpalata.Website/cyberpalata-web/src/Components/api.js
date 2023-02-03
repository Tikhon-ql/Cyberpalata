import axios from 'axios';
const api = axios.create({baseURL: 'https://localhost:7227'});

api.interceptors.request.use(
    config=> {
        const accessToken = localStorage.getItem('accessToken');
        if(accessToken)
        {
            config.headers['Authorization'] = `Bearer ${accessToken}`;
        }
        return config
    },
    error=>{
        if(error.response.status === 401)
        {
            console.log(401);
        }
    }
)

api.interceptors.response.use(
    response=>response,
    error=>{
        console.log("anime response");
    }
)

export default api;