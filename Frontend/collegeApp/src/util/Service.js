export const API_BASE = "http://localhost:5229";

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

export const admin_menus = [{
    id: 1,
    name: "Department"
},
{
    id: 2,
    name: "Staff"
},
{
    id: 3,
    name: "Student"
},
{
    id: 4,
    name: "Applicant"
}
]

export const staffList = [
    {
      id: 1,
      name: "Dr. Jane Smith",
      dob: "1980-05-15",
      departmentId: 2,
      position: "Professor",
      photoUrl: "https://randomuser.me/api/portraits/women/44.jpg"
    },
    {
      id: 2,
      name: "Mr. John Doe",
      dob: "1975-08-22",
      departmentId: 1,
      position: "Lecturer",
      photoUrl: "https://randomuser.me/api/portraits/men/45.jpg"
    },
    {
      id: 3,
      name: "Ms. Emily Johnson",
      dob: "1990-11-02",
      departmentId: 3,
      position: "Assistant",
      photoUrl: "https://randomuser.me/api/portraits/women/46.jpg"
    },
    {
      id: 4,
      name: "Dr. Robert Brown",
      dob: "1983-04-09",
      departmentId: 4,
      position: "Professor",
      photoUrl: "https://randomuser.me/api/portraits/men/47.jpg"
    },
    {
      id: 5,
      name: "Mrs. Olivia Davis",
      dob: "1988-12-18",
      departmentId: 2,
      position: "Lecturer",
      photoUrl: "https://randomuser.me/api/portraits/women/48.jpg"
    }
  ];
  
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





