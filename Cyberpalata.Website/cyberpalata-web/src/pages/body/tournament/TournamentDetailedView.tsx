import { Children, useEffect, useRef, useState } from "react";
import { useParams } from "react-router-dom"
import api from "../../../Components/api";
import { TournamentDetailed } from "../../../types/types";
import { TournamentNetwork } from "./TournamentNetwork";
import React from 'react';
import './custom-tree.css';
import { useCenteredTree } from "./helpers";
import { TreeMap } from "../tournamentNetwork/TreeMap";


var treeData = {
    firstTeamName:"slhflif",
    secondTeamName: "secsdghgf",
    name: "",
    roundNumber: 0,
    children:[],
    batleId:"",
    firstTeamId:"",
    secondTeamId: "",
};

export const TournamentDetailedView = ()=> {
    const [isloaded, setIsLoaded] = useState<boolean>(false);
    const {id} = useParams();
    const [tournament, setTournament] = useState<any>({});
    const [firstRound, setFirstRound] = useState<any>([]);
    const [secondRound, setSecondRound] = useState<any>([]);
    const [thirdRound, setThirdRound] = useState<any>([]);
    const [firstRoundCoef, setFirstRoundCoef] = useState<number>(1);
    const [secondRoundCoef, setSecondRoundCoef] = useState<number>(1.5);
    const [thirdRoundCoef, setThirdRoundCoef] = useState<number>(2);

    const [tournamentId, setTournamentId] = useState<string>("");
    function initTree(node:any, list:any, parIndex:number)
    {
        var right:number =  2 * (parIndex + 1);
        var left: number =  2 * (parIndex + 1) - 1;
        // console.log("Par index : " + parIndex);
        // console.log(`Left: ${left}`);
        // console.log(`Right: ${right}`);
        if(!list[left])
            return;
        //console.log("Logdfkgn");
        //console.dir(node);
        list[left].children = [];
        list[left]['events'] = "dsd";
        if(list[left].firstTeamName === "")
        {
            list[left].name = list[left].secondTeamName;
        }
        if(list[left].secondTeamName === "")
        {
            list[left].name = list[left].firstTeamName;
        }
        if(list[left].firstTeamName != "" && list[left].secondTeamName != "")
        {
            list[left].name = `${list[left].firstTeamName} VS ${list[left].secondTeamName}`;
        }
        node.children.push(list[left]);
        initTree(node.children[0],list,left);
        list[right].children = [];
        if(list[right].firstTeamName === "")
        {
            list[right].name = list[right].secondTeamName;
        }
        if(list[right].secondTeamName === "")
        {
            list[right].name = list[right].firstTeamName;
        }
        if(list[right].firstTeamName != "" && list[right].secondTeamName != "")
        {
            list[right].name = `${list[right].firstTeamName} VS ${list[right].secondTeamName}`;
        }
        //list[right].name = `${list[right].firstTeamName} VS ${list[right].secondTeamName} ${list[right].roundNumber}`;
        node.children.push(list[right]);
        initTree(node.children[1],list,right);
    }

    
    useEffect(()=>{
        api.get(`/tournaments/getTournamentDetaile?tournamentId=${id}`).then(res=>{
            console.log("anime23123");
            console.dir(res.data);
            setTournamentId(res.data.tournamentId);
            treeData = {
                firstTeamName:res.data.batles[0].firstTeamName,
                secondTeamName:res.data.batles[0].secondTeamName,
                roundNumber: res.data.batles[0].roundNumber,
                children:[],
                name: "",
                batleId:res.data.batles[0].batleId,
                firstTeamId: res.data.batles[0].firstTeamId,
                secondTeamId: res.data.batles[0].secondTeamId
            }
            if(treeData.firstTeamName === "")
            {
                treeData.name = treeData.secondTeamName;
            }
            if(treeData.secondTeamName === "")
            {
                treeData.name = treeData.firstTeamName;
            }
            if(treeData.firstTeamName != "" && treeData.secondTeamName != "")
            {
                treeData.name = `${treeData.firstTeamName} VS ${treeData.secondTeamName}`;
            }
            //treeData.name = `${treeData.firstTeamName} VS ${treeData.secondTeamName} ${treeData.roundNumber}`;
            initTree(treeData,res.data.batles, 0);
            setTournament(res.data);
            console.log("Tree nodeeee");
            console.dir(treeData);
            //console.dir(tournament); 
            setIsLoaded(true);
        });
    },[]);
    useEffect(()=>{
        if(treeData.name != "")
        {

        }
    },[treeData]);
    return (
        <TreeMap tournamentId={tournamentId} treeData={treeData}/>
        // <svg ref={svgRef}>

        // </svg>
      
        // `<Tree />` will fill width/height of its container; in this case `#treeWrapper`.
        //<div className='bracket'>
        
            /* <div className='round'>
                {thirdRound.map((item,index)=>{
                    return  <div className="match" key={index}>
                        <div className="team">{item.firstChildTeamName}</div>
                        <div className="team">{item.secondChildTeamName}</div>
                    </div>
                })}
            </div>
            <div className='round'>
                {secondRound.map((item,index)=>{
                        return  <div className="match" key={index}>
                            <div className="team">{item.firstChildTeamName}</div>
                            <div className="team">{item.secondChildTeamName}</div>
                        </div>
                })}
            </div>
            <div className='round'>
                {firstRound.map((item,index)=>{
                    return  <div className="match" key={index}>
                        <div className="team">{item.firstChildTeamName}</div>
                        <div className="team">{item.secondChildTeamName}</div>
                    </div>
                })}
            </div> */
        // </div>
      );
};
    //     name:"",
    //     date:"",
    //     teamsMaxCount:16,
    //     rounds:[{
    //         number:0,
    //         batles:[],
    //         batlesMaxCount:4,
    //         date:"21.12.2023"
    //     },{
    //         number:1,
    //         batles:[],
    //         batlesMaxCount:2,
    //         date:"21.12.2023"
    //     },{
    //         number:2,
    //         batles:[],
    //         batlesMaxCount:1,
    //         date:"21.12.2023"
    //     }]
    // });
    // useEffect(()=>{
    //     api.get(`/tournaments/getTournamentDetaile?tournamentId=${id}`).then(res=>{
    //         console.log("anime");
    //         console.dir(res.data); 
    //         // setTournament(res.data);
    //         // setIsLoaded(true);
    //     })
    // },[]);
    // return <>
    //     {isloaded && <TournamentNetwork name={tournament.name} date={tournament.date} teamsMaxCount={tournament.teamsMaxCount} rounds={tournament.rounds}/>   }
    // </>