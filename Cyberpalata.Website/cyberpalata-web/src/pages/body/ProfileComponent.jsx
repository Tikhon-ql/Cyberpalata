import axios from "axios"
import jwtDecode from "jwt-decode";
import { Link, useNavigate } from "react-router-dom";
import { Children, useState } from "react";
import { Home } from "./Home";
import { Modal } from "../../Components/Modal/Modal";

export const ProfileComponent = () => {

    const [modalActive, setModalActive] = useState(false);
    const [editingActive, setEditingActive] = useState(false);

    let navigate = useNavigate();
    let accessToken = localStorage.getItem('accessToken');
    let [name, setName] = useState("");
    let [surname, setSurname] = useState("");
    let [email, setEmail] = useState("");
    let [phone, setPhone] = useState("");
    //let [user, setUser] = useState({});
    //let [bookings, setBookings] = useState([]);
    let state = true;
    if(accessToken != null)
    {
        //const baseUrl = `http://dotnetinternship2022.norwayeast.cloudapp.azure.com:83`;
        const baseUrl = `https://localhost:7227`;
        const apiRequestUrl = `${baseUrl}/users/profile`;

        const config = {
            headers: { Authorization: `Bearer ${accessToken}` }
        };

        axios.get(apiRequestUrl,config).then(res =>{
            console.dir(res);
            setName(res.data.username);
            setSurname(res.data.surname);
            setEmail(res.data.email);
            setPhone(res.data.phone);
            //setUser(res.data.user);
            //setBookings(res.data.bookings);
        }).catch(console.log, ()=>{state = false});
    }
    else
    {
        console.error("Access is denied");
        state = false;
    }

    // let columnCount = 10;
    // let rowCount = bookings.seats.length / columnCount;

    // seats.sort((a,b) => a.number > b.number ? 1 : -1);
   
    // let seatsPerRow = [];
    // for(let i = 0;i < rowCount * columnCount;i+=columnCount)
    // {
    //     let chunk = seats.slice(i, i + columnCount);
    //     seatsPerRow.push(chunk);
    // }

    function editingEnableButtonClick(event)
    {
        setEditingActive(!editingActive);
    }

    function editingSubmit(event)
    {
        event.preventDefault();
        const baseUrl = `https://localhost:7227`;
        const apiRequestUrl = `${baseUrl}/users/profileEditing`;
        const config = {
            headers: { Authorization: `Bearer ${accessToken}` }
        };
        const requestBody = {
            "username": event.target.elements.name.value,
            "surname": event.target.elements.surname.value,
            "email":event.target.elements.email.value,
            "phone":event.target.elements.phone.value,
        };
        axios.post(apiRequestUrl,requestBody,config).then(()=>{
            setEditingActive(false);
            navigate('/profile');
        }).catch(console.log);
    }


    return <>{state ?
        <div className="mt-5 p-5" style={{"margin":"auto","width":"50%", "border" : "3px solid black", "padding" : "10px"}}>
            <form method="post" onSubmit={editingSubmit}>
                <h1 className="pt-5">User profile</h1>
                <hr></hr>
                {editingActive ?  
                    <div>
                        <div className="d-flex flex-row"><h2>Name: </h2><input id="name" name="name" type="text" className="form-control" defaultValue={name} /></div>
                        <div className="d-flex flex-row"><h2>Surname: </h2><input id="surname" name="surname" type="text" className="form-control" defaultValue={surname}/></div>
                        <div className="d-flex flex-row"><h2>Email: </h2><input id="email" name="email" type="email" className="form-control" defaultValue={email} /></div>
                        <div className="d-flex flex-row"><h2>Phone: </h2><input id="phone" name="phone" type="tel" className="form-control" defaultValue={phone}/></div>
                    </div>
                    : 
                    <div>
                        <div className="d-flex flex-row"><h2>Name: </h2><input id="name" name="name" type="text" className="form-control" value={name} readOnly/></div>
                        <div className="d-flex flex-row"><h2>Surname: </h2><input id="surname" name="surname" type="text" className="form-control" value={surname} readOnly/></div>
                        <div className="d-flex flex-row"><h2>Email: </h2><input id="email" name="email" type="email" className="form-control" value={email} readOnly/></div>
                        <div className="d-flex flex-row"><h2>Phone: </h2><input id="phone" name="phone" type="tel" className="form-control" value={phone} readOnly/></div>
                    </div>
                }
                <input type="submit" value="Save changes" className="btn btn-dark mb-2"/>
            </form> 
            <button onClick={editingEnableButtonClick}>{editingActive ? <div>Stop editing profile</div>: <div>Edit profile</div>}</button>
            <button onClick={()=>{setModalActive(true)}}>Show bookings</button>
            
            <Modal active={modalActive} setActive={setModalActive}>
            {/* <h2>Seats</h2>
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
                </table> */}
            </Modal>
            <Link to='/' className="btn btn-outline-dark btn-sm mt-2">Home page</Link>
        </div>
             : <Home/>}
        </>
}