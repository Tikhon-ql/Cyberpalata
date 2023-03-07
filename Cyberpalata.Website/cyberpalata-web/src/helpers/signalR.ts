import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import jwt_decode from "jwt-decode";

export const joinRoom = async(user, chat, setConnection, setMessageList)=>{
    try
    {
        let accessToken = localStorage.getItem('accessToken');
        if(accessToken)
        {
            // console.log(accessToken);
            const connection = new HubConnectionBuilder()
            .withUrl("https://localhost:7227/chat",{ accessTokenFactory: () => accessToken })
            .configureLogging(LogLevel.Information)
            .build();
    
            connection.on("ReceiveMessage",(user,message)=>{
                console.log(message);
                
                setMessageList(messages=>[...messages, {user, message}]);
            })
    
            connection.onclose(e=>{
                setConnection();
                setMessageList([]);
            })
    
            await connection.start();
            await connection.invoke("JoinRoom",{user, chat})
            setConnection(connection);
        }   
    }
    catch(e)
    {
        console.log(e);
    }
}

export const sendMessage = async(message, connection)=>{
    try{
        await connection.invoke("SendMessage", message);
    }
    catch(e)
    {
        console.log(e);
    }
}

export const closeConnection = async(connection)=>{
    try
    {
        await connection.stop();
    }
    catch(e)
    {
        console.log(e);
    }
}