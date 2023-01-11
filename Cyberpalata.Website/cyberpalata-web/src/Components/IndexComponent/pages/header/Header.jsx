import {Logo} from '../../logoComponent'
import {Link} from 'react-router-dom'
import axios, {AxiosError} from "axios";

export const Header = () => {

    function refreshToken(event)
    {

        var accessToken = localStorage.getItem('accessToken');
        var refreshToken = localStorage.getItem('refreshToken');
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

    return <>
        <Link to='/' ><Logo/></Link>
        <div>
            <Link to='/login' class="d-flex flex-row-reverse m-3 p-2"><b>Login</b></Link>
            <button onClick={refreshToken}>Refresh</button>
        </div>
    </>
}