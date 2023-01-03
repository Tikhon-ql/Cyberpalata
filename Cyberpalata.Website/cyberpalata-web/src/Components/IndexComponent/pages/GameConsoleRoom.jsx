    
import {Link, useAsyncError} from 'react-router-dom'
import './RoomInfo.css'
import './../Index.css'
import { DeviceInfo } from './body/DeviceInfo'
import Dropdown from 'react-bootstrap/Dropdown';
import axios from 'axios';
import { useState } from 'react';
import DropdownItem from 'react-bootstrap/esm/DropdownItem';
import { PriceInfo } from './body/PriceInfo';

export const GameConsoleRoom = () => {

    const [deviceInfo, setDevice] = useState([]);
    const [peripheryInfo, setPeriphery] = useState([]);
    const [priceInfo, setPrices] = useState([]);
    {
        axios.get(`https://localhost:7227/gameConsoleRoom`).then(res => {
            //console.dir(res);
            setDevice(res.data.pcInfos);
            setPeriphery(res.data.peripheries);
            setPrices(res.data.prices);
        })
    }
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
                                    return <DeviceInfo type={device.name} value={device.value}/>
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