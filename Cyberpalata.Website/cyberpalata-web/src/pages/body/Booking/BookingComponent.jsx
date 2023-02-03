import axios from "axios";
import jwtDecode from "jwt-decode";
import { useState } from "react";
import { useParams } from "react-router-dom";
import "./BookingComponent.css";

export const BookingComponent = () => {
    
    const {roomId} = useParams()
    const {roomName} = useParams();
    const {roomType} = useParams();
    const [seats,setSeats] = useState([]);
    const [tarrifs, setTarrifs] = useState([]);
    const apiUrl = `https://localhost:7227/booking/seats?roomId=${roomId}`;

    let accessToken = localStorage.getItem('accessToken');
    let refreshToken = localStorage.getItem('refreshToken');

    const config = {
        headers: { Authorization: `Bearer ${accessToken}` }
    };

    axios.get(apiUrl,{},config).then(res=>{
        //console.dir(res);
        setSeats(res.data.seats);
        setTarrifs(res.data.tariffs);
    }).catch(console.log);

    let columnCount = 10;
    let rowCount = seats.length / columnCount;

    seats.sort((a,b) => a.number > b.number ? 1 : -1);
   
    let seatsPerRow = [];
    for(let i = 0;i < rowCount * columnCount;i+=columnCount)
    {
        let chunk = seats.slice(i, i + columnCount);
        seatsPerRow.push(chunk);
    }
   
    // if(allSeats.length > 0)
    // {
    //     console.dir(allSeats);
    //     for(let i = 0;i < seats.length;i++)
    //     {
    //         console.dir(allSeats[seats[i]]);
    //         allSeats[seats[i]].isFree = true;
    //     }
    //     //console.dir(allSeats);
    // }

    function sendBookToServer(event)
    {
        event.preventDefault();
        console.dir(event);
        const apiUrl = `https://localhost:7227/booking`;
        if(localStorage.getItem('accessToken') != null)
        {
            let accessToken = jwtDecode(localStorage.getItem(`accessToken`));
            let tariff = event.target.elements.tariff.value.split(":");
            console.dir(accessToken);
            let requestBody = { 
                "roomId":roomId,
                "begining": event.target.elements.begining.value,
                "ending": event.target.elements.ending.value,
                "tariff": 
                {
                    "hours":tariff[0],
                    "cost":tariff[1]
                },
                "seats": clickedSeats,        
            }
            const config = {
                headers: { Authorization: `Bearer ${localStorage.getItem('accessToken')}` }
            };
            console.dir(requestBody);
            axios.post(apiUrl, requestBody,config).then(res=>setClickedSeats([]));
        }    
    }

    const[clickedSeats, setClickedSeats] = useState([]);
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
    

    return <>
    <form method="post" onSubmit={sendBookToServer} className="mt-5 p-5" style={{"margin":"auto","width":"50%", "border" : "3px solid black", "padding" : "10px"}}>
        <h2 className="mx-auto">{roomName}</h2>
        <h2>Dates</h2>
        <div className="">
            <label htmlFor="begining" className="m-3">
                <div>Begining</div>
                <input id="begining" name="begining" type="date"/>
            </label>
            <label htmlFor="ending" className="m-3">
                <div>Ending</div> 
                <input id="ending" name="ending" type="date"/>
            </label>
        </div>
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
        <div>
            <h2>Tarrifs</h2>
                <div className="m-auto">
                    {tarrifs.map(item=>{
                        return <div>
                            <label style={{"marginRight":"1vh"}}>Hours:{item.hours}    -   Cost: {item.cost}</label>
                            <input id ={`tariff${item.hours}`} name="tariff" type="radio" className="form-check-input" value={`${item.hours}:${item.cost}`}/>
                            </div>
                    })}
                </div>    
            <input type="submit" style={{"marginTop":"1vh"}} className value="Book"/>
            <input id="seats" name="seats" style={{"visibility":"hidden"}} type="text"/>
        </div>      
    </form>
    </>
}
