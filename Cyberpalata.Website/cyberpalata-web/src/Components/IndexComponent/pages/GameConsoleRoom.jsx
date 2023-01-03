    
import {Link, useAsyncError} from 'react-router-dom'
import './RoomInfo.css'
import './../Index.css'
import { DeviceInfo } from './body/DeviceInfo'
import Dropdown from 'react-bootstrap/Dropdown';
import axios from 'axios';
import { useState } from 'react';
import DropdownItem from 'react-bootstrap/esm/DropdownItem';
import { PriceInfo } from './body/PriceInfo';
import { useParams } from 'react-router-dom'

export const GameConsoleRoom = () => {
    const {id} = useParams();
    const [deviceInfo, setDevice] = useState([]);
    const [priceInfo, setPrices] = useState([]);
    {
        //399CE32F-1610-44DD-B634-4FFDC223038B
        axios.get(`https://localhost:7227/gameConsoleRoom/id?id=${id}`).then(res => {
            //console.dir(res);
            setDevice(res.data.gameConsoles);
            setPrices(res.data.prices);
        })
    }
    console.dir(deviceInfo);
    return <div style={{"position" : "absolute", "top":"30%", "left":"41%"}}>
        <Link style={{"textDecoration":"none", "color":"black"}}>
            <div className='bookButton labelText'>
                Book
            </div>
        </Link>
        <ul style={{"listStyle":"none"}}>
            <li>
                <div style={{"display" : "flex"}}>
                    <div style={{"justifyContent":"left"}}>
                        <Dropdown >
                            <Dropdown.Toggle variant="secondary " id="dropdown-basic">
                                Devices
                            </Dropdown.Toggle>
                            <Dropdown.Menu>
                                {deviceInfo.map(device=>{
                                    return <DeviceInfo  value={device}/>
                                })}
                            </Dropdown.Menu>
                        </Dropdown>
                    </div>
                    <div className='circleButton'>
                        {/* <img src=''></img> */}
                    </div>
                </div>
            </li>
            <hr />
            <li>
                <div style={{"display" : "flex"}}>
                    <div style={{"justifyContent":"left"}}>
                    <Dropdown >
                            <Dropdown.Toggle variant="secondary " id="dropdown-basic">
                                Prices
                            </Dropdown.Toggle>
                            <Dropdown.Menu>
                                {priceInfo.map(price=>{
                                    return <PriceInfo hours={price.hours} cost={price.cost}/>
                                })}
                            </Dropdown.Menu>
                        </Dropdown>
                    </div>
                    <div className='circleButton'>
                        {/* <img src=''></img> */}
                    </div>
                </div>
            </li>
        </ul>
    </div>
}