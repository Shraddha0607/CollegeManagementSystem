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
    try{
        const response = await fetch(`${API_BASE}/topFive`);
        if(!response.ok) throw new Error("Failed to fetch");
        console.log(await response.json());
        return await response.json();
    }catch(ex){
        console.error("Error occured");
        return [];
    }
}

// export const toppers = [
//     {
//         id: 1,
//         name: "Krishna",
//         departmentName: "Computer Science",
//         percentage: 96
//     },
//     {
//         id: 2,
//         name: "Aarav",
//         departmentName: "Mechanical Engineering",
//         percentage: 94
//     },
//     {
//         id: 3,
//         name: "Ishita",
//         departmentName: "Electrical Engineering",
//         percentage: 95.5
//     },
//     {
//         id: 4,
//         name: "Meera",
//         departmentName: "Biotechnology",
//         percentage: 93.7
//     },
//     {
//         id: 5,
//         name: "Rohan",
//         departmentName: "Information Technology",
//         percentage: 95.2
//     }
// ];


export const departmentDetails = [
    {
        id:"1",
        name:"Commerce",
    },
    {
        id:2,
        name:"Mathematics"
    },
    {
        id:"3",
        name:"Computer Science",
    },
    {
        id:4,
        name:"Biology"
    },

]