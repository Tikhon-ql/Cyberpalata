import axios from "axios";
import { useState } from "react";
import { useParams } from "react-router-dom";

export const OneBookingView = ()=>{
    const [countInRow,setCountInRow] = useState(0);    
    //const [booking, setBooking] = useState({});
    const [roomName, setRoomName] = useState("")
    const [begining, setBegining] = useState("");
    const [ending, setEnding] = useState("");
    const [tariff, setTariff] = useState({});
    const [seats, setSeats] = useState([]);
    
    const {id} = useParams();

    const baseUrl = `https://localhost:7227`;
    let apiRequestUrl = `${baseUrl}/booking/getBooking?id=${id}`;
    const config = {
        headers: { Authorization: `Bearer ${localStorage.getItem('accessToken')}` }
    };
    axios.get(apiRequestUrl,config).then(res=>{
        setRoomName(res.data.roomName);
        setBegining(res.data.begining);
        setEnding(res.data.ending);
        setTariff(res.data.tariff);
        setSeats(res.data.seats);
        console.dir(seats);
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
   

    //setBookingsIds(res.data.bookingsIds);

    return <>
        <div>{roomName}</div>
        <div>{begining}</div>
        <div>{ending}</div>
        <div>{tariff.hours}: {tariff.cost}</div> 
        <table className="table w-50 m-auto">
            <tbody id = 'tbody'>
            {seatsPerRow.map(row=>{
                return <tr>
                    {row.map(cell=>{
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
          {/* {seats.map(seat=>{
                            setCountInRow(countInRow + 1);
                            return <> 
                                    {countInRow > 10 & <br/>}
                                    {seat.type.name == "Free" & <button id = {`button${seat.number}`} className="btn btn-outline-dark" >{seat.number}</button>}
                                    {seat.type.name == "IsTaken" & <button id = {`button${seat.number}`} className="btn btn-dark disabled">{seat.number}</button>}
                                    {seat.type.name == "UsersSeat" & <button id = {`button${seat.number}`} className="btn btn-primary disabled">{seat.number}</button>}
                                </>
            })} */}
    </>
}