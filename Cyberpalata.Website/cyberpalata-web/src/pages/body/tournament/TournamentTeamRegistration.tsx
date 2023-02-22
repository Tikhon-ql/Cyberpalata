import { useEffect, useState } from "react"
import api from "./../../../Components/api";
import { QrCode, Team, Tournament } from "./../../../types/types";
import React from 'react'
import { useParams } from "react-router-dom";
import { QRCodeCanvas } from "qrcode.react";

export const TournamentTeamRegistration =   ()=>{

    const {tournamentId} = useParams();
    const [teams, setTeams] = useState<Team[]>([]);
    const [qrCodeInfo,setQrCodeInfo] = useState<QrCode>();
    const [isRegistered, setIsRegistered] = useState<boolean>(false);
    useEffect(()=>{
        api.get('/teams/getByUserId').then(res=>{
            console.dir(res);
            setTeams(res.data);
        });
    },[]);

    function sendTournamentCreatingRequest(event:any)
    {
        console.log("anime");
        event.preventDefault();
        console.dir(event);
        let requestBody = 
        { 
            "tournamentId":tournamentId,
            "teamId": event.target[0].value
        };
        api.put(`/tournaments/registerTeam`,requestBody).then(res=>{
            setQrCodeInfo(res.data);
            setIsRegistered(true);
        }).catch(err=>err);
    }

    return <>
        <form onSubmit={(event)=>{sendTournamentCreatingRequest(event)}}>
            <select id="teams" name="teams">
                {teams.map((item:Team,index)=>{
                    return <>
                        <option key={index} value={item.id}>{item.name}</option>
                    </>
                })}
            </select>
            <input type="submit" value="Register"/>
            {isRegistered &&  <QRCodeCanvas
                id="qrCode"
                value={`http://dotnetinternship2022.norwayeast.cloudapp.azure.com:83/checkTeam/${qrCodeInfo?.tournamentId}/${qrCodeInfo?.teamId}`}
                size={300}
                bgColor={"#00ff00"}
                level={"H"}
            />}
        </form>
        
    </>
}