import axios from 'axios';
import { useState } from 'react';
import {Link} from 'react-router-dom'

export const GameConsoleRoomList = () =>{

    const [gameConsoleRoomsInfo, setGameConsoleRoomInfo] = useState([]);

    axios.get(`https://localhost:7227/gameConsoleRoom`).then(res => {
        //console.dir(res);
        setGameConsoleRoomInfo(res.data.infos);
    })
    return (
        <div>
            <ul>
                {gameConsoleRoomsInfo.map(item=>{
                    return <li><Link to={`/gameConsoleRoom/${item.id}`}>{item.name}</Link></li>
                })}
            </ul>
        </div>
    )
}