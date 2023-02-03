import {Link} from "react-router-dom"
import { useNavigate } from "react-router-dom";
import api from "./../../../Components/api";

export const PasswordRecovering = ()=> {

    const navigate = useNavigate();
    function sendRecoveringMessage(event)
    {
        event.preventDefault();
        // const baseUrl = `https://localhost:7227`;
        // const apiUrl = `${baseUrl}/users/passwordRecovering?email=${event.target.elements.email.value}`;
        api.get(`/users/passwordRecovering?email=${event.target.elements.email.value}`).then(()=>{
            navigate("/");
        }).catch(console.log);
    }

    return <div className="row">
    <div className="col-sm-4"></div>
        <form className="m-5 p-5 col-sm-4" onSubmit={sendRecoveringMessage}>
            <div className="mb-3">
                <label for="exampleInputEmail1" className="form-label">Email address</label>
                <input type="email" name="email" className="form-control" id="exampleInputEmail1" aria-describedby="emailHelp"/>
                <div id="emailHelp" className="form-text">We'll never share your email with anyone else.</div>
            </div>
            <div className="d-flex justify-content-around">
                <button type="submit" className="btn btn-outline-dark mr-3 w-25">Send</button>
                <Link to='/' className="btn btn-outline-dark ml-3 w-25">Cancel</Link>
            </div>
        </form>
    </div>
}