import { useState } from "react";
import { BarLoader } from "react-spinners";
import api from "../../Components/api";
import Error from "react-500";
import { Link } from "react-router-dom";

export const RoomSearch = ()=> {

    const[count, setCount] = useState(0);
    const[date, setDate] = useState("");
    const[hours,setHours] = useState(0);
    const[begining,setBegining] = useState("");
    const[typeState,setTypeState] = useState(1);
    const [otherError,setOtherError] = useState("");
    const [iternalServerError, setIternalServerError] = useState(false);
    const [loading, setLoading] = useState(false);
    const [rooms, setRooms] = useState([]);

    function submitSearch(event)
    {
        event.preventDefault();
        setLoading(true);
        console.dir(event);
        console.log("Count " + count);
        console.log("Date " + date);
        console.log("Hours count" + hours);
        console.log("Beginging " + begining);
        console.log("Type " + event.target.elements.roomType.value)
        if(count != 0)
        {
            const requestBody = 
            {
                "Count": count,
                "Type": event.target.elements.roomType.value,
                "HoursCount" : hours,
                "Date" : date,
                "Begining" : begining
            }
            api.post(`/gamingRooms/searchRooms`,requestBody).then(res=>{
                setRooms(res.data);
                console.dir(res.data);
            }).catch(error=>
            {

            })
            .finally(()=>{setLoading(false)});
        }
    }
    function clearErrors(event)
    {
        setOtherError("");
    }

    return <>
        <form onSubmit={submitSearch}>
            <input type="number" name="count" onInput={clearErrors} className="form-control" id="count" onChange={(e)=>{setCount(e.target.value)}} defaultValue={count}/>
            <input type="radio" name="roomType" onInput={clearErrors} id="roomType" onChange={(e)=>{setTypeState(1)}} value="Vip" checked={typeState == 1 ? true : false}/>
            <input type="radio" name="roomType" onInput={clearErrors} id="roomType" onChange={(e)=>{setTypeState(2)}} value="Common" checked={typeState == 2 ? true : false}/>
            <input id="date" name="date" type="date" onChange={(e)=>{setDate(e.target.value)}} defaultValue={date}/>
            <input id="begining" name="begining" type="time" onChange={(e)=>{setBegining(e.target.value)}} defaultValue={begining}/>
            <input id="hours" name="hours" className="w-50" type="range" onChange={(e)=>{setHours(e.target.value)}} min = "1" max = "10" defaultValue={hours}/>
            <input type="submit" className="btn btn-outline-dark btn-sm m-2 text-white" value="Search"/> 
        </form>
    </>





    // return <>{iternalServerError ? <div><Error/></div> 
    // :<div style={{"display":"flex","justifyContent":"center","alignItems":"center","width":"100%","height":"80vh"}}>{loading ? <div> 
    //     <BarLoader
    //         color={"#123abc"}
    //         loading={loading}
    //         size={30}
    //         />
    //     </div> : 
    //     <div className="d-flex align-items-center justify-content-center">
    //         <form className="p-5 m-2 bg-info text-white shadow rounded-2" onSubmit={submitSearch}>
    //             <div className="mb-3">
    //                 {otherError != "" && <div className="text-danger m-1 rounded">{otherError}</div>}
    //                 <label for="exampleInputEmail1" className="form-label" min="1" max = "10">Count</label>
    //                 <input type="number" name="count" onInput={clearErrors} className="form-control" id="count" onChange={(e)=>{setCount(e.target.value)}} defaultValue={count}/>
    //             </div>
    //             <div className="mb-3">
    //                 <input type="radio" name="roomType" onInput={clearErrors} id="roomType" onChange={(e)=>{setTypeState(1)}} value="Vip" checked={typeState == 1 ? true : false}/>
    //                 <label for="exampleInputEmail1" className="form-label">Vip</label>
    //             </div>
    //             <div className="mb-3">
    //                 <input type="radio" name="roomType" onInput={clearErrors} id="roomType" onChange={(e)=>{setTypeState(2)}} value="Common" checked={typeState == 2 ? true : false}/>
    //                 <label for="exampleInputEmail1" className="form-label ml-1">Common</label>
    //             </div>
    //             <h2>Dates</h2>
    //                 <div className="">
    //                     <label htmlFor="date" className="m-3">
    //                         <div>Date</div>
    //                         <input id="date" name="date" type="date" onChange={(e)=>{setDate(e.target.value)}} defaultValue={date}/>
    //                     </label>
    //                     <label htmlFor="begining" className="m-3">
    //                         <div>Begining</div>
    //                         <input id="begining" name="begining" type="time" onChange={(e)=>{setBegining(e.target.value)}} defaultValue={begining}/>
    //                     </label>
    //                     <label htmlFor="hoursCount" className="m-3 w-100 ">
    //                         <div className="d-flex">Hours count(0-10):<div id="rangeVal" style={{"marginLeft":"5px"}}>10</div></div>
    //                         <input id="hours" name="hours" className="w-50" type="range" onChange={(e)=>{setHours(e.target.value)}} min = "1" max = "10" defaultValue={hours}/>
    //                     </label>
    //                 </div>
    //             <div className="d-flex justify-content-around">
    //                 <button type="submit" className="btn btn-outline-dark btn-sm m-2 text-white">Search</button> 
    //                 <Link to='/' className="btn  btn-outline-dark btn-sm m-2 text-white">Home</Link>
    //             </div>  
    //         </form> 
    //     </div>
    // }</div>}</>
}