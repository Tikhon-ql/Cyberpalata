import './../../Components/Index.css';
import {Link} from 'react-router-dom'
import axios, {AxiosError} from "axios";
import { LoginComponent } from './Identity/LoginComponent';
import { Logo } from './LogoComponent';
import { AuthVerify } from '../../Components/AuthVerify';
import jwtDecode from 'jwt-decode';
// import { Logout } from './Identity/Logout';
import { useNavigate } from 'react-router-dom';
import { LogoutComponent } from './Identity/LogoutComponent';

export const Header = () => {
    let accessToken = false;
    if(localStorage.getItem('accessToken') != null)
    {
        accessToken = jwtDecode(localStorage.getItem('accessToken'));
    }

    console.dir(accessToken);
    return <>
        <nav id="navbar-example2" class="navbar navbar-light bg-transparent">
            <Link to='/' className='navbar-brand'><Logo/></Link>
            <ul class="nav nav-pills d-flex justify-content-center">
                <li class='nav-item mt-3'>
                    <Link to="/gamesLibrary">Games library</Link>
                </li>
                {(AuthVerify() && accessToken) && <Link to="/profile"><li class='nav-item m-3'>{accessToken.name}</li></Link>}
                <li class="nav-item m-3">
                    {AuthVerify() ? <Link to="/logout">Logout</Link> : <Link to="/login">Login</Link>}
                </li>
            </ul>
        </nav>
   </>
}

