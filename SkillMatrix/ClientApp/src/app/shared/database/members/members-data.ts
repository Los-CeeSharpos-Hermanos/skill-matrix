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
                skill: 'C#',
                rating: Rating.Begginer
            },
            {
                skill: 'Js',
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
    //     skill: "Python",
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
    //     skill: "Exel",
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
    //     skill: "Photoshop Illustrator",
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
    //     skill: "Corrdinating",
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
    //     skill: "Java C# C C++ BASIC HTML CSS Angular",
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
    //     skill: "C#",
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
    //     skill: "Scrum Master",
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
    //     skill: "Facility Managemnent",
    //     language: "ungarian",
    //     imageUrl: "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png";
    // }
];
