import axios from 'axios';
import { useNavigate } from 'react-router-dom';
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
        console.error();
        return Promise.reject(error);
    }   
)


api.interceptors.response.use(
    response=>response,
    error=>{
        if(error.response.status === 500)
        {
            window.location.replace("/500");
        }
        if(error.response.status === 400)
        {
            alert(error.response.data)
        }
        if(error.response.status === 404)
        {
            window.location.replace("/404");
        }
        if(error.response.status === 401)
        {  
            alert("You aren't authorized!");
            const accessToken = localStorage.getItem('accessToken');
            if(accessToken != null)
            {
                var refreshToken = localStorage.getItem('refreshToken');
                if(refreshToken != null)
                {
                    console.log("Access token has been refreshed.");
                    const requestBody =
                    {       
                        "accessToken" : accessToken,
                        "refreshToken":refreshToken
                    }
                    api.post(`/authentication/refresh`,requestBody).then(res=>
                    {
                        localStorage.setItem("accessToken", res.data.accessToken);
                        localStorage.setItem("refreshToken", res.data.refreshToken);
                    }).catch(console.log);
                }
                else{
                    alert("There are some trubles: refresh token is undefined.");
                }                
            }           
        }    
        return Promise.reject(error);
    }
)

export default api;