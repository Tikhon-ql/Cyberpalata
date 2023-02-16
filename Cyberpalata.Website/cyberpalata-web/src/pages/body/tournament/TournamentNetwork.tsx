import { useEffect, useState } from "react";
import api from "src/Components/api";
import { Championship } from "../tournamentNetwork/Championship";
import { Matchup } from "../tournamentNetwork/Matchup";
import { Round } from "../tournamentNetwork/Round";
import "./Tournament.css";

export const TournamentNetwork = () => {
    const [indexes,setIndexes] = useState<number[]>([]);
	const [teamsMaxCount, setTeamsMaxCount] = useState<number>(32);
	const [teamsCounts, setTeamsCounts] = useState<number[]>([]);
	const [rounds, setRound] = useState<number[]>([]);
	const [reverseRounds, setReverseRounds] = useState<number[]>([]);
	const [currentRound, setCurrentRound] = useState<number>(0);

	let max = teamsMaxCount;
	while(Math.floor(max / 2) > 0)
	{
		teamsCounts.push(max/2);
		max = Math.floor(max / 2);
	}
	console.dir(teamsCounts);

	for(let i = 0 ; i < (teamsMaxCount / 8);i++)
	{
		rounds.push(i);
	}
	console.dir(rounds);
	for(let i = (teamsMaxCount / 8) - 1;i >= 0;i--)
	{
		reverseRounds.push(i);
	}

	// 16 -> 8 -> 4 -> 2 -> 1

    return <>
        <section id="bracket">
            <div className="container">
				<div className="split split-one">
					{rounds.map((item:number, index)=>{
						return <Round round={item} teamsCount = {teamsCounts[index]} isCurrent={index == currentRound ? true : false}/>
					})}
{/*
					<Round round={2} isCurrent={false}/>	 */}
				</div>
				<Championship/>
				<div className="split split-two">
					{reverseRounds.map((item:number, index)=>{
						return <Round round={item} teamsCount = {teamsCounts[(teamsMaxCount / 8) - 1 - index]} isCurrent={(teamsMaxCount / 8) - 1 - index == currentRound ? true : false}/>
					})}
					{/* <Round round={2} isCurrent={false}/>
					<Round round={1} isCurrent={true}/> */}
				</div>
            </div>
        </section>
	   </>
}




	{/* <div className="round round-two">
							<div className="round-details">Round 2<span className="date">March 18</span></div>
								<Matchup team1={''} team2={''} score1={''} score2={''} isChampionMatchup = {false}/>
								<Matchup team1={''} team2={''} score1={''} score2={''} isChampionMatchup = {false}/>
						</div> */}
					{/* <div className="round round-one current">
							<div className="round-details">Round 1<span className="date">March 16</span></div>
							<Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>
							<Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>
							<Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>
							<Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>                  
					</div> */}


				{/* <div className="round round-one current">
						<div className="round-details">Round 1<span className="date">March 16</span></div>
						<Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>
						<Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>
						<Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>
						<Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>                  
					</div>
					<div className="round round-two">
						<div className="round-details">Round 2<span className="date">March 18</span></div>
							<Matchup team1={''} team2={''} score1={''} score2={''} isChampionMatchup = {false}/>
							<Matchup team1={''} team2={''} score1={''} score2={''} isChampionMatchup = {false}/>
					</div> */}



// 					<div className="split split-one">
//                     <div className="round round-one current">
//                         <div className="round-details">Round 1<span className="date">March 16</span></div>
//                         <Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>
//                         <Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>
//                         <Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>
//                         <Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>                  
//                     </div>
//                     <div className="round round-two">
//                         <div className="round-details">Round 2<span className="date">March 18</span></div>
//                         <Matchup team1={''} team2={''} score1={''} score2={''} isChampionMatchup = {false}/>
//                         <Matchup team1={''} team2={''} score1={''} score2={''} isChampionMatchup = {false}/>
//                     </div>
//                    </div>
//                    
//                      <div className="split split-two">
//                      <div className="round round-two">
//                         <div className="round-details">Round 2<span className="date">March 18</span></div>
//                         <Matchup team1={''} team2={''} score1={''} score2={''} isChampionMatchup = {false}/>
//                         <Matchup team1={''} team2={''} score1={''} score2={''} isChampionMatchup = {false}/>
//                     </div>
//                         <div className="round round-one current">
//                             <div className="round-details">Round 1<span className="date">March 16</span></div>
//                             <Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>
//                             <Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>
//                             <Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>
//                             <Matchup team1 = {`Navi`} team2 = {`VP`} score1 = {"1"} score2 = {"3"} isChampionMatchup = {false}/>  
//                         </div>
//                     </div>





