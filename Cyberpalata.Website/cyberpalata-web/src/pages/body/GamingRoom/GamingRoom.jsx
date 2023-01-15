    
import {Link, useAsyncError} from 'react-router-dom'
import './../css/RoomInfo.css';
import './../../../Components/Index.css';
import { DeviceInfo } from './../DeviceInfo';
import Dropdown from 'react-bootstrap/Dropdown';
import axios from 'axios';
import { useState } from 'react';
import DropdownItem from 'react-bootstrap/esm/DropdownItem';
import { PriceInfo } from './../PriceInfo';
import { useParams } from 'react-router-dom'

export const GamingRoom = () => {
    const {id} = useParams();
    const {name} = useParams();
    const [peripheriesInfo, setPeripheries] = useState([]);
    const [deviceInfo, setDevices] = useState([]);
    const [priceInfo, setPrices] = useState([]);
    {
        //399CE32F-1610-44DD-B634-4FFDC223038B
        axios.get(`https://localhost:7227/gamingRooms/id?id=${id}`).then(res => {
            console.dir(res);
            setDevices(res.data.pcInfos);
            setPrices(res.data.prices);
            setPeripheries(res.data.peripheries);
        })
    }
    //console.dir(deviceInfo);
    return <>
                 <div className="mt-5 p-5" style={{"margin":"auto","width":"50%", "border" : "3px solid black", "padding" : "10px"}}>
                    <h1>{name}</h1>
                    <hr></hr>
                    <h2>Devices</h2>
                    <table className='table'>
                        <thead>
                            <th scope='col'>Type</th>
                            <th scope='col'>Name</th>
                        </thead>
                        <tbody>
                        {deviceInfo.map((item)=>{
                            return <tr><td>{item.type}</td><td>{item.name}</td></tr>
                        })}
                        </tbody>
                    </table>
                    <h2>Peripheries</h2>
                    <table className='table'>
                        <thead>
                            <th scope='col'>Type</th>
                            <th scope='col'>Name</th>
                        </thead>
                        <tbody>
                        {peripheriesInfo.map((item)=>{
                            return <tr><td>{item.typeName}</td><td>{item.name}</td></tr>
                        })}
                        </tbody>
                    </table>
                    <h2>Prices</h2>
                    <table className='table'>
                        <thead className='thead-dark'>
                            <th scope='col'>Hours</th>
                            <th scope='col'>Cost</th>
                        </thead>
                        <tbody>
                            {priceInfo.map((item)=>{
                                return <tr><td>{item.hours}</td><td>{item.cost}</td></tr>
                            })}
                        </tbody>
                    </table>
                    <Link to={`/gamingRooms`} className="btn btn-outline-dark btn-sm mt-2">Back</Link>
                </div>
           </>
}








// return <div style={{"position" : "absolute", "top":"30%", "left":"41%"}}>
//         <Link style={{"textDecoration":"none", "color":"black"}}>
//             <div className='bookButton labelText'>
//                 Book
//             </div>
//         </Link>
//         <ul style={{"listStyle":"none"}}>
//             <li>
//                 <div style={{"display" : "flex"}}>
//                     <div style={{"justifyContent":"left"}}>
//                         <Dropdown >
//                             <Dropdown.Toggle variant="secondary " id="dropdown-basic">
//                                 Devices
//                             </Dropdown.Toggle>
//                             <Dropdown.Menu>
//                                 {deviceInfo.map(device=>{
//                                     return <DeviceInfo  value={device}/>
//                                 })}
//                             </Dropdown.Menu>
//                         </Dropdown>
//                     </div>
//                     <div className='circleButton'>
//                         {/* <img src=''></img> */}
//                     </div>
//                 </div>
//             </li>
//             <hr />
//             <li>
//                 <div style={{"display" : "flex"}}>
//                     <div style={{"justifyContent":"left"}}>
//                     <Dropdown >
//                             <Dropdown.Toggle variant="secondary " id="dropdown-basic">
//                                 Prices
//                             </Dropdown.Toggle>
//                             <Dropdown.Menu>
//                                 {priceInfo.map(price=>{
//                                     return <PriceInfo hours={price.hours} cost={price.cost}/>
//                                 })}
//                             </Dropdown.Menu>
//                         </Dropdown>
//                     </div>
//                     <div className='circleButton'>
//                         {/* <img src=''></img> */}
//                     </div>
//                 </div>
//             </li>
//         </ul>
//     </div>