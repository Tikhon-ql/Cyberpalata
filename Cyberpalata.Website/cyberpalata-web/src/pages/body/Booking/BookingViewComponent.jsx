import { useState} from "react";
import { Link } from "react-router-dom";
import api from "../../../Components/api";
import {OneBookingView} from "./OneBookingView"

export const BookingViewComponent = (props)=>{
    const[bookingsSmall, setBookingsSmall] = useState([]);
    const[curPage, setCurPage] = useState(1);

    api.get(`/profile/getBookingSmallInfo`).then(res=>{
        setBookingsSmall(res.data);
    }).catch(console.log);
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
        </div>
    </>
}