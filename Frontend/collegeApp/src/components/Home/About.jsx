import React, { useEffect, useState } from 'react'
import { about } from '../../util/Service'
import { getToppers } from '../../util/Service'


function About() {
    const [toppers, setToppers] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        getToppers().then(data => setToppers(data))
            .finally(() => setLoading(false));
    }, []);

    return (
        <>
            <div class="container bg-info p-2 mt-6 rounded">
                <h1>{about.name}</h1>
                <div><p>{about.about}</p></div>
                <h3>{about.mission}</h3>
            </div>
            {(loading) && <p> Loading toppers...</p>}
            {(!loading) && <div className=" container rounded bg-info mt-1   p-2 bd-highlight ">
                <h1 className='pb-2'> Our Toppers </h1>
                <ul className='d-flex flex-row justify-content-center flex-wrap'>
                    {toppers.map((topper) => (
                        <li key={topper.id} className='card card-inline rounded m-1 '>
                            {/* <img className="card-img-top" src={topper.url} alt="Card image cap"></img> */}
                            <div className='card-body'>
                                <h2 className='card-title'>{topper.name}</h2>
                                <p className='card-text'>{topper.course}</p>
                                <h4 className='card-text'>{topper.percentage}</h4>
                            </div>

                        </li>
                    ))}
                </ul>
            </div>

            }
        </>

    )
}

export default About
