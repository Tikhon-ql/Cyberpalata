import axios from "axios";
import { useState } from "react";
import { Link,useLocation, useParams } from "react-router-dom";


export const EmailConfirm = ()=>{

    //const {email} = useParams();

    const [code,setCode] = useState(0);
    const baseUrl = `https://localhost:7227`;
    const apiUrl = `${baseUrl}/users/emailConfirm`;
    const {state} = useLocation();
    const {data} = state;

    console.dir(data);

    // let requestBody = {
    //     "email" : email
    // }

    axios.post(apiUrl).then(res=>{
        setCode(res.data.code);
    });

    // function confirmEmail(event)
    // {
    //     event.preventDefault();

    //     if(event.target.elements.code != code)
    //     {
    //         requestBody = {
    //             "result":false,
    //             "email": email
    //         }
    //     }
    //     else
    //     {
    //         requestBody = {
    //             "result":true,
    //             "email": email
    //         }
    //     }
    //     axios.post(apiUrl,requestBody).then(res=>{
    //     }).catch(console);
    // }

    return <>
        <div>On your email we send message</div>
        <form className="m-5 p-5 col-sm-4" onSubmit={()=>{}}>
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