import React, { useEffect, useState } from 'react'
import Select from 'react-select';
import axios from 'axios';

function Try() {
    const [selectOptions, setSelectOptions] = useState([]);
    const [selectSubOptions, setSelectSubOptions] = useState([]);
    const [selectValue, setSelectedValue] = useState(null);

    useEffect(() => {
        const getOptions = async () => {
            try {
                const res = await axios.get('http://localhost:5229/all');
                console.log("fetched");
                console.log("res ", res);
                const options = res.data.map(user => ({
                    value: user.id,
                    label: user.name
                }));

                setSelectOptions(options);
            }
            catch {
                console.log("error occured");
            }

        }
        getOptions();
    }, []);

    useEffect(() => {
        const getOptions = async () => {
            try {
                const res = await axios.get(`http://localhost:5229/departmentId/${selectValue}`);
                console.log("fetched");
                console.log("res ", res);
                const options = res.data.map(user => ({
                    value: user.id,
                    label: user.name
                }));

                setSelectSubOptions(options);
            }
            catch {
                console.log("error occured");
            }

        }
        getOptions();
    }, [selectValue]);

    const handleChange = (selectOptions) => {
        setSelectedValue(selectOptions.value);
        console.log("Selected : ", selectOptions.value);
    };

    const handleSubChange = (selectSubOptions) => {
        setSelectSubOptions(selectSubOptions);
        console.log("Selected : ", selectSubOptions);
    };

    return (
        <div>
            <p>Department</p>
            <Select options={selectOptions} onChange={handleChange} />
            (selectValue != null) && <>
                <p>Courses</p>
                <Select options={selectSubOptions} onChange={handleSubChange} />
            </>
            {/* <h1>fghjk</h1> */}
        </div>
    )
}

export default Try
