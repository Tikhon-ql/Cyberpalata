import { formToJSON } from "axios";
import {Link} from "react-router-dom"

export const GamingRoomTypeChoosing = ()=> {
  return (
    <div className="pt-5" style={{"height":"100vh","width":"100vw","display":"flex","alignItems":"center","justifyContent":"center"}}>
    <div>
    <h2>What type of gaming room you want to?</h2>
    <div style={{'display': 'flex'}}>
        <Link to="/gamingRooms/vip" className="btn btn-outline-dark w-25 m-5">Vip</Link>
        <Link to="/gamingRooms/common" className="btn btn-outline-dark ml-3 w-25 h-25 m-5">Common</Link>
    </div>
    </div>
</div>
  );
}
// 