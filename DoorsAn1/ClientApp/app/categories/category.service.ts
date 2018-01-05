import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Category } from '../Category';

@Injectable()
export class CategoryService {

    private url = "/api/сategories";

    constructor(private http: HttpClient) {
    }

    getCategories() {
        return this.http.get(this.url);
    }

    createCategory(category: Category) {
        return this.http.post(this.url, category);
    }
    updateCategory(category: Category) {

        return this.http.put(this.url + '/' + category.categoryId, category);
    }
    deleteCategory(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}