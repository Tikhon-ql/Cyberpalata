import { observer } from "mobx-react-lite";
import { Link, useNavigate } from "react-router-dom";
import headerRerenderStore from "./../../../store/headerRerenderStore";
import api from "./../../../Components/api";
import React from "react";

export const LogoutComponent = observer(({setModalActive}: any) => {
    const navigate = useNavigate();
    function logout(event: any)
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
                
            }).catch(error=>{
                if(error.code && error.code == "ERR_NETWORK")
                {
                    navigate('/500');
                }
                if((error.response.status >= 500 && error.response.status <= 599))
                {
                    navigate('/500');
                }
            }).finally(()=>{
                localStorage.removeItem('accessToken');
                localStorage.removeItem('refreshToken');
                headerRerenderStore.stateChange();
            });      
            setModalActive(false);
            navigate('/');
        }
    }


    return <>
    <div className="d-flex align-items-center justify-content-center pt-4" >
        <div className="p-5 m-2 bg-info text-white shadow rounded-2">
            <h2>You really want logout?</h2>
            <div style={{'display': 'flex'}}>
                <button onClick={logout} className="btn btn-outline-dark btn-sm text-white w-50 m-1">Ok</button>
                <button onClick={()=>{setModalActive(false)}} className="btn btn-outline-dark btn-sm text-white w-50 m-1">Cancel</button>
            </div>
        </div>
    </div>
    </>
})
