import './Index.css';
import {BrowserRouter, Routes, Route} from 'react-router-dom';
// import {LoungeInfo} from './pages/LoungeInfo'
// import {GamingRoomInfo} from './pages/GamingRoomInfo'
import { GameConsoleRoom } from './../pages/body/GameConsoleRoom/GameConsoleRoom';
import { Header } from './../pages/header/Header';
import {Home} from './../pages/body/Home';
import { GameLibrary } from './../pages/body/GameLibrary';
import { GameConsoleRoomList } from './../pages/body/GameConsoleRoom/GameConsoleRoomList';
import {LoginComponent} from './../pages/header/Identity/LoginComponent';
import {RegistrationComponent} from './../pages/header/Identity/RegistrationComponent';
import { AccessTokenVerify } from './AccessTokenVerify';
import { LogoutComponent } from '../pages/header/Identity/LogoutComponent';
import { ProfileComponent } from '../pages/body/ProfileComponent';

export const Index = () => {
    return (
        <BrowserRouter basename='/'>
          
            <Routes>
                <Route path='/' element={<Home />} />
                {/* <Route path="/lounge" element = {<LoungeInfo/>}/> */}
                {/* <Route path="/gamingRoom" element = {<GamingRoomInfo/>}/> */}
                <Route path="/gameConsoleRoom" element = {<GameConsoleRoomList/>}/>
                <Route path="/gameConsoleRoom/:id" element = {<GameConsoleRoom/>}/>
                <Route path="/gamesLibrary" element = {<GameLibrary/>}/>          
                <Route path="/login" element = {<LoginComponent/>}/>                
                <Route path="/logout" element = {<LogoutComponent/>}/>                
                <Route path="/register" element = {<RegistrationComponent/>}/>
                <Route path="/profile" element={<ProfileComponent/>}/>
            </Routes>
            <AccessTokenVerify/>          
        </BrowserRouter>
    );
}