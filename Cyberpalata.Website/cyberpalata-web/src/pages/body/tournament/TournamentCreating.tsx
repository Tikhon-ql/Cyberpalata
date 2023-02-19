import api from "./../../../Components/api"
import React, { useEffect, useState } from 'react'

export type Round = {
    number:number,
    date:string
}

export const TournamentCreating = ()=>{
    const [rounds, setRounds] = useState<Round[]>([]);
    const [maxState, setMaxState] = useState<boolean>(false);

    useEffect(()=>{

    },[maxState])

    function sendTournamentCreatingRequest(event:any)
    {
        event.preventDefault();
        console.dir(event.target.elements);
        var requestBody = {
            "name":event.target.elements.name.value,
            "date":event.target.elements.date.value,
            "teamsMaxCount":event.target.elements.teamsMaxCount.value,
            "rounds": rounds
        };
        console.dir(requestBody);
        api.post(`/tournaments/createTournament`,requestBody)
        .then(res=>res)
        .catch(err=>err)
        .finally(()=>{});
    }

    function teamsMaxCountChanged(event: any)
    {
        event.preventDefault();
        if(event.target.value >= 8)
        {
            var teamsCount = event.target.value;
            var index:number = 0;
            while(Math.floor(teamsCount) > 1)
            {
                teamsCount /= 2;
                index++;
                console.log(teamsCount);
            }
            var round: number = index - 1;
            if(rounds.length > round)
            {
                for(let i = 0;i < rounds.length - round;i++)
                {
                    rounds.pop();
                }
            }
            else
            {
                for(let i = rounds.length;i < round;i++)
                {
                    rounds.push({
                        number: i,
                        date: ""
                    });
                }
            }      
            console.dir(rounds);
            setMaxState(!maxState);
        }
        // else
        // {
        //     event.target.value /= 4;
        // }
    }

    return <div style={{"display":"flex","justifyContent":"center", "alignItems":"center","width":"100%","height":"80vh"}}>
        <form className="form p-5 bg-white rounded"  onSubmit={(event) => {sendTournamentCreatingRequest(event)}}>
                <div className ="m-1">
                    <input id="name" name="name" className="w-100"  type="text" placeholder="Name here..."/>
                </div>
                <div  className ="m-1">
                    <input id="date" name="date" className="w-100" type="date" placeholder="Date here..."/>
                </div>
                <div className ="m-1">
                    <input id="teamsMaxCount" className="w-100" name="teamsMaxCount" type="number" onChange={(event)=>{teamsMaxCountChanged(event)}}  placeholder="Teams max count here..." min={8} max={40}/>
                </div>
            {rounds.map((item:Round, index)=>{
                return <div className="m-1">
                    <h6 className="m-1">Round number {item.number + 1}</h6>
                    <input id="roundDate" name="roundDate" type="date" onChange={(e)=>{rounds[item.number].date = e.target.value}} className="m-2" placeholder="Round date here..."/>
                </div>
            })}
            <input type="submit" className="m-2" value ="Create"/>
        </form>
    </div>

}

    // return <div style={{"display":"flex","justifyContent":"center","alignItems":"center","height":"80vh"}}>
    //     <form onSubmit={(event) => {sendTournamentCreatingRequest(event)}}>
    //         <input id="name" name="name" type="text" placeholder="Enter tournament name here..."/>
    //         <input id="date" name="date" type="date"/>
    //         <input id="teamsMaxCount" name="teamsMaxCount" type="number" placeholder="Enter teams max count here..."/>
    //         <input type="submit" value="Create"/>
    //     </form>
    // </div>
// }