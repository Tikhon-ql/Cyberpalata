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
        name:"",
        date:"",
        teamsMaxCount:0,
        rounds:[]
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