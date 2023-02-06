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
            setCode(res.data);
        });
    },[]);
   
    function sendActivateRequest(event)
    {
        event.preventDefault();
        if(event.target.elements.code.value == code)
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
        else
        {
            alert("Code is incorrect");
        }
    }

    return <div className="d-flex align-items-center justify-content-center">
        <div className="p-5 m-2 bg-info text-white shadow rounded-2">
            <div>On your email we send a message</div>
            <form onSubmit={sendActivateRequest}>
                <div className="mb-3">
                    <label for="exampleInputEmail1" className="form-label"></label>
                    <input type="number" name="code" className="form-control" id="exampleInputEmail1" onChange={(e)=>{e.preventDefault()}} required placeholder="Enter six-digit code here..." aria-describedby="emailHelp"/>
                    <div id="emailHelp" className="form-text text-white">We'll never share your code with anyone else.</div>
                </div>
                <div className="d-flex justify-content-around">
                    <button type="submit" className="btn btn-outline-dark btn-sm text-white w-50 m-1">Confirm</button>
                    <Link to='/' className="btn btn-outline-dark btn-sm text-white w-50 m-1">Cancel</Link>
                </div>
            </form>
        </div>
    </div>
}