import { Category } from "./Category";

export class Product {
    constructor(
        public productId?: number,
        public name?: string,
        public producer?: string,
        public price?: number,
        public longDescription?: string,
        public status?: boolean,
        //public image?: byte[],
        public inStock?: number,
        public categoryId?: number,
        public category?: Category,
    ) { }
}