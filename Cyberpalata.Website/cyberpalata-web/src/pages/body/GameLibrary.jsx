import axios from "axios"
import jwtDecode from "jwt-decode";
import { useEffect, useState } from "react"
import { Link } from "react-router-dom";
import api from "./../../Components/api";

const GameLibrary = () => {
    const [games, setGames] = useState([]);
    useEffect(()=>{
        //const baseUrl = `http://dotnetinternship2022.norwayeast.cloudapp.azure.com:83`;
        api.get(`/games`).then(res => {
            setGames(res.data.games);
        });
    },[]);
    return(

        <div className="mt-5 p-5" style={{"margin":"auto","width":"50%", "border" : "3px solid black", "padding" : "10px"}}>
            <h1>Game library</h1>
            <ul className="list-group list-group-flush">
            {games.map(game=>{
                return <li className="list-group-item">{game}</li>
            })}
            </ul>
          
            <Link to='/' className="btn btn-outline-dark btn-sm mt-2">Home page</Link>
        </div>
    )
}
export {GameLibrary}