import React, { useEffect, useState } from 'react'
import { getDepartments } from '../../util/DepartmentServices'



function DepartmentSection() {
  const [departments, setDepartments] = useState([]);
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    getDepartments().then((data) => setDepartments(data))
      .finally(() => setIsLoading(true));
      console.log(departments, " are departments");
  }, []);

  return (
    <>
      {!isLoading && <p>Departments are Loading...</p>}
      {isLoading && <div className='container bg-info rounded m-1 p-2 '>
        <h1 className='pb-3'> Departments</h1>
        <ul className='d-flex flex-row justify-content-center flex-wrap'>
          {departments.map((department) => (
            <li className='card rounded m-1' key={department.id} >
              {department.name}
            </li>
          ))}
        </ul>
      </div>}
    </>

  )
}

export default DepartmentSection
