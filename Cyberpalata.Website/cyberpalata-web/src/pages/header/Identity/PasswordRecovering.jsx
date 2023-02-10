import {Link} from "react-router-dom"
import { useNavigate } from "react-router-dom";
import api from "./../../../Components/api";

export const PasswordRecovering = ()=> {

    const navigate = useNavigate();
    function sendRecoveringMessage(event)
    {
        event.preventDefault();
        api.get(`/users/passwordRecovering?email=${event.target.elements.email.value}`).then(()=>{
            navigate("/");
        }).catch(error=>{
            if(error.code && error.code == "ERR_NETWORK")
            {
                navigate('/500');
            }
            if((error.response.status >= 500 && error.response.status <= 599))
            {
                navigate('/500');
            }
        });
    }

    return <div className="d-flex align-items-center justify-content-center">
        <form className="p-5 m-2 bg-info text-white shadow rounded-2" onSubmit={sendRecoveringMessage}>
            <div className="mb-3">
                <label for="exampleInputEmail1" className="form-label">Email address</label>
                <input type="email" name="email" className="form-control" id="exampleInputEmail1" required aria-describedby="emailHelp"/>
                <div id="emailHelp" className="form-text text-white">We'll never share your email with anyone else.</div>
            </div>
            <div className="d-flex justify-content-around">
                <button type="submit" className="btn btn-outline-dark btn-sm text-white w-50 m-1">Send</button>
                <Link to='/' className="btn btn-outline-dark btn-sm text-white w-50 m-1">Cancel</Link>
            </div>
        </form>
    </div>
}