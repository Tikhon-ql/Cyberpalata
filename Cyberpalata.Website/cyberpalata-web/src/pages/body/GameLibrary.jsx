import axios from "axios"
import { useEffect, useState } from "react"
import { Link } from "react-router-dom";


const GameLibrary = () => {
    const [games, setGames] = useState([]);

    useEffect(()=>{
        axios.get(`https://localhost:7227/games`).then(res => {
            setGames(res.data.games);
        });
    },[]);
    return(

        <div className="mt-5 p-5" style={{"margin":"auto","width":"50%", "border" : "3px solid black", "padding" : "10px"}}>
            <h1>Game library</h1>
            <ul class="list-group list-group-flush">
            {games.map(game=>{
                return <li class="list-group-item">{game}</li>
            })}
            </ul>
          
            <Link to='/' className="btn btn-outline-dark btn-sm mt-2">Home page</Link>
        </div>
    )
}




export {GameLibrary}