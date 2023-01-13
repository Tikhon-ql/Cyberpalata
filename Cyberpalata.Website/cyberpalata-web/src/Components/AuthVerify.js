
const parseJwt = (token) => {
    try {
      return JSON.parse(atob(token.split('.')[1]));
    } catch (e) {
      return null;
    }
  };

export function AuthVerify()
{
    if(localStorage.getItem('accessToken') != null)
    {
        return true;
    }  
    return false;
}