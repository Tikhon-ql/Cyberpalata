import React, { useEffect, useState } from "react"
import { Link } from "react-router-dom";
import { useParams } from "react-router-dom"
import api from "../../../Components/api";
import { Tournament, UserTournament } from "../../../types/types";

export const UsersTournaments = ()=>{
    // const {tournamentId} = useParams();

    const [usersTournaments, setUsersTournaments] = useState<UserTournament[]>([]);
    useEffect(()=>{
        api.get('/tournaments/getUsersTournaments').then(res=>{
            console.dir(res.data);
            setUsersTournaments(res.data);
        });
    },[]);

    return <>
        <div style={{"display":"flex","justifyContent":"center","alignItems":"center","width":"100%","height":"80vh"}}>
            <ul className="list-style-non w-50" style={{"listStyle":"none"}}>
                    {usersTournaments.map((item:UserTournament, index)=>{
                        return <li key={index} className="text-decoration-none m-1">       
                                <Link className="text-decoration-none text-dark" to={`/showQrCode/${item.id}/${item.teamId}`}>
                                    <div className="d-flex bg-white rounded p-2">
                                        <img src="https://cdn-icons-png.flaticon.com/512/4392/4392354.png" width="50"/>
                                        <h6 className="m-3">{item.name}</h6> 
                                    </div>
                                </Link>
                        </li>
                    })}
            </ul>
        </div>
    </>
}