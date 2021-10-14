export interface Skill {
    id: number;
    skillName: string | null;
    skillCategory: string | null;
}

export interface AddSkill extends Omit<Skill, "id"> {
    id: undefined;
}
