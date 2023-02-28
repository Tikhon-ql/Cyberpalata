import React from "react";
import BarLoader from "react-spinners/BarLoader";

export const Loader = (loading:boolean, size:number) =>
{
    return  <BarLoader
        color={"#123abc"}
        loading={loading}
        />
}