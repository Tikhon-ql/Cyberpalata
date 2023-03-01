import './../../Components/Index.css';
import {Link} from 'react-router-dom'
import { AuthVerify } from '../../Components/AuthVerify';
import jwtDecode from 'jwt-decode';
import { useNavigate } from 'react-router-dom';
import { LogoutComponent } from './Identity/LogoutComponent';
import { useEffect, useState } from 'react';
import { Modal } from '../../Components/Helpers/Modal/Modal';
import { observer } from 'mobx-react-lite';
import headerRerenderStore from '../../store/headerRerenderStore';
import stateStore from '../../store/stateStore';
import React from 'react';


export const Header = observer((props) => {
    stateStore.state = false;
    headerRerenderStore.state = false;
    let accessToken;
    const [modalActive, setModalActive] = useState(false);

    if(localStorage.getItem('accessToken'))
    {

        accessToken = jwtDecode(localStorage.getItem('accessToken') || "");
        console.dir(accessToken);
    }
    useEffect(()=>{},[headerRerenderStore.state])
    console.dir(accessToken);

    //                                                                 background: -webkit-linear-gradient(90deg, #583544,#463951,#3614e1);/* Chrome 10-25, Safari 5.1-6 */                         ;/* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */                                             

    return <>
        <nav id="headerId" className="navbar navbar-light" style={{background: "linear-gradient(90deg, #583544,#463951,#3614e1)"}}>
            <ul style={{"height":"5vh", "display":"flex","width":"100%","justifyContent":"end","alignItems":"center","listStyle":"none"}}>
                <li className='whiteLink' style={{"color":"white","marginRight":"2vw","marginTop":"2vh","fontSize":"20px"}}>
                        <Link to="/">Home</Link>
                </li>
                {accessToken && accessToken.role === "Admin" &&
                    <li className='whiteLink' style={{"color":"white","marginRight":"2vw","marginTop":"2vh","fontSize":"20px"}}>
                        <Link to="/createTournament">Create tournament</Link>
                    </li>
                }
                {(AuthVerify() && accessToken) && <li style={{"color":"white","marginRight":"2vw","marginTop":"2vh","fontSize":"20px"}}>
                    <Link to="/profile" >Profile</Link>
                </li>}
                {!AuthVerify() ? 
                    <li style={{"color":"white","marginRight":"2vw","marginTop":"2vh","fontSize":"20px"}}>
                        <Link to="/login">Sign In</Link>
                    </li>:
                    <li style={{"color":"white","marginRight":"2vw","marginTop":"2vh","fontSize":"20px"}}>
                        <a onClick={()=>{setModalActive(true)}}>SignOut</a>
                    </li>
                }
                {!AuthVerify() && 
                    <li className='whiteLink' style={{"color":"white","marginRight":"2vw","marginTop":"2vh","fontSize":"20px"}}>
                        <Link to="/register">Register</Link>
                    </li>
                }


                {/* <li className='nav-item text-dark' style={{"marginTop":"2vh"}}>
                    <Link to="/gamesLibrary" className='text-decoration-none text-white h4 m-5 mya' style={{"paddingBottom":"5px"}} onClick={()=>{stateStore.stateChange()}}>Games library</Link>
                </li>
                {accessToken && accessToken.role === "Admin" &&
                <li className='nav-item text-dark' style={{"marginTop":"2vh"}}>
                    <Link to="/createTournament" className='text-decoration-none text-white h4 m-5 mya' style={{"paddingBottom":"5px"}}>Create tournament</Link>
                </li>
                }

                <li className='nav-item text-dark' style={{"marginTop":"2vh"}}>
                    <Link to="/showActualTournaments" className='text-decoration-none text-white h4 m-5 mya' style={{"paddingBottom":"5px"}}>Show actual tournaments</Link>
                </li>
                <li className='nav-item text-dark' style={{"marginTop":"2vh"}}>
                    <Link to="/searchRoom" className='text-decoration-none text-white h4 m-5 mya' style={{"paddingBottom":"5px"}} onClick={()=>{stateStore.stateChange()}}>Search</Link>
                </li>
                {(AuthVerify() && accessToken) && <li className='nav-item text-white' style={{"marginTop":"2vh"}}>
                    <Link to="/bookingView" className='text-decoration-none text-white h4 mya' style={{"paddingBottom":"5px"}}>My orders</Link>
                </li>}
                <li className='nav-item'> <Link to='/' className='animate-charcter mya h1' style={{"marginTop":"0","marginRight":"2vw", "paddingBottom":"5px"}}>CYBERPALATA</Link></li>
                {(AuthVerify() && accessToken) && <li className='nav-item text-white' style={{"marginTop":"2vh"}}>
                    <Link to="/profile" className='text-decoration-none text-white m-3 h4 mya' style={{"paddingBottom":"5px"}}>Profile</Link>
                    </li>}
                <li className="nav-item text-white" style={{"marginTop":"2vh"}}>
                    {AuthVerify() ?

                    <div>
                        <a className="text-decoration-none text-white h4 m-5 mya" style={{"paddingBottom":"5px"}} onClick={()=>{setModalActive(true)}}>Logout</a>
                    </div>

                    : <Link to="/login" className='text-decoration-none text-white h4 mya m-5' style={{"paddingBottom":"5px"}}>Login</Link>}
                </li> */}
            </ul>
            <Modal active={modalActive} setActive={setModalActive}>
                <LogoutComponent setModalActive={setModalActive}/>
            </Modal>
        </nav>
   </>
})