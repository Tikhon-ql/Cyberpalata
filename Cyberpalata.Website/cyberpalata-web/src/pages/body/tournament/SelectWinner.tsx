import React, { useState } from "react"
import { useParams } from "react-router-dom"
import api from "../../../Components/api";

export const SelectWinner = () => {

    const {firstTeamName} = useParams();
    const {firstTeamId} = useParams();
    const {secondTeamName} = useParams();
    const {secondTeamId} = useParams();
    const {batleId} = useParams();
    const {tournamentId} = useParams();

    const [winnerId, setWinnerId] = useState<string>("");

    function submitWinner(e)
    {
        e.preventDefault();
        var requestBody = {
            tournamentId: tournamentId,
            batleId: batleId,
            winnerId: e.target.elements.winner.value
        }
        console.dir(requestBody);
        api.post(`/batles/setWinner`,requestBody).then(res=>res);
    }

    return (
        <div style={{"display":"flex","justifyContent":"center","alignItems":"center","width":"100%","height":"80vh",color:"white"}}>
            <form onSubmit={(e)=>{submitWinner(e)}}>
                <input id="winner1" name="winner" type="radio" value={firstTeamId}/><label>{firstTeamName}</label>
                <input id="winner2" name="winner" type="radio" value={secondTeamId}/><label>{secondTeamName}</label>
                <input type="submit" value="Submit"/>
            </form>
        </div>
    )
}