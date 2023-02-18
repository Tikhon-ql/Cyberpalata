import { useEffect, useState } from "react";
import { Batle } from "../../../types/types";
import { Matchup } from "./Matchup";
import React from 'react'

type Props = {
    teamsMaxCount: number
    round: number,
    isCurrent: boolean,
    batles: Batle[],
    date:string
}

export const RoundView = ({round, isCurrent,batles, teamsMaxCount, date}:Props) => {

    const [rounds, setRounds] = useState<string[]>(["round-one", "round-two","round-three","round-four","round-five","round-six","round-seven"]);
    const [batleNumbers, setBatleNumbers] = useState<number[]>([]);
    if(batles.length == 0)
    {
        console.log("anime");
        var count: number = teamsMaxCount / 4 - round * 2;
        count = count === 0 ? 1 : count;
        for(let i = 0;i < count;i++)
        {
            batles.push({
                firstTeamName: " ",
                secondTeamName: " ",
                firstTeamScore: 0,
                secondTeamScore: 0,
                date: " ",
                time: " ",
            });
        }      
        console.dir(batles);
    }
    // for(let i = 0;i < teamsCount / 2;i++)
    // {
    //     teamsNumbers.push(i);
    // }
    //console.dir(batles);
    //console.log(`Round ${round} : ${teamsCount}`);
    return <div className={isCurrent ? `round ${rounds[round]} current` : `round ${rounds[round]}`}>
		<div className="round-details">Round {round + 1}<span className="date"> {date}</span></div>
            {batles.map((item:Batle,index)=>{
                console.log(item.firstTeamName + " " + item.secondTeamName);
                if(!item)
                {
                    item = {
                        firstTeamName: " ",
                        secondTeamName: " ",
                        firstTeamScore: 0,
                        secondTeamScore: 0,
                        date: " ",
                        time: " ",
                    }
                }
                console.dir(item);
            return <Matchup team1 = {item.firstTeamName} team2 = {item.secondTeamName} score1 = {`${item.firstTeamScore}`} score2 = {`${item.secondTeamScore}`} isChampionMatchup = {false}/>
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