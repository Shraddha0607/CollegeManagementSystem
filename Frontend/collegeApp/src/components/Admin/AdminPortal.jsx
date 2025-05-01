import React from 'react'
import { admin_menus } from '../../util/Service'
import { Link, Outlet } from 'react-router-dom'
import '../../index.css'

function AdminPortal() {
    return (
        <>
            <div id="navbar">
                <ul>
                    {admin_menus.map((menu) => (
                        <li key={menu.id} className='btn btn-secondary mx-1'>
                            <Link to={`/Admin/${menu.name}`} className='text-white'>
                                {menu.name}
                            </Link>

                        </li>
                    ))}
                </ul>

            </div>
            <Outlet />
        </>

    )
}

export default AdminPortal
