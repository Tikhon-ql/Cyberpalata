import {Logo} from '../../logoComponent'
import {Link} from 'react-router-dom'

export const Header = () => {
    return  <Link to='/'><Logo/></Link>
}