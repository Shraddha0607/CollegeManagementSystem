import React from 'react'

const saveHandler = function (event){
  event.preventDefault();
  console.log("Svae handler clicked");
}

function Student() {
  return (
    <div>
      <h1>Add Student</h1>
      <form onSubmit={saveHandler}>
        <p>
          <label htmlFor='name'>Name</label>
          <input id="name" type='text' name="name"></input>
        </p>
        <p>
          <label htmlFor='dob'>Date Of Birth</label>
          <input id="dob" type='date' name="dob"></input>
        </p>
        <p>
          <label htmlFor='course'>Course</label>
          <input id="course" type='text' name="course"></input>
        </p>
        <p>
          <label htmlFor='aadharNo'>Aadhar Number</label>
          <input id="aadharNo" type='text' name="aadharNo"></input>
        </p>
        <p>
          <label htmlFor='email'>Email</label>
          <input id="email" type='email' name="email"></input>
        </p>
        <button type="submit" >Submit</button>
      </form>
    </div>
  )
}

export default Student
