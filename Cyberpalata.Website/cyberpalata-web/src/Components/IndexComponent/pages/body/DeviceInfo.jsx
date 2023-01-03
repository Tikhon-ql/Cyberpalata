

export const DeviceInfo = (props) =>{
    if(props.type)
        var res =  `${props.type} - ${props.value}`;
    else
        var res = props.value;
    return <div>
        {props.type} - {props.value}
    </div>
}