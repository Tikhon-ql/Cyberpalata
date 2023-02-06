import {Link} from "react-router-dom";

export const NotFound = ()=>{
    return <div className="d-flex align-items-center justify-content-center pt-4" style={{"height":"100vh","width":"100vw","display":"flex","alignItems":"center","justifyContent":"center"}}>
        <div className="p-5 m-2 bg-info text-white shadow rounded-2 d-flex align-items-center justify-content-center">
            <h1 className="text-centre">404 - Not Found!</h1>
            <Link to="/" className="btn btn-outline-dark btn-sm text-white w-50 m-1">Go Home</Link>
        </div>
    </div>
}