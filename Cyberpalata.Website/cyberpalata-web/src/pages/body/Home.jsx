import './../../Components/Index.css';
import {Link} from 'react-router-dom'
import { GameLibrary } from './../body/GameLibrary';
import { Header } from '../header/Header';
import jwtDecode from 'jwt-decode';
import { useEffect, useState } from 'react';
import { Modal } from '../../Components/Helpers/Modal/Modal';
import { GamingRoomTypeChoosing } from './GamingRoom/GamingRoomTypeChoosing';
import headerRerenderStore from '../../store/headerRerenderStore';
import { observer } from 'mobx-react-lite';

export const Home = observer(() => {
    useEffect(()=>{},[headerRerenderStore.state]);
    const [modalActive, setModalActive] = useState(false);
    return <>
        <div style={{"display":"flex", "justifyContent":"center", "position":"absolute", "top":"30%","left":"30%"}}>
            <div className='loungeLink'>
                <Link to='/lounge'><label className='labelRoomVert'>Lounge</label></Link>
            </div>
            <div style={{"justifyContent":"right"}}>
                <button onClick={()=>{setModalActive(true)}} style={{"border":"none"}}><div className='gamingRoomLink'><label className='labelRoomHoriz'>Gaming room</label></div></button>
                <button to='/gameConsoleRoom' style={{"border":"none"}}><div className='gameConsoleRoomLink'><label className='labelRoomHoriz'>Game console room</label></div></button>
            </div>
            <Modal active={modalActive} setActive={setModalActive}>
                <GamingRoomTypeChoosing/>
            </Modal>
        </div>
    </>
})

{/* <Link to='/gamingRoomTypeChoosing'><div className='gamingRoomLink'><label className='labelRoomHoriz'>Gaming room</label></div></Link>
<Link to='/gameConsoleRoom'><div className='gameConsoleRoomLink'><label className='labelRoomHoriz'>Game console room</label></div></Link> */}