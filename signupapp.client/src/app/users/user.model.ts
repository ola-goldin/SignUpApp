export interface User {
    id: number;
    identityNumber:number;
    firstName: string;
    lastName: string;
    email: string;
    gender: string;
    dateOfBirth: Date;
    phoneNumber: string;
}

export const Gender = ['Female', 'Male', 'Other'];
