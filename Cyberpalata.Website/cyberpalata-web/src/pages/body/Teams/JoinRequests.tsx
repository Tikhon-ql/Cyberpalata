import React, { useEffect, useState } from "react"
import api from "../../../Components/api";
import { JoinRequest } from "../../../types/types";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

export const JoinRequests = ()=>{

    const [joinRequest, setJoinRequest] = useState<JoinRequest>();
    
    useEffect(()=>{
        console.log("Log 1");
        api.get(`/joinRequests/getTeamJoinRequests`).then(res=>{
            console.log("Join requests");
            console.dir(res);
            setJoinRequest(res.data[0]);
        });
    },[]);

    function setJoinRequestState(state: string)
    {
        console.log("sdoufbiodsf");
        var requestBody = {
            userToJoinId: joinRequest?.userId,
            teamId: joinRequest?.teamId,
            state: state
        }
        api.put(`/joinRequests/acceptJoinRequest`,requestBody).then(res=>{toast.success("Accepted successfully")});
    }

    return <div className="myConteiner">
        <div className="card">
            <div className="cardContent">
                <div>
                    {joinRequest?.username}
                </div>
                <div>
                    {joinRequest?.usersurname}
                </div>
            </div>
            <div className="links">
                <a className="blackLink" style={{marginBottom:"2vh"}}><img src={require(`./../../../imgs/skipArrow.png`)}  onClick={()=>{setJoinRequestState("Rejected")}} style={{"width":"15px", height:"15px",marginBottom:"0.5vh"}}/> Skip</a>
                <a  className="blackLink" style={{marginBottom:"2vh"}}><img src={require(`./../../../imgs/messenger.png`)} onClick={()=>{setJoinRequestState("InProgress")}}  style={{"width":"15px", height:"15px",marginBottom:"0.5vh"}}/> Open chat</a>
            </div>
        </div>
    </div> 
}