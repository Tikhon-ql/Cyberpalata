import './Index.css';
import {BrowserRouter, Routes, Route} from 'react-router-dom'
import {LoungeInfo} from './pages/LoungeInfo'
import {GamingRoomInfo} from './pages/GamingRoomInfo'
import { GameConsoleRoom } from './pages/GameConsoleRoom';
import { Header } from './pages/header/Header';
import Home from './pages/Home'
import { GameLibrary } from './pages/GameLibrary';
import { GameConsoleRooms } from './pages/GameConsoleRooms';
import {LoginComponent} from './pages/header/LoginComponent';
import {RegistrationComponent} from './pages/header/RegistrationComponent';

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
                <Route path="/login" element = {<LoginComponent/>}/>                
                <Route path="/register" element = {<RegistrationComponent/>}/>                
            </Routes>
        </BrowserRouter>
    );
}