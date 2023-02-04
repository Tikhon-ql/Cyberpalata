import { useEffect, useState } from "react";
import { Link,Navigate,useLocation, useNavigate, useParams } from "react-router-dom";
import api from "./../../../Components/api";

export const EmailConfirm = ()=>{

    const navigate = useNavigate();
    const {email} = useParams();
    //const {state} = useLocation();
    //const {data} = state;
    const [code,setCode] = useState(0);
    // const baseUrl = `https://localhost:7227`;
    // let apiUrl = `${baseUrl}/users/emailConfirm?email=${email}`;
 

    //console.dir(data);

    // let requestBody = {
    //     "email" : email
    // }
    useEffect(()=>{
        api.post(`/users/emailConfirm?email=${email}`).then(res=>{
            setCode(res.data.code);
        });
    },[]);
   
    function sendActivateRequest(event)
    {
        event.preventDefault();
        if(event.target.elements.code != code)
        {
            //apiUrl = `${baseUrl}/users/activate?email=${email}`;
            // const requestBody = {
            //     "username": data.username,
            //     "surname": data.surname,
            //     "email":data.email,
            //     "phone":data.phone,
            //     "password":data.password,
            //     "passwordConfirm" : data.passwordConfirm
            // }
            api.post(`/users/activate?email=${email}`).then(()=>{
                navigate('/');
            })
        }
    }

    return <>   
        <div>On your email we send message</div>
        <form className="m-5 p-5 col-sm-4" onSubmit={sendActivateRequest}>
            <div className="mb-3">
                <label for="exampleInputEmail1" className="form-label">Your code</label>
                <input type="text" name="code" className="form-control" id="exampleInputEmail1" placeholder="Enter code here..." aria-describedby="emailHelp"/>
                <div id="emailHelp" className="form-text">We'll never share your email with anyone else.</div>
            </div>
            <div className="d-flex justify-content-around">
                <button type="submit" className="btn btn-outline-dark mr-3 w-25">Confirm</button>
                <Link to='/' className="btn btn-outline-dark ml-3 w-25">Cancel</Link>
            </div>
        </form>
    </>
}