import { useEffect, useState } from "react"
import { Link } from "react-router-dom";
import api from "../../../../Components/api";
import { Chat } from "../../../../types/types"
import React from "react";

export type Chats = {
    items: Chat[],
    pageSize: number,
    totalItemsCount: number
}

export const ChatList = () => {

    const [chats, setChats] = useState<Chats>({items:[], pageSize:0,totalItemsCount:0});
    const [curPage, setCurPage] = useState<number>(1);

    useEffect(()=>{
        api.get(`/chats/getChatList?page=${curPage}`).then(res=>{
            console.log("Chat list");
            console.dir(res);
            setChats(res.data);
        })
    },[]);

    return <>
    <div className="myConteiner">
                {chats?.items.map((item: Chat,index)=>{
                    return <Link to={`/chats/${item.chatId}`} key={index}>
                            <div className="w-100">
                                <div>{item.otherUserName}</div>
                                <div>{item.otherUserSurname}</div>
                            </div>
                        </Link>
                })}
    </div>
    </>
}