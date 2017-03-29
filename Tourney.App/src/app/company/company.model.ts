export class Company {
    id : string;
    name: string;
    description: string;
}
export class PagedResponse <T> {
    total: number;
    results: Array<T>;
}