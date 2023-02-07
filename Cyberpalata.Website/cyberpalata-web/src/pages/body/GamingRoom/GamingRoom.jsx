    import {Link, useAsyncError} from 'react-router-dom'
import './../css/RoomInfo.css';
import './../../../Components/Index.css';
import { DeviceInfo } from '../DeviceInfo';
import Dropdown from 'react-bootstrap/Dropdown';
import axios from 'axios';
import { useEffect, useState } from 'react';
import DropdownItem from 'react-bootstrap/esm/DropdownItem';
import { PriceInfo } from '../PriceInfo';
import { useParams } from 'react-router-dom';
// import { Method } from "../../../Components/Method";
// import { GamingRoomInfo } from '../../../types/types';
import api from "./../../../Components/api.js";
import BarLoader from "react-spinners/BarLoader";

const GamingRoom = () => {
    const {id} = useParams();
    const {name} = useParams();
    const {type} = useParams();
    const [peripheriesInfo, setPeripheries] = useState([]);
    const [deviceInfo, setDevices] = useState([]);
    const [priceInfo, setPrices] = useState([]);
    const [loading, setLoading] = useState(true);
    useEffect(()=>{
        setTimeout(()=>{
            api.get(`/gamingRooms/getRoomInfo?id=${id}`).then(res => {
                console.dir(res);
                setDevices(res.data.pcInfos);
                setPrices(res.data.prices);
                setPeripheries(res.data.peripheries);
            });
            setLoading(false);
        },1000)
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
            : <div className="d-flex align-items-center justify-content-center">
                <div className="p-5 m-2 bg-info text-white shadow rounded-2" >
                    <div style={{"display":"flex"}}>
                        <div><h1>{name}</h1></div>
                        
                    </div>
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
                    <div className='d-flex w-100'>
                        <Link to={`/booking/${id}/${name}/${type}`} className="btn btn-outline-dark w-50 btn-sm m-1">Booking</Link>
                        <Link to={`/gamingRooms`} className="btn btn-outline-dark w-50 btn-sm m-1">Back</Link>
                    </div>
                
            </div>
        </div>}
    </div> 
}

export default GamingRoom;




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