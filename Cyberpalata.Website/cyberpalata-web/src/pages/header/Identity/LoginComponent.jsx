import { createBrowserHistory } from "@remix-run/router";
import axios  from 'axios';
import {Link} from 'react-router-dom';
import { useNavigate } from "react-router-dom";

export const LoginComponent = () => {

    let navigate = useNavigate();
    function sendLoginRequest(event)
    {
        event.preventDefault();
        const data = {
            "email":event.target.elements.email.value,
            "password":event.target.elements.password.value
        }

        // console.dir(data);

        const apiRequestUrl = `https://localhost:7227/users/login`;
        
        const res = axios.post(apiRequestUrl, data).then(res=>
        {
            localStorage.setItem('accessToken', res.data.accessToken);
            localStorage.setItem('refreshToken', res.data.refreshToken);
            localStorage.setItem('isAuthenticated', true);

            navigate("/");
        });
    }


    return <div class="row">
    <div class="col-sm-4"></div>
    <form class="m-5 p-5 col-sm-4" onSubmit={sendLoginRequest}>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Email address</label>
            <input type="email" name="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp"/>
            <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
        </div>
        <div class="mb-3">
            <label for="exampleInputPassword1" class="form-label">Password</label>
            <input type="password" name="password" class="form-control" id="exampleInputPassword1"/>
        </div>
        <Link to='/register'>Register</Link>
        <button type="submit" class="btn btn-primary" >Submit</button>
    </form>
    </div>
}

