import { Product } from "../models/product";
import { Component, OnInit } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Observable } from 'rxjs';
import { ProductService } from "../product.service";
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-product-list',
  standalone: true,
  templateUrl: './product-list.component.html',
  imports: [CommonModule, MatTableModule, MatIconModule, MatButtonModule],
})

export class ProductListComponent implements OnInit {
  products$: Observable<Product[]>;

  constructor(private productService: ProductService) {
    this.products$ = this.productService.getProducts();
  }

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(): void {
     this.products$ = this.productService.getProducts()
      .pipe();
  }

  delete(id: number) {
    this.productService.deleteProduct(id).subscribe();
  }
}
