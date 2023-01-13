import axios from "axios"
import { Link, useNavigate } from "react-router-dom";

export const LogoutComponent = () => {
    
    const navigate = useNavigate();
    function Logout(event)
    {
        event.preventDefault();

        if(localStorage.getItem('accessToken') != null && localStorage.getItem('refreshToken') != null)
        {
            const apiUrl = `https://localhost:7227/users/logout`;
    
            let accessToken = localStorage.getItem('accessToken');
            let refreshToken = localStorage.getItem('refreshToken');
    
            const config = {
                headers: { Authorization: `Bearer ${accessToken}` }
            };
    
            let requestBody = 
            {
                accessToken : accessToken,
                refreshToken : refreshToken
            };
    
            localStorage.removeItem('accessToken');    
            localStorage.removeItem('refreshToken');    
    
            axios.post(apiUrl, requestBody, config).then(res =>{ navigate("/"); }).catch((error) => {console.log(error); navigate("/");});
        }
    }

    return <>
    <Link onClick={Logout} className="btn btn-primary btn-lg">Ok</Link>
    <Link to="/" className="btn btn-secondary btn-lg">Cancel</Link>
    </>
}