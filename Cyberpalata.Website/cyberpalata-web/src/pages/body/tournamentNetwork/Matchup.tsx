import './../tournament/Tournament.css';

type Props = {
    team1: string,
    team2: string,
    score1: string,
    score2: string,
    isChampionMatchup: boolean
}

export const Matchup = ({team1,team2,score1,score2, isChampionMatchup}:Props)=>{
    return <>
        <ul className={isChampionMatchup ? "matchup championship" : "matchup"}>
            <li className="team team-top">{team1}<span className={isChampionMatchup ? "vote-count" : "score"}>{score1}</span></li>
            <li className="team team-bottom">{team2}<span className={isChampionMatchup ? "vote-count" : "score"}>{score2}</span></li>
        </ul>
    </>
}