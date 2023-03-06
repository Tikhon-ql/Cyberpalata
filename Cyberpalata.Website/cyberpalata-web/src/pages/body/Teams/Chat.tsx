import { useEffect, useState, useRef } from "react";
import { useParams } from "react-router-dom"
import { joinRoom, sendMessage } from "../../../helpers/signalR";
import { ChatUser, Message } from "../../../types/types";
import React from "react";

export type MessageList = {
    items: Message[],
    pageSize: number,
    totalItemsCount: number
}

export const Chat = ()=>{
    const {chatId} = useParams();
    const [connection, setConnection] = useState();
    const [user,setUser] = useState<ChatUser>({id:"7f5b1a33-f9d8-4e40-8842-4600056b3dab",name:"Ivan",surname:"Ivanov"});
    const [messageList, setMessageList] = useState<MessageList>({items:[],pageSize:0,totalItemsCount:0});

    const [message, setMessage] = useState<string>();

    const messageRef = useRef() as React.MutableRefObject<HTMLInputElement>;;

    useEffect(()=>{
        joinRoom(user,"b54c91f5-619b-49ab-9d0a-ea171404ea1e",setConnection,messageList);
    },[]);

    return <div className="myConteiner">
        <div className="chatPlaceholder">
            <div className="messageContainer" ref={messageRef}>
                {messageList.items.map((message: Message,index)=>{
                    return <>{(messageRef && messageRef.current) ? 
                            <div>
                                <div key={index}>
                                    <div className="message bg-dark">{message.messageText}</div>
                                    <div className="from-user">{message.username}</div>
                                </div>
                            </div> : 
                            <div key={index}>
                                <div className="message bg-primary">{message.messageText}</div>
                                <div className="from-user">{message.username}</div>
                            </div>} 
                        </>
                })}
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