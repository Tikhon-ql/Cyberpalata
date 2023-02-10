import { useState } from 'react';
import {Link} from 'react-router-dom';
import { useNavigate } from "react-router-dom";
import api from "./../../../Components/api";
import "./../../../index.css";
import BarLoader from "react-spinners/BarLoader";
import { observer } from 'mobx-react-lite';
import headerRerenderStore from '../../../store/headerRerenderStore';
import Error from "react-500";

const LoginComponent = () => {
    const [email, setEmail] = useState("");
    const [iternalServerError, setIternalServerError] = useState(false);
    const [otherError,setOtherError] = useState("");
    const [emailError,setEmailError] = useState("");
    const [passwordError, setPasswordError] = useState("");
    const [loading, setLoading] = useState(false);
    let navigate = useNavigate();
    function clearErrors()
    {
        setEmailError("");
        setOtherError("");
        setPasswordError("");
    }
    function sendLoginRequest(event)
    {
        setLoading(true);
        event.preventDefault();
        const data = {
            "email":event.target.elements.email.value,
            "password":event.target.elements.password.value
        }
        api.post(`/authentication/login`, data).then(res=>
        {
            localStorage.setItem('accessToken', res.data.accessToken);
            localStorage.setItem('refreshToken', res.data.refreshToken);
            localStorage.setItem('isAuthenticated', true);
            headerRerenderStore.stateChange();
            navigate("/");
        }).catch(error=>{
            if(error.code && error.code == "ERR_NETWORK")
            {
                //navigate('/500');
                setIternalServerError(true);
            }
            if((error.response.status >= 500 && error.response.status <= 599))
            {
                //navigate('/500');
                setIternalServerError(true);
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
        })
        .finally(()=>{ setLoading(false);});     
    }
return <>{iternalServerError ? <div><Error/></div> 
    :<div style={{"display":"flex","justifyContent":"center","alignItems":"center","width":"100%","height":"80vh"}}>{loading ? <div> 
        <BarLoader
            color={"#123abc"}
            loading={loading}
            size={30}
            />
        </div> : 
        <div className="d-flex align-items-center justify-content-center">
            <form className="p-5 m-2 bg-info text-white shadow rounded-2" onSubmit={sendLoginRequest}>
                <div className="mb-3">
                    {otherError != "" && <div className="text-danger m-1 rounded">{otherError}</div>}
                    <label for="exampleInputEmail1" className="form-label">Email address</label>
                    <input type="email" name="email" onInput={clearErrors} onChange={(event)=>{setEmail(event.target.value)}} className="form-control" id="exampleInputEmail1" defaultValue={email} aria-describedby="emailHelp"/>
                    {emailError != "" && <div className="text-danger m-1 rounded">{emailError}</div>}
                </div>
                <div className="mb-3">
                    <label for="exampleInputPassword1" className="form-label">Password</label>
                    <input type="password" name="password" onInput={clearErrors} className="form-control" id="exampleInputPassword1"/>
                    {passwordError != "" && <div className="text-danger m-1 rounded">{passwordError}</div>}
                </div>
                <div className="d-flex justify-content-around">
                    <button type="submit" className="btn  btn-outline-dark btn-sm m-2 text-white">Login</button> 
                    <Link to='/passwordRecovering' className="btn btn-outline-dark btn-sm m-2 text-white">Forgot password</Link>
                    <Link to='/register' className="btn  btn-outline-dark btn-sm m-2 text-white">Register</Link>
                    <Link to='/' className="btn  btn-outline-dark btn-sm m-2 text-white">Cancel</Link>
                </div>  
            </form>
        </div>
    }</div>}
    </>
}

export default observer(LoginComponent);