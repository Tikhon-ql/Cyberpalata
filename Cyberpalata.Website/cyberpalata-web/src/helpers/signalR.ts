import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";

export const joinRoom = async(user, chat, setConnection, messageList)=>{
    try
    {
        const connection = new HubConnectionBuilder()
        .withUrl("https://localhost:7227/chat")
        .configureLogging(LogLevel.Information)
        .build();

        connection.on("ReceiveMessage",(user,message)=>{
            messageList.items.push({user, message});
        })

        connection.onclose(e=>{
            setConnection();
            messageList = {}; 
        })

        await connection.start();
        await connection.invoke("JoinRoom",{user, chat})
        setConnection(connection);
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