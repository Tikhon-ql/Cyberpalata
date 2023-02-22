import React,{useState,useEffect} from 'react';
import { useParams } from 'react-router-dom';
import api from '../../../Components/api';
import { QRCodeCanvas } from "qrcode.react";

export const ShowQrCode = () => {

    const {tournamentId} = useParams();
    const {teamId} = useParams();

    return <>
          <QRCodeCanvas
                id="qrCode"
                value={`http://dotnetinternship2022.norwayeast.cloudapp.azure.com:83/checkTeam/${tournamentId}/${teamId}`}
                size={300}
                bgColor={"#00ff00"}
                level={"H"}
            />
    </>
}