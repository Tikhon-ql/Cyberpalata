import { Link, useNavigate } from "react-router-dom";
import { Children, useEffect, useState } from "react";
import api from "../../../Components/api";
import BarLoader from "react-spinners/BarLoader";
import stateStore from "../../../store/stateStore";
import { observer } from "mobx-react-lite";
import React from "react";
import { ClimbingBoxLoader } from "react-spinners";

export const ProfileComponent = observer(() => {
    const [editingActive, setEditingActive] = useState<boolean>(false);
    const [submitState, setSubmitState] = useState<boolean>(false);
    let navigate = useNavigate();
    let accessToken = localStorage.getItem('accessToken');
    let [name, setName] = useState<string>("");
    let [surname, setSurname] = useState<string>("");
    let [email, setEmail] = useState<string>("");
    let [phone, setPhone] = useState<string>("");
    const [loading, setLoading] = useState<boolean>(false);

    const [otherError, setOtherError] = useState<string>("");
    const [usernameError, setUsernameError] = useState<string>("");
    const [surnameError, setSurnameError] = useState<string>("");
    const [emailError, setEmailError] = useState<string>("");
    const [phoneError, setPhoneError] = useState<string>("");

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

    function editingEnableButtonClick(event: any)
    {
        event.preventDefault();
        setEditingActive(!editingActive);
    }


    function editingSubmit(event: any)
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
                 <ClimbingBoxLoader
                    color={"white"}
                    loading={loading}
                    />
            </div>
             :

            <div className="align-items-center justify-content-center text-white">
                <h1 className="text-white" style={{"textAlign":"center","marginBottom":"1vw"}}>User profile</h1><hr/>
                <div style={{"display":"flex"}}>
                    <div style={{"display":"flex","flexDirection":"column","justifyContent":"start", "marginRight":"1vw"}}>
                        <Link to='/teamCreating' style={{"border":"1px solid","padding":"1vh","borderRadius":"1vh", "marginRight":"1vw",marginBottom:"0"}}>Create team</Link><br />
                        <Link to='/usersTournaments'  style={{"border":"1px solid","padding":"1vh","borderRadius":"1vh","marginRight":"1vw"}}>Show tournaments</Link><br />
                        {/* <Link to='/'style={{"border":"1px solid","padding":"1vh","borderRadius":"1vh","marginRight":"1vw",marginBottom:"3vh"}}>Home page</Link> */}
                        {!editingActive ?
                            <button onClick={editingEnableButtonClick} style={{"background":"none","border":"1px solid","padding":"1vh","borderRadius":"1vh","marginRight":"1vw",textAlign:"start"}}><div>Edit profile</div></button>
                            :<button onClick={editingEnableButtonClick} style={{"background":"none","border":"1px solid","padding":"1vh","borderRadius":"1vh","marginRight":"1vw",textAlign:"start"}}><div>Stop editing profile</div></button>}
                        <Link to='/joinRequests'  style={{"border":"1px solid","padding":"1vh","borderRadius":"1vh","marginRight":"1vw"}}>Show join request</Link><br />
                    </div>
                    <div>
                        <form  method="post" onSubmit={editingSubmit}>
                            {editingActive ?  
                                <div>
                                    {otherError != "" && <div className="m-1 text-danger">{otherError}</div>}
                                    <div className="d-flex flex-row"><h2 className="text-white">Name: </h2><input id="nameInput" name="name" type="text" onInput={clearErrors} className="form-control bg-transparent border-0 text-white" defaultValue={name} /></div>
                                    {usernameError != "" && <div className="m-1 text-danger">{usernameError}</div>}
                                    <div className="d-flex flex-row"><h2 className="text-white">Surname: </h2><input id="surnameInput" name="surname" type="text" onInput={clearErrors} className="form-control bg-transparent border-0 text-white" defaultValue={surname}/></div>
                                    {surnameError != "" && <div className="m-1 text-danger">{surnameError}</div>}
                                    <div className="d-flex flex-row"><h2 className="text-white">Email: </h2><input id="emailInput" name="email" type="email" onInput={clearErrors} className="form-control bg-transparent border-0 text-white" defaultValue={email} /></div>
                                    {emailError != "" && <div className="m-1 text-danger">{emailError}</div>}
                                    <div className="d-flex flex-row"><h2 className="text-white">Phone: </h2><input id="phoneInput" name="phone" type="tel" onInput={clearErrors} className="form-control bg-transparent border-0 text-white" defaultValue={phone}/></div>
                                    {phoneError != "" && <div className="m-1 text-danger">{phoneError}</div>}
                                </div>
                                : 
                                <div>
                                    <div className="d-flex flex-row"><h2 className="text-white" style={{"marginRight":"1vw"}}>Name: </h2><div id = "name" className="h3">{name}</div></div>
                                    <div className="d-flex flex-row"><h2 className="text-white" style={{"marginRight":"1vw"}}>Surname: </h2><div id="surname" className="h3">{surname}</div></div>
                                    <div className="d-flex flex-row"><h2 className="text-white" style={{"marginRight":"1vw"}}>Email: </h2><div id="email" className="h3">{email}</div></div>
                                    <div className="d-flex flex-row"><h2 className="text-white"style={{"marginRight":"1vw"}}>Phone: </h2><div id="phone" className="h3">{phone}</div></div>
                                </div>
                            }
                            <div>
                            {editingActive &&
                                <input type="submit" style={{"border":"1px solid","padding":"1vh","borderRadius":"1vh"}} value="Save changes"/>}
                            </div>
                        </form>
                    </div>   
                </div>
            </div>
           }
        </div>
})



