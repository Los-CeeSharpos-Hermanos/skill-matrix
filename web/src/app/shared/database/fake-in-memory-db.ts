import { InMemoryDbService } from "angular-in-memory-web-api";
import { languages } from "./languages/languages-data";
import { skills } from "./skills/skills-data";


export class SkillMatrixMockDb implements InMemoryDbService {
    createDb() {
        return { skills, languages };
    }
}