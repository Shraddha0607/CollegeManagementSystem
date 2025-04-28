import './App.css'
import Home from './components/Home/Home'
import AdminPortal from './components/Admin/AdminPortal'
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom'
import Department from './components/Admin/Department';
import Student from './components/Admin/Student';
import Applicant from './components/Admin/Applicant';
import Staff from './components/Admin/Staff'



export default function App() {
  return (
    <Router>
      <div className='mt-3'>
        <p><Link to="/User, /">Home</Link></p>
        <p><Link to="/Admin">Admin</Link></p>
      </div>


      <div>
        <Routes>
          <Route path="/User, /" element={<Home />} />
          <Route path="/Admin" element={<AdminPortal />} >
            <Route path='Department' element={<Department />} />
            <Route path='Staff' element={<Staff />} />
            <Route path='Student' element={< Student />} />
            <Route path='Applicant' element={< Applicant />} />
          </Route>
        </Routes>
      </div>

    </Router>
  )
}
