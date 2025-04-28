import React, { useEffect, useState } from 'react'
import StaffList from './StaffList';
import { getDepartments } from '../../util/DepartmentServices'
import { saveStaff } from '../../util/StaffService';

function Staff() {
    const [file, setFile] = useState();
    const [departmentOptions, setDepartmentOptions] = useState([]);
    const [isLoading, setIsLoading] = useState(false);

    const saveHandler = async function (event) {
        event.preventDefault();

        const formData = new FormData(event.target);
        const data = Object.fromEntries(formData.entries());

        if (data.name === '') {
            console.log("empty name");
            return;
        }

        console.log("http request ... ", data);
        const payload = {
            "name": data.name,
            "dob": data.dob,
            "departmentId": data['department-name'],
            "position": parseInt(data.role,10),
        }

        await saveStaff(payload);
        console.log("after saving staff");
    }

    function handleChange(event) {
        console.log(event.target.files);
        setFile(URL.createObjectURL(event.target.files[0]));
    }

    useEffect(() => {
        getDepartments().then((data) => setDepartmentOptions(data))
            .finally(() => setIsLoading(true));
        // setDepartmentOptions(getDepartments());
        console.log(departmentOptions, " are the departments");

    }, []);

    console.log("departments are : ", departmentOptions);

    return (
        <>
            <div className="container bg-info p-2  mb-4">
                <h1 className='p-1'>Add Staff</h1>
                <form onSubmit={saveHandler}>
                    <p>
                        <label htmlFor='name'>Name</label>
                        <input id="name" type="text" name="name" required />
                    </p>
                    <p>
                        <label htmlFor='dob'>Date of Birth</label>
                        <input id="dob" type="date" name="dob" required />
                    </p>
                    <p>
                        <label htmlFor='departmentName'>Department Name</label>
                        <select id="department-name" name="department-name" required>
                            {departmentOptions.map((department) => (
                                <option value={department.id} key={department.id}>{department.name}</option>
                            ))}
                        </select>
                    </p>
                    <p>
                        <label htmlFor="position">Position</label>
                        <select id="role" name="role" required>
                            <option value="2">Principal</option>
                            <option value="1">Teacher</option>
                            <option value="0">Other Staff</option>
                        </select>
                    </p>
                    <p>
                        <label htmlFor="image">Add your photo</label>
                        <input type="file" onChange={handleChange} />
                        <img className="w-25 p-3" src={file} />
                    </p>

                    {/* // photo upload and save in backend
                    // and save url */}
                    <button type="submit" className=''>Submit</button>                </form>
            </div >
            <StaffList />
        </>
    )
}

export default Staff
