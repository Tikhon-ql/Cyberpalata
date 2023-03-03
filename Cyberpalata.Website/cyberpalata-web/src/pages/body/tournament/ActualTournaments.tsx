import { useEffect, useState } from "react"
import { Tournament, TournamentDetailed } from "../../../types/types"
import api from "./../../../Components/api";
import {Link} from "react-router-dom";
import React from 'react'
import { Pagination } from "../../../Components/Helpers/Pagination";
import { ClimbingBoxLoader } from "react-spinners";

export type TournamentList = {
    items: Tournament[],
    totalItemsCount: number,
    pageSize: number
}

export const ActualTournaments = ()=>{

    const [tournamentList, setTournamentList] = useState<TournamentList>();
    const [curPage, setCurPage] = useState<number>(1);
    const [isLoading, setIsLoaded] = useState<boolean>(false);

    useEffect(()=>{
        setIsLoaded(true);
        api.get(`/tournaments/getActualTournaments?page=${curPage}`).then(res=>{
            console.dir(res.data);
            setTournamentList(res.data);
        }).finally(()=>{setIsLoaded(false)});
    },[curPage]);
     return <div style={{display:"flex",justifyContent:"center",alignItems:"center",height:"80vh"}}>
    {isLoading ? 
     <div>
        <ClimbingBoxLoader
          color={"white"}
          loading={isLoading}/>
     </div>:
     <div style={{"display":"flex","justifyContent":"center","alignItems":"center","width":"100%","height":"80vh"}}>
     <ul className="list-style-non w-50" style={{"listStyle":"none"}}>
             {tournamentList?.items.map((item:Tournament, index)=>{
                 return <li key={index} className="text-decoration-none m-1">       
                         <Link className="text-decoration-none text-dark" to={`/showTournamentDetailed/${item.id}`}>
                             <div className="d-flex bg-white rounded p-2">
                                 <img src="https://cdn-icons-png.flaticon.com/512/9743/9743492.png" style={{"width":"50px"}}/>
                                 <h6 className="m-3">{item.name}</h6> 
                                 <Link to={`/registerTeam/${item.id}`} style={{background:"#383651","border":"1px solid","padding":"1vh","borderRadius":"1vh",height:"5.5vh",marginTop:"0.7vh", "marginRight":"1vw","textAlign":"center"}}>Register</Link>        
                             </div>
                         </Link>
                 </li>
             })}
     </ul>
     {/* <Pagination totalItemsCount = {tournamentList?.totalItemsCount} pageCount = {tournamentList?.pageSize} curPage = {curPage} setCurPage = {setCurPage}/> */}
    </div>}</div>
}




// <div style={{"display":"flex","justifyContent":"center","alignItems":"center","width":"100%","height":"80vh"}}>
//         <ul className="list-style-non w-50" style={{"listStyle":"none"}}>
//                 {tournaments.map((item:Tournament, index)=>{
//                     return <li key={index} className="text-decoration-none m-1">       
//                             <Link className="text-decoration-none text-dark" to={`/showTournamentDetailed/${item.id}`}>
//                                 <div className="d-flex bg-white rounded p-2">
//                                     <img src="https://cdn-icons-png.flaticon.com/512/4392/4392354.png" width="50"/>
//                                     <h6 className="m-3">{item.name}</h6> 
//                                     <Link to={`/registerTeam/${item.id}`} className="m-2 btn btn-outline-dark" style={{"justifyContent":"end"}}>Register</Link>                    
//                                 </div>
//                             </Link>
//                     </li>
//                 })}
//         </ul>
//     </div>