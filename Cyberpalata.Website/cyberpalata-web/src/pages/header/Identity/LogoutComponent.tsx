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
            headerRerenderStore.stateChange();
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
        <div style={{background:"rgba(68, 50, 72,0.5)",padding:"2vh 2vw 2vh 2vw", borderRadius:"1vw", color:"white"}}>
            <h2>Do you really want ot sign out?</h2>
            <div style={{'display': 'flex',justifyContent:"center",marginTop:"3vh"}}>
                <Link to="" style={{"border":"1px solid","padding":"0.5vh 1.5vh 0.5vh 1.5vh","borderRadius":"1vh","marginRight":"5vw",marginBottom:"3vh"}} onClick={logout}>Ok</Link>
                <Link to="" style={{"border":"1px solid","padding":"0.5vh 1.5vh 0.5vh 1.5vh","borderRadius":"1vh","marginRight":"1vw",marginBottom:"3vh"}} onClick={()=>{setModalActive(false)}}>Cancel</Link>
            </div>
        </div>
    </div>
    </>
})
