import { useEffect, useState } from 'react';
import {Link, useNavigate} from 'react-router-dom'
import { useParams } from 'react-router-dom'
import api from "./../../../Components/api";
import BarLoader from "react-spinners/BarLoader";
import React from 'react';
import { RoomItem } from './../../../types/types';
import { Pagination } from '../../../Components/Helpers/Pagination';
import { ClimbingBoxLoader } from 'react-spinners';

export type RoomList = {
    items: RoomItem[],
    totalItemsCount:number,
    pageSize: number
}

export const GamingRoomList = () =>{

    let navigate = useNavigate();
    const [gamingList, setGamingList] = useState<RoomList>();
    const [loading, setLoading] = useState(true);
    const [curPage, setCurPage] = useState(1);
    // const {type} = useParams();
    useEffect(()=>{
        // var isVip: boolean = type == "vip" ? true : false;
        var isVip: boolean = true
        console.log(isVip);
        console.log(curPage);
        api.get(`/gamingRooms/getRoomByType?page=${curPage}`).then(res => {
            setGamingList(res.data);
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
    },[curPage]); 

    return <div style={{"display":"flex","justifyContent":"center","alignItems":"center","width":"100%","height":"80vh"}}>
        {loading ? 
        <div>
              <ClimbingBoxLoader
                color={"white"}
                loading={loading}
                />
        </div>
        : 

        <div className='d-flex align-items-center justify-content-center' style={{"color":"white"}}>
            <div>
                <div>
                    <h1 className='m-5'>Gaming rooms</h1>
                    <ul className="list-group list-group-flush">
                        {gamingList?.items.map(item=>{
// return <li className="list-group-item bg-transparent" key={item.id}><Link to={`/gamingRooms/${item.id}/${item.name}/${type}`} className="text-decoration-none text-dark mya">{item.name}</Link></li>
                            return <li className="list-group-item bg-transparent" key={item.id}><Link to={`/booking/${item.id}/${item.name}`} className="text-decoration-none mya">{item.name}</Link></li>
                        })}
                    </ul>
                    <div style={{"marginTop":"3vw"}}>
                        <Pagination totalItemsCount = {gamingList?.totalItemsCount} pageCount = {gamingList?.pageSize} curPage = {curPage} setCurPage = {setCurPage}/>
                    </div>
                </div>
            </div>
        </div>
        }   
    </div> 
}