{/* <section id="bracket">
	<div className="container">
	<div className="split split-one">
		<div className="round round-one current">
			<div className="round-details">Round 1<br/><span className="date">March 16</span></div>
			<ul className="matchup">
				<li className="team team-top">Duke<span className="score">76</span></li>
				<li className="team team-bottom">Virginia<span className="score">82</span></li>
			</ul>
			<ul className="matchup">
				<li className="team team-top">Wake Forest<span className="score">64</span></li>
				<li className="team team-bottom">Clemson<span className="score">56</span></li>
			</ul>
			<ul className="matchup">
				<li className="team team-top">North Carolina<span className="score">68</span></li>
				<li className="team team-bottom">Florida State<span className="score">54</span></li>
			</ul>
			<ul className="matchup">
				<li className="team team-top">NC State<span className="score">74</span></li>
				<li className="team team-bottom">Maryland<span className="score">92</span></li>
			</ul>			
			<ul className="matchup">
				<li className="team team-top">Georgia Tech<span className="score">78</span></li>
				<li className="team team-bottom">Georgia<span className="score">80</span></li>
			</ul>	
			<ul className="matchup">
				<li className="team team-top">Auburn<span className="score">64</span></li>
				<li className="team team-bottom">Florida<span className="score">63</span></li>
			</ul>	
			<ul className="matchup">
				<li className="team team-top">Kentucky<span className="score">70</span></li>
				<li className="team team-bottom">Alabama<span className="score">59</span></li>
			</ul>
			<ul className="matchup">
				<li className="team team-top">Vanderbilt<span className="score">64</span></li>
				<li className="team team-bottom">Gonzaga<span className="score">68</span></li>
			</ul>										
		</div>	{/*END ROUND ONE*/}

	// 	<div className="round round-two">
	// 		<div className="round-details">Round 2<br/><span className="date">March 18</span></div>			
	// 		<ul className="matchup">
	// 			<li className="team team-top">&nbsp;<span className="score">&nbsp;</span></li>
	// 			<li className="team team-bottom">&nbsp;<span className="score">&nbsp;</span></li>
	// 		</ul>	
	// 		<ul className="matchup">
	// 			<li className="team team-top">&nbsp;<span className="score">&nbsp;</span></li>
	// 			<li className="team team-bottom">&nbsp;<span className="score">&nbsp;</span></li>
	// 		</ul>	
	// 		<ul className="matchup">
	// 			<li className="team team-top">&nbsp;<span className="score">&nbsp;</span></li>
	// 			<li className="team team-bottom">&nbsp;<span className="score">&nbsp;</span></li>
	// 		</ul>
	// 		<ul className="matchup">
	// 			<li className="team team-top">&nbsp;<span className="score">&nbsp;</span></li>
	// 			<li className="team team-bottom">&nbsp;<span className="score">&nbsp;</span></li>
	// 		</ul>										
	// 	</div>	{/*END ROUND TWO*/}
		
	// 	<div className="round round-three">
	// 		<div className="round-details">Round 3<br/><span className="date">March 22</span></div>			
	// 		<ul className="matchup">
	// 			<li className="team team-top">&nbsp;<span className="score">&nbsp;</span></li>
	// 			<li className="team team-bottom">&nbsp;<span className="score">&nbsp;</span></li>
	// 		</ul>	
	// 		<ul className="matchup">
	// 			<li className="team team-top">&nbsp;<span className="score">&nbsp;</span></li>
	// 			<li className="team team-bottom">&nbsp;<span className="score">&nbsp;</span></li>
	// 		</ul>										
	// 	</div>	{/*END ROUND THREE*/}		
	// </div> 

