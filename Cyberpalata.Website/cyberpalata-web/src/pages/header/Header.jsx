import './../../Components/Index.css';
import {Link} from 'react-router-dom'
import { LoginComponent } from './Identity/LoginComponent';
import { Logo } from './LogoComponent';
import { AuthVerify } from '../../Components/AuthVerify';
import jwtDecode from 'jwt-decode';
// import { Logout } from './Identity/Logout';
import { useNavigate } from 'react-router-dom';
import { LogoutComponent } from './Identity/LogoutComponent';
import { useEffect, useState } from 'react';
import { Modal } from '../../Components/Helpers/Modal/Modal';


export const Header = (props) => {
    let accessToken = false;

    const [modalActive, setModalActive] = useState(false);

    if(localStorage.getItem('accessToken') != null)
    {
        accessToken = jwtDecode(localStorage.getItem('accessToken'));
    }
    const [state, setState] = useState(0);
    useEffect(()=>{setState(1)},[]);
    console.dir(accessToken);
    return <>
        <nav id="headerId" className="navbar navbar-light bg-transparent">
            <Link to='/' className='navbar-brand'><Logo/></Link>
            <ul class="nav nav-pills d-flex justify-content-center">
                <li className='nav-item m-3 text-dark'>
                    <Link to="/gamesLibrary" className='btn btn-outline-dark btn-sm'>Games library</Link>
                </li>
                {(AuthVerify() && accessToken) && <li className='nav-item m-3 text-dark'>
                    <Link to="/bookingView" className='btn btn-outline-dark btn-sm'>My orders</Link>
                </li>}
                {(AuthVerify() && accessToken) && <li className='nav-item mt-3 text-dark'><Link to="/profile" className='btn btn-outline-dark btn-sm'>{accessToken.name}</Link></li>}
                <li className="nav-item m-3 text-dark">
                    {AuthVerify() ? 
                    <div>
                        <button className="btn btn-outline-dark btn-sm" onClick={()=>{setModalActive(true)}} >Logout</button>
                    </div> 
                    : <Link to="/login" className='btn btn-outline-dark btn-sm'>Login</Link>}
                </li>
            </ul>
            <Modal active={modalActive} setActive={setModalActive}>
                <LogoutComponent setModalActive={setModalActive}/>
            </Modal>
        </nav>
   </>
}
//<Link to="/logout" className='text-decoration-none text-dark'>Logout</Link>