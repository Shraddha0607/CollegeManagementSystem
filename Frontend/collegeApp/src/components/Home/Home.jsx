import React, { useState } from 'react'
import About from './About'
import DepartmentSection from './DepartmentSection'
import ContactUs from './ContactUs'
import Navbar from './Navbar'


function Home() {

  return (
    <>
      <div>
        <Navbar />
        <About />
        <DepartmentSection />
        <ContactUs />
      </div>
    </>

  )
}

export default Home
