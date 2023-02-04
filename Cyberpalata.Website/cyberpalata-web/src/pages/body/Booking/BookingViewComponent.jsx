import { useEffect, useState} from "react";
import { Link } from "react-router-dom";
import api from "../../../Components/api";
import { Pagination } from "../../../Components/Helpers/Pagination";
import {OneBookingView} from "./OneBookingView"

export const BookingViewComponent = (props)=>{
    const[bookingsSmall, setBookingsSmall] = useState([]);
    const[curPage, setCurPage] = useState(1);
    const[totalItemsCount, setTotalItemsCount] = useState(0);
    useEffect(()=>{
        api.get(`/profile/getBookingSmallInfo?page=${curPage}`).then(res=>{
            console.dir(res.data);
            setBookingsSmall(res.data.viewModel);
            setTotalItemsCount(res.data.totalItemsCount);
        }).catch(console.log);
    },[]);
    return <>
        <h1>Bookings</h1>       
        <div className="list-group">
            {bookingsSmall.map(item=>{
                return <Link to={`/bookingView/${item.id}`} className="list-group-item list-group-item-action list-group-item-dark">
                        <div>
                            <div>{item.roomName}</div>
                            <div>{item.begining} : {item.ending}</div>
                        </div>
                    </Link>
            })}
            <Pagination  totalItemsCount = {totalItemsCount} pageCount = {bookingsSmall.length} curPage = {curPage} setCurPage = {setCurPage}/>
        </div>
    </>
}