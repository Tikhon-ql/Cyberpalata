import axios from "axios";
import { useState } from "react";
import { useParams } from "react-router-dom";
import "./BookingComponent.css";

export const BookingComponent = () => {
    
    const {roomId} = useParams()
    const {name} = useParams();
    const [seats,setSeats] = useState([]);
    const [tarrifs, setTarrifs] = useState([]);
    const apiUrl = `https://localhost:7227/booking/seats?roomId=${roomId}`;

    let accessToken = localStorage.getItem('accessToken');
    let refreshToken = localStorage.getItem('refreshToken');

    const config = {
        headers: { Authorization: `Bearer ${accessToken}` }
    };

    axios.get(apiUrl,{},config).then(res=>{
        console.dir(res);
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
        const apiUrl = `https://localhost:7227/booking`;
        let request = {
            "begining": event.target.elements.begining.value,
            "ending": event.target.elements.ending.value,
            "tariff": event.target.elements.tariff.value,
        }
    }

    return <>
    <form method="post" onSubmit={sendBookToServer} className="mt-5 p-5" style={{"margin":"auto","width":"50%", "border" : "3px solid black", "padding" : "10px"}}>
        <h2 className="mx-auto">{name}</h2>
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
            <tbody>
            {seatsPerRow.map(row=>{
                return <tr>
                    {row.map(cell=>{
                        return <>
                        {cell.isFree ? <td className="seat p-2">{cell.number}</td> : <td className="seat text-white bg-dark p-2">{cell.number}</td>}
                        </>
                    })}
                </tr>
            })}
            </tbody>         
        </table>
            <h2>Tarrifs</h2>
            <div className="m-auto">
                {tarrifs.map(item=>{
                    console.dir(item);
                    return <div>
                        <label className="m-2">Hours:{item.hours}    -   Cost: {item.cost}</label>
                        <input id ={`tariff${item.hours}`} name="tariff" type="radio" value={`${item.hours}:${item.cost}`}/>
                        </div>
                })}
            </div>
        <input type="submit" value="Book"/>
    </form>
    </>
}



{/* <tr>
<td><div className="m-1 seat" style={{"border":"1 px solid black"}}>1</div></td>
<td><div className="m-1 seat notFreeSeat" style={{"border":"1 px solid black"}}>2</div></td>
<td><div className="" style={{"border":"1 px solid black",}}>3</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>4</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>5</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>6</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>7</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>8</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>9</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>10</div></td>
</tr>
<tr>
<td><div className="m-1" style={{"border":"1 px solid black"}}>11</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>12</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>13</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>14</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>15</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>16</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>17</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>18</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>19</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>20</div></td>
</tr>
<tr>
<td><div className="m-1" style={{"border":"1 px solid black"}}>21</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>22</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>23</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>24</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>25</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>26</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>27</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>28</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>29</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>30</div></td>
</tr>
<tr>
<td><div className="m-1" style={{"border":"1 px solid black"}}>31</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>32</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>33</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>34</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>35</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>36</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>37</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>38</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>39</div></td>
<td><div className="m-1" style={{"border":"1 px solid black"}}>40</div></td>
</tr> */}