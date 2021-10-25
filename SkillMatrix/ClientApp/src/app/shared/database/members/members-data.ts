import { IUser, Rating } from "src/app/users/user";


export const users: IUser[] = [
    {
        id: 1,
        surName: "Schmidt",
        firstName: "Marten",
        email: "marten@web.de",
        telephone: "4901512345678",
        department: "Sales",
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
        id: 3,
        surName: "Schmidt",
        firstName: "Marten",
        email: "marten@web.de",
        telephone: "4901512345678",
        department: "Sales",
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
            },
            {
                skillName: 'C#',
                skillCategory: 'Technical Skill',
                rating: Rating.Begginer
            },
            {
                skillName: 'Java',
                skillCategory: 'Technical Skill',
                rating: Rating.Advanced
            },
            {
                skillName: 'Elixir',
                skillCategory: 'Technical Skill',
                rating: Rating.Intermediate
            },
            {
                skillName: 'Js',
                skillCategory: 'Technical Skill',
                rating: Rating.Advanced
            },
            {
                skillName: 'C#',
                skillCategory: 'Technical Skill',
                rating: Rating.Begginer
            },
            {
                skillName: 'Js',
                skillCategory: 'Technical Skill',
                rating: Rating.Advanced
            },
            {
                skillName: 'Phyton',
                skillCategory: 'Technical Skill',
                rating: Rating.Intermediate
            },
            {
                skillName: 'Js',
                skillCategory: 'Technical Skill',
                rating: Rating.Advanced
            },
            {
                skillName: 'C#',
                skillCategory: 'Technical Skill',
                rating: Rating.Begginer
            },
            {
                skillName: 'Js',
                skillCategory: 'Technical Skill',
                rating: Rating.Advanced
            },
        ],
        languages: [
            {
                language: 'German',
                rating: Rating.Advanced
            },
            {
                language: 'English',
                rating: Rating.Begginer
            }
        ],
        imageUrl: "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png"
    },
    {
        id: 2,
        surName: "Schmidt",
        firstName: "Marten",
        email: "marten@web.de",
        telephone: "4901512345678",
        department: "Sales",
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
            }
        ],
        imageUrl: "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png"
    },
    // {
    //     id: 2,
    //     surName: "Meier",
    //     firstName: "Bernd",
    //     email: "Bernd@web.de",
    //     department: "Coding",
    //     team: "B",
    //     skillName: "Python",
    // skillCategory: 'Technical Skill',
    //     language: "english",
    //     imageUrl: "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png";
    // },
    // {
    //     id: 3,
    //     surName: "Seehofer",
    //     firstName: "Lutz",
    //     email: "lutz@web.de",
    //     department: "Finance",
    //     team: "F",
    //     skillName: "Exel",
    // skillCategory: 'Technical Skill',
    //     language: "french",
    //     imageUrl: "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png";
    // },
    // {
    //     id: 4,
    //     surName: "Motz",
    //     firstName: "Fritz",
    //     email: "motz@web.de",
    //     department: "Marketing",
    //     team: "C",
    //     skillName: "Photoshop Illustrator",
    // skillCategory: 'Technical Skill',
    //     language: "hindi",
    //     imageUrl: "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png";
    // },
    // {
    //     id: 5,
    //     surName: "Petry",
    //     firstName: "Frauke",
    //     email: "perty@web.de",
    //     department: "CEO",
    //     team: "V",
    //     skillName: "Corrdinating",
    // skillCategory: 'Technical Skill',
    //     language: "danish",
    //     imageUrl: "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png";
    // },
    // {
    //     id: 6,
    //     surName: "Rauschenbach",
    //     firstName: "Peter",
    //     email: "peter@web.de",
    //     department: "Development",
    //     team: "G",
    //     skillName: "Java C# C C++ BASIC HTML CSS Angular",
    // skillCategory: 'Technical Skill',
    //     language: "spanish",
    //     imageUrl: "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png";
    // },
    // {
    //     id: 7,
    //     surName: "Ramsauer",
    //     firstName: "Hans",
    //     email: "Hans@web.de",
    //     department: "Development",
    //     team: "B",
    //     skillName: "C#",
    // skillCategory: 'Technical Skill',
    //     language: "spanish",
    //     imageUrl: "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png";
    // },
    // {
    //     id: 8,
    //     surName: "Fritzl",
    //     firstName: "Joseph",
    //     email: "fritzl@web.de",
    //     department: "Public Relations",
    //     team: "D",
    //     skillName: "Scrum Master",
    // skillCategory: 'Technical Skill',
    //     language: "italian",
    //     imageUrl: "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png";
    // },
    // {
    //     id: 9,
    //     surName: "Janßen",
    //     firstName: "Stefan",
    //     email: "Stefan@web.de",
    //     department: "Facility",
    //     team: "C",
    //     skillName: "Facility Managemnent",
    // skillCategory: 'Technical Skill',
    //     language: "ungarian",
    //     imageUrl: "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png";
    // }
];
