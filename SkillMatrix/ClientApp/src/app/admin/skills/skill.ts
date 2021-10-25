export interface Skill {
    id: number;
    skillName: string | null;
    skillCategoryName: string | null;
    skillCategoryId: number | null;
}

export interface AddSkill {
    id: number | undefined;
    skillName: string | null;
    skillCategoryId: number | null;
}
