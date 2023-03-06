import { useEffect, useState } from "react";
import { useParams } from "react-router-dom"
import { joinRoom } from "../../../helpers/signalR";
import { ChatUser } from "../../../types/types";


export const Chat = ()=>{
    const {chatId} = useParams();
    const [connection, setConnection] = useState();
    const [user,setUser] = useState<ChatUser>({id:"7f5b1a33-f9d8-4e40-8842-4600056b3dab",name:"Ivan",surname:"Ivanov"});

    useEffect(()=>{
        joinRoom(user,"b54c91f5-619b-49ab-9d0a-ea171404ea1e",setConnection);
    },[]);

    return <div className="myConteiner">
        <div className="chatPlaceholder">
        </div>
    </div>
}