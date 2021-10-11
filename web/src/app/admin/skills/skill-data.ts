import { InMemoryDbService } from "angular-in-memory-web-api";
import { Skill } from "./skill";

export class SkillData implements InMemoryDbService {
    createDb(): { skills: Skill[]; } {
        const skills: Skill[] = [
            {
                id: "5980ae40-3be6-5aff-9354-ae4b8c278355",
                skillName: "C#",
                skillCategory: "Technical Skill"
            },
            {
                id: "ba627820-48c3-5056-82c7-75adb9c56364",
                skillName: "Java",
                skillCategory: "Technical Skill"
            },
            {
                id: "e149994b-6143-5b42-b021-9292be72b843",
                skillName: "Javascript",
                skillCategory: "Technical Skill"
            },
            {
                id: "287390f2-dfda-5332-b15b-05bd5c159ca8",
                skillName: "Python",
                skillCategory: "Technical Skill"
            },
            {
                id: "ffa9189d-94bd-5937-8395-5dd9b947a5a7",
                skillName: "Team Play",
                skillCategory: "Soft Skill"
            },
            {
                id: "ffa9189d-94bd-5937-8395-5dd9b947a5a7",
                skillName: "Speed",
                skillCategory: "Soft Skill"
            }
        ];

        return { skills };
    }
}