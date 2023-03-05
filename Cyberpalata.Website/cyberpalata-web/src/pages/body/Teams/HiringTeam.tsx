import React, { useEffect, useState } from "react"
import { Link } from "react-router-dom"
import api from "../../../Components/api"
import { Team } from "../../../types/types"
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

export type TeamList = {
    items: Team[],
    pageSize: number,
    totalPageCount: number
}

export const HiringTeam = ()=>{

    const [teamList, setTeamList] = useState<TeamList>(
        {
            items:[
                {id:"gdfsfs",name:"d;g;kjdfigjdfg"},
                {id:"gdfsfs",name:"d;g;dfgdfsdfsgdfgs"},
                {id:"gdfsfs",name:"d;g;sdgdfghgdfsgddf"},
                {id:"gdfsfs",name:"d;g;rter"},
                {id:"gdfsfs",name:"d;g;dffghfggd"},
                {id:"gdfsfs",name:"d;g;fgfh'g"},
                {id:"gdfsfs",name:"d;g;fsdgdh"},
                {id:"gdfsfs",name:"d;g;dsfgdsadfg"},
                {id:"gdfsfs",name:"d;g;sadfds"},
                {id:"gdfsfs",name:"d;g;sdfgdsfg"},
            ],
            pageSize:5,
            totalPageCount: 15
        }
    );
    const [curPage, setCurPage] = useState<number>(1);
    const [curTeamId, setCurTeamId] = useState<string>("");

    useEffect(()=>{
       api.get(`/teams/getHiringTeams?page=${curPage}`).then(res=>{
            setTeamList(res.data);
       });
    },[]);

    function sendTeamJoinRequest(event)
    {
        var requestBody = {
            teamId: event.target.id
        };
        // console.dir(requestBody);
        api.post(`/joinRequests/createJoinRequest?teamId=${event.target.id}`).then(res=>{
            toast.success("Request sended successfully");
        });
    }

    return <div style={{display:"flex",justifyContent:"center",alignItems:"center",height:"80vh"}}>
         <ul className="list-style-non w-50" style={{"listStyle":"none"}}>
             {teamList?.items.map((item:Team, index)=>{
                console.log("dshfiodsjfjdsofidsiofsdiodaTEAm");
                 return <li key={index} className="text-decoration-none m-1" value={item.id}>       
                         <a className="text-decoration-none text-dark">
                             <div className="d-flex bg-white rounded p-2">
                                 <img src="https://cdn-icons-png.flaticon.com/512/9743/9743492.png" style={{"width":"50px"}}/>
                                 <h6 className="m-3">{item.name}</h6> 
                                 <a onClick={(event)=>{sendTeamJoinRequest(event)}} style={{display:"flex",justifyContent:"center",alignItems:"center"}}><img id={item.id}  style={{width:"35px",height:"35px",position:"relative", right:"0px"}} src={require(`./../plus.png`)}/></a>
                             </div>
                         </a>
                 </li>
             })}
     </ul>
    </div>
}