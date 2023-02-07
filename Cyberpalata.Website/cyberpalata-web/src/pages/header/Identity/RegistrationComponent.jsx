import { useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";
import api from "./../../../Components/api";
import BarLoader from "react-spinners/BarLoader";
import { useState } from "react";

export const RegistrationComponent = ()=>{
    let navigate = useNavigate();
    const [otherError, setOtherError] = useState("");
    const [usernameError, setUsernameError] = useState("");
    const [surnameError, setSurnameError] = useState("");
    const [emailError, setEmailError] = useState("");
    const [phoneError, setPhoneError] = useState("");
    const [passwordError, setPasswordError] = useState("");
    const [passwordConfirmError, setPasswordConfirmError] = useState("");
    const [loading,setLoading] = useState(false);
    const baseUrl = `https://localhost:7227`;
    function sendRegisterRequest(event)
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
        // const apiRequestUrl = `${baseUrl}/users/register`;

        api.post(`/users/register`, data).then(()=>
        {
            navigate(`/emailConfirm/${data.email}`);
        }).catch((err)=>
        {
            let data = err.response.data;
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
        size={30}
        /> : 
        <div className="d-flex align-items-center justify-content-center">
        <form className="p-5 m-2 bg-info text-white shadow rounded-2" onSubmit={sendRegisterRequest}>
            {otherError != "" && <div className="m-1 text-danger">{otherError}</div>}
            <div className="d-flex"> 
                <div className="m-1">
                    <label for="username" className="form-label">Name</label>
                    <input type="text" className="form-control" onInput={clearErrors} id="username" name="username" aria-describedby="usernameHelp"/>
                    {usernameError != "" && <div className="m-1 text-danger">{usernameError}</div>}
                </div>
                <div className="m-1">
                    <label for="surname" className="form-label">Surname</label>
                    <input type="text" className="form-control" id="surname" name="surname" aria-describedby="surnameHelp"/>
                    {surnameError != "" && <div className="m-1 text-danger">{surnameError}</div>}
                </div>
            </div>
            <div className="m-1">
                <label for="email" className="form-label">Email address</label>
                <input type="email" className="form-control" id="email" name="email" aria-describedby="emailHelp"/>
                {emailError != "" && <div className="m-1 text-danger">{emailError}</div>}
            </div>
            <div className="m-1">
                <label for="phone" className="form-label">Phone</label>
                <input type="tel" className="form-control" id="phone" name="phone" aria-describedby="phoneHelp" pattern="^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$"/>
                {phoneError != "" && <div className="m-1 text-danger">{phoneError}</div>}
            </div>
            <div className="d-flex">
                <div className="w-50 m-1">
                    <label for="password" className="form-label">Password</label>
                    <input type="password" className="form-control" name="password" id="password"/>
                    {passwordError != "" && <div className="m-1 text-danger">{passwordError}</div>}
                </div>
                <div className="w-50 m-1">
                    <label for="passwordConfirm" className="form-label">Password confirm</label>
                    <input type="password" className="form-control" name="passwordConfirm" id="passwordConfirm"/>
                    {passwordConfirmError != "" && <div className="m-1 text-danger">{passwordConfirmError}</div>}
                </div>
            </div>
            <div className="d-flex justify-content-around">
                <button type="submit" className="btn btn-outline-dark btn-sm text-white w-50 m-1">Register</button>
                <Link to='/' className="btn btn-outline-dark btn-sm text-white w-50 m-1">Cancel</Link>
            </div>
        </form>
        </div>}
    </div> 
}