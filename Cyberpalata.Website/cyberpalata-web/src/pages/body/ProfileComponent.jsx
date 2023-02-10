import { Link, useNavigate } from "react-router-dom";
import { Children, useEffect, useState } from "react";
import api from "./../../Components/api";
import BarLoader from "react-spinners/BarLoader";
import stateStore from "../../store/stateStore";
import { observer } from "mobx-react-lite";

export const ProfileComponent = observer(() => {
    const [editingActive, setEditingActive] = useState(false);
    const [submitState, setSubmitState] = useState(false);
    let navigate = useNavigate();
    let accessToken = localStorage.getItem('accessToken');
    let [name, setName] = useState("");
    let [surname, setSurname] = useState("");
    let [email, setEmail] = useState("");
    let [phone, setPhone] = useState("");
    const [loading, setLoading] = useState(false);

    const [otherError, setOtherError] = useState("");
    const [usernameError, setUsernameError] = useState("");
    const [surnameError, setSurnameError] = useState("");
    const [emailError, setEmailError] = useState("");
    const [phoneError, setPhoneError] = useState("");

    let state = true;
    useEffect(()=>{
        setLoading(true);
        api.get(`/users/getUserProfile`).then(res =>{
            console.dir(res);
            setName(res.data.username);
            setSurname(res.data.surname);
            setEmail(res.data.email);
            setPhone(res.data.phone);
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
    },[submitState, stateStore.state]);
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
        api.put(`/users/editUser`,requestBody).then(()=>{
            setEditingActive(false);
            setSubmitState(!submitState);
            navigate('/profile');
        }).catch(error=>{
            console.dir(error);
            if((error.response.status >= 500 && error.response.status <= 599) || error.code == "ERR_NETWORK")
            {
                navigate('/');
            }
            const data = error.response.data;
            if(data.Other)
            {
                setOtherError(data.Other);
            }
            if(data.Email)
            {
                setEmailError(data.Email);
            }
            if(data.Username)
            {
                setUsernameError(data.Username);
            }
            if(data.Surname)
            {
                setSurnameError(data.Surname);
            }
            if(data.Phone)
            {
                setPhoneError(data.Phone);
            }
        });
    }

    function clearErrors()
    {
        setOtherError("");
        setEmailError("");
        setUsernameError("");
        setSurnameError("");
        setPhoneError("");
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
                            {otherError != "" && <div className="m-1 text-danger">{otherError}</div>}
                            <div className="d-flex flex-row"><h2 className="text-dark">Name: </h2><input id="nameInput" name="name" type="text" onInput={clearErrors} className="form-control bg-transparent border-0 text-white" defaultValue={name} /></div>
                            {usernameError != "" && <div className="m-1 text-danger">{usernameError}</div>}
                            <div className="d-flex flex-row"><h2 className="text-dark">Surname: </h2><input id="surnameInput" name="surname" type="text" onInput={clearErrors} className="form-control bg-transparent border-0 text-white" defaultValue={surname}/></div>
                            {surnameError != "" && <div className="m-1 text-danger">{surnameError}</div>}
                            <div className="d-flex flex-row"><h2 className="text-dark">Email: </h2><input id="emailInput" name="email" type="email" onInput={clearErrors} className="form-control bg-transparent border-0 text-white" defaultValue={email} /></div>
                            {emailError != "" && <div className="m-1 text-danger">{emailError}</div>}
                            <div className="d-flex flex-row"><h2 className="text-dark">Phone: </h2><input id="phoneInput" name="phone" type="tel" onInput={clearErrors} className="form-control bg-transparent border-0 text-white" defaultValue={phone}/></div>
                            {phoneError != "" && <div className="m-1 text-danger">{phoneError}</div>}
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
})