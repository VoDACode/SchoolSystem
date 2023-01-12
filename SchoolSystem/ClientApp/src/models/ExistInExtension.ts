export class ExistInExtension<T>{
    constructor(
        public existIn: boolean,
        public data: T
    ){}
}