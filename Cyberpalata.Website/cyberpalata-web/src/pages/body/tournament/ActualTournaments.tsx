import { useEffect, useState } from "react"
import { Tournament, TournamentDetailed } from "../../../types/types"
import api from "./../../../Components/api";
import {Link} from "react-router-dom";
import React from 'react'

export const ActualTournaments = ()=>{

    const [tournaments, setTournaments] = useState<Tournament[]>([]);

    useEffect(()=>{
        api.get(`/tournaments/getActualTournaments`).then(res=>{
            setTournaments(res.data);
        });
    },[]);

    return <div>
        <ul>
            {tournaments.map((item:Tournament, index)=>{
                return <li key={index}>
                    <Link to={`/showTournamentDetailed/${item.id}`}>{item.name}</Link>
                </li>
            })}
        </ul>
    </div>
}