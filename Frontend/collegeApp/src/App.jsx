import './App.css'
import Home from './components/Home/Home'
import AdminPortal from './components/Admin/AdminPortal'
import { BrowserRouter as Router, Route, Routes, Link, createBrowserRouter, RouterProvider } from 'react-router-dom'
import Department from './components/Admin/Department';
import Student from './components/Admin/Student';
import Applicant from './components/Admin/Applicant';
import Staff from './components/Admin/Staff'
import AuthContextProvider from './store/AuthContext';
import MainNavigation from './components/MainNavigation';
import Error from './pages/Error';
import RootLayout from './components/RootLayout';

const router = createBrowserRouter([
  {
    path: '/',
    element:  <RootLayout />,
    errorElement:  <Error />,
    children : [
      { path : '/User', element: <Home /> },
      { path : '/Admin', element: <AdminPortal /> } 
    ]
  },
  {
    path: '/Admin',
    element : <AdminPortal/> ,
    errorElement : <Error />,
    children: [
      {path: '/Admin/Department', element : <Department /> },
      {path: '/Admin/Staff', element : <Staff /> },
      {path: '/Admin/Student', element: <Student /> },
      { path: '/Admin/Applicant', element: <Applicant /> }
    ]
  }
])

export default function App() {

  return (
    <AuthContextProvider>
      <RouterProvider router={router} />
    </AuthContextProvider>

  )
}
