import "./BookingComponent.css";
import jwtDecode from "jwt-decode";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import api from "./../../../Components/api";
import { servicesVersion } from "typescript";
import BarLoader from "react-spinners/BarLoader";

export const BookingComponent = () => {
    
    const {roomId} = useParams()
    const {roomName} = useParams();
    const [seats,setSeats] = useState([]);
    const [price, setPrice] = useState(0);
    const [clickedSeats, setClickedSeats] = useState([]);
    const [loading, setLoading] = useState(false);
    const apiUrl = `https://localhost:7227;`;

    let accessToken = localStorage.getItem('accessToken');
    let refreshToken = localStorage.getItem('refreshToken');

    function onTimeChange(event)
    {
        console.dir(event);
        let date = document.forms[0].date.value;
        let beg = document.forms[0].begining.value;
        let hours = document.forms[0].hours.value;
        if(hours)
        {
            document.getElementById("rangeVal").innerText = hours;
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
            })
            api.get(`/booking/getPrice?beg=${beg}&hours=${hours}`).then(res=>{
                setPrice(res.data);
            });
        }     
    }

    useEffect(()=>{
        api.get(`/booking/seats?roomId=${roomId}`).then(res=>{

            //console.dir(res);
            //setSeats(res.data.seats);
            //setTarrifs(res.data.tariffs);
            //tarrifs.sort((a,b) => a.hours > b.hours);
        }).catch(console.log);
    },[clickedSeats]);
  
    let columnCount = 10;
    let rowCount = seats.length / columnCount;

    seats.sort((a,b) => a.number > b.number ? 1 : -1);
   
    let seatsPerRow = [];
    for(let i = 0;i < rowCount * columnCount;i+=columnCount)
    {
        let chunk = seats.slice(i, i + columnCount);
        seatsPerRow.push(chunk);
    }
    const sendBookToServer = (event) =>
    {
        setLoading(true);
        event.preventDefault();
        console.dir(event);
        if(localStorage.getItem('accessToken') != null)
        {
            let accessToken = jwtDecode(localStorage.getItem(`accessToken`));
            let price = document.getElementById("price").innerHTML;
            //let tariff = event.target.elements.tariff.value.split(":");
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
                setLoading(false);
            }).catch(console.log);
        }
    }

    function onSeatClick(event)
    {   
        event.preventDefault();
        console.dir(event);
        if(event.target.className == "btn btn-dark")
        {
            setClickedSeats(clickedSeats.filter(item => item != event.target.textContent));
            event.target.className = "btn btn-outline-dark";
        }
        else
        {       
            setClickedSeats([...clickedSeats,event.target.textContent])     
            event.target.className = "btn btn-dark";
        }         
        console.dir(clickedSeats);
    }
    return <div style={{"display":"flex","justifyContent":"center","alignItems":"center","width":"100%","height":"80vh"}}>
        {loading ? 
      <div> 
        <BarLoader
            color={"#123abc"}
            loading={loading}
            size={30}
            />
            </div>
        :<div>
            <div className="d-flex align-items-center justify-content-center">
                <form method="post" onSubmit={sendBookToServer} className="p-5 m-2 bg-info text-white shadow rounded-2" style={{"margin":"auto", "border" : "3px solid black", "padding" : "10px"}}>
                    <h2 className="mx-auto">{roomName}</h2>
                    <h2>Dates</h2>
                    <div className="">
                        <label htmlFor="date" className="m-3">
                            <div>Date</div>
                            <input id="date" name="data" onInput={onTimeChange} type="date"/>
                        </label>
                        <label htmlFor="begining" className="m-3">
                            <div>Begining</div>
                            <input id="begining" name="begining" onInput={onTimeChange} type="time"/>
                        </label>
                        <label htmlFor="hoursCount" className="m-3 w-100 ">
                            <div className="d-flex">Hours count(0-10):<div id="rangeVal" style={{"marginLeft":"5px"}}>10</div></div>
                            <input id="hours" name="hours" className="w-50" onInput={onTimeChange} type="range" min = "1" max = "10"/>
                        </label>
                    </div>
                    {seats.length != 0 ?
                        <div>
                            <h2>Seats</h2>
                                <table className="table w-50 m-auto">
                                    <tbody id = 'tbody'>
                                    {seatsPerRow.map(row=>{
                                        return <tr>
                                            {row.map(cell=>{
                                                return <>
                                                {cell.isFree ? <td className="seat p-2"><button id = {`button${cell.number}`} className="btn btn-outline-dark" onClick={onSeatClick}>{cell.number}</button></td> : <td className="seat text-white p-2"><button id = {`button${cell.number}`} className="btn btn-outline-dark disabled" onClick={onSeatClick}>{cell.number}</button></td>}
                                                </>
                                            })}
                                        </tr>   
                                    })}
                                    </tbody>         
                                </table>
                            </div>
                    : <h2>Enter correct data and time to view available seats</h2>
                    }
                    <div>
                        {price != 0 ? 
                        <div className="d-flex">
                            <h2 className="m-1">Your price: </h2>
                            <label id = "price" name = "price" class="label label-default h2 m-1">{price}</label>
                        </div>:
                        <div>

                        </div>
                        }
                    <input type="submit" className="btn btn-dark btn-sm text-white w-25 m-1" style={{"marginTop":"1vh"}} value="Book"/>  
                    </div>
                    {/* <div>
                        <h2>Tarrifs</h2>
                            <div className="m-auto">
                                {tarrifs.map(item=>{
                                    return <div>
                                        <label style={{"marginRight":"1vh"}}>Hours:{item.hours}    -   Cost: {item.cost}</label>
                                        <input id ={`tariff${item.hours}`} name="tariff" type="radio" className="form-check-input" value={`${item.hours}:${item.cost}`}/>
                                        </div>
                                })}
                            </div>
                    
                        <input id="seats" name="seats" style={{"visibility":"hidden"}} type="text"/>
                    </div>       */}
                </form>
                </div>
            </div>
    }
    </div>
}
