import { Component, OnInit } from '@angular/core';
import { CategoryService } from './category.service';
import { Category } from '../Category';

@Component({
    selector: 'category',
    templateUrl: './category.component.html',
    providers: [CategoryService]
})
export class CategoryComponent implements OnInit {

    category: Category = new Category();   // изменяемый товар
    categories: Category[];                // массив товаров
    tableMode: boolean = true;          // табличный режим

    constructor(private categoryService: CategoryService) { }

    ngOnInit() {
        this.loadCategories();    // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadCategories() {
        this.categoryService.getCategories()
            .subscribe((data: Category[]) => this.categories = data);
    }
    // сохранение данных
    save() {
        if (this.category.categoryId == null) {
            this.categoryService.createCategory(this.category)
                .subscribe((data: Category) => this.categories.push(data));
        } else {
            this.categoryService.updateCategory(this.category)
                .subscribe(data => this.loadCategories());
        }
        this.cancel();
    }
    editCategory(c: Category) {
        this.category = c;
    }
    cancel() {
        this.category = new Category();
        this.tableMode = true;
    }
    delete(c: Category) {
        this.categoryService.deleteCategory(c.categoryId)
            .subscribe(data => this.loadCategories());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}