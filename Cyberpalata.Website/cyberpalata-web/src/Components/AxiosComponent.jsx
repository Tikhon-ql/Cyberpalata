
import axios from "axios";
import { useNavigate } from "react-router-dom";


// export class AxiosComponent{
//     constructor()
//     {
//         this.baseUrl = `https://localhost:7227`;
//     }
//     static async GetAll(limit, page){
//         const posts = await axios.get('https://jsonplaceholder.typicode.com/posts',{
//             params: {
//             _limit: limit,
//             _page: page
//             }
//             })
//         return posts;
//     }


//     static async SendPostWithoutAuthenticationAndThanReturnToHomePage(apiUrl,requestBody)
//     {
//         const navigate = useNavigate();
//         axios.post(`${this.baseUrl}/${apiUrl}`).then(()=>{});
//     }

// }