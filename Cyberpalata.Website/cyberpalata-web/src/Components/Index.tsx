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
import { TeamCreating } from './../pages/body/profile/TeamCreating';
import { TournamentCreating } from './../pages/body/tournament/TournamentCreating';
import { TournamentTeamRegistration } from './../pages/body/tournament/TournamentTeamRegistration';
import { TournamentNetwork } from './../pages/body/tournament/TournamentNetwork';
import { ActualTournaments } from '../pages/body/tournament/ActualTournaments';
import { TournamentDetailedView } from '../pages/body/tournament/TournamentDetailedView';
import { TeamRegistrationQrCode } from '../pages/body/profile/TeamRegistrationQrCode';
import { UsersTournaments } from '../pages/body/profile/UsersTournaments';
import { ShowQrCode } from '../pages/body/profile/ShowQrCode';
import { CheckTeam } from '../pages/organisation/CheckTeam';
import { SelectWinner } from '../pages/body/tournament/SelectWinner';
import { HashRouter } from 'react-router-dom';
import { HiringTeam } from '../pages/body/Teams/HiringTeam';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css'
import { JoinRequests } from '../pages/body/Teams/JoinRequests';
import { ChatList } from '../pages/body/Teams/Chat/ChatList';
import { Chat } from '../pages/body/Teams/Chat/Chat';

export const Index = () => {

    const[isAuth, setIsAuth] = useState(false);

    return <div>
        <HashRouter basename='/'>
            <Header/>
            <Routes>
                <Route path='/' element={<Home />} />
                <Route path="/gamingRoomTypeChoosing" element = {<GamingRoomTypeChoosing/>}/>
                <Route path="/gamingRooms" element = {<GamingRoomList/>}/>
                <Route path="/gamingRooms/:id/:name" element = {<GamingRoom/>}/> 
                <Route path="/gamesLibrary" element = {<GameLibrary/>}/>          
                <Route path="/login" element = {<LoginComponent/>}/>                
                <Route path="/passwordRecovering" element = {<PasswordRecovering/>}/>                
                <Route path="/passwordReset/:email" element = {<ResetPassword/>}/>                
                <Route path="/logout" element = {<LogoutComponent />}/>                
                <Route path="/register" element = {<RegistrationComponent/>}/>
                <Route path="/profile" element={<ProfileComponent/>}/>
                <Route path="/usersTournaments" element={<UsersTournaments/>}/>
                <Route path="/teamCreating" element={<TeamCreating/>}/>
                <Route path="/booking/:roomId/:roomName/" element={<BookingComponent/>}/>
                <Route path="/emailConfirm/:email/:userId" element={<EmailConfirm/>}/>
                <Route path="/bookingView/:isActual" element={<BookingViewComponent/>}/>
                <Route path="/bookingViewDetail/:id" element={<OneBookingView/>}/>
                <Route path="/checkTeam/:tournamentId/:teamId" element={<CheckTeam/>}/>
                <Route path="/searchRoom" element={<RoomSearch/>}/>
                <Route path="/createTournament" element={<TournamentCreating/>}/>
                <Route path="/showQrCode/:tournamentId/:teamId" element={<ShowQrCode/>}/>
                <Route path="/404" element={<NotFound/>}/>
                <Route path="*" element={<Navigate replace to="/404" />} />
                <Route path="/index" element={<Index/>}></Route>
                <Route path="/joinRequests" element={<JoinRequests/>}></Route>
                <Route path="/hiringTeam" element={<HiringTeam/>}></Route>
                <Route path="/chats" element={<ChatList/>}></Route>
                <Route path="/chats/:chatId" element={<Chat/>}></Route>
                <Route path="/sendTeamJoinRequest" element={<Home/>}></Route>
                <Route path="/registerTeam/:tournamentId" element={<TournamentTeamRegistration/>}></Route>   
                {/* <Route path="/tournamentNetwork" element={<TournamentNetwork/>}></Route> */}
                <Route path="/showActualTournaments" element={<ActualTournaments/>}></Route>
                <Route path="/showTournamentDetailed/:id" element={<TournamentDetailedView/>}></Route>
                <Route path="/selectWinner/:tournamentId/:batleId/:firstTeamName/:firstTeamId/:secondTeamName/:secondTeamId" element={<SelectWinner/>}></Route>
            </Routes>
            <AccessTokenVerify/> 
            <ToastContainer position="bottom-right"
                    autoClose={5000}
                    hideProgressBar={false}
                    newestOnTop={false}
                    closeOnClick
                    rtl={false}
                    pauseOnFocusLoss
                    draggable
                    pauseOnHover
                    theme="light"/>         
        </HashRouter>
    </div>
}