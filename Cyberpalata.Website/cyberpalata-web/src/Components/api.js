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
            const accessToken = localStorage.getItem('accessToken');
            if(accessToken != null)
            {
                //const decodedToken = jwtDecode(accessToken);
                //console.log(decodedToken);
                //console.log((Date.now() / 1000));
                //let minutes = 1 * 30;
                // if(decodedToken.exp - minutes < (Date.now() / 1000))
                // {
                //console.log(decodedToken.exp - minutes);
                //console.log(Date.now() / 1000);
                var refreshToken = localStorage.getItem('refreshToken');
                if(refreshToken != null)
                {
                    console.log("Access token has been refreshed.");
                    //const apiRequestUrl = `https://localhost:7227/authentication/refresh`;
                    // const config = {
                    //     headers: { Authorization: `Bearer ${accessToken}` }
                    // };
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
                //}
            }
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