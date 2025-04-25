import React, { useState, useEffect, useRef } from 'react'
import { saveDepartment, getDepartments, deleteDepartment } from '../../util/Service'

function DepartmentForm() {
    const tempName = useRef();

    const [state, setState] = useState({
        departments: [],
        isLoading: true,
    });

    const enableLoading = () => {
        setState((prevState) => ({
            ...prevState,
            isLoading: true,
        }))
    }
    const saveHandler = async () => {

        const val = tempName.current.value;
        const payload = {
            "name": val
        }

        enableLoading();
        await saveDepartment(payload);
        setInitial();
    }

    const deleteHandler = async (id) => {
        enableLoading();
        await deleteDepartment(id);
        setInitial();
    }

    const setInitial = () => {

        let deptData = [];
        getDepartments()
            .then((data) => deptData = data)
            .catch((error) => {
                console.error("Error occured!", error);
                deptData = [];
            })
            .finally(() => {
                setState(() => ({
                    departments: deptData,
                    isLoading: false,
                }))
            });
    }

    useEffect(() => {
        setInitial();
    }, []);

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
                {(state.isLoading) && <p>Details are Loading..</p>}
                {(!state.isLoading) && <table className='p-2'>
                    <thead>
                        <tr className='py-2'>
                            <th className='p-1 px-5'>ID</th>
                            <th className='p-1 px-5'>Name</th>
                            <th className='p-1 px-5'></th>
                            <th className='p-1 px-5'></th>
                        </tr>
                    </thead>
                    <tbody>
                        {state.departments.map((department) => (
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
