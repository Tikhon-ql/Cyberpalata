import axios from "axios"
import { Link, useParams } from "react-router-dom";
import { useNavigate } from "react-router-dom";

export const ResetPassword = ()=>{

    const {email} = useParams();
    const navigate = useNavigate();

    function passwordReset(event)
    {
        event.preventDefault();
        const baseUrl = `https://localhost:7227`;
        const apiUrl = `${baseUrl}/users/passwordRecovering`;
        const requestBody = {
            "email":email,
            "password":event.target.elements.password.value,
            "passwordConfirm": event.target.elements.passwordConfirm.value
        }
        axios.post(apiUrl,requestBody).then(()=>{
            navigate("/");
        }).catch(console.log);
    }

    return <>
    <form method="post" onSubmit={passwordReset}>
        <div className="mb-3">
                <label for="password" className="form-label">New password</label>
                <input type="password" className="form-control" name="password" id="password"/>
            </div>
            <div className="mb-3">
                <label for="passwordConfirm" className="form-label">New password confirm</label>
                <input type="password" className="form-control" name="passwordConfirm" id="passwordConfirm"/>
            </div>
            <div className="d-flex justify-content-around">
                <button type="submit" className="btn btn-outline-dark mr-3 w-25">Reset</button>
                <Link to='/' className="btn btn-outline-dark ml-3 w-25">Cancel</Link>
        </div>
    </form>   
    </>
}