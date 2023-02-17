import { useEffect, useState } from "react";
import { Batle } from "../../../types/types";
import { Matchup } from "./Matchup";

type Props = {
    round: number,
    teamsCount: number,
    isCurrent: boolean,
    batles: Batle[]
}

export const Round = ({round, isCurrent, teamsCount,batles}:Props) => {

    const [rounds, setRounds] = useState<string[]>(["round-one", "round-two","round-three","round-four","round-five","round-six","round-seven"]);
    const [teamsNumbers, setTeamsNumbers] = useState<number[]>([]);
    // for(let i = 0;i < teamsCount / 2;i++)
    // {
    //     teams.push(i);
    // }
    return <div className={isCurrent ? `round ${rounds[round]} current` : `round ${rounds[round]}`}>
		<div className="round-details">Round {round + 1}<span className="date">March 16</span></div>
        {batles.map((item:Batle,index)=>{
            return <Matchup team1 = {item.firstTeamName} team2 = {item.secondTeamName} score1 = {`${item.firstTeamScore}`} score2 = {`${item.secondTeamScore}`} isChampionMatchup = {false}/>
        })}
	</div>
}

{/* 
<Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>
<Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>
<Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>     */}