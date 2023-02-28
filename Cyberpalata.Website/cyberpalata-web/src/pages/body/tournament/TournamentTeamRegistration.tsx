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

    return <>{teams.length != 0 ? <div style={{display:"flex", justifyContent:"center",alignItems:"center", width:"100%",height:"100vh"}}>
            <form onSubmit={(event)=>{sendTournamentCreatingRequest(event)}}>
                <select id="teams" name="teams" className="w-100 m-2">
                    {teams.map((item:Team,index)=>{
                        return <>
                            <option key={index} value={item.id}>{item.name}</option>
                        </>
                    })}
                </select>
                <input type="submit" value="Register" className="w-100 m-2"/>    
                <div style={{marginTop:"5vh"}}>
                    {isRegistered && <div style={{display:"flex",justifyContent:"center",alignItems:"center",width:"100%"}}><QRCodeCanvas
                        id="qrCode"
                        value={`https://dotnetinternship2022.norwayeast.cloudapp.azure.com:8080/#/checkTeam/${qrCodeInfo?.tournamentId}/${qrCodeInfo?.teamId}`}
                        size={200}
                        bgColor={"#00607c"}
                        level={"H"}
                    />
                    <h6 style={{color:"white"}} className="w-25 m-3">This QRcode you can see in your profile</h6></div>}
                </div>  
            </form>    
        </div> : <h1>Teams list is empty</h1>}
 </>
}