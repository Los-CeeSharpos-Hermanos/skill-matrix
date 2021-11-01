import { InMemoryDbService } from "angular-in-memory-web-api";
import { categories } from "./skills/categories/categories";


export class SkillMatrixMockDb implements InMemoryDbService {
  static apiBase: 'api/mock';

  createDb() {
    return { categories };
  }
}
