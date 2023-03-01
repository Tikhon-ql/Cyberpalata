import React, { useEffect, useState } from "react"
import { Link } from "react-router-dom";
import { useParams } from "react-router-dom"
import { ClimbingBoxLoader } from "react-spinners";
import api from "../../../Components/api";
import { Pagination } from "../../../Components/Helpers/Pagination";
import { Tournament, UserTournament } from "../../../types/types";

export type UserTournamentList = {
    items: UserTournament[],
    totalItemsCount: number,
    pageSize: number
}

export const UsersTournaments = ()=>{
    // const {tournamentId} = useParams();
    const [isLoading, setIsLoading] = useState<boolean>(false);

    const [usersTournamentsList, setUsersTournamentsList] = useState<UserTournamentList>();
    const [curPage, setCurPage] = useState<number>(1);
    useEffect(()=>{
        setIsLoading(true);
        api.get(`/tournaments/getUsersTournaments?page=${curPage}`).then(res=>{
            console.dir(res.data);
            setUsersTournamentsList(res.data);
        }).finally(()=>{setIsLoading(false)});
    },[curPage]);

    return <div style={{display:"flex",justifyContent:"center",alignItems:"center",height:"80vh"}}>
    {isLoading ? <div>
        <ClimbingBoxLoader
            loading={isLoading}
            color={"white"}/>
    </div>:
        <div style={{"display":"flex","justifyContent":"center","alignItems":"center","width":"100%","height":"80vh"}}>
            <div className="w-100">
                <div style={{display:"flex",justifyContent:"center",alignItems:"center",width:"100%"}}>
                    <ul className="list-style-non w-50" style={{"listStyle":"none"}}>
                        {usersTournamentsList?.items.map((item:UserTournament, index)=>{
                            return <li key={index} className="text-decoration-none m-1">       
                                    <Link className="text-decoration-none text-dark" to={`/showQrCode/${item.id}/${item.teamId}`}>
                                        <div className="d-flex bg-white rounded p-2">
                                            <img src="https://cdn-icons-png.flaticon.com/512/9743/9743492.png" style={{"width":"50px"}}/>
                                            <h6 className="m-3">{item.name}</h6> 
                                        </div>
                                    </Link>
                            </li>
                        })}
                    </ul>
                </div>
                <div>
                    <Pagination totalItemsCount = {usersTournamentsList?.totalItemsCount} pageCount = {usersTournamentsList?.pageSize} curPage = {curPage} setCurPage = {setCurPage}/>
                </div>
            </div>
        </div>  
    }
    </div>
}