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
import { useState } from 'react';


export const Header = (props) => {
    let accessToken = false;
    if(localStorage.getItem('accessToken') != null)
    {
        accessToken = jwtDecode(localStorage.getItem('accessToken'));
    }

    const [state, setState] = useState(0);

  

    console.dir(accessToken);
    return <>
        <nav id="headerId" class="navbar navbar-light bg-transparent">
            <Link to='/' className='navbar-brand'><Logo/></Link>
            <ul class="nav nav-pills d-flex justify-content-center">
                <li className='nav-item m-3 text-dark'>
                    <Link to="/gamesLibrary" className='text-decoration-none text-dark'>Games library</Link>
                </li>
                {(AuthVerify() && accessToken) ? <li className='nav-item mt-3 text-dark'><Link to="/profile" className='text-decoration-none text-dark'>{accessToken.name}</Link></li> : <li class='nav-item m-3'><Link to="/profile" className='text-decoration-none text-dark'>Guest</Link></li>}
                <li className="nav-item m-3 text-dark">
                    {AuthVerify() ? <Link to="/logout" className='text-decoration-none text-dark'>Logout</Link> : <Link to="/login" className='text-decoration-none text-dark'>Login</Link>}
                </li>
            </ul>
        </nav>
   </>
}