export interface IUser {
  id: number | undefined;
  surName: string;
  firstName: string;
  telephone: string;
  email: string;
  department: string;
  team: string;
  skills: IUserSkill[];
  languages: IUserLanguage[];
  imageUrl: string;
}

export interface IUserHability {
  rating: Rating;
}

export interface IUserSkill extends IUserHability {
  skillName: string,
  skillCategory: string,
}

export interface IUserLanguage extends IUserHability {
  language: string,
}

export enum Rating {
  Begginer = 1,
  Intermediate = 2,
  Advanced = 3
}