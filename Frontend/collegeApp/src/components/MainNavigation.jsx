import {Link} from 'react-router-dom'

function MainNavigation() {
  return (
      <nav id='navbar' >
        <ul>
            <li className='btn btn-secondary mx-1 '>
                <Link to='/User' className='text-white text-decoration-none'>Home</Link>
                </li>
            <li className='btn btn-secondary mx-1'>
                <Link to='/Admin' className='text-white text-decoration-none'>Admin</Link>
                </li>
        </ul>
      </nav>
  )
}

export default MainNavigation
