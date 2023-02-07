import { Link, useParams } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import api from "./../../../Components/api";

export const ResetPassword = ()=>{

    const {email} = useParams();
    const navigate = useNavigate();

    function passwordReset(event)
    {
        event.preventDefault();
        // const baseUrl = `https://localhost:7227`;
        // const apiUrl = `${baseUrl}/users/passwordRecovering`;
        const requestBody = {
            "email":email,
            "password":event.target.elements.password.value,
            "passwordConfirm": event.target.elements.passwordConfirm.value
        }
        api.put(`/users/passwordRecovering`,requestBody).then(()=>{
            navigate("/");
        }).catch(err=>{
            if(err.response.status >= 500 && err.response.status <= 599)
            {
                navigate("/500");
            }
        });
    }

    return <div className="d-flex align-items-center justify-content-center">
        <form className="p-5 m-2 bg-info text-white shadow rounded-2" method="post" onSubmit={passwordReset}>
            <div className="mb-3">
                    <label for="password" className="form-label">New password</label>
                    <input type="password" className="form-control" name="password" id="password" required/>
                </div>
                <div className="mb-3">
                    <label for="passwordConfirm" className="form-label">New password confirm</label>
                    <input type="password" className="form-control" name="passwordConfirm" id="passwordConfirm" required/>
                </div>
                <div className="d-flex justify-content-around">
                    <button type="submit" className="btn btn-outline-dark btn-sm text-white w-50 m-1">Reset</button>
                    <Link to='/' className="btn btn-outline-dark btn-sm text-white w-50 m-1">Cancel</Link>
            </div>
        </form>   
    </div>
}