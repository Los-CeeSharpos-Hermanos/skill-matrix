import { InMemoryDbService } from "angular-in-memory-web-api";
import { Skill } from "./skill";

export class SkillData implements InMemoryDbService {
    createDb(): { skills: Skill[]; } {
        const skills: Skill[] = [
            {
                id: 1,
                skillName: "C#",
                skillCategory: "Technical Skill"
            },
            {
                id: 2,
                skillName: "Java",
                skillCategory: "Technical Skill"
            },
            {
                id: 3,
                skillName: "Javascript",
                skillCategory: "Technical Skill"
            },
            {
                id: 4,
                skillName: "Python",
                skillCategory: "Technical Skill"
            },
            {
                id: 5,
                skillName: "Team Play",
                skillCategory: "Soft Skill"
            },
            {
                id: 6,
                skillName: "Speed",
                skillCategory: "Soft Skill"
            }
        ];

        return { skills };
    }
}