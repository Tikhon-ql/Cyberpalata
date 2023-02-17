import { useEffect, useState } from "react"
import api from "./../../../Components/api";
import { Team, Tournament } from "./../../../types/types";
import React from 'react'

export const TournamentTeamRegistration = ()=>{

    const [teams, setTeams] = useState<Team[]>([]);
    const [tournaments, setTournaments] = useState<Tournament[]>([]);
    useEffect(()=>{
        api.get('/teams/getByUserId').then(res=>{
            console.dir(res);
            setTeams(res.data);
        });
        api.get('/tournaments/getActualTournaments').then(res=>{
            console.dir(res);
            setTournaments(res.data);
        })
    },[]);

    function sendTournamentCreatingRequest(event:any)
    {
        console.log("anime");
        event.preventDefault();
        console.dir(event);
        let requestBody = 
        { 
            "tournamentId":event.target[0].value,
            "teamId": event.target[1].value
        };
        api.put(`/tournaments/registerTeam`,requestBody).then(res=>res).catch(err=>err);
    }

    return <>
        <form onSubmit={(event)=>{sendTournamentCreatingRequest(event)}}>
            <select id="tournament" name="tournament">
                {tournaments.map((item:Tournament,index)=>{
                    return <>
                        <option key={index} value={item.id}>{item.name}</option>
                    </>
                })}
            </select>
            <select id="teams" name="teams">
                {teams.map((item:Team,index)=>{
                    return <>
                        <option key={index} value={item.id}>{item.name}</option>
                    </>
                })}
            </select>
            <input type="submit" value="Register"/>
        </form>
    </>
}