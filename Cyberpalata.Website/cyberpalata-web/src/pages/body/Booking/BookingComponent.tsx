import "./BookingComponent.css";
import jwtDecode from "jwt-decode";
import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import api from "./../../../Components/api";
import BarLoader from "react-spinners/BarLoader";
import React from 'react';
import { Seat } from "./../../../types/types";

export const BookingComponent = () => {
    
    const navigate = useNavigate();
    const {roomId} = useParams()
    const {roomName} = useParams();
    const [seats,setSeats] = useState<Seat[]>([]);
    const [price, setPrice] = useState(0);
    const [begTime, setBegTime] = useState();
    const [hoursCount, setHoursCount] = useState<number>(0);
    const [updatePrice, setUpdatePrice] = useState<boolean>(false);
    const [clickedSeats, setClickedSeats] = useState<number[]>([]);
    const [loading, setLoading] = useState(false);
    const [otherError,setOtherError] = useState("");
    const [dateError, setDateError] = useState("");
    const [priceError, setPriceError] = useState("");
    const [hoursCountError,setHoursCountError] = useState("");
    const apiUrl = `https://localhost:7227;`;

    let accessToken = localStorage.getItem('accessToken');
    let refreshToken = localStorage.getItem('refreshToken');

    useEffect(()=>{
        api.get(`/booking/calculateBookingPrice?beg=${begTime}&hours=${hoursCount}&seatsCount=${clickedSeats.length}`).then(res=>{
            setPrice(res.data);
        }).catch(err=>{
            if(err.response.status >= 500 && err.response.status <= 599)
            {
                //navigate("/500");
            }
        });
    },[updatePrice,begTime,hoursCount]);

    function onTimeChange(event: any)
    {
        console.dir(clickedSeats);
        console.dir(event);
        clearErrors();
        let date = document.forms[0].date.value;
        let beg = document.forms[0].begining.value;
        let hours = document.forms[0].hours.value;
        setHoursCount(hours);
        setBegTime(beg);
        setUpdatePrice(!updatePrice);
        if(hours)
        {
            (document.getElementById("rangeVal") as HTMLInputElement).innerText = hours;
        }
        if(date && beg && hours)
        {
            let requestBody = {
                "roomId":roomId,
                "date":date,
                "begining":beg,
                "hoursCount":hours
            }
            api.post(`/seats/getSeats`,requestBody).then(res=>{
                setSeats(res.data);
            }).catch(err=>{
                if(err.response.status >= 500 && err.response.status <= 599)
                {
                    //navigate("/500");
                }
            })
            console.log("dsadasfsdf");
            console.dir(clickedSeats);
          
        }     
    }

    function clearErrors()
    {
        setDateError("");
        setOtherError("");
        setPriceError("");
        setHoursCountError("");
    }

    useEffect(()=>{
        api.get(`/booking/seats?roomId=${roomId}`).then(res=>{
        }).catch(err=>{
            if(err.response.status >= 500 && err.response.status <= 599)
            {
                navigate("/500");
            }
        });
    },[]);
  
    let columnCount = 10;
    let rowCount = seats.length / columnCount;


    seats.sort((a,b) => a.number > b.number ? 1 : -1);
   
    let seatsPerRow:Seat[][] = [];
    for(let i = 0;i < rowCount * columnCount;i+=columnCount)
    {
        let chunk:Seat[] = seats.slice(i, i + columnCount);
        seatsPerRow.push(chunk);
    }

    const sendBookToServer = (event: any) => {
        setLoading(true);
        event.preventDefault();
        console.dir(event);
        if(localStorage.getItem('accessToken') != null)
        {

            let accessToken = jwtDecode(localStorage.getItem(`accessToken`) || "");
            let price = (document.getElementById("price") as HTMLInputElement).innerHTML;
            console.dir(accessToken);
            let requestBody = { 
                "roomId":roomId,
                "date": event.target.elements.date.value,
                "begining": event.target.elements.begining.value,
                "hoursCount": event.target.elements.hours.value,
                "price": price,       
                "seats": clickedSeats,        
            }
            console.dir(requestBody);
            api.post(`/booking`, requestBody).then(res=>{
                setClickedSeats([]);
                setSeats([]);
            }).catch((error)=>{
                if(error.code && error.code == "ERR_NETWORK")
                {
                    navigate('/500');
                }
                if((error.response.status >= 500 && error.response.status <= 599))
                {
                    navigate('/500');
                }
                const data = error.response.data;
                if(data.Other)
                {
                    setOtherError(data.Other);
                }
                if(data.Date)
                {
                    setDateError(data.Date);
                }
                if(data.Price)
                {
                    setPriceError(data.Price);
                }
                if(data.HoursCount)
                {
                    setHoursCountError(data.HoursCount);
                }
            })
            .finally(()=>{ setLoading(false);});
        }
    }


    function onSeatClick(event: any)
    {   
        event.preventDefault();
        console.dir(event);
        console.log(event.target.style.color);
        if(event.target.style.color === "white")
        {
            clickedSeats.push(event.target.textContent as number);
            event.target.style.background = "white";
            event.target.style.color = "black";
            setUpdatePrice(!updatePrice);
        }
        else
        {       
            setClickedSeats(clickedSeats.filter(item => item != event.target.textContent as number));
            // setClickedSeats([...clickedSeats,event.target.textContent as number]) 
            console.log("oldnfopdsjpg[ksdkgsdkgpdsmgsdfgs");
            event.target.style.background = "none";
            event.target.style.color = "white";
            setUpdatePrice(!updatePrice);
        }         
        console.dir(clickedSeats);
    }

    return <div style={{"display":"flex","justifyContent":"center","alignItems":"center","width":"100%","height":"80vh","marginTop":"5vh"}}>
        {loading ? 

      <div> 
        <BarLoader
            color={"#123abc"}
            loading={loading}
            />
            </div>

        :<div>
            <div className="d-flex align-items-center justify-content-center text-white">
                <form method="post" onSubmit={sendBookToServer} style={{"margin":"auto"}}>
                    {otherError != "" && <div className="text-danger m-1 rounded">{otherError}</div>}
                    <h2 style={{"textAlign":"center"}}>{roomName}</h2><hr/>
                    <div className="">
                        <label htmlFor="date" className="m-3">
                            <div>Date</div>
                            <input id="date" name="data" onChange={(e) => onTimeChange(e)} type="date"/>
                            {dateError != "" && <div className="text-danger m-1 rounded">{dateError}</div>}
                        </label>
                        <label htmlFor="begining" className="m-3">
                            <div>Begining</div>
                            <input id="begining" name="begining" onChange={onTimeChange} type="time"/>
                        </label>
                        <label htmlFor="hoursCount" className="m-3 w-100 ">
                            <div className="d-flex">Hours count ( 0-10 ) :<div id="rangeVal" style={{"marginLeft":"5px"}}>10</div></div>
                            <input id="hours" name="hours" className="w-50" onChange={onTimeChange} type="range" min = "1" max = "10"/>
                            {hoursCountError != "" && <div className="text-danger m-1 rounded">{hoursCountError}</div>}
                        </label>
                    </div>
                    {seats.length != 0 ?
                        <div>
                            <h2>Seats</h2>
                            <table className="table w-50 m-auto">
                                <tbody id = 'tbody'>
                                {seatsPerRow.map((row:Seat[],index)=>{
                                    return <tr>
                                        {row.map((cell:Seat)=>{
                                            return <>
                                            {cell.type.name == "Free" ? <td className="seat p-2"><button id = {`button${cell.number}`} style={{"color":"white","background":"none","border":"1px solid","padding":"0.5vh 1vh 0.5vh 1vh","borderRadius":"0.3vw"}} onClick={onSeatClick}>{cell.number}</button></td> : <td className="seat text-white p-2"><button id = {`button${cell.number}`} style={{"color":"gray","background":"none","border":"1px solid","padding":"0.5vh 1vh 0.5vh 1vh","borderRadius":"0.3vw"}} disabled onClick={onSeatClick}>{cell.number}</button></td>}
                                            </>
                                        })}
                                    </tr>   
                                })}
                                </tbody>         
                            </table>
                            <div>
                            {price != 0 ? 

                            <div style={{"display":"flex","marginTop":"1vh","justifyContent":"center","alignItems":"center"}}>
                                <h2 className="m-1">Your price: </h2>
                                <label id = "price" className="label label-default h2 m-1">{price}</label>
                            </div>:
                            <div>
                        </div>
                        }
                        <input type="submit" className="w-50" style={{"marginTop":"3vh","marginLeft":"7.4vw","border":"1px solid","padding":"0.5vh 1vh 0.5vh 1vh","borderRadius":"0.5vw"}} value="Book"/>  
                    </div>
                    </div>
                    : <div><h2>Enter correct data and time to view available seats</h2>
                    </div> 
                    }
                </form>
                </div>
            </div>
    }
    </div>
}
