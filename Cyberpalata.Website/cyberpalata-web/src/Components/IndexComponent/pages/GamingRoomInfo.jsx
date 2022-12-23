    
import {Link} from 'react-router-dom'
import './GamingRoomInfo.css'
import './../Index.css'

export const GamingRoomInfo = () => {
    return <div style={{"position" : "absolute", "top":"30%", "left":"41%"}}>
        <Link style={{"textDecoration":"none", "color":"black"}}>
            <div className='bookButton labelText'>
                Book
            </div>
        </Link>
        <ul style={{"listStyle":"none"}}>
            <li>
                <div style={{"display" : "flex"}}>
                    <div style={{"justifyContent":"left"}}>
                        <div className='labelText'>Device</div>
                    </div>
                    <div className='circleButton'>
                        {/* <img src=''></img> */}
                    </div>
                </div>
            </li>
            <hr />
            <li>
                <div style={{"display" : "flex"}}>
                    <div style={{"justifyContent":"left"}}>
                        <div className='labelText'>Peripheries</div>
                    </div>
                    <div className='circleButton'>
                        {/* <img src=''></img> */}
                    </div>
                </div>
            </li>
            <hr />
            <li>
                <div style={{"display" : "flex"}}>
                    <div style={{"justifyContent":"left"}}>
                        <div className='labelText'>Prices</div>
                    </div>
                    <div className='circleButton'>
                        {/* <img src=''></img> */}
                    </div>
                </div>
            </li>
        </ul>
    </div>
}