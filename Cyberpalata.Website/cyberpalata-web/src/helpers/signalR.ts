import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";

export const joinRoom = async(user, chat, setConnection)=>{
    try
    {
        const connection = new HubConnectionBuilder()
        .withUrl("https://localhost:7227/chat")
        .configureLogging(LogLevel.Information)
        .build();

        connection.on("ReceiveMessage",(user,message)=>{
            console.log("message received: ", message);
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