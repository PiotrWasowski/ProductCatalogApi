import { Product } from "../models/product";
import { Component } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ProductService } from "../product.service";
import { FormsModule } from "@angular/forms";
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  imports: [CommonModule, FormsModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatSnackBarModule],
})
export class ProductFormComponent {
  product: Product = {
    kod: '',
    nazwa: '',
    cena: 0
  }

  constructor(
    private productService: ProductService,
    private snackBar: MatSnackBar
  ) { }

  submit(form: any) {
    this.productService.addProduct(this.product)
      .subscribe({
        next: () => {
          this.snackBar.open('Dodano produkt', 'OK', { duration: 2000 });
          form.resetForm();
        },
        error: (err) => {
          this.snackBar.open('Błąd walidacji', 'OK');
          console.log(err.error);
        }
      });
  }
}
