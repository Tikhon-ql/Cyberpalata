import './Index.css';
import {BrowserRouter, Routes, Route} from 'react-router-dom'
import {LoungeInfo} from './pages/LoungeInfo'
import {GamingRoomInfo} from './pages/GamingRoomInfo'
import { GameConsoleRoom } from './pages/GameConsoleRoom';
import { Header } from './pages/header/Header';
import Home from './pages/Home'
import { GameLibrary } from './pages/GameLibrary';
import { GameConsoleRooms } from './pages/GameConsoleRooms';

export const Index = () => {
    return (
        <BrowserRouter basename='/'>
            <Header/>
            <Routes>
                <Route path='/' element={<Home />} />
                <Route path="/lounge" element = {<LoungeInfo/>}/>
                <Route path="/gamingRoom" element = {<GamingRoomInfo/>}/>
                <Route path="/gameConsoleRoom" element = {<GameConsoleRooms/>}/>
                <Route path="/gameConsoleRoom/:id" element = {<GameConsoleRoom/>}/>
                <Route path="/gamesLibrary" element = {<GameLibrary/>}/>          
            </Routes>
        </BrowserRouter>
    );
}