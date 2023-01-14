import axios from "axios"
import jwtDecode from "jwt-decode";
import { useNavigate } from "react-router-dom";
import { useState } from "react";

export const ProfileComponent = () => {

    let navigate = useNavigate();
    let accessToken = localStorage.getItem('accessToken');
    let [name, setName] = useState("");
    let [surname, setSurname] = useState("");
    let [email, setEmail] = useState("");
    let [phone, setPhone] = useState("");
    if(accessToken != null)
    {
        const apiRequestUrl = `https://localhost:7227/users/id` + '?id=' + jwtDecode(accessToken).sid;

        axios.get(apiRequestUrl).then(res =>{
            console.dir(res);
            setName(res.data.username);
            setSurname(res.data.surname);
            setEmail(res.data.email);
            setPhone(res.data.phone);
        });
    }
    else
        navigate('/');
    return <>
            <div  className="centre-block">
                <h1>{name}</h1>
                <h2>Surname : {surname}</h2>
                <h2>Email : {email}</h2>
                <h2>Phone : {phone}</h2>
            </div>
        </>
}
