import { useLocation } from "react-router-dom";
import { useEffect } from "react";
import jwtDecode from "jwt-decode";
import api from "./../Components/api";

export const AccessTokenVerify = (props) => {
    let location = useLocation();

    function checkAccessTokenExpirationTime()
    {
        const accessToken = localStorage.getItem('accessToken');
        if(accessToken != null)
        {
            const decodedToken = jwtDecode(accessToken);
            //console.log(decodedToken);
            //console.log((Date.now() / 1000));
            let minutes = 1 * 30;
            if(decodedToken.exp - minutes < (Date.now() / 1000))
            {
                console.log(decodedToken.exp - minutes);
                console.log(Date.now() / 1000);
                var refreshToken = localStorage.getItem('refreshToken');
                if(refreshToken != null)
                {
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
                    console.log("Access token has been refreshed.");
                }
                // else{
                //     alert("There are some trubles: refresh token is undefined.");
                // }        
            }
        }
    }


    useEffect(()=>{
        setInterval(checkAccessTokenExpirationTime,5000);
        console.log(location);
       
    },[]);//[location, props]);
    return <></>;
}
