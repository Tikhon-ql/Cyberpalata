
export type Device = {
    type: string,
    name: string
}

export type Periphery = {
    name:string,
    typeName:string
}

export type Price = {
    hours:number,
    cost: number
}


export type GamingRoomInfo = 
{
    devices:Device[],
    peripheries:Periphery[]
    prices:Price[]
}
