import axios from "axios"
import jwtDecode from "jwt-decode";
import { Link, useNavigate } from "react-router-dom";
import { useState } from "react";
import { Home } from "./Home";

export const ProfileComponent = () => {

    let navigate = useNavigate();
    let accessToken = localStorage.getItem('accessToken');
    let [name, setName] = useState("");
    let [surname, setSurname] = useState("");
    let [email, setEmail] = useState("");
    let [phone, setPhone] = useState("");
    let state = true;
    if(accessToken != null)
    {
        const apiRequestUrl = `https://localhost:7227/users` + '?id=' + jwtDecode(accessToken).sid;

        const config = {
            headers: { Authorization: `Bearer ${accessToken}` }
        };

        axios.get(apiRequestUrl,config).then(res =>{
            console.dir(res);
            setName(res.data.username);
            setSurname(res.data.surname);
            setEmail(res.data.email);
            setPhone(res.data.phone);
        }).catch(console.log, ()=>{state = false});
    }
    else
    {
        console.error("Access is denied");
        state = false;
    }
    return <>{state ?
            <div className="mt-5 p-5" style={{"margin":"auto","width":"50%", "border" : "3px solid black", "padding" : "10px"}}>
                <h1 className="pt-5">User profile</h1>
                <hr></hr>
                <h1>{name}</h1>
                <h2>Surname : {surname}</h2>
                <h2>Email : {email}</h2>
                <h2>Phone : {phone}</h2>
                <Link to='/' className="btn btn-outline-dark btn-sm mt-2">Home page</Link>
            </div> : <Home/>}
        </>
}
