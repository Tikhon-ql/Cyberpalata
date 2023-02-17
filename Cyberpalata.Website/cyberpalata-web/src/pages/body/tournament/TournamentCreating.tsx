import api from "./../../../Components/api"

export const TournamentCreating = ()=>{

    function sendTournamentCreatingRequest(event:any)
    {
        event.preventDefault();
        var requestBody = {
            "name":event.target.elements.name.value,
            "date":event.target.elements.date.value,
            "teamsMaxCount":event.target.elements.teamsMaxCount.value
        };
        api.post(`/tournaments/createTournament`,requestBody)
        .then(res=>res)
        .catch(err=>err)
        .finally(()=>{});
    }

    return <div style={{"display":"flex","justifyContent":"center","alignItems":"center","height":"80vh"}}>
        <form onSubmit={(event) => {sendTournamentCreatingRequest(event)}}>
            <input id="name" name="name" type="text" placeholder="Enter tournament name here..."/>
            <input id="date" name="date" type="date"/>
            <input id="teamsMaxCount" name="teamsMaxCount" type="number" placeholder="Enter teams max count here..."/>
            <input type="submit" value="Create"/>
        </form>
    </div>
}