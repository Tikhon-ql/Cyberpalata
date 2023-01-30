import axios from "axios"
import { Link, useNavigate } from "react-router-dom";

export const LogoutComponent = () => {
    
    const navigate = useNavigate();
    function Logout(event)
    {
        event.preventDefault();

        if(localStorage.getItem('accessToken') != null && localStorage.getItem('refreshToken') != null)
        {
            //const baseUrl = `http://dotnetinternship2022.norwayeast.cloudapp.azure.com:83`;
            const baseUrl = `https://localhost:7227`;
            const apiUrl = `${baseUrl}/authentication/logout`;
            //const apiUrl = `https://localhost:7227/users/logout`;
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
    <div className="pt-5" style={{"height":"100vh","width":"100vw","display":"flex","alignItems":"center","justifyContent":"center"}}>
        <div>
        <h2>You really want logout?</h2>
        <div style={{'display': 'flex'}}>
            <Link onClick={Logout} className="btn btn-outline-dark w-25 m-5">Ok</Link>
            <Link to="/" className="btn btn-outline-dark ml-3 w-25 h-25 m-5">Cancel</Link>
        </div>
        </div>
        
    </div>
    </>
}