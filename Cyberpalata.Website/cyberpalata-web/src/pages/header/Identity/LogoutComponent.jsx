import { Link, useNavigate } from "react-router-dom";
import api from "./../../../Components/api";

export const LogoutComponent = () => {
    
    const navigate = useNavigate();
    function Logout(event)
    {
        event.preventDefault();

        if(localStorage.getItem('accessToken') != null && localStorage.getItem('refreshToken') != null)
        {
            // const baseUrl = `https://localhost:7227`;
            // const apiUrl = `${baseUrl}/authentication/logout`;
            let accessToken = localStorage.getItem('accessToken');
            let refreshToken = localStorage.getItem('refreshToken');
    
            let requestBody = 
            {
                accessToken : accessToken,
                refreshToken : refreshToken
            };
    
            localStorage.removeItem('accessToken');    
            localStorage.removeItem('refreshToken');    
    
            api.post(`/authentication/logout`, requestBody).then(res =>{ navigate("/"); }).catch((error) => {console.log(error); navigate("/");});
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