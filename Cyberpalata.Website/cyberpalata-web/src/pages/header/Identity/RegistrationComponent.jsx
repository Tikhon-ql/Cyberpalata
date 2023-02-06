import { useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";
import api from "./../../../Components/api";

export const RegistrationComponent = ()=>{

    let navigate = useNavigate();
    const baseUrl = `https://localhost:7227`;
    function sendRegisterRequest(event)
    {
        event.preventDefault();
        const data = {
            "username": event.target.elements.username.value,
            "surname": event.target.elements.surname.value,
            "email":event.target.elements.email.value,
            "phone":event.target.elements.phone.value,
            "password":event.target.elements.password.value,
            "passwordConfirm" : event.target.elements.passwordConfirm.value
        }
        console.log(data.email);
        // const apiRequestUrl = `${baseUrl}/users/register`;

        api.post(`/users/register`, data).then(()=>
        {
            navigate(`/emailConfirm/${data.email}`);
        });
    }

    return<div className="d-flex align-items-center justify-content-center">
    <form className="p-5 m-2 bg-info text-white shadow rounded-2" onSubmit={sendRegisterRequest}>
        <div className="mb-3">
            <label for="username" className="form-label">Name</label>
            <input type="text" className="form-control" id="username" name="username" required aria-describedby="usernameHelp"/>
            {/* <div id="usernameHelp" className="form-text">We'll never share your email with anyone else.</div> */}
        </div>
        <div className="mb-3">
            <label for="surname" className="form-label">Surname</label>
            <input type="text" className="form-control" id="surname" name="surname" required aria-describedby="surnameHelp"/>
            {/* <div id="usernameHelp" className="form-text">We'll never share your email with anyone else.</div> */}
        </div>
        <div className="mb-3">
            <label for="email" className="form-label">Email address</label>
            <input type="email" className="form-control" id="email" required name="email" aria-describedby="emailHelp"/>
            <div id="emailHelp" className="form-text text-white">We'll never share your email with anyone else.</div>
        </div>
        <div className="mb-3">
            <label for="phone" className="form-label">Phone</label>
            <input type="tel" className="form-control" id="phone" required name="phone" aria-describedby="phoneHelp" pattern="^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$"/>
            {/* <div id="emailHelp" className="form-text">We'll never share your email with anyone else.</div> */}
        </div>
        <div className="mb-3">
            <label for="password" className="form-label">Password</label>
            <input type="password" className="form-control" required name="password" id="password"/>
        </div>
        <div className="mb-3">
            <label for="passwordConfirm" className="form-label">Password confirm</label>
            <input type="password" className="form-control" required name="passwordConfirm" id="passwordConfirm"/>
        </div>
        <div className="d-flex justify-content-around">
            <button type="submit" className="btn btn-outline-dark btn-sm text-white w-50 m-1">Register</button>
            <Link to='/' className="btn btn-outline-dark btn-sm text-white w-50 m-1">Cancel</Link>
        </div>
    </form>
    </div>
}