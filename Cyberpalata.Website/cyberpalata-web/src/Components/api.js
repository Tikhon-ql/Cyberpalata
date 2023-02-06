import axios from 'axios';
import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
const api = axios.create({baseURL: 'http://dotnetinternship2022.norwayeast.cloudapp.azure.com:83'});
//https://localhost:7227
//http://dotnetinternship2022.norwayeast.cloudapp.azure.com:83/
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
        if(error.response.status >= 500 && error.response.status <= 599)
        {
            window.location.replace("/500");
        }
        if(error.response.status === 400)
        {
            console.log("error");
            console.dir(error.response.data);
            //alert(error.response.data)
        }
        if(error.response.status === 404)
        {
            window.location.replace("/404");
        }
        // if(error.response.status === 401)
        // { 
          
        // }
        return Promise.reject(error);
    }
)

export default api;