var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { CategoryService } from './category.service';
import { Category } from '../Category';
var CategoryComponent = /** @class */ (function () {
    function CategoryComponent(categoryService) {
        this.categoryService = categoryService;
        this.category = new Category(); // изменяемый товар
        this.tableMode = true; // табличный режим
    }
    CategoryComponent.prototype.ngOnInit = function () {
        this.loadCategories(); // загрузка данных при старте компонента  
    };
    // получаем данные через сервис
    CategoryComponent.prototype.loadCategories = function () {
        var _this = this;
        this.categoryService.getCategories()
            .subscribe(function (data) { return _this.categories = data; });
    };
    // сохранение данных
    CategoryComponent.prototype.save = function () {
        var _this = this;
        if (this.category.categoryId == null) {
            this.categoryService.createCategory(this.category)
                .subscribe(function (data) { return _this.categories.push(data); });
        }
        else {
            this.categoryService.updateCategory(this.category)
                .subscribe(function (data) { return _this.loadCategories(); });
        }
        this.cancel();
    };
    CategoryComponent.prototype.editCategory = function (c) {
        this.category = c;
    };
    CategoryComponent.prototype.cancel = function () {
        this.category = new Category();
        this.tableMode = true;
    };
    CategoryComponent.prototype.delete = function (c) {
        var _this = this;
        this.categoryService.deleteCategory(c.categoryId)
            .subscribe(function (data) { return _this.loadCategories(); });
    };
    CategoryComponent.prototype.add = function () {
        this.cancel();
        this.tableMode = false;
    };
    CategoryComponent = __decorate([
        Component({
            selector: 'app',
            templateUrl: './category.component.html',
            providers: [CategoryService]
        }),
        __metadata("design:paramtypes", [CategoryService])
    ], CategoryComponent);
    return CategoryComponent;
}());
export { CategoryComponent };
//# sourceMappingURL=category.component.js.map