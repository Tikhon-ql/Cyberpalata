import './Index.css';
import {Logo} from './logoComponent'
import {BrowserRouter,Routes, Route, Link} from 'react-router-dom'
import {LoungeInfo} from './LoungeInfo'
import {GamingRoomInfo} from './GamingRoomInfo'
import { GameConsoleRoom } from './GameConsoleRoom';

const Index = () =>
{
    return (
        <BrowserRouter>
        
            <Link to='/'><Logo/></Link>
            <div style={{"display":"flex", "justifyContent":"center", "position":"absolute", "top":"30%","left":"30%"}}>
                <div className='loungeLink'>
                    <Link to='/lounge'><label className='labelRoomVert'>Lounge</label></Link>
                </div>
                <div style={{"justifyContent":"right"}}>
                    <Link to='/gamingRoom'><div className='gamingRoomLink'><label className='labelRoomHoriz'>Gaming room</label></div></Link>
                    <Link to='/gameConsoleRoom'><div className='gameConsoleRoomLink'>  <label className='labelRoomHoriz'>Game console room</label></div></Link>
                </div>
            </div>
            <Routes>
                <Route path="/" element = {<Index/>}/>
                <Route path="/lounge" element = {<LoungeInfo/>}/>
                <Route path="/gamingRoom" element = {<GamingRoomInfo/>}/>
                <Route path="/gameConsoleRoom" element = {<GameConsoleRoom/>}/>
            </Routes>
        </BrowserRouter>
    );
}

export {Index};