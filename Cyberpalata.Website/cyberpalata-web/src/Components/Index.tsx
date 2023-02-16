import './Index.css';
import {BrowserRouter, Routes, Route, Navigate} from 'react-router-dom';
import { GameConsoleRoom } from '../pages/body/GameConsoleRoom/GameConsoleRoom';
import { Header } from '../pages/header/Header';
import {Home} from '../pages/body/Home';
import GameLibrary from '../pages/body/GameLibrary';
// import { GameConsoleRoomList } from '../pages/body/GameConsoleRoom/GameConsoleRoomList';
import LoginComponent from '../pages/header/Identity/LoginComponent';
import {RegistrationComponent} from '../pages/header/Identity/RegistrationComponent';
import { AccessTokenVerify } from './AccessTokenVerify';
import { LogoutComponent } from '../pages/header/Identity/LogoutComponent';
import { ProfileComponent } from '../pages/body/profile/ProfileComponent';
import { GamingRoomList } from '../pages/body/GamingRoom/GamingRoomList';
import { GamingRoomTypeChoosing } from '../pages/body/GamingRoom/GamingRoomTypeChoosing';
import { BookingComponent } from '../pages/body/Booking/BookingComponent';
import { PasswordRecovering } from '../pages/header/Identity/PasswordRecovering';
import { ResetPassword } from '../pages/header/Identity/ResetPassword';
import { EmailConfirm } from '../pages/header/Identity/EmailConfirm';
import { BookingViewComponent } from '../pages/body/Booking/BookingViewComponent';
import GamingRoom from '../pages/body/GamingRoom/GamingRoom';
import { OneBookingView } from '../pages/body/Booking/OneBookingView';
import { IternalServerError } from './Errors/500/IternalServerError';
import { NotFound } from './Errors/404/NotFound';
import { RoomSearch } from '../pages/header/RoomSearch';
import React, {useState} from 'react';
import { TeamCreating } from 'src/pages/body/profile/TeamCreating';
import { TournamentCreating } from 'src/pages/body/tournament/TournamentCreating';
import { TournamentTeamRegistration } from 'src/pages/body/tournament/TournamentTeamRegistration';
import { TournamentNetwork } from 'src/pages/body/tournament/TournamentNetwork';

export const Index = () => {

    const[isAuth, setIsAuth] = useState(false);

    return <div>
        <BrowserRouter basename='/'>
            <Header/>
            <Routes>
                <Route path='/' element={<Home />} />
                <Route path="/gamingRoomTypeChoosing" element = {<GamingRoomTypeChoosing/>}/>
                <Route path="/gamingRooms/:type" element = {<GamingRoomList/>}/>
                <Route path="/gamingRooms/:id/:name/:type" element = {<GamingRoom/>}/> 
                <Route path="/gamesLibrary" element = {<GameLibrary/>}/>          
                <Route path="/login" element = {<LoginComponent/>}/>                
                <Route path="/passwordRecovering" element = {<PasswordRecovering/>}/>                
                <Route path="/passwordReset/:email" element = {<ResetPassword/>}/>                
                <Route path="/logout" element = {<LogoutComponent />}/>                
                <Route path="/register" element = {<RegistrationComponent/>}/>
                <Route path="/profile" element={<ProfileComponent/>}/>
                <Route path="/teamCreating" element={<TeamCreating/>}/>
                <Route path="/booking/:roomId/:roomName/:roomType" element={<BookingComponent/>}/>
                <Route path="/emailConfirm/:email/:userId" element={<EmailConfirm/>}/>
                <Route path="/bookingView" element={<BookingViewComponent/>}/>
                <Route path="/bookingView/:id" element={<OneBookingView/>}/>
                <Route path="/searchRoom" element={<RoomSearch/>}/>
                <Route path="/createTournament" element={<TournamentCreating/>}/>
                <Route path="/404" element={<NotFound/>}/>
                <Route path="*" element={<Navigate replace to="/404" />} />
                <Route path="/index" element={<Index/>}></Route>
                <Route path="/registerTeam" element={<TournamentTeamRegistration/>}></Route>   
                <Route path="/tournamentNetwork" element={<TournamentNetwork/>}></Route>   
            </Routes>
            <AccessTokenVerify/>          
        </BrowserRouter>
    </div>
}