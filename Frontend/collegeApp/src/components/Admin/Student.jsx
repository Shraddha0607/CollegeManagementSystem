import { useActionState } from 'react'
import { isAlphaOnly , isValidAge, isValidAadhaar} from '../../util/Validation';

function saveAction (prevFormState, formData){
  const name = formData.get('name');
  const dob = formData.get('dob');
  const course = formData.get('course');
  const aadharNo = formData.get('aadharNo');
  const email = formData.get('email');

  const errors = [];

  if(!isAlphaOnly(name.trim())){
    console.log("name issue")
    errors.push("Name must contains alphabets only.");
  }

  if(!isValidAge(dob)) {
    errors.push("Age must be equal or greater than 18 years.");
    console.log("age error");
  }

  if(course.trim() === ''){
    errors.push("Course is required.");
  }

  if(!isValidAadhaar(aadharNo.trim())) {
    errors.push("Aadhaar number must be valid.");
  }

  if(errors.length > 0){
    return {
      errors,
      enterValues : {
        name,
        dob,
        course,
        aadharNo,
        email
      }
    }
  }

  return { errors : null};
  console.log("Svae handler clicked ", name, dob, course, aadharNo, email );
}

function Student() {
  const [formState, formAction] = useActionState(saveAction, {errors : null});

  return (
    <div>
      <h1>Add Student</h1>
      <form action={formAction}>
        <p>
          <label htmlFor='name'>Name</label>
          <input id="name" type='text' name="name" required defaultValue={formState.enterValues?.name}></input>
        </p>
        <p>
          <label htmlFor='dob'>Date Of Birth</label>
          <input id="dob" type='date' name="dob" required defaultValue={formState.enterValues?.dob}></input>
        </p>
        <p>
          <label htmlFor='course'>Course</label>
          <input id="course" type='text' name="course" required defaultValue={formState.enterValues?.course}></input>
        </p>
        <p>
          <label htmlFor='aadharNo'>Aadhar Number</label>
          <input id="aadharNo" type='text' name="aadharNo" required defaultValue={formState.enterValues?.aadharNo}></input>
        </p>
        <p>
          <label htmlFor='email'>Email</label>
          <input id="email" type='email' name="email" required defaultValue={formState.enterValues?.email}></input>
        </p>
        {formState.errors && (
          <ul>
            {formState.errors.map((error) => (
              <li key={error}> {error} </li>
            ))}
          </ul>
        )}
        <button type="submit" >Submit</button>
      </form>
    </div>
  )
}

export default Student
