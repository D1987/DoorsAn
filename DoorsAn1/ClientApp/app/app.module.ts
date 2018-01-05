import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { CategoryComponent } from './categories/category.component';

import { DataService } from './data.service';
import { CategoryService } from './categories/category.service';

// определение маршрутов
const appRoutes: Routes = [
    { path: 'categories', component: CategoryComponent }   
];


@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
    declarations: [AppComponent, CategoryComponent],
    providers: [DataService, CategoryService],
    bootstrap: [AppComponent]
})
export class AppModule { }