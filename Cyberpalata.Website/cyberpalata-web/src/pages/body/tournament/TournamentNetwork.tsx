import { useEffect, useState } from "react";
import api from "./../../../Components/api";
import { Championship } from "../tournamentNetwork/Championship";
import { Matchup } from "../tournamentNetwork/Matchup";
import { RoundView } from "../tournamentNetwork/RoundView";
// import "./Tournament.css";
import React from 'react'
import { Batle, Round } from "../../../types/types";

type Props = {
	name:string,
	date:string,
	teamsMaxCount:number,
	rounds: Round[]
}

export const TournamentNetwork = ({name, date, teamsMaxCount,rounds}:Props) => {
    //const [indexes,setIndexes] = useState<number[]>([]);
	//const [teamsMaxCount, setTeamsMaxCount] = useState<number>(32);
	const [teamsCounts, setTeamsCounts] = useState<number[]>([]);
	// const [rounds, setRound] = useState<number[]>([]);
	const [reverseRounds, setReverseRounds] = useState<number[]>([]);
	const [currentRound, setCurrentRound] = useState<number>(0);
	const [splitOneBatles, setSplitOneBatles] = useState<Batle[]>([]);
	const [splitTwoBatles, setSplitTwoBatles] = useState<Batle[]>([]);

	useEffect(()=>{
		// const middle = teamsMaxCount / 2;
		// const splitOne = teams.splice(0, middle);
		// const splitTwo = teams.splice(-middle);
		// for(let i = 0;i < middle / 2;i+=2)
		// {
		// 	const batle:Batle = {
		// 		teamOne: splitOne[i],
		// 		teamOneScore: 1,
		// 		teamTwo: splitOne[i + 1],
		// 		teamTwoScore:1
		// 	};
		// 	console.dir(batle);
		// 	splitOneBatles.push(batle);
		// }
		// for(let i = 0;i < middle / 2;i+=2)
		// {
		// 	const batle:Batle = {
		// 		teamOne: splitTwo[i],
		// 		teamOneScore: 1,
		// 		teamTwo: splitTwo[i + 1],
		// 		teamTwoScore:1
		// 	};
		// 	splitTwoBatles.push(batle);
		// }
		// console.log("split one");
		// console.dir(splitOneBatles);
	},[]);

	let max = teamsMaxCount;
	while(Math.floor(max / 2) > 0)
	{
		teamsCounts.push(max / 2);
		max = Math.floor(max / 2);
	}
	console.dir(teamsCounts);

	// for(let i = 0 ; i < (teamsMaxCount / 8);i++)
	// {
	// 	rounds.push(i);
	// }
	// console.dir(rounds);
	// for(let i = (teamsMaxCount / 8) - 1;i >= 0;i--)
	// {
	// 	reverseRounds.push(i);
	// }
	console.log("Rounds");
	console.dir(rounds);
	console.log("Lenght:" + rounds[0].batles.length);
	// 16 -> 8 -> 4 -> 2 -> 1

    return <div>
        <section id="bracket" className="h-75">
            <div className="container">
				<div className="split split-one">
					{/* <Round round={0} teamsCount = {teamsCounts[0]} isCurrent={0 == currentRound ? true : false} batles={batles.splice(0,batles.length / 2)}/> */}
					{rounds.map((item:Round, index)=>{
						console.dir(item.number)
						return <RoundView date={item.date} key={index} round={item.number} isCurrent={item.number == currentRound ? true : false} batles={item.batles.splice(0, item.batlesMaxCount)} teamsMaxCount={teamsMaxCount}/>
					})}
{/*
				<Round round={2} isCurrent={false}/>	 */}
				</div>
				<Championship/>
				<div className="split split-two">
					{rounds.reverse().map((item:Round, index)=>{
						return <RoundView date={item.date} key={index} round={item.number} isCurrent={item.number == currentRound ? true : false} batles={item.batles.splice(item.batles.length - item.batlesMaxCount)} teamsMaxCount={teamsMaxCount}/>
					})}
					{/* <Round round={0} teamsCount = {teamsCounts[0]} isCurrent={0 == currentRound ? true : false} batles={batles.splice(-(batles.length))}/> */}
					{/* <Round round={2} isCurrent={false}/>
					<Round round={1} isCurrent={true}/> */}
				</div>
            </div>
        </section>
	   </div>	
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