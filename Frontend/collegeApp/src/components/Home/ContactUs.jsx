import React from 'react'
import { about } from '../../util/Service'

function ContactUs() {
  return (
    <div className='container bg-info rounded'>
      <h1>Contact Us</h1>
      <p>{about.address}</p>
      <p>{about.phoneNumber}</p>
      <p>{about.email}</p>

      <div class="copyright p-0 m-0">
        <p>© Copyright {} {about.name}</p>
      </div>
    </div>
  )
}

export default ContactUs
