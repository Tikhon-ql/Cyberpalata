import './res/ul.css';
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
    return <>
     <div className="container d-flex justify-content-center">
        <ul className="list-group mt-5 text-white h-50">
            {tournaments.map((item:Tournament,index)=>{
                return <li className="list-group-item d-flex justify-content-between align-content-center" key={index}>
                    <Link to={`/showTournamentDetailed/${item.id}`} className="text-decoration-none text-white" style={{"paddingRight":"3vw","paddingLeft":"3vw"}}>
                        <div className="d-flex flex-row">
                            <img src='https://cdn-icons-png.flaticon.com/512/3522/3522080.png' style={{"marginLeft":"0"}} width={40}/>
                            <div style={{"marginLeft":"2vw"}}>
                                <h6 className="mb-0">{item.name}</h6>
                                <div className="about">
                                    <span>Jan 21, 2020</span>
                                </div>
                            </div>

                        </div>
                    </Link>           
            </li>
            })}
        </ul>
    </div>
</>
}
// return <div style={{"display":"flex","justifyContent":"centre","alignItems":"center","width":"100%","height":"80vh"}}>
//     <ul>
//         {tournaments.map((item:Tournament, index)=>{
//             return <li key={index}>
//                 <Link to={`/showTournamentDetailed/${item.id}`}>{item.name}</Link>
//             </li>
//         })}
//     </ul>
// </div>