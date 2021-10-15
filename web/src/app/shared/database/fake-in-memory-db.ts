import { InMemoryDbService } from "angular-in-memory-web-api";
import { languages } from "./languages/languages-data";
import { categories } from "./skills/categories/categories";
import { users } from "./members/members-data";
import { skills } from "./skills/skills-data";


export class SkillMatrixMockDb implements InMemoryDbService {
    static apiBase: 'api';

    createDb() {
        return { skills, languages, categories, users };
    }
}
