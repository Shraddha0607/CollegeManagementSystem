import React from 'react'
import {staffList} from '../../util/Service'

function StaffList() {
  return (
    <div>
      <h1> Staff List</h1>
      <div>
        <table>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Data of Birth</th>
                    <th>Department Name</th>
                    <th>Position</th>
                    <th>Photo</th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {staffList.map((staff) => (
                    <tr key={staff.id}>
                        <td>{staff.id}</td>
                        <td>{staff.name}</td>
                        <td>{staff.dob}</td>
                        <td>{staff.departmentId}</td>
                        <td>{staff.position}</td>
                        <td>< img src={staff.photoUrl}/></td>
                        <td><button>Edit</button></td>
                        <td><button>Delete</button></td>
                    </tr>
                ))}
            </tbody>
        </table>
      </div>
    </div>
  )
}

export default StaffList
