import { useEffect, useState } from "react";
import { useParams } from "react-router-dom"
import api from "../../../Components/api";
import { TournamentDetailed } from "../../../types/types";
import { TournamentNetwork } from "./TournamentNetwork";
import React from 'react'

export const TournamentDetailedView = ()=>{
    const [isloaded, setIsLoader] = useState<boolean>(false);
    const {id} = useParams();
    const [tournament, setTournament] = useState<TournamentDetailed>({
        name:"NBAALLSTAR",
        date:"10.10.2023",
        teamsMaxCount:16,
        rounds:[{
            number:0,
            batles:[],
            batlesMaxCount:4,
            date:"21.12.2023"
        },{
            number:1,
            batles:[],
            batlesMaxCount:2,
            date:"21.12.2023"
        },{
            number:2,
            batles:[],
            batlesMaxCount:1,
            date:"21.12.2023"
        }]
    });
    useEffect(()=>{
        api.get(`/tournaments/getTournamentDetaile?tournamentId=${id}`).then(res=>{
            console.dir(res.data); 
            setTournament(res.data);
            setIsLoader(true);
        })
    },[]);
    return <>
        {isloaded && <TournamentNetwork name={tournament.name} date={tournament.date} teamsMaxCount={tournament.teamsMaxCount} rounds={tournament.rounds}/>   }
    </>
}