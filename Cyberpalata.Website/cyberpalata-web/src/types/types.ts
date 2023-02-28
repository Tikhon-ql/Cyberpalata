
export type BookingCollection = {
    id: string,
    roomName: string,
    date: string,
    begining: string,
    hoursCount: number,
    price: number
};

export type Seat = {
    number: number,
    type: {
        id:number,
        name:string
    },
};

export type BookingDetails = {
    roomName: string,
    date: string,
    begining: string,
    hoursCount: number,
    price: number,
    seats:Seat[]
};

export type Pc = {
    type: string,
    name: string,
};

export type Periphery = {
    name: string,
    typeName: string
}

export type RoomItem = {
    id: string,
    name: string
}

export type Team = {
    id:string,
    name: string
}

export type Tournament = {
    id:string,
    name:string
}

export type UserTournament = {
    id:string,
    name:string,
    teamId: string
}


export type TournamentDetailed = {
    name:string,
    date:string,
    // teamsMaxCount: number,
    // rounds:Round[]
}

export type Batle = {
    firstTeamName: string,
    secondTeamName: string,
    firstTeamScore:number,
    secondTeamScore:number,
    date: string,
    time:string
}

export type TeamTournamentViewModel = {
    name:string,
    score:number
}

export type Round = {
    number: number,
    batles: Batle[],
    batlesMaxCount: number,
    date: string,
}

export type QrCode ={
    tournamentId:string,
    teamId:string
}

export type TeamInfo = {
    name: string,
    captainName:string,
    members: string[]   
}

export type TreeData = {
    batleId:string,
    firstTeamId:string,
    secondTeamId: string,
    firstTeamName:string,
    secondTeamName: string,
    name: string,
    roundNumber: number,
    children: TreeData[]
};

