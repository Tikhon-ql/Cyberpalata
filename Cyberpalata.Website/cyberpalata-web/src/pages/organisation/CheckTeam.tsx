import React, { useEffect, useState } from "react"
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
        <div style={{"display":"flex","justifyContent":"center","alignItems":"center","width":"100%","height":"80vh"}}>
            <div>
            <h1>{teamInfo?.name}</h1>
            <h1>{teamInfo?.captainName}</h1>
            <ul>
                {teamInfo?.members.map((item:string, index)=>{
                    return <li key={index}>
                        {item}
                    </li>
                })}
            </ul>
            <button className="btn btn-outline-dark">Accept</button>
            <button className="btn btn-outline-dark">Discval</button>
            </div>
            
        </div>
    </>
}
