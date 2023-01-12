import './../../Components/Index.css';
import {Link} from 'react-router-dom'
import axios, {AxiosError} from "axios";
import { LoginComponent } from './Identity/LoginComponent';
import { Logo } from './LogoComponent';

// import {isAcessTokenExpired} from './../../../../isAcessTokenExpired';
// import { LoginLogoutComponent } from './css/LoginLogoutComponent';

export const Header = () => {

    function refreshToken(event)
    {

      
    }

    return <>
     <div>
          <Link to='/'><Logo/></Link>
        </div>
        <div>

            {/* <Link to='/login' class="d-flex flex-row-reverse m-3 p-2"><b>Login</b></Link> */}
            {/* <LoginLogoutComponent/> */}
            <Link to='/login' class="d-flex flex-row-reverse m-3 p-2"><b>Login</b></Link>
            <button onClick={refreshToken}>Refresh</button>
        </div>
    </>
}