var Product = (function () {
    function Product(productId, name, producer, price, longDescription, status, 
        //public image?: byte[],
        inStock, categoryId) {
        this.productId = productId;
        this.name = name;
        this.producer = producer;
        this.price = price;
        this.longDescription = longDescription;
        this.status = status;
        this.inStock = inStock;
        this.categoryId = categoryId;
    }
    return Product;
}());
export { Product };
//# sourceMappingURL=product.js.map