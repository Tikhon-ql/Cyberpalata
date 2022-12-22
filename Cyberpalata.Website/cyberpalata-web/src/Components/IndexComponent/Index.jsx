import './Index.css';
import {BrowserRouter, Routes, Route} from 'react-router-dom'
import {LoungeInfo} from './pages/LoungeInfo'
import {GamingRoomInfo} from './pages/GamingRoomInfo'
import { GameConsoleRoom } from './pages/GameConsoleRoom';
import Home from './Home'

export const Index = () => {
    return (
        <BrowserRouter basename='/'>
            <Routes>
                <Route path='/' element={<Home />} />
                <Route path="/lounge" element = {<LoungeInfo/>}/>
                <Route path="/gamingRoom" element = {<GamingRoomInfo/>}/>
                <Route path="/gameConsoleRoom" element = {<GameConsoleRoom/>}/>
            </Routes>
        </BrowserRouter>
    );
}