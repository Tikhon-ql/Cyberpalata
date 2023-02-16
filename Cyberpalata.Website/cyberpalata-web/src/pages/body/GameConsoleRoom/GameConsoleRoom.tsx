   
import {Link, useAsyncError} from 'react-router-dom'
import './../css/RoomInfo.css';
import './../../../Components/Index.css';
import Dropdown from 'react-bootstrap/Dropdown';
import axios from 'axios';
import { useState } from 'react';
import DropdownItem from 'react-bootstrap/esm/DropdownItem';
import { useParams } from 'react-router-dom'
import { BookingComponent } from '../Booking/BookingComponent';
import React from 'react';

export const GameConsoleRoom = () => {
    const {id} = useParams();
    const {name} = useParams();
    const [deviceInfo, setDevice] = useState([]);
    {
        axios.get(`https://localhost:7227/gameConsoleRoom/id?id=${id}`).then(res => {
            //console.dir(res);
            setDevice(res.data.gameConsoles);
        })
    }
    //console.dir(deviceInfo);

    return <>
                 <div className="mt-5 p-5" style={{"margin":"auto","width":"50%", "border" : "3px solid black", "padding" : "10px"}}>
                    <h1>{name}</h1>
                    <hr></hr>
                    <h2>Consoles</h2>
                    <ul className="list-group list-group-flush">
                        {deviceInfo.map((item)=>{
                            return <li className="list-group-item">{item}</li>
                        })}
                    </ul>
                    <Link to={`/gameConsoleRoom`} className="btn btn-outline-dark btn-sm mt-2">Back</Link>
                </div>
           </>
}
