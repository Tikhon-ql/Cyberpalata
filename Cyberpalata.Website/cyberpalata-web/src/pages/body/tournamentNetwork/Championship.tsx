import './../tournament/Tournament.css';
import { Matchup } from './Matchup';
import React from 'react'

export const Championship = ()=>{
    return <>
    	<div className="champion">
                     <div className="final">
						<i className="fa fa-trophy"></i>
						<div className="round-details">championship <br/><span className="date">March 30 - Apr. 1</span></div>
						<Matchup team1={''} team2={''} score1={''} score2={''} isChampionMatchup = {true}/>	
                     	</div>
            	</div>
    </>
}