    
import {Link, useAsyncError} from 'react-router-dom'
import './GamingRoomInfo.css'
import './../Index.css'
import { DeviceInfo } from './body/DeviceInfo'
import Dropdown from 'react-bootstrap/Dropdown';
import axios from 'axios';
import { useState } from 'react';
import DropdownItem from 'react-bootstrap/esm/DropdownItem';
import { PeripheryInfo } from './body/PeripheryInfo';
import { PriceInfo } from './body/PriceInfo';

export const GamingRoomInfo = () => {

    const [deviceInfo, setDevice] = useState([]);
    const [peripheryInfo, setPeriphery] = useState([]);
    const [priceInfo, setPrices] = useState([]);
    {
        axios.get(`https://localhost:7227/gamingRoom`).then(res => {
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
                                Peripheries
                            </Dropdown.Toggle>
                            <Dropdown.Menu>
                                {peripheryInfo.map(periphery=>{
                                    return <PeripheryInfo type={periphery.typeName} name={periphery.name}/>
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