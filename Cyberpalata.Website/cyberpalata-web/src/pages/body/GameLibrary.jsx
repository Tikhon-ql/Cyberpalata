import axios from "axios"
import jwtDecode from "jwt-decode";
import { observer } from "mobx-react-lite";
import { useEffect, useState } from "react"
import { Link } from "react-router-dom";
import stateStore from "../../store/stateStore";
import api from "./../../Components/api";
import BarLoader from "react-spinners/BarLoader";

const GameLibrary = () => {
    const [games, setGames] = useState([]);
    const [loading,setLoading] = useState(true);
    useEffect(()=>{
        api.get(`/games`).then(res => {
            setGames(res.data.games);
        });
        setTimeout(() => { console.log("мир"); }, 3000);
        setLoading(false);
    },[]);
    return <div style={{"display":"flex","justifyContent":"center","alignItems":"center","width":"100%","height":"80vh"}}>
        {loading ? 
            <div>
            <BarLoader
                    color={"#123abc"}
                    loading={loading}
                    size={30}
                    />
            </div>
            : 
            <div className="d-flex align-items-center justify-content-center">
                <div className="p-5 m-2 bg-info text-white shadow rounded-2">
                    <h1>Game library</h1>
                    <ul className="list-group list-group-flush">
                    {games.map(game=>{
                        return <li className="list-group-item">{game}</li>
                    })}
                    </ul>
                
                    <Link to='/' className="btn btn-outline-dark btn-sm mt-2">Home page</Link>
                </div>
        </div>}
    </div>
}
export default observer(GameLibrary);