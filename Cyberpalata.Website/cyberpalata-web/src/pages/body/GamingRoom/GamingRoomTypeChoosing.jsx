import {Link} from "react-router-dom"

export const GamingRoomTypeChoosing = ()=> {
  return (
    <div className="d-flex align-items-center justify-content-center pt-4" >
      <div className="p-5 m-2 bg-info text-white shadow rounded-2">
          <h2>What type of gaming room you want?</h2>
          <div style={{'display': 'flex'}}>
                <Link to="/gamingRooms/vip" className="btn btn-outline-dark w-50 m-5">Vip</Link>
                <Link to="/gamingRooms/common" className="btn btn-outline-dark ml-3 w-50 h-25 m-5">Common</Link>
          </div>
      </div>
    </div>
  );
}