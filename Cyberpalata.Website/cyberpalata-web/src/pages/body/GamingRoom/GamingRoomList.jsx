import { useEffect, useState } from 'react';
import {Link, useNavigate} from 'react-router-dom'
import { useParams } from 'react-router-dom'
import api from "./../../../Components/api";
import BarLoader from "react-spinners/BarLoader";

export const GamingRoomList = () =>{

    let navigate = useNavigate();
    const [gamingRoomsInfo, setGamingRoomsInfo] = useState([]);
    const [loading, setLoading] = useState(true);
    const {type} = useParams();
    useEffect(()=>{
        api.get(`/gamingRooms/getRoomByType?type=${type}`).then(res => {
            setGamingRoomsInfo(res.data.infos);
            setLoading(false);
        }).catch(error=>{
            if(error.code && error.code == "ERR_NETWORK")
            {
                navigate('/500');
            }
            if((error.response.status >= 500 && error.response.status <= 599))
            {
                navigate('/500');
            }
        });
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
        : 
        <div className='d-flex align-items-center justify-content-center'>
            <div className="p-5 m-2 bg-info text-white shadow rounded-2">
                <div>
                    <h1 className='m-1'>Gaming rooms</h1>
                    <ul class="list-group list-group-flush">
                        {gamingRoomsInfo.map(item=>{
                            return <li class="list-group-item bg-transparent" key={item.id}><Link to={`/gamingRooms/${item.id}/${item.name}/${type}`} className="text-decoration-none text-dark mya">{item.name}</Link></li>
                        })}
                    </ul>
                </div>
                <Link to='/' className="btn btn-dark btn-sm m-2">Home page</Link>
            </div>
        </div>
        }   
    </div> 
}