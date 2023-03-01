import { useNavigate } from "react-router-dom";
import api from "./../../../Components/api"
import React, { useState } from "react";

export const TeamCreating = () => {

    let navigate = useNavigate();
    const [teamName, setTeamName] = useState<string>("");
    const [otherError, setOtherError] = useState<string>("");
    const [teamNameError, setTeamNameError] = useState<string>("");

    function clearErrors()
    {
        setOtherError("");
        setTeamNameError("");
    }

    function sendTeamCreateRequest(event: any)
    {
        event.preventDefault();
        var requestBody = {
            "name": event.target.elements.teamName.value
        };
        api.post(`/teams/createTeam/`,requestBody).then(()=>{ navigate('/profile')
        }).catch(err=>
            {
                const data = err.response.data;
                if(data.Other)
                {
                    setOtherError(data.Other);
                }
                if(data.Name)
                {
                    setTeamNameError(data.Name);
                }
            }).finally(()=>{
           ;
        })
    }


    return <div style={{"display":"flex","justifyContent":"center","alignItems":"center","height":"80vh"}}>
        <form onSubmit={(event)=>{sendTeamCreateRequest(event)}}>
            {otherError != "" && <div className="m-1 text-danger">{otherError}</div>}
            <input id="teamName" type="text" onChange={(e)=>{setTeamName(e.target.value);clearErrors();}} name="teamName" value={teamName} placeholder="Enter team's name here..."/>
            {teamNameError != "" && <div className="m-1 text-danger">{teamNameError}</div>}
            <input type="submit" value="Create"/>
        </form>
    </div>
}