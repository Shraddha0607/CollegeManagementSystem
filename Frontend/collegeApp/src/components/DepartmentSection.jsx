import React from 'react'
import { departmentDetails } from '../Service'


function DepartmentSection() {
  return (
    <div className='container bg-info rounded m-1 p-2 '>
      <h1 className='pb-3'> Departments</h1>
      <ul className='d-flex flex-row justify-content-center'>
        {departmentDetails.map((department) => (
            <li className='card rounded-circle mx-1' key={department.id} >
                {department.name}
            </li>
        ))}
      </ul>
    </div>
  )
}

export default DepartmentSection
