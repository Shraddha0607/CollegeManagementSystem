import { API_BASE } from "./Service";

export const getDepartments = async () => {
    try {
        const response = await fetch(`${API_BASE}/all`);
        if (!response.ok) throw new Error("Failed to fetch!");
        const data = await response.json();
        return data;
    } catch (ex) {
        console.error("Error occured");
        return [];
    }
}

export const saveDepartment = async (payload) => {
    try {
        const response = await fetch(`${API_BASE}/api/Department`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(payload)
        });
        if (!response.ok) throw new Error("Failed to save");
        alert("Department added successfully.");
    } catch (ex) {
        console.error("Error Occured");
    }
}

export const deleteDepartment = async (id) => {
    try {
        // console.log("in svc " , id);
        const url = `${API_BASE}/id/${id}`;
        const response = await fetch(url, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        });
        if (!response.ok) throw new Error("Failed to delete!");
        const data = await response.json();
        alert("data deleted successfully.");
    } catch (ex) {
        console.error("Error Occured!");
    }
}