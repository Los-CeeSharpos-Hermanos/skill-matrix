export interface IAuthUser {
    email: string;
    password: string;
}

export interface IAuthToken {
    accessToken: string;
    expiresIn: string;
    userinfo: IUserInfo;
}

export interface IUserInfo {
    email: string;
    claims: IClaim[];
}

export interface IClaim {
    type: string;
    value: string;
}