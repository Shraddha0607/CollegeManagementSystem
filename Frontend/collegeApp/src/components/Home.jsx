import React from 'react'
import Navbar from './Navbar'
import About from './About'
import DepartmentSection from './DepartmentSection'
import ContactUs from './ContactUs'


function Home() {
  return (
    <div>
      <Navbar/>
      <About />
      <DepartmentSection/>
      <ContactUs/>
    </div>
  )
}

export default Home
