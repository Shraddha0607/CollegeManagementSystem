import React from 'react'
import { menus } from '../../util/Service'
import '../../index.css'
import '../../assets/react.svg'

function Navbar() {
  return (
    <>
      <div id="navbar">
      <img src="/vite.svg"></img>
        {<ul>
          {menus.map((menu) => (
            <li key={menu.id} className='btn btn-secondary mx-1'>{menu.name}</li>
          ))}

        </ul>}

      </div>
    </>

  );

}

export default Navbar
