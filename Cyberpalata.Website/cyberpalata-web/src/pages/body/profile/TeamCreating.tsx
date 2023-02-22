import { useNavigate } from "react-router-dom";
import api from "./../../../Components/api"
import React from "react";

export const TeamCreating = () => {

    let navigate = useNavigate();
    function sendTeamCreateRequest(event: any)
    {
        event.preventDefault();
        var requestBody = {
            "name": event.target.elements.teamName.value
        };
        api.post(`/teams/createTeam/`,requestBody).then(()=>{
        }).catch(err=>err).finally(()=>{
            navigate('/profile');
        })
    }

    return <div style={{"display":"flex","justifyContent":"center","alignItems":"center","height":"80vh"}}>
        <form onSubmit={(event)=>{sendTeamCreateRequest(event)}}>
            <input id="teamName" type="text" name="teamName" placeholder="Enter team's name here..."/>
            <input type="submit" value="Create"/>
        </form>
    </div>
}