import './App.css'
import Home from './components/Home/Home'
import AdminPortal from './components/Admin/AdminPortal'
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom'



export default function App() {
  return (
    <Router>
      <div className='mt-3'>
        <p><Link to="/User">Home</Link></p>
        <p><Link to="/Admin">Admin</Link></p>
      </div>

      <div>
        <Routes>
          <Route path="/User" element={<Home />} />
          <Route path="/Admin" element={<AdminPortal />} />
        </Routes>
      </div>

    </Router>
  )
}
