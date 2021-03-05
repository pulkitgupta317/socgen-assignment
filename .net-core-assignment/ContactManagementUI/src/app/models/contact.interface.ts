export interface PhoneNumber {
    type: string;
    countryCode: string;
    number: string;
    id: number;
}

export interface Contact {
    firstName: string;
    lastName: string;
    fullName: string;
    phoneNumbers: PhoneNumber[];
    id: number;
}