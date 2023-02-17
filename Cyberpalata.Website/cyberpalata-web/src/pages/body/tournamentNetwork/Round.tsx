import { useEffect, useState } from "react";
import { Batle } from "../../../types/types";
import { Matchup } from "./Matchup";
import React from 'react'

type Props = {
    round: number,
    teamsCount: number,
    isCurrent: boolean,
    batles: Batle[]
}

export const Round = ({round, isCurrent, teamsCount,batles}:Props) => {

    const [rounds, setRounds] = useState<string[]>(["round-one", "round-two","round-three","round-four","round-five","round-six","round-seven"]);
    const [teamsNumbers, setTeamsNumbers] = useState<number[]>([]);
    for(let i = 0;i < teamsCount / 2;i++)
    {
        teamsNumbers.push(i);
    }
    //console.dir(batles);
    //console.log(`Round ${round} : ${teamsCount}`);
    return <div className={isCurrent ? `round ${rounds[round]} current` : `round ${rounds[round]}`}>
		<div className="round-details">Round {round + 1}<span className="date">March 16</span></div>
            {teamsNumbers.map((item:number,index)=>{
            return <Matchup team1 = {batles[item] ? batles[item].firstTeamName : " "} 
                            team2 = {batles[item] ? batles[item].secondTeamName : " "} 
                            score1 = {batles[item] ? `${batles[item].firstTeamScore}` : " "} 
                            score2 = {batles[item] ? `${batles[item].secondTeamScore}` : " "} isChampionMatchup = {false}/>
        })
        //</div> 
        // :<div> 
        //     {batles.map((item:Batle,index)=>{
        //     return <Matchup team1 = {" "} team2 = {" "} score1 = {` `} score2 = {` `} isChampionMatchup = {false}/>
        // })}</div>
    }
	</div>
}

{/* 
<Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>
<Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>
<Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>     */}