import { Message } from "../../../../types/types"
import React, { useEffect, useRef } from 'react';

export type Props = {
    messages: Message[]
}

export const MessageContainer = ({messages}:Props) => {

    const messageRef = useRef() as React.MutableRefObject<HTMLInputElement>;

    useEffect(()=>{
        if (messageRef && messageRef.current) {
            const { scrollHeight, clientHeight } = messageRef.current;
            messageRef.current.scrollTo({ left: 0, top: scrollHeight - clientHeight, behavior: 'smooth' });
        }
    },[messages])

    return <div ref={messageRef} className="message-container" >
        {messages.map((item:Message,index)=>{
            return <div key={index} className="user-message">
                <div className='message bg-primary'>
                    {item.message}
                </div>
                <div className='from-user'>
                    {item.user}
                </div>
            </div>
        })}
    </div>
}