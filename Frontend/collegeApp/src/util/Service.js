const API_BASE = "http://localhost:5229";

export const menus = [{
        id: 1,
        name: "Home"
    },
    {
        id: 2,
        name: "About"
    },
    {
        id: 3,
        name: "Department"
    },
    {
        id: 4,
        name: "Contant Us"
    }
]

export const about = {
    name: "Learn By Doing",
    about: "Learn By Doing is not your traditional school — it's a place where curiosity leads and hands-on experience drives learning. We believe that the best way to learn is by rolling up your sleeves, making mistakes, and building real things. Founded in 2022, our unique model emphasizes real-world problem-solving, creativity, and collaboration over rote memorization and lectures.",
    mission: "Empower students to become confident problem-solvers through project-based learning that blends technology, creativity, and curiosity.",
    photoUrl: "https://example.com/images/school-campus.jpg", // Replace with real URL or asset path
    address: "42 Maker Street, Innovation District, Bengaluru, Karnataka 560001, India",
    phoneNumber: "+91 98765 43210",
    email: "contact@learnbydoing.school"
};

export const getToppers = async () => {
    try {
        const response = await fetch(`${API_BASE}/topFive`);
        if (!response.ok) throw new Error("Failed to fetch!");
        const data = await response.json();
        console.log(data);
        return data;
    } catch (ex) {
        console.error("Error occured");
        return [];
    }
}

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
        if (!response.ok) throw new Error("Failed to save1");
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