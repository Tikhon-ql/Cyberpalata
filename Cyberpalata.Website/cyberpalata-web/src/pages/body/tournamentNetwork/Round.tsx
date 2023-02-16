import { useEffect, useState } from "react";
import { Matchup } from "./Matchup";

type Props = {
    round: number,
    teamsCount: number,
    isCurrent: boolean
}

export const Round = ({round, isCurrent, teamsCount}:Props) => {

    const [rounds, setRounds] = useState<string[]>(["round-one", "round-two","round-three","round-four","round-five","round-six","round-seven"]);
    const [teams, setTeams] = useState<number[]>([]);
    console.log(teamsCount);
    for(let i = 0;i < teamsCount / 2;i++)
    {
        teams.push(i);
    }
    return <div className={isCurrent ? `round ${rounds[round]} current` : `round ${rounds[round]}`}>
		<div className="round-details">Round {round + 1}<span className="date">March 16</span></div>
        {teams.map((item:number,index)=>{
            return <Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {`${index}`} score2 = {`${index}`} isChampionMatchup = {false}/>
        })}
	</div>
}

{/* 
<Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>
<Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>
<Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>     */}