// <div className="champion">
// 		<div className="semis-l">
// 			<div className="round-details">west semifinals <br/><span className="date">March 26-28</span></div>		
// 			<ul className ="matchup championship">
// 				<li className="team team-top">&nbsp;<span className="vote-count">&nbsp;</span></li>
// 				<li className="team team-bottom">&nbsp;<span className="vote-count">&nbsp;</span></li>
// 			</ul>
// 		</div>
// 		<div className="final">
// 			<i className="fa fa-trophy"></i>
// 			<div className="round-details">championship <br/><span className="date">March 30 - Apr. 1</span></div>		
// 			<ul className ="matchup championship">
// 				<li className="team team-top">&nbsp;<span className="vote-count">&nbsp;</span></li>
// 				<li className="team team-bottom">&nbsp;<span className="vote-count">&nbsp;</span></li>
// 			</ul>
// 		</div>
// 		<div className="semis-r">		
// 			<div className="round-details">east semifinals <br/><span className="date">March 26-28</span></div>		
// 			<ul className ="matchup championship">
// 				<li className="team team-top">&nbsp;<span className="vote-count">&nbsp;</span></li>
// 				<li className="team team-bottom">&nbsp;<span className="vote-count">&nbsp;</span></li>
// 			</ul>
// 		</div>	
// 	</div>


// 	<div className="split split-two">


// 		<div className="round round-three">
// 			<div className="round-details">Round 3<br/><span className="date">March 22</span></div>						
// 			<ul className="matchup">
// 				<li className="team team-top">&nbsp;<span className="score">&nbsp;</span></li>
// 				<li className="team team-bottom">&nbsp;<span className="score">&nbsp;</span></li>
// 			</ul>	
// 			<ul className="matchup">
// 				<li className="team team-top">&nbsp;<span className="score">&nbsp;</span></li>
// 				<li className="team team-bottom">&nbsp;<span className="score">&nbsp;</span></li>
// 			</ul>										
// 		</div>	{/*END ROUND THREE*/}	

// 		<div className="round round-two">
// 			<div className="round-details">Round 2<br/><span className="date">March 18</span></div>						
// 			<ul className="matchup">
// 				<li className="team team-top">&nbsp;<span className="score">&nbsp;</span></li>
// 				<li className="team team-bottom">&nbsp;<span className="score">&nbsp;</span></li>
// 			</ul>	
// 			<ul className="matchup">
// 				<li className="team team-top">&nbsp;<span className="score">&nbsp;</span></li>
// 				<li className="team team-bottom">&nbsp;<span className="score">&nbsp;</span></li>
// 			</ul>	
// 			<ul className="matchup">
// 				<li className="team team-top">&nbsp;<span className="score">&nbsp;</span></li>
// 				<li className="team team-bottom">&nbsp;<span className="score">&nbsp;</span></li>
// 			</ul>
// 			<ul className="matchup">
// 				<li className="team team-top">&nbsp;<span className="score">&nbsp;</span></li>
// 				<li className="team team-bottom">&nbsp;<span className="score">&nbsp;</span></li>
// 			</ul>										
// 		</div>	{/*END ROUND TWO*/}
//  		<div className="round round-one current">
// 			<div className="round-details">Round 1<br/><span className="date">March 16</span></div>
// 			<ul className="matchup">
// 				<li className="team team-top">Minnesota<span className="score">62</span></li>
// 				<li className="team team-bottom">Northwestern<span className="score">54</span></li>
// 			</ul>
// 			<ul className="matchup">
// 				<li className="team team-top">Michigan<span className="score">68</span></li>
// 				<li className="team team-bottom">Iowa<span className="score">66</span></li>
// 			</ul>
// 			<ul className="matchup">
// 				<li className="team team-top">Illinois<span className="score">64</span></li>
// 				<li className="team team-bottom">Wisconsin<span className="score">56</span></li>
// 			</ul>
// 			<ul className="matchup">
// 				<li className="team team-top">Purdue<span className="score">36</span></li>
// 				<li className="team team-bottom">Boise State<span className="score">40</span></li>
// 			</ul>			
// 			<ul className="matchup">
// 				<li className="team team-top">Penn State<span className="score">38</span></li>
// 				<li className="team team-bottom">Indiana<span className="score">44</span></li>
// 			</ul>	
// 			<ul className="matchup">
// 				<li className="team team-top">Ohio State<span className="score">52</span></li>
// 				<li className="team team-bottom">VCU<span className="score">80</span></li>
// 			</ul>	
// 			<ul className="matchup">
// 				<li className="team team-top">USC<span className="score">58</span></li>
// 				<li className="team team-bottom">Cal<span className="score">59</span></li>
// 			</ul>
// 			<ul className="matchup">
// 				<li className="team team-top">Virginia Tech<span className="score">74</span></li>
// 				<li className="team team-bottom">Dartmouth<span className="score">111</span></li>
// 			</ul>										
// 		</div> {/*END ROUND ONE*/}          				
// 	</div>
// 	</div>
// 	</section>
//   */}