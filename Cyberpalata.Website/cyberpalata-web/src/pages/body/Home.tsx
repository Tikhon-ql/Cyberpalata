import './../../Components/Index.css';
import {Link} from 'react-router-dom'
import { useEffect, useState } from 'react';
import { Modal } from '../../Components/Helpers/Modal/Modal';
import { GamingRoomTypeChoosing } from './GamingRoom/GamingRoomTypeChoosing';
import headerRerenderStore from '../../store/headerRerenderStore';
import { observer } from 'mobx-react-lite';
import React from 'react';
import { log } from 'console';

// const img = React.lazy(() => import())

export type Image = {
    path: string,
    index: number
};

export const Home = () => {

    const imgsPathes = [
        "./first.jpg",
        "./second.jpg",
        "./third.jpg",
        "./forth.jpg",
        "./fiveth.jpg"
    ]

    const [curImage, setCurImage] = useState<number>(0);
    const [img, setImg] = useState<string>("./first.jpg");

    
    function liFocus(event:any)
    {   
        if(event.target.value)
        {
            setCurImage(event.target.value as number);
            // console.log();
            setImg(imgsPathes[curImage]);
        }
        // var indexImage: number = event.target.value as number;
        // (document.getElementById("image") as HTMLDivElement).style.backgroundImage = `${images[indexImage].path}`;
    }
    return <>
        <div style={{"display":"flex","justifyContent":"center","alignItems":"center","width":"100%","height":"90vh"}}>
            {/* <div style={{"width":"150px"
            ,"height":"150px","background":"blue","position":"absolute","top":"0","left":"0"}}></div> */}
            <div style={{"height":"100vh","width":"35%"}}>
                <div className='circle' style={{"borderRadius":"125px","width":"250px","height":"250px","marginLeft":"9vw"}}>
                </div>
                <div style={{"marginTop":"8vh","marginLeft":"7vw"}}>
                    <ul className="customUl">
                        <li onMouseOver={(e)=>{
                            liFocus(e)
                        }}  
                        className="dropdown">
                            <button value={0} className="dropbtn">Booking</button>
                            <div className="dropdown-content">
                                <Link to="/gamingRooms">Add</Link>
                                <Link to="/bookingView/actual">Current</Link>
                                <Link to="/bookingView/history">History</Link>
                            </div>
                        </li>                  
                        <li className="dropdown" onMouseOver={(e)=>{liFocus(e)}}>
                            <button className="dropbtn" value={1}>Tournaments</button>
                            <div className="dropdown-content">
                                <Link to="/showActualTournaments">Actual</Link>
                            </div>
                        </li>
                        <Link to="/" onMouseOver={(e)=>{liFocus(e)}}><li value={2}>Game library</li></Link>
                        <Link to="/" onMouseOver={(e)=>{liFocus(e)}}><li value={3}>Contacts</li></Link>
                        <Link to="/" onMouseOver={(e)=>{liFocus(e)}}><li value={4}>Location</li></Link>
                    </ul>
                </div>
            </div>
            <div id="image" className="leftSide"> <img src={require(`${imgsPathes[curImage]}`)} style={{padding:"8vw 8vh",borderRadius:""}}/></div>
        </div>
    </>
}




// export const Home = observer(() => {
//     useEffect(()=>{},[headerRerenderStore.state]);
//     const [modalActive, setModalActive] = useState(false);
//     return <>
//         <div style={{"display":"flex", "justifyContent":"center", "position":"absolute", "top":"30%","left":"30%"}}>
//             <div className='loungeLink'>
//                 <Link to='/lounge'><label className='labelRoomVert'>Lounge</label></Link>
//             </div>
//             <div style={{"justifyContent":"right"}}>
//                 <button onClick={()=>{setModalActive(true)}} style={{"border":"none"}}><div className='gamingRoomLink'><label className='labelRoomHoriz'>Gaming room</label></div></button>
//                 <button style={{"border":"none"}}><div className='gameConsoleRoomLink'><label className='labelRoomHoriz'>Game console room</label></div></button>
//             </div>
//             <Modal active={modalActive} setActive={setModalActive}>
//                 <GamingRoomTypeChoosing/>
//             </Modal>
//         </div>
//     </>
// })