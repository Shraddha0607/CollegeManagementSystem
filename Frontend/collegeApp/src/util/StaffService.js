// import { API_BASE } from "./Service";

// export const saveStaff = async (payload) => {
//     try{
//         console.log("in services ", payload);
//         const response = await fetch(`${API_BASE}/api/Staff`, {
//             method :"POST",
//             headers : {
//                 'Content-Type' : 'application/json'
//             },
//             body : JSON.stringify(payload)
//         });

//         if(!response.ok) throw new Error("Failed to save staff!");
//         alert("Staff saved successfully.");
//     }
//     catch(error){
//         console.error("Error Occured!");
//     }
// }

import { API_BASE } from "./Service";

export const saveStaff = async (payload) => {
    try {
        console.log("Sending payload to server:", payload);

        const response = await fetch(`${API_BASE}/api/Staff`, {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(payload)
        });
        console.log("###",response)
        if (!response.ok) {
            const errorText = await response.text();  // better debugging
            throw new Error(`Failed to save staff: ${errorText}`);
        }

        const data = await response.json();  // Optional: parse response data
        alert("Staff saved successfully.");
        return data;  // optional: useful if calling function needs a result
    } catch (error) {
        console.error("Error occurred while saving staff:", error);
        alert("Failed to save staff. Please try again.");
    }
};
