import React, { useState, useEffect, useRef } from 'react'
import { saveDepartment, getDepartments, deleteDepartment, updateDepartment } from '../../util/DepartmentServices'
import '../../Custom.css'
import Popup from 'reactjs-popup';

function Department() {
    const tempName = useRef();

    const [state, setState] = useState({
        departments: [],
        isLoading: true,
        error: null,
    });

    const updatedName = useRef();

    const enableLoading = () => {
        setState((prevState) => ({
            ...prevState,
            isLoading: true,
            error: null,
        }))
    }

    const saveHandler = async (event) => {

        event.preventDefault();
        const val = tempName.current.value.trim();

        if (!val) {
            setState((prevState) => ({
                ...prevState,
                error: "Name is required!",
            }))
            return;
        }

        const alphaRegex = /^[A-Za-z\s]+$/;
        if (!alphaRegex.test(val)) {
            setState((prevState) => ({
                ...prevState,
                error: "Only letters and spaces are allowed!",
            }));
            return;
        }

        const payload = {
            "name": val
        }

        enableLoading();
        await saveDepartment(payload);
        tempName.current.value = "";
        setInitial();
    }

    const updateHandler = async (event, close) => {
        event.preventDefault();

        const formData = new FormData(event.target);
        const data = Object.fromEntries(formData.entries());
        var val = data.name.trim();

        if (!val) {
            setState((prevState) => ({
                ...prevState,
                error: "Name is required!",
            }))
            return;
        }

        const alphaRegex = /^[A-Za-z\s]+$/;
        if (!alphaRegex.test(val)) {
            setState((prevState) => ({
                ...prevState,
                error: "Only letters and spaces are allowed!",
            }));
            return;
        }

        const payload = {
            "id": parseInt(data.id),
            "name": val
        }

        await updateDepartment(payload);
        setInitial();
        close();
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

            <h1> Department</h1>
            <div className="container bg-info p-2  mb-4">
                <h2 className='p-1'>Add Department</h2>
                <form onSubmit={saveHandler}>
                    <label>Name</label>
                    <input ref={tempName}></input>
                    <div>
                        <button>Submit</button>
                    </div >
                    <div className='control-error'>
                        {state.error && <p>{state.error}</p>}
                    </div>
                </form>

            </div>


            <div className='container bg-info p-5'>
                <h2>Department Details</h2>
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
                                <td>
                                    <Popup trigger={<button>Edit </button>}
                                        modal nested>
                                        {
                                            close => (
                                                <div className='result-modal'>
                                                    <h1>Update Department</h1>
                                                    <form onSubmit={(event) => updateHandler(event, close)}>
                                                        <p>
                                                            <label>Id</label>
                                                            <input name="id" readOnly value={department.id}></input>
                                                        </p>
                                                        <p>
                                                            <label>Name</label>
                                                            <input name="name" defaultValue={department.name}></input>
                                                        </p>
                                                        <div className='control-error'>
                                                            {state.error && <p>{state.error}</p>}
                                                        </div>

                                                        <button type="submit" className='mx-2'>Update</button>
                                                        <button onClick={() => close()}>Close</button>
                                                    </form>
                                                </div>
                                            )}

                                    </Popup>
                                </td>
                                <td><button onClick={() => deleteHandler(department.id)}>Delete</button></td>
                            </tr>
                        ))}
                    </tbody>

                </table>}

            </div>

        </>
    )
}

export default Department
