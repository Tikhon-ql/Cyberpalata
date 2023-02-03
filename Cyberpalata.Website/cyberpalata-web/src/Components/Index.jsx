import './Index.css';
import {BrowserRouter, Routes, Route} from 'react-router-dom';
// import {LoungeInfo} from './pages/LoungeInfo'
// import {GamingRoomInfo} from './pages/GamingRoomInfo'
import { GameConsoleRoom } from '../pages/body/GameConsoleRoom/GameConsoleRoom';
import { Header } from '../pages/header/Header';
import {Home} from '../pages/body/Home';
import { GameLibrary } from '../pages/body/GameLibrary';
import { GameConsoleRoomList } from '../pages/body/GameConsoleRoom/GameConsoleRoomList';
import {LoginComponent} from '../pages/header/Identity/LoginComponent';
import {RegistrationComponent} from '../pages/header/Identity/RegistrationComponent';
import { AccessTokenVerify } from './AccessTokenVerify';
import { LogoutComponent } from '../pages/header/Identity/LogoutComponent';
import { ProfileComponent } from '../pages/body/ProfileComponent';
import { GamingRoomList } from '../pages/body/GamingRoom/GamingRoomList';
import { GamingRoomTypeChoosing } from '../pages/body/GamingRoom/GamingRoomTypeChoosing';
import { BookingComponent } from '../pages/body/Booking/BookingComponent';
import { PasswordRecovering } from '../pages/header/Identity/PasswordRecovering';
import { ResetPassword } from '../pages/header/Identity/ResetPassword';
import { EmailConfirm } from '../pages/header/Identity/EmailConfirm';
import { BookingViewComponent } from '../pages/body/Booking/BookingViewComponent';
import GamingRoom from './../pages/body/GamingRoom/GamingRoom'
import { OneBookingView } from '../pages/body/Booking/OneBookingView';

export const Index = () => {
    return (
        <BrowserRouter basename='/'>   
            <Routes>
                <Route path='/' element={<Home />} />
                <Route path="/gameConsoleRoom" element = {<GameConsoleRoomList/>}/>
                <Route path="/gameConsoleRoom/:id/:name" element = {<GameConsoleRoom/>}/>
                <Route path="/gamingRoomTypeChoosing" element = {<GamingRoomTypeChoosing/>}/>
                <Route path="/gamingRooms/:type" element = {<GamingRoomList/>}/>
                <Route path="/gamingRooms/:id/:name/:type" element = {<GamingRoom/>}/> 
                <Route path="/gamesLibrary" element = {<GameLibrary/>}/>          
                <Route path="/login" element = {<LoginComponent/>}/>                
                <Route path="/passwordRecovering" element = {<PasswordRecovering/>}/>                
                <Route path="/passwordReset/:email" element = {<ResetPassword/>}/>                
                <Route path="/logout" element = {<LogoutComponent/>}/>                
                <Route path="/register" element = {<RegistrationComponent/>}/>
                <Route path="/profile" element={<ProfileComponent/>}/>
                <Route path="/booking/:roomId/:roomName/:roomType" element={<BookingComponent/>}/>
                <Route path="/emailConfirm/:email" element={<EmailConfirm/>}/>
                <Route path="/bookingView" element={<BookingViewComponent/>}/>
                <Route path="/bookingView/:id" element={<OneBookingView/>}/>
            </Routes>
            <AccessTokenVerify/>          
        </BrowserRouter>
    );
}