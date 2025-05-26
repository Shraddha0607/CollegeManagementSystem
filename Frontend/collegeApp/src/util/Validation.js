const alphaRegex = /^[A-Za-z\s]+$/ ;
const aadharRegex = /^[2-9]{1}[0-9]{11}$/ ;

export function isAlphaOnly(value) {
    return alphaRegex.test(value);
}

export function isValidAge(value) {
    const today = new Date();
    const dob = new Date(value);

    let age = today.getFullYear() - dob.getFullYear();
    const monthDifference = today.getMonth() - dob.getMonth();

    if(monthDifference < 0 || (monthDifference === 0 && today.getDate() < dob.getDate() )){
        age--;
    }

    return age >= 18;
}

export function isValidAadhaar(value) {
    return aadharRegex.test(value);
}