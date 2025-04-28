import React from 'react'
import { admin_menus } from '../../util/Service'
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import Department from './Department';
import Staff from './Staff';
import Student from './Student';
import Applicant from './Applicant';

function AdminPortal() {
    return (
        <Router>
            <div id="navbar">
                <ul>
                    {admin_menus.map((menu) => (
                        <li key={menu.id} className='btn btn-secondary mx-1'>
                            <Link to={`/${menu.name}`}>
                                {menu.name}
                            </Link>

                        </li>
                    ))}
                </ul>

            </div>

            <div className='mt-5'>
                <Routes>
                    <Route path='/Department' element={<Department />} />
                    <Route path='/Staff' element={<Staff />} />
                    <Route path='/Student' element={< Student />} />
                    <Route path='Applicant' element={< Applicant />} />
                </Routes>
            </div>
        </Router>

    )
}

export default AdminPortal
