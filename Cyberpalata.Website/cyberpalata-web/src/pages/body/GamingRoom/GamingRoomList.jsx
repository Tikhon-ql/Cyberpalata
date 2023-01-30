import axios from 'axios';
import { useState } from 'react';
import {Link} from 'react-router-dom'
import { useParams } from 'react-router-dom'

export const GamingRoomList = () =>{

    const [gamingRoomsInfo, setGamingRoomsInfo] = useState([]);
    const {type} = useParams();
    axios.get(`https://localhost:7227/gamingRooms/type?type=${type}`).then(res => {
        setGamingRoomsInfo(res.data.infos);
    })
    //console.dir(gameConsoleRoomsInfo);
    // const sort = gameConsoleRoomsInfo.sort((a,b)=>{a.name < b.name ? 1 : -1});
    // console.dir(sort);
    return (
        <div className="mt-5 p-5" style={{"margin":"auto","width":"50%", "border" : "3px solid black", "padding" : "10px"}}>
            <h1>Gaming rooms</h1>
            <ul class="list-group list-group-flush">
                {gamingRoomsInfo.map(item=>{
                    return <li class="list-group-item" key={item.id}><Link to={`/gamingRooms/${item.id}/${item.name}/${type}`} className="text-decoration-none text-dark">{item.name}</Link></li>
                })}
            </ul>
            <Link to='/' className="btn btn-outline-dark btn-sm mt-2">Home page</Link>
        </div>
        
    )
}