import axios from 'axios';
import { useState } from 'react';
import {Link} from 'react-router-dom'

export const GameConsoleRoomList = () =>{

    const [gameConsoleRoomsInfo, setGameConsoleRoomInfo] = useState([]);

    axios.get(`https://localhost:7227/gameConsoleRoom`).then(res => {
        //console.dir(res);
        setGameConsoleRoomInfo(res.data.infos);
    })
    //console.dir(gameConsoleRoomsInfo);
    // const sort = gameConsoleRoomsInfo.sort((a,b)=>{a.name < b.name ? 1 : -1});
    // console.dir(sort);
    return (
        <div className="mt-5 p-5" style={{"margin":"auto","width":"50%", "border" : "3px solid black", "padding" : "10px"}}>
            <h1>Game console rooms</h1>
            <ul className="list-group list-group-flush">
                {gameConsoleRoomsInfo.map(item=>{
                    return <li className="list-group-item" key={item.id}><Link to={`/gameConsoleRoom/${item.id}/${item.name}`} className="text-decoration-none text-dark">{item.name}</Link></li>
                })}
            </ul>
            <Link to='/' className="btn btn-outline-dark btn-sm mt-2">Home page</Link>
        </div>
        
    )
}