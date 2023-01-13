import './../../Components/Index.css';
import {Link} from 'react-router-dom'
import { GameLibrary } from './../body/GameLibrary';
import { Header } from '../header/Header';
import jwtDecode from 'jwt-decode';

export const Home = () => {
    return <>
        <Header/>
        <div style={{"display":"flex", "justifyContent":"center", "position":"absolute", "top":"30%","left":"30%"}}>
            <div className='loungeLink'>
                <Link to='/lounge'><label className='labelRoomVert'>Lounge</label></Link>
            </div>
            <div style={{"justifyContent":"right"}}>
                <Link to='/gamingRoom'><div className='gamingRoomLink'><label className='labelRoomHoriz'>Gaming room</label></div></Link>
                <Link to='/gameConsoleRoom'><div className='gameConsoleRoomLink'><label className='labelRoomHoriz'>Game console room</label></div></Link>
            </div>
        </div>
    </>
}
