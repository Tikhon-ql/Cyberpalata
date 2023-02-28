import React, { useEffect, useState } from "react"
import { Link } from "react-router-dom";
import { useParams } from "react-router-dom"
import api from "../../Components/api";
import { TeamInfo } from "../../types/types";

export const CheckTeam = () => {
    const {tournamentId} = useParams();
    const {teamId} = useParams();
    const [teamInfo, setTeamInfo] = useState<TeamInfo>();

    useEffect(()=>{
        api.get(`/teams/getTeamInTournament?teamId=${teamId}&tournamentId=${tournamentId}`).then(res=>{
            setTeamInfo(res.data);
        });
    },[]);

    return <>
        <div style={{color:"white","display":"flex","justifyContent":"center","alignItems":"center","width":"100%","height":"80vh"}}>
            <div>
                <h4>Team: {teamInfo?.name}</h4><hr/>
                <h4>Captain: {teamInfo?.captainName}</h4><hr/>
                <h4>Members</h4>
                <ul style={{listStyle:"none"}}>
                    {teamInfo?.members.map((item:string, index)=>{
                        return <div>
                            <li key={index}>
                                {item}
                            </li>
                        </div> 
                    })}
                </ul><hr/>
                <div style={{display:"flex",justifyContent:"center"}}>
                    <Link to="/" style={{"border":"1px solid","padding":"0.5vh 1.5vh 0.5vh 1.5vh","borderRadius":"1vh","marginRight":"1vw",marginBottom:"3vh"}}>Accept</Link>
                    <Link to="/" style={{"border":"1px solid","padding":"0.5vh 1.5vh 0.5vh 1.5vh","borderRadius":"1vh","marginRight":"1vw",marginBottom:"3vh"}}>Discval</Link>
                </div>
               
            </div>
            
        </div>
    </>
}
