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
     return <div style={{"display":"flex","justifyContent":"center","alignItems":"center","width":"100%","height":"80vh"}}>
        <ul className="list-style-non w-50" style={{"listStyle":"none"}}>
                {tournaments.map((item:Tournament, index)=>{
                    return <li key={index} className="text-decoration-none m-1">       
                            <Link className="text-decoration-none text-dark" to={`/showTournamentDetailed/${item.id}`}>
                                <div className="d-flex bg-white rounded p-2">
                                    <img src="https://cdn-icons-png.flaticon.com/512/4392/4392354.png" width="50"/>
                                    <h6 className="m-3">{item.name}</h6> 
                                    <Link to={`/registerTeam/${item.id}`} className="m-2 btn btn-outline-dark" style={{"justifyContent":"end"}}>Register</Link>                    
                                </div>
                            </Link>
                    </li>
                })}
        </ul>
    </div>
}
