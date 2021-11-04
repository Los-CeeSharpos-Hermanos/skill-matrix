import { IUser, Rating } from "src/app/users/user";


export const users: IUser[] = [
    {
        id: 1,
        surName: "Schmidt",
        firstName: "Marten",
        telephone: "4901512345678",
        email: "marten@web.de",
        department: "Sales",
        jobTitle: "Test",
        location: "Leipzig",
        team: "A",
        skills: [
            {
                skillName: 'C#',
                skillCategory: 'Technical Skill',
                rating: Rating.Begginer
            },
            {
                skillName: 'Js',
                skillCategory: 'Technical Skill',
                rating: Rating.Advanced
            }
        ],
        languages: [
            {
                language: 'German',
                rating: Rating.Advanced
            },
            {
                language: 'English',
                rating: Rating.Begginer
            },
            {
                language: 'Portuguese',
                rating: Rating.Intermediate
            }
        ],
        imageUrl: "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png"
    },
    {
        id: 2,
        surName: "Meier",
        firstName: "Bernd",
        telephone: "4901512345678",
        email: "Bernd@web.de",
        department: "Coding",
        jobTitle: "Test",
        location: "Leipzig",
        team: "B",
        skills: [
            {
                skillName: 'C#',
                skillCategory: 'Technical Skill',
                rating: Rating.Advanced
            },
            {
                skillName: 'Typescript',
                skillCategory: 'Technical Skill',
                rating: Rating.Intermediate
            }
        ],
        languages: [
            {
                language: 'German',
                rating: Rating.Advanced
            },
            {
                language: 'English',
                rating: Rating.Begginer
            },
            {
                language: 'Portuguese',
                rating: Rating.Intermediate
            }
        ],
        imageUrl: "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png"
    },
    {
        id: 3,
        surName: "Seehofer",
        firstName: "Lutz",
        telephone: "4901512345678",
        email: "lutz@web.de",
        department: "Finance",
        jobTitle: "Test",
        location: "Leipzig",
        team: "F",
        skills: [
            {
                skillName: 'C#',
                skillCategory: 'Technical Skill',
                rating: Rating.Begginer
            },
            {
                skillName: 'Js',
                skillCategory: 'Technical Skill',
                rating: Rating.Advanced
            }
        ],
        languages: [
            {
                language: 'English',
                rating: Rating.Begginer
            },
            {
                language: 'Portuguese',
                rating: Rating.Intermediate
            }
        ],
        imageUrl: "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png"
    },
    {
        id: 4,
        surName: "Motz",
        firstName: "Fritz",
        telephone: "4901512345678",
        email: "motz@web.de",
        department: "Marketing",
        jobTitle: "Test",
        location: "Leipzig",
        team: "C",
        skills: [
            {
                skillName: 'C#',
                skillCategory: 'Technical Skill',
                rating: Rating.Begginer
            },
            {
                skillName: 'Js',
                skillCategory: 'Technical Skill',
                rating: Rating.Advanced
            }
        ],
        languages: [
            {
                language: 'German',
                rating: Rating.Advanced
            },
            {
                language: 'English',
                rating: Rating.Begginer
            },
            {
                language: 'Spanish',
                rating: Rating.Intermediate
            }
        ],
        imageUrl: "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png"
    },
    {
        id: 5,
        surName: "Petry",
        firstName: "Frauke",
        telephone: "4901512345678",
        email: "perty@web.de",
        department: "CEO",
        jobTitle: "Test",
        location: "Leipzig",
        team: "V",
        skills: [
            {
                skillName: 'C#',
                skillCategory: 'Technical Skill',
                rating: Rating.Begginer
            },
            {
                skillName: 'Js',
                skillCategory: 'Technical Skill',
                rating: Rating.Advanced
            }
        ],
        languages: [
            {
                language: 'German',
                rating: Rating.Advanced
            },
            {
                language: 'English',
                rating: Rating.Begginer
            },
            {
                language: 'Spanish',
                rating: Rating.Intermediate
            }
        ],
        imageUrl: "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png"
    },
    {
        id: 6,
        surName: "Rauschenbach",
        firstName: "Peter",
        telephone: "4901512345678",
        email: "peter@web.de",
        department: "Development",
        jobTitle: "Test",
        location: "Leipzig",
        team: "G",
        skills: [
            {
                skillName: 'C#',
                skillCategory: 'Technical Skill',
                rating: Rating.Begginer
            },
            {
                skillName: 'Js',
                skillCategory: 'Technical Skill',
                rating: Rating.Advanced
            }
        ],
        languages: [
            {
                language: 'German',
                rating: Rating.Advanced
            },
            {
                language: 'English',
                rating: Rating.Begginer
            },
            {
                language: 'Spanish',
                rating: Rating.Intermediate
            }
        ],
        imageUrl: "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png"
    },
    {
        id: 7,
        surName: "Ramsauer",
        firstName: "Hans",
        telephone: "4901512345678",
        email: "Hans@web.de",
        department: "Development",
        jobTitle: "Test",
        location: "Leipzig",
        team: "B",
        skills: [
            {
                skillName: 'C#',
                skillCategory: 'Technical Skill',
                rating: Rating.Begginer
            },
            {
                skillName: 'Js',
                skillCategory: 'Technical Skill',
                rating: Rating.Advanced
            }
        ],
        languages: [
            {
                language: 'German',
                rating: Rating.Advanced
            },
            {
                language: 'English',
                rating: Rating.Begginer
            },
            {
                language: 'Spanish',
                rating: Rating.Advanced
            }
        ],
        imageUrl: "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png"
    },
    {
        id: 8,
        surName: "Fritzl",
        firstName: "Joseph",
        telephone: "4901512345678",
        email: "fritzl@web.de",
        jobTitle: "Test",
        department: "Public Relations",
        location: "Leipzig",
        team: "D",
        skills: [
            {
                skillName: 'C#',
                skillCategory: 'Technical Skill',
                rating: Rating.Begginer
            },
            {
                skillName: 'Js',
                skillCategory: 'Technical Skill',
                rating: Rating.Advanced
            }
        ],
        languages: [
            {
                language: 'German',
                rating: Rating.Advanced
            },
            {
                language: 'English',
                rating: Rating.Begginer
            },
            {
                language: 'Portuguese',
                rating: Rating.Intermediate
            }
        ],
        imageUrl: "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png"
    },
    {
        id: 9,
        surName: "Janßen",
        firstName: "Stefan",
        telephone: "4901512345678",
        email: "Stefan@web.de",
        department: "Facility",
        jobTitle: "Test",
        location: "Leipzig",
        team: "C",
        skills: [
            {
                skillName: 'C#',
                skillCategory: 'Technical Skill',
                rating: Rating.Begginer
            },
            {
                skillName: 'Js',
                skillCategory: 'Technical Skill',
                rating: Rating.Advanced
            }
        ],
        languages: [
            {
                language: 'German',
                rating: Rating.Advanced
            },
            {
                language: 'English',
                rating: Rating.Begginer
            },
            {
                language: 'Portuguese',
                rating: Rating.Intermediate
            }
        ],
        imageUrl: "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png"
    },
    {
        id: 10,
        surName: "Janßen",
        firstName: "Stefan",
        telephone: "4901512345678",
        email: "Stefan@web.de",
        department: "Facility",
        jobTitle: "Test",
        location: "Leipzig",
        team: "C",
        skills: [],
        languages: [],
        imageUrl: ''
    }
];
