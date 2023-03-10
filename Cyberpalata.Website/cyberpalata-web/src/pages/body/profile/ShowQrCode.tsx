import React,{useState,useEffect} from 'react';
import { useParams } from 'react-router-dom';
import api from '../../../Components/api';
import { QRCodeCanvas } from "qrcode.react";
import { TournamentDetailed } from '../../../types/types';

export const ShowQrCode = () => {

    const {tournamentId} = useParams();
    const {teamId} = useParams();
    const [tournament, setTournament] = useState<TournamentDetailed>();

    useEffect(()=>{
        api.get(`/tournaments/getTournamentSmall?id=${tournamentId}`)
        .then(res=>{
            setTournament(res.data);
        });
    },[]);

    return <div style={{"display":"flex","justifyContent":"center","alignItems":"center","height":"100vh"}}>
        <div>
            <QRCodeCanvas
                    id="qrCode"
                    value={`https://dotnetinternship2022.norwayeast.cloudapp.azure.com:8080/#/checkTeam/${tournamentId}/${teamId}`}
                    size={300}
                    bgColor={"#00607c"}
                    level={"H"}
                />
                <div style={{textAlign:"center", color:"white"}}>
                    <div style={{marginBottom:"1vh"}}><h4>Tournament: </h4>{tournament?.name}</div>
                    <div><h4>Date: </h4>{tournament?.date}</div>
                </div>
        </div>  
    </div>
}