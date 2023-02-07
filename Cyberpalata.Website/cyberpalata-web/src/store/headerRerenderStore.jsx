import {observable} from "mobx"

const store = observable({
    state:false,
    stateChange(){
        this.state = !this.state;
    },
});

export default store;