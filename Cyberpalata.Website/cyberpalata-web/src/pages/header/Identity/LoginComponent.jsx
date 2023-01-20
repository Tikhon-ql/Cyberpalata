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

        const baseUrl = `http://dotnetinternship2022.norwayeast.cloudapp.azure.com:83`;

        const apiRequestUrl = `${baseUrl}/users/login`;
        
        const res = axios.post(apiRequestUrl, data).then(res=>
        {
            localStorage.setItem('accessToken', res.data.accessToken);
            localStorage.setItem('refreshToken', res.data.refreshToken);
            localStorage.setItem('isAuthenticated', true);

            navigate("/");
        });
    }


    return <div className="row">
    <div className="col-sm-4"></div>
    <form className="m-5 p-5 col-sm-4" onSubmit={sendLoginRequest}>
        <div className="mb-3">
            <label for="exampleInputEmail1" className="form-label">Email address</label>
            <input type="email" name="email" className="form-control" id="exampleInputEmail1" aria-describedby="emailHelp"/>
            <div id="emailHelp" className="form-text">We'll never share your email with anyone else.</div>
        </div>
        <div className="mb-3">
            <label for="exampleInputPassword1" className="form-label">Password</label>
            <input type="password" name="password" className="form-control" id="exampleInputPassword1"/>
        </div>
        <div className="d-flex justify-content-around">
            <button type="submit" className="btn btn-outline-dark mr-3 w-25">Login</button>
            <Link to='/register' className="btn btn-outline-dark ml-3 w-25">Register</Link>
            <Link to='/' className="btn btn-outline-dark ml-3 w-25">Cancel</Link>
        </div>
    </form>
    </div>
}

