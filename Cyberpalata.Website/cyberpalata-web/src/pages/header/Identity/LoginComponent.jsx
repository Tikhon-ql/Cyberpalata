import {Link} from 'react-router-dom';
import { useNavigate } from "react-router-dom";
import api from "./../../../Components/api";
import "./../../../index.css";

export const LoginComponent = () => {

    let navigate = useNavigate();
    function sendLoginRequest(event)
    {
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
            navigate("/");
        });
    }
    return <div className="d-flex align-items-center justify-content-center">
        <form className="p-5 m-2 bg-info text-white shadow rounded-2" onSubmit={sendLoginRequest}>
            <div className="mb-3">
                <label for="exampleInputEmail1" className="form-label">Email address</label>
                <input type="email" name="email" className="form-control" id="exampleInputEmail1" aria-describedby="emailHelp"/>
                <div id="emailHelp" className="form-text text-white">We'll never share your email with anyone else.</div>
            </div>
            <div className="mb-3">
                <label for="exampleInputPassword1" className="form-label">Password</label>
                <input type="password" name="password" className="form-control" id="exampleInputPassword1"/>
            </div>
            <div className="d-flex justify-content-around">
                <button type="submit" className="btn  btn-outline-dark btn-sm m-2 text-white">Login</button> 
                <Link to='/passwordRecovering' className="btn btn-outline-dark btn-sm m-2 text-white">Forgot password</Link>
                <Link to='/register' className="btn  btn-outline-dark btn-sm m-2 text-white">Register</Link>
                <Link to='/' className="btn  btn-outline-dark btn-sm m-2 text-white">Cancel</Link>
            </div>  
        </form>
    </div>
}

