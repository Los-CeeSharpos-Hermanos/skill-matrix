export interface IAuthUser {
    email: string;
    password: string;
}

export interface IAuthToken {
    accessToken: string;
    expiresIn: string;
    userInfo: IUserInfo;
}

export interface IUserInfo {
    id: string;
    email: string;
    claims: IClaim[];
}

export interface IClaim {
    type: string;
    value: string;
}