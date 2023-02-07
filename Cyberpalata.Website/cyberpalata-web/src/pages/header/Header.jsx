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
import store from '../../store/headerRerenderStore';
import { observer } from 'mobx-react-lite';



export const Header = observer((props) => {
    store.state = false;
    let accessToken = false;
    const [modalActive, setModalActive] = useState(false);

    if(localStorage.getItem('accessToken') != null)
    {
        accessToken = jwtDecode(localStorage.getItem('accessToken'));
    }
    const [state, setState] = useState(0);
    useEffect(()=>{console.log("Anime")},[store.state])
    console.dir(accessToken);
    return <>
        <nav id="headerId" className="navbar navbar-light bg-dark">
            {/* <Link to='/' className='navbar-brand'><Logo/></Link> */}
            <ul class="nav nav-pills d-flex justify-content-between w-100">
                <li className='nav-item text-dark' style={{"marginTop":"2vh"}}>
                    <Link to="/gamesLibrary" className='text-decoration-none text-white h4 m-5 mya' style={{"paddingBottom":"5px"}}>Games library</Link>
                </li>
                {(AuthVerify() && accessToken) && <li className='nav-item text-white' style={{"marginTop":"2vh"}}>
                    <Link to="/bookingView" className='text-decoration-none text-white h4 mya' style={{"paddingBottom":"5px"}}>My orders</Link>
                </li>}
                <li className='nav-item'> <Link className='animate-charcter mya h1'  style={{"marginTop":"0","marginRight":"2vw", "paddingBottom":"5px"}}>CYBERPALATA</Link></li>
                {(AuthVerify() && accessToken) && <li className='nav-item text-white' style={{"marginTop":"2vh"}}>
                    <Link to="/profile" className='text-decoration-none text-white m-3 h4 mya' style={{"paddingBottom":"5px"}}>Profile</Link>
                    </li>}
                <li className="nav-item text-white" style={{"marginTop":"2vh"}}>
                    {AuthVerify() ? 
                    <div>
                        <a className="text-decoration-none text-white h4 m-5 mya" style={{"paddingBottom":"5px"}} onClick={()=>{setModalActive(true)}}>Logout</a>
                    </div> 
                    : <Link to="/login" className='text-decoration-none text-white h4 mya m-5' style={{"paddingBottom":"5px"}}>Login</Link>}
                </li>
            </ul>
            <Modal active={modalActive} setActive={setModalActive}>
                <LogoutComponent setModalActive={setModalActive}/>
            </Modal>
        </nav>
   </>
})
//<Link to="/logout" className='text-decoration-none text-dark'>Logout</Link>