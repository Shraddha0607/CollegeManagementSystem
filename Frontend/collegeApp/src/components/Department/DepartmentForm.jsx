import React, { useState, useEffect, useRef } from 'react'
import { saveDepartment, getDepartments, deleteDepartment } from '../../util/Service'

function DepartmentForm() {
    const [departments, setDepartments] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const [isChanged, setIsChanged] = useState(false);
    const tempName = useRef();

    const saveHandler = async () => {

        const val = tempName.current.value;
        const payload = {
            "id": 0,
            "name": val
        }
        await saveDepartment(payload);
        setIsChanged(true);
    }

    const deleteHandler = async (id) => {
        await deleteDepartment(id);
        setIsChanged(true);
    }

    useEffect(() => {
        const response = getDepartments().then((data) => setDepartments(data))
            .finally(() => {
                setIsLoading(true);
                setIsChanged(false);
            });
    }, [isChanged]);

    return (

        <>
            <div className="container bg-info p-2  mb-4">
                <h1 className='p-1'>Add Department</h1>
                <p>
                    <label>Name</label>
                    <input ref={tempName}></input>
                </p>
                <button onClick={() => saveHandler()}>Submit</button>
            </div>
            <div className='container bg-info p-5'>
                <h1>Department Details</h1>
                {(!isLoading) && <p>Details are Loading..</p>}
                {(isLoading) && <table className='p-2'>
                    <thead>
                        <tr className='py-2'>
                            <th className='p-1 px-5'>ID</th>
                            <th className='p-1 px-5'>Name</th>
                            <th className='p-1 px-5'></th>
                            <th className='p-1 px-5'></th>
                        </tr>
                    </thead>
                    <tbody>
                        {departments.map((department) => (
                            <tr className='py-2' key={department.id}  >
                                <td>{department.id}</td>
                                <td>{department.name}</td>
                                <td><button>Edit</button></td>
                                <td><button onClick={() => deleteHandler(department.id)}>Delete</button></td>
                            </tr>
                        ))}
                    </tbody>

                </table>}

            </div>
        </>
    )
}

export default DepartmentForm
