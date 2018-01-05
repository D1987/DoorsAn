export class Category {
    constructor(
        public categoryId?: number,
        public categoryName?: string,
        public producer?: string,
        public price?: number,
        public description?: string,
        public products?: any[],
        //public image?: byte[]       
    ) { }
}