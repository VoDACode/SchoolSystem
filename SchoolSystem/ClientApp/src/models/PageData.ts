export class PageData<T> {
    constructor(
        public data: T,
        public page: number,
        public totalPages: number,
    ) { }
}