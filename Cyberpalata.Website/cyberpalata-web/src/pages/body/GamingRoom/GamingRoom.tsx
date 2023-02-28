import {Link, useAsyncError, useNavigate} from 'react-router-dom'
import './../css/RoomInfo.css';
import './../../../Components/Index.css';
import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import api from "./../../../Components/api";
import BarLoader from "react-spinners/BarLoader";
import React from 'react';
import { Periphery } from './../../../types/types';
import { Pc } from './../../../types/types';

const GamingRoom = () => {
    let navigate = useNavigate();
    const {id} = useParams();
    const {name} = useParams();
    const {type} = useParams();
    const [iternalServerError, setIternalServerError] = useState<boolean>(false);
    const [peripheries, setPeripheries] = useState<Periphery[]>([]);
    const [device, setDevices] = useState<Pc[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    useEffect(()=>{
        api.get(`/gamingRooms/getRoomInfo?id=${id}`).then(res => {
            console.dir(res);
            setDevices(res.data.pcInfos);
            setPeripheries(res.data.peripheries);
            setLoading(false);
        }).catch(error=>{
            if(error.code && error.code == "ERR_NETWORK")
            {
                setIternalServerError(true);
            }
            if((error.response.status >= 500 && error.response.status <= 599))
            {
                setIternalServerError(true);
            }
        });
    },[]);


    return <> { iternalServerError ? <div></div>

        : <div style={{"display":"flex","justifyContent":"center","alignItems":"center","width":"100%","height":"80vh"}}>
        {loading ?

            <div>
                <BarLoader
                color={"#123abc"}
                loading={loading}
                />
            </div> 

            : <div className="d-flex align-items-center justify-content-center text-white">
                <div className="" >
                    <div style={{"display":"flex","alignItems":"center"}}>
                        <div style={{"justifyContent":"start"}}><h1>{name}</h1></div><Link to={`/booking/${id}/${name}`} style={{"marginLeft":"1vw","border":"1px solid","padding":"0.5vh 1vh 0.5vh 1vh","borderRadius":"10%"}}>Booking</Link>
                    </div>
                    <hr></hr>
                    <div className='d-flex'>
                        <div className='m-5'>
                            <h2>Devices</h2>
                            <table className='table'>
                                <thead>
                                    <th scope='col' className='text-white'>Type</th>
                                    <th scope='col' className='text-white'>Name</th>
                                </thead>
                                <tbody>
                                {device.map((item)=>{
                                    return <tr className='text-white'><td>{item.type}</td><td>{item.name}</td></tr>
                                })}
                                </tbody>
                            </table>
                        </div>
                        <div className='m-5'>
                            <h2>Peripheries</h2>
                            <table className='table'>
                                <thead>
                                    <th scope='col' className='text-white'>Type</th>
                                    <th scope='col' className='text-white'>Name</th>
                                </thead>
                                <tbody>
                                {peripheries.map((item)=>{

                                    return <tr className='text-white'><td>{item.typeName}</td><td>{item.name}</td></tr>
                                })}
                                </tbody>
                            </table>
                        </div>
                    </div>
                   
                    <div className='d-flex w-100'>
                    </div>
                
            </div>
        </div>}
    </div>}
</>
}

export default GamingRoom;
