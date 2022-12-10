export class Address{
    constructor(
        public country: string, 
        public area: string,
        public region: string,
        public settlement: string,
        public street: string,
        public house: string,
        public flat: number
    ){}
}