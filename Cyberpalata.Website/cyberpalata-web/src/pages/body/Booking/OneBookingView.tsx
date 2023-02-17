import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import api from "./../../../Components/api";
import BarLoader from "react-spinners/BarLoader";
import { Link } from "react-router-dom";
import React from 'react';
import { BookingDetails, Seat } from "./../../../types/types";

export const OneBookingView = ()=>{
    const [countInRow,setCountInRow] = useState(0);    
    const [roomName, setRoomName] = useState<string>("")
    const [begining, setBegining] = useState<string>("");
    const [hours, setHours] = useState<number>(0);
    const [price, setPrice] = useState<number>(0);
    const [seats, setSeats] = useState<Seat[]>([]);
    const [loading, setLoading] = useState(false);
    let navigate = useNavigate();
    const {id} = useParams();

    useEffect(()=>{
        setLoading(true);
        api.get(`/booking/getBooking?id=${id}`).then(res=>{
            setRoomName(res.data.roomName);
            setBegining(res.data.begining);
            setHours(res.data.hoursCount);
            setPrice(res.data.price);
            setSeats(res.data.seats);
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
 
    let columnCount = 10;
    let rowCount = seats.length / columnCount;


    seats.sort((a,b) => a.number > b.number ? 1 : -1);
   
    let seatsPerRow = [];
    for(let i = 0;i < rowCount * columnCount;i+=columnCount)
    {
        let chunk = seats.slice(i, i + columnCount);
        seatsPerRow.push(chunk);
    }
   

    return <div style={{"display":"flex","justifyContent":"center","alignItems":"center","width":"100%","height":"80vh"}}>{loading ? 

        <div>
            <BarLoader
                color={"#123abc"}
                loading={loading}
                />
        </div> 

        :<div className="d-flex align-items-center justify-content-center">
            <div className="p-5 m-2 bg-info text-white shadow rounded-2">
                <div className="bg-light rounded p-2 w-50">
                    <div className="d-flex">
                        <div className="m-1 bg-dark p-1 rounded">Room: {roomName}</div>
                        <div className="m-1 bg-dark p-1 rounded">Price: {price}</div> 
                    </div>
                    <div className="d-flex">
                        <div className="m-1 bg-dark p-1 rounded">Begining: {begining}</div>
                        <div className="m-1 bg-dark p-1 rounded">Hours count: {hours}</div>
                    </div>
                </div>
                <table className="table w-50 m-auto">
                    <tbody id = 'tbody'>
                    {seatsPerRow.map(row=>{

                        return <tr>
                            {row.map((cell: Seat)=>{
                                console.dir(cell);

                                return <>
                                {cell.type.name == "Free" && <td className="seat p-2"><button id = {`button${cell.number}`} className="btn btn-outline-dark">{cell.number}</button></td>}
                                {cell.type.name == "IsTaken" && <td className="seat p-2"><button id = {`button${cell.number}`} className="btn btn-dark">{cell.number}</button></td>}
                                {cell.type.name == "UsersSeat" && <td className="seat p-2"><button id = {`button${cell.number}`} className="btn btn-primary">{cell.number}</button></td>}
                                </>
                            })}
                        </tr>
                    })}
                    </tbody>         
                </table>
                <Link to='/bookingView' className="btn btn-dark btn-sm m-2">Back</Link>
            </div>
     
    </div>
    }
    </div>
}