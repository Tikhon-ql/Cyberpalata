import React, {useState, useEffect} from "react";
import api from "../../../Components/api";
import { QrCode } from "../../../types/types";


export const TeamRegistrationQrCode = ()=>{

    const [info, setInfo] = useState<QrCode[]>([]);

    useEffect(()=>{
        api.get('/users/getUsersQrCode').then(res=>{
            console.dir(res);
        });
    },[]);
    return <>
    </>
}