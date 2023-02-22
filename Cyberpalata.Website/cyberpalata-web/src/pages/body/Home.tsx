import './../../Components/Index.css';
import {Link} from 'react-router-dom'
import { useEffect, useState } from 'react';
import { Modal } from '../../Components/Helpers/Modal/Modal';
import { GamingRoomTypeChoosing } from './GamingRoom/GamingRoomTypeChoosing';
import headerRerenderStore from '../../store/headerRerenderStore';
import { observer } from 'mobx-react-lite';
import React from 'react';
import { url } from 'inspector';

// export const Home = () => {

//     const [images, setImages] = useState<string[]>(["first.jpg","second.jpg","third.jpg"]);

//     function liFocus(event:any)
//     {
//         console.dir(event.target.value);
//         (document.getElementById("image") as HTMLDivElement).style.background = url('');
//     }
//     return <>
//         <div style={{"display":"flex","justifyContent":"center","alignItems":"center","width":"100%","height":"100vh"}}>
//             <div style={{"width":"150px"
//             ,"height":"150px","background":"red","position":"absolute","top":"0","left":"0"}}></div>
//             <div style={{"background":"white","height":"80vh","width":"40%","marginTop":"7vh"}}>
//                 <div style={{"background":"red","borderRadius":"125px","width":"250px","height":"250px","marginLeft":"12vw"}}>
//                 </div>
//                 <div style={{"marginTop":"8vh","marginLeft":"1.5vw"}}>
//                     <ul className="customUl">
//                         <Link to="/" onMouseOver={(e)=>{liFocus(e)}}><li value={0}>Lorem, ipsum dolor.</li></Link>
//                         <Link to="/" onMouseOver={(e)=>{liFocus(e)}}><li value={1}>Tenetur, eos laboriosam?</li></Link>
//                         <Link to="/" onMouseOver={(e)=>{liFocus(e)}}><li value={2}>Provident, delectus id.</li></Link>
//                         <Link to="/" onMouseOver={(e)=>{liFocus(e)}}><li>Veniam, minima asperiores.</li></Link>
//                         <Link to="/" onMouseOver={(e)=>{liFocus(e)}}><li>Dolore, illo officiis.</li></Link>
//                         <Link to="/" onMouseOver={(e)=>{liFocus(e)}}><li>Sunt, quos inventore?</li></Link>
//                         <Link to="/" onMouseOver={(e)=>{liFocus(e)}}><li>Sunt, totam quo?</li></Link>
//                         <Link to="/" onMouseOver={(e)=>{liFocus(e)}}><li>Laboriosam, molestiae ut.</li></Link>
//                         <Link to="/" onMouseOver={(e)=>{liFocus(e)}}><li>Cum, enim asperiores!</li></Link>
//                     </ul>
//                 </div>
//             </div>
//             <div id="image" className="leftSide">
//             </div>
//         </div>
//     </>
// }




export const Home = observer(() => {
    useEffect(()=>{},[headerRerenderStore.state]);
    const [modalActive, setModalActive] = useState(false);
    return <>
        <div style={{"display":"flex", "justifyContent":"center", "position":"absolute", "top":"30%","left":"30%"}}>
            <div className='loungeLink'>
                <Link to='/lounge'><label className='labelRoomVert'>Lounge</label></Link>
            </div>
            <div style={{"justifyContent":"right"}}>
                <button onClick={()=>{setModalActive(true)}} style={{"border":"none"}}><div className='gamingRoomLink'><label className='labelRoomHoriz'>Gaming room</label></div></button>
                <button style={{"border":"none"}}><div className='gameConsoleRoomLink'><label className='labelRoomHoriz'>Game console room</label></div></button>
            </div>
            <Modal active={modalActive} setActive={setModalActive}>
                <GamingRoomTypeChoosing/>
            </Modal>
        </div>
    </>
})