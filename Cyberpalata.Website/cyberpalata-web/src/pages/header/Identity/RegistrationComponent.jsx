import axios from "axios";

export const RegistrationComponent = ()=>{

    function sendRegisterRequest(event)
    {
        const data = {
            "username": event.target.elements.username.value,
            "surname": event.target.elements.surname.value,
            "email":event.target.elements.email.value,
            "phone":event.target.elements.phone.value,
            "password":event.target.elements.password.value,
            "passwordConfirm" : event.target.elements.passwordConfirm.value
        }

        console.dir(data);

        const apiRequestUrl = `https://localhost:7227/users/register`;
        
        const res = axios.post(apiRequestUrl, data).then(res=>
        {
            console.log("anime");
        });
       
    }

    return<div class="row">
    <div class="col-sm-4"></div>
    <form class="m-5 p-5 col-sm-4" onSubmit={sendRegisterRequest}>
        <div class="mb-3">
            <label for="username" class="form-label">Name</label>
            <input type="text" class="form-control" id="username" name="username" aria-describedby="usernameHelp"/>
            {/* <div id="usernameHelp" class="form-text">We'll never share your email with anyone else.</div> */}
        </div>
        <div class="mb-3">
            <label for="surname" class="form-label">Surname</label>
            <input type="text" class="form-control" id="surname" name="surname" aria-describedby="surnameHelp"/>
            {/* <div id="usernameHelp" class="form-text">We'll never share your email with anyone else.</div> */}
        </div>
        <div class="mb-3">
            <label for="email" class="form-label">Email address</label>
            <input type="email" class="form-control" id="email" name="email" aria-describedby="emailHelp"/>
            <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
        </div>
        <div class="mb-3">
            <label for="phone" class="form-label">Phone</label>
            <input type="tel" class="form-control" id="phone" name="phone" aria-describedby="phoneHelp" pattern="^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$"/>
            {/* <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div> */}
        </div>
        <div class="mb-3">
            <label for="password" class="form-label">Password</label>
            <input type="password" class="form-control" name="password" id="password"/>
        </div>
        <div class="mb-3">
            <label for="passwordConfirm" class="form-label">Password confirm</label>
            <input type="password" class="form-control" name="passwordConfirm" id="passwordConfirm"/>
        </div>
        <button type="submit" class="btn btn-primary">Submit</button>
    </form>
    </div>
}