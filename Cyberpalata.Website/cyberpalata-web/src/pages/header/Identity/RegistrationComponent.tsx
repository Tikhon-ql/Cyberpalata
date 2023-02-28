import { useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";
import api from "./../../../Components/api";
import BarLoader from "react-spinners/BarLoader";
import { useState } from "react";
import React from "react";


export const RegistrationComponent = ()=>{
    let navigate = useNavigate();
    const [username, setUsername] = useState<string>("");
    const [surname, setSurname] = useState<string>("");
    const [email, setEmail] = useState<string>("");
    const [phone, setPhone] = useState<string>("");
    const [otherError, setOtherError] = useState<string>("");
    const [usernameError, setUsernameError] = useState<string>("");
    const [surnameError, setSurnameError] = useState<string>("");
    const [emailError, setEmailError] = useState<string>("");
    const [phoneError, setPhoneError] = useState<string>("");
    const [passwordError, setPasswordError] = useState<string>("");
    const [passwordConfirmError, setPasswordConfirmError] = useState<string>("");
    const [loading,setLoading] = useState<boolean>(false);

    function sendRegisterRequest(event: any)
    {
        event.preventDefault();
        setLoading(true);
        const data = {
            "username": event.target.elements.username.value,
            "surname": event.target.elements.surname.value,
            "email":event.target.elements.email.value,
            "phone":event.target.elements.phone.value,
            "password":event.target.elements.password.value,
            "passwordConfirm" : event.target.elements.passwordConfirm.value
        }
        console.log(data.email);

        api.post(`/users/register`, data).then((res)=>
        {  
            navigate(`/emailConfirm/${data.email}/${res.data}`);
        }).catch((error)=>
        {
            if(error.code && error.code == "ERR_NETWORK")
            {
                navigate('/500');
            }
            if((error.response.status >= 500 && error.response.status <= 599))
            {
                navigate('/500');
            }
            let data = error.response.data;
            if(data.Other)
            {
                setOtherError(data.Other);
            }
            if(data.Email)
            {
                setEmailError(data.Email);
            }
            if(data.Password)
            {
                setPasswordError(data.Password);
            }
            if(data.PasswordConfirm)
            {
                setPasswordConfirmError(data.PasswordConfirm);
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
        }).finally(()=>{ setLoading(false);});
    }

    function clearErrors()
    {
        setOtherError("");
        setEmailError("");
        setPasswordError("");
        setPasswordConfirmError("");
        setUsernameError("");
        setSurnameError("");
        setPhoneError("");
    }


    return <div style={{"display":"flex","justifyContent":"center","alignItems":"center","width":"100%","height":"80vh"}}>
        {loading ?  

         <BarLoader
        color={"#123abc"}
        loading={loading}

        // size={30}
        /> : 
        <div className="myForm">
            <h1>Registration</h1>
            <form method="post" onSubmit={(e)=>{sendRegisterRequest(e)}}>
                <div className="d-flex">
                    <input type="text" style={{"marginRight":"0.3vw"}} onInput={clearErrors} onChange={(e)=>{setUsername(e.target.value)}} id="username" name="username" placeholder="Name" required/>
                    <input type="text" style={{"marginLeft":"0.3vw"}} id="surname" onChange={(e)=>{setSurname(e.target.value)}} name="surname" placeholder="Surname" required/>
                </div>
                <input type="email" id="email" name="email" onChange={(e)=>{setEmail(e.target.value)}} placeholder="Email" required/>
                <input type="tel" id="phone" name="phone" aria-describedby="phoneHelp" onChange={(e)=>{setPhone(e.target.value)}} placeholder="Phone" required/>
                <input type="password" name="password" id="password" placeholder="Password" required/>
                <input type="password" name="passwordConfirm" id="passwordConfirm" placeholder="Password confirm" required/>
                <button type="submit" className="btn btn-primary btn-block btn-large">Register</button>
            </form>
        </div>}
    </div>
}
{/* 
<div className="d-flex align-items-center justify-content-center">
        <form className="p-5 m-2 bg-info text-white shadow rounded-2" onSubmit={sendRegisterRequest}>
            {otherError != "" && <div className="m-1 text-danger">{otherError}</div>}
            <div className="d-flex"> 
                <div className="m-1">
                    <label htmlFor="username" className="form-label">Name</label>
                    <input type="text" className="form-control" onInput={clearErrors} onChange={(e)=>{setUsername(e.target.value)}} id="username" name="username" defaultValue={username} aria-describedby="usernameHelp"/>
                    {usernameError != "" && <div className="m-1 text-danger">{usernameError}</div>}
                </div>
                <div className="m-1">
                    <label htmlFor="surname" className="form-label">Surname</label>
                    <input type="text" className="form-control" id="surname" onChange={(e)=>{setSurname(e.target.value)}} name="surname" defaultValue={surname} aria-describedby="surnameHelp"/>
                    {surnameError != "" && <div className="m-1 text-danger">{surnameError}</div>}
                </div>
            </div>
            <div className="m-1">
                <label htmlFor="email" className="form-label">Email address</label>
                <input type="email" className="form-control" id="email" name="email" onChange={(e)=>{setEmail(e.target.value)}} defaultValue={email} aria-describedby="emailHelp"/>
                {emailError != "" && <div className="m-1 text-danger">{emailError}</div>}
            </div>
            <div className="m-1">
                <label htmlFor="phone" className="form-label">Phone</label>
                <input type="tel" className="form-control" id="phone" name="phone" aria-describedby="phoneHelp" onChange={(e)=>{setPhone(e.target.value)}} defaultValue={phone} />
                {phoneError != "" && <div className="m-1 text-danger">{phoneError}</div>}
            </div>
            <div className="d-flex">
                <div className="w-50 m-1">
                    <label htmlFor="password" className="form-label">Password</label>
                    <input type="password" className="form-control" name="password" id="password"/>
                    {passwordError != "" && <div className="m-1 text-danger">{passwordError}</div>}
                </div>
                <div className="w-50 m-1">
                    <label htmlFor="passwordConfirm" className="form-label">Password confirm</label>
                    <input type="password" className="form-control" name="passwordConfirm" id="passwordConfirm"/>
                    {passwordConfirmError != "" && <div className="m-1 text-danger">{passwordConfirmError}</div>}
                </div>
            </div>
            <div className="d-flex justify-content-around">
                <button type="submit" className="btn btn-outline-dark btn-sm text-white w-50 m-1">Register</button>
                <Link to='/' className="btn btn-outline-dark btn-sm text-white w-50 m-1">Cancel</Link>
            </div>
        </form>
        </div>
  */}