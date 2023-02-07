import axios from "axios"
import jwtDecode from "jwt-decode";
import { Link, useNavigate } from "react-router-dom";
import { Children, useEffect, useState } from "react";
import { Home } from "./Home";
import { Modal } from "../../Components/Helpers/Modal/Modal";
import { BookingViewComponent } from "./Booking/BookingViewComponent";
import api from "./../../Components/api";
import BarLoader from "react-spinners/BarLoader";

export const ProfileComponent = () => {
    const [index, setIndex] = useState(0);
    console.log("ANIME PROFILE");
    const [modalActive, setModalActive] = useState(false);
    const [editingActive, setEditingActive] = useState(false);
    const [submitState, setSubmitState] = useState(false);
    let navigate = useNavigate();
    let accessToken = localStorage.getItem('accessToken');
    let [name, setName] = useState("");
    let [surname, setSurname] = useState("");
    let [email, setEmail] = useState("");
    let [phone, setPhone] = useState("");
    const [loading, setLoading] = useState(false);
    let state = true;
    //const baseUrl = `http://dotnetinternship2022.norwayeast.cloudapp.azure.com:83`;
    // const baseUrl = `https://localhost:7227`;
    // const apiRequestUrl = `${baseUrl}/profile/getProfile`;

    // const config = {
    //     headers: { Authorization: `Bearer ${accessToken}` }
    // };
    useEffect(()=>{
        setLoading(true);
        setTimeout(()=>{
            api.get(`/profile/getProfile`).then(res =>{
                console.dir(res);
                setName(res.data.username);
                setSurname(res.data.surname);
                setEmail(res.data.email);
                setPhone(res.data.phone);
                setLoading(false);
                //setSubmitState(false);
            }).catch(console.log, ()=>{state = false});
        },1000);        
    },[submitState]);
    function editingEnableButtonClick(event)
    {
        event.preventDefault();
        setEditingActive(!editingActive);
    }

    function editingSubmit(event)
    {
        event.preventDefault();
        const requestBody = {
            "username": event.target.elements.name.value,
            "surname": event.target.elements.surname.value,
            "email":event.target.elements.email.value,
            "phone":event.target.elements.phone.value,
        };
        api.put(`/profile/profileEditing`,requestBody).then(()=>{
            setEditingActive(false);
            setSubmitState(!submitState);
            navigate('/profile');
        }).catch(console.log);
    }
 
    return <div style={{"display":"flex","justifyContent":"center","alignItems":"center","width":"100%","height":"80vh"}}>{loading ?
            <div>
                 <BarLoader
                    color={"#123abc"}
                    loading={loading}
                    size={30}
                    />
            </div>
             : 
             <div className="d-flex align-items-center justify-content-center">
              <div className="p-5 m-2 bg-info text-white shadow rounded-2">
                <form  method="post" onSubmit={editingSubmit}>
                    <h1 className="pt-2 text-dark">User profile</h1>
                    <hr></hr>
                    {editingActive ?  
                        <div>
                            <div className="d-flex flex-row"><h2 className="text-dark">Name: </h2><input id="nameInput" name="name" type="text" className="form-control bg-transparent border-0 text-white" defaultValue={name} /></div>
                            <div className="d-flex flex-row"><h2 className="text-dark">Surname: </h2><input id="surnameInput" name="surname" type="text" className="form-control bg-transparent border-0 text-white" defaultValue={surname}/></div>
                            <div className="d-flex flex-row"><h2 className="text-dark">Email: </h2><input id="emailInput" name="email" type="email" className="form-control bg-transparent border-0 text-white" defaultValue={email} /></div>
                            <div className="d-flex flex-row"><h2 className="text-dark">Phone: </h2><input id="phoneInput" name="phone" type="tel" className="form-control bg-transparent border-0 text-white" defaultValue={phone}/></div>
                        </div>
                        : 
                        <div>
                            <div className="d-flex flex-row"><h2 className="text-dark">Name: </h2><div id = "name" className="h3 m-1">{name}</div></div>
                            <div className="d-flex flex-row"><h2 className="text-dark">Surname: </h2><div id="surname" className="h3 m-1">{surname}</div></div>
                            <div className="d-flex flex-row"><h2 className="text-dark">Email: </h2><div id="email" className="h3 m-1">{email}</div></div>
                            <div className="d-flex flex-row"><h2 className="text-dark">Phone: </h2><div id="phone" className="h3 m-1">{phone}</div></div>
                        </div>
                    }
                     <div>
                    {!editingActive ? <div className="d-flex">
                        <button onClick={editingEnableButtonClick} className="btn btn-outline-dark btn-sm w-25 m-2"><div>Edit profile</div></button>
                        <Link to='/' className="btn btn-outline-dark btn-sm m-2">Home page</Link>
                    </div>
                    :<div className="d-flex">
                        <input type="submit" className="btn btn-outline-dark btn-sm m-2" value="Save changes"/> 
                        <button onClick={editingEnableButtonClick} className="btn btn-outline-dark btn-sm m-2"><div>Stop editing profile</div></button> 
                        <Link to='/' className="btn btn-outline-dark btn-sm m-2">Home page</Link>
                    </div>}
                </div>
                </form> 
                </div>
         </div>}
        </div>
} 