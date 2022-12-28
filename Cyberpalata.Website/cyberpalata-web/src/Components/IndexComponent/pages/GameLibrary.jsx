import axios from "axios"
import { useEffect, useState } from "react"


const GameLibrary = () => {
    const [games, setGames] = useState([]);

    useEffect(()=>{
        axios.get(`https://localhost:7227/games`).then(res => {
            setGames(res.data.games);
        });
    },[]);
    return(
        <div style={{"position":"absolute","top":"30%","left":"35%"}}>
            {games.map(game=>{
                return <p>{game}</p>
            })}
        </div>
    )
}

export {GameLibrary}