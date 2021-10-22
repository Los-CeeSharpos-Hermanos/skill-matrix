import { InMemoryDbService } from "angular-in-memory-web-api";
import { languages } from "./languages/languages-data";
import { users } from "./members/members-data";
import { categories } from "./skills/categories/categories";
import { skills } from "./skills/skills-data";


export class SkillMatrixMockDb implements InMemoryDbService {
  static apiBase: 'api/mock';

  createDb() {
    return { languages, categories, users };
  }
}
