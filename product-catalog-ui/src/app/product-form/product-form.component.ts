import { Product } from "../models/product";
import { Component } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ProductService } from "../product.service";
import { FormsModule } from "@angular/forms";
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';


@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  imports: [CommonModule, FormsModule, MatFormFieldModule, MatInputModule, MatButtonModule],
})
export class ProductFormComponent {
  product: Product = {
    kod: '',
    nazwa: '',
    cena: 0
  }

  constructor(private productService: ProductService) { }

  submit(form: any) {
    this.productService.addProduct(this.product)
      .subscribe(() => {
        alert('Produkt został dodany');
        this.product = { kod: '', nazwa: '', cena: 0 };
        form.resetForm();
    });
  }
}
