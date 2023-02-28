import { useEffect, useState} from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import api from "../../../Components/api";
import { Pagination } from "../../../Components/Helpers/Pagination";
import BarLoader from "react-spinners/BarLoader";
import React from 'react';
import { BookingCollection } from "./../../../types/types";


export const BookingViewComponent = (props: any) => {
    const navigate = useNavigate();
    const[bookingCollection, setBookingCollection] = useState<BookingCollection[]>([]);
    const[curPage, setCurPage] = useState(1);
    const[totalItemsCount, setTotalItemsCount] = useState(0);
    const [loading,setLoading] = useState(false);

    const {isActual} = useParams();
    useEffect(()=>{
        setLoading(true);
        var flag: boolean = isActual == "actual" ? true : false;
        api.get(`/booking/getBookingSmallInfo?page=${curPage}&isActual=${flag}`).then(res=>{
            console.dir(res.data);
            setBookingCollection(res.data.viewModel);
            setTotalItemsCount(res.data.totalItemsCount);
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

    return <div style={{"display":"flex","justifyContent":"center","alignItems":"center","width":"100%","height":"80vh"}}>{loading ? 
        <div>
            <BarLoader
                color={"#123abc"}
                loading={loading}
                // size={30}
                />
        </div>:
        <div className="d-flex align-items-center justify-content-center w-75" style={{color:"white"}}>
            <div className="w-100 h-100">
                <h1>Bookings</h1>  
                <div className="list-group w-100 p-2">
                    {bookingCollection.map((item: BookingCollection,index)=>{
                        return <Link to={`/bookingViewDetail/${item.id}`} key={index} style={{color:"white"}} className="list-group-item list-group-item-action bg-transparent rounded">
                                <div className="w-100">
                                    <div className="d-flex w-100">
                                        <div className="m-1">Room: {item.roomName}</div>
                                        <div className="m-1">Price: {item.price}</div>
                                    </div>
                                    <div className="d-flex">
                                        <div className="m-1">Date: {item.date}</div>
                                        <div className="m-1">Begining: {item.begining}</div>
                                    </div>
                                </div>
                            </Link>
                    })}
                    <Pagination totalItemsCount = {totalItemsCount} pageCount = {3} curPage = {curPage} setCurPage = {setCurPage}/>
                </div>
            </div>
        </div>}
    </div>
}