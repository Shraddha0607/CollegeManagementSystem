import { API_BASE } from "./Service";

export const saveStaff = async (payload) => {
    try{
        console.log("in services ", payload);
        const response = await fetch(`${API_BASE}/api/Staff`, {
            method :"POST",
            headers : {
                'Content-Type' : 'application/json'
            },
            body : JSON.stringify(payload)
        });

        if(!response.ok) throw new Error("Failed to save staff!");
        alert("Staff saved successfully.");
    }
    catch(error){
        console.error("Error Occured!");
    }
}