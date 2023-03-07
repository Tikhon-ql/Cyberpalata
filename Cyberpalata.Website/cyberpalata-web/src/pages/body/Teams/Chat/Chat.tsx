import { useEffect, useState, useRef } from "react";
import { useParams } from "react-router-dom"
import { joinRoom, sendMessage } from "../../../../helpers/signalR";
import { ChatUser, Message } from "../../../../types/types";
import React from "react";
import { MessageContainer } from "./MessageContainer";
import jwtDecode from "jwt-decode";

// export type MessageList = {
//     items: Message[],
//     pageSize: number,
//     totalItemsCount: number
// }

export const Chat = ()=>{
    const {chatId} = useParams();
    const [connection, setConnection] = useState();
    const [user,setUser] = useState<ChatUser>({id:"",name:"",surname:""});
    const [messageList, setMessageList] = useState<Message[]>([]);

    const [message, setMessage] = useState<string>();

    const accessToken:any = jwtDecode(localStorage.getItem('accessToken') || "");
    if(accessToken)
    {
        console.dir(accessToken);
        user.id = accessToken.sid;
        user.name = accessToken.email ;
    }

    // const messageRef = useRef() as React.MutableRefObject<HTMLInputElement>;
    //ref={messageRef}

    useEffect(()=>{
        api.get(``);

        joinRoom(user,"b54c91f5-619b-49ab-9d0a-ea171404ea1e",setConnection,setMessageList);
    },[]);

    return <div className="myConteiner">
        <div className="chatPlaceholder">
            <div className="messageContainer">
                <MessageContainer messages={messageList}/>
                {/* {messageList.map((message: Message,index)=>{
                    console.log(message.messageText);
                    return  <div key={index}>
                        <h2>{message.messageText}</h2>
                                {/* <div className="message bg-primary">{message.messageText}</div>
                                <div className="from-user">{message.username}</div> */}
                            {/* </div>
                })} */} 
            </div>
           
            <form onSubmit={(e)=>
                {
                    e.preventDefault();
                    sendMessage(message, connection);
                    setMessage("");
                }}>
                <input  type="text" onChange={(e)=>{setMessage(e.target.value);}} value={message}/>
                <input type="submit" value="Send"/>
            </form>
        </div>
    </div>
}



{/* <>{(messageRef && messageRef.current) ? 
                            <div>
                                <div key={index}>
                                    <div className="message bg-dark">{message.messageText}</div>
                                    <div className="from-user">{message.username}</div>
                                </div>
                            </div> : 
                          } 
                        </> */}