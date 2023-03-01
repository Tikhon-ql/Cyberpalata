import { observer } from "mobx-react-lite";
import { useEffect, useState } from "react"
import { Link, useNavigate } from "react-router-dom";
import api from "./../../Components/api";
import BarLoader from "react-spinners/BarLoader";
import React from "react";
import { ClimbingBoxLoader } from "react-spinners";
import { Game } from "../../types/types";

const GameLibrary = () => {
    const navigate = useNavigate();
    const [games, setGames] = useState<Game[]>([]);
    const [loading,setLoading] = useState<boolean>(true);
    const [curPage, setCurPage] = useState<number>(1);
    useEffect(()=>{
        api.get(`/games/getGames?page=${curPage}`).then(res => {
            setGames(res.data.games);
        }).catch(error=>{
            if(error.code && error.code == "ERR_NETWORK")
            {
                navigate('/500');
            }
            if((error.response.status >= 500 && error.response.status <= 599))
            {
                navigate('/500');
            }
        }).finally(()=>{setLoading(false);});
    },[]);

    return <div style={{"display":"flex","justifyContent":"center","alignItems":"center","width":"100%","height":"80vh"}}>
        {loading ? 

            <div>
            <ClimbingBoxLoader
                    color={"white"}
                    loading={loading}
                    />
            </div>
            : 

            <div className="d-flex align-items-center justify-content-center">
                <div className="p-5 m-2 bg-info text-white shadow rounded-2">
                    <h1>Game library</h1>
                    {games.map((game:Game,index)=>{

                        return <div key={index}>
                            <img src={game.imageUrl}/>
                            <h3>{game.name}</h3>
                        </div>
                    })}
                    <Link to='/' className="btn btn-outline-dark btn-sm mt-2">Home page</Link>
                </div>
        </div>}
    </div>
}
export default observer(GameLibrary);