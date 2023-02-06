import { Link, useNavigate } from "react-router-dom";
import api from "./../../../Components/api";

export const LogoutComponent = ({setModalActive}) => {
    const navigate = useNavigate();
    function Logout(event)
    {
        event.preventDefault();

        if(localStorage.getItem('accessToken') != null && localStorage.getItem('refreshToken') != null)
        {
            let accessToken = localStorage.getItem('accessToken');
            let refreshToken = localStorage.getItem('refreshToken');
    
            let requestBody = 
            {
                accessToken : accessToken,
                refreshToken : refreshToken
            };
            api.post(`/authentication/logout`, requestBody).then(()=>
            {
            });
            localStorage.removeItem('accessToken');
            localStorage.removeItem('refreshToken');
            setModalActive(false);
        }
    }

    return <>
    <div className="d-flex align-items-center justify-content-center pt-4" style={{"height":"100vh","width":"100vw","display":"flex","alignItems":"center","justifyContent":"center"}}>
        <div className="p-5 m-2 bg-info text-white shadow rounded-2">
            <h2>You really want logout?</h2>
            <div style={{'display': 'flex'}}>
                <Link onClick={Logout} className="btn btn-outline-dark btn-sm text-white w-50 m-1">Ok</Link>
                <button onClick={()=>{setModalActive(false)}} className="btn btn-outline-dark btn-sm text-white w-50 m-1">Cancel</button>
            </div>
        </div>
    </div>
    </>
}