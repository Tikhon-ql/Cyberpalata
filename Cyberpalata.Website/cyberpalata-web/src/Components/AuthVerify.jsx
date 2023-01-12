import { useLocation } from "react-router-dom";
import { useEffect } from "react";
import jwtDecode from "jwt-decode";
import axios from "axios";

export const AuthVerify = (props) => {
    let location = useLocation();

    useEffect(()=>{
        //console.log(location);
        const accessToken = localStorage.getItem('accessToken');
        if(accessToken)
        {
            const decodedToken = jwtDecode(accessToken);
            console.log(decodedToken);
            console.log((Date.now() / 1000));
            if(decodedToken.exp < (Date.now() / 1000))
            {
                var refreshToken = localStorage.getItem('refreshToken');
                if(refreshToken)
                {
                    console.log("ANIMEANIMEANIME");
                    const apiRequestUrl = `https://localhost:7227/users/refresh`;
                    const config = {
                        headers: { Authorization: `Bearer ${accessToken}` }
                    };
                    const requestBody =
                    {       
                        "accessToken" : accessToken,
                        "refreshToken":refreshToken
                    }
                    var res = axios.post(apiRequestUrl,requestBody,config).then(res=>
                    {
                        console.dir(res);
                        localStorage.setItem("accessToken", res.data.accessToken);
                        localStorage.setItem("refreshToken", res.data.refreshToken);
                    }).catch(console.log);
                }
                else{
                    alert("There are some trubles: refresh token is undefined.");
                }
            }
        }
    },[location, props]);
    return <></>;
}

