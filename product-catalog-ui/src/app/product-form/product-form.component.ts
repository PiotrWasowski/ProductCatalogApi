import { Product } from "../models/product";
import { Component } from "@angular/core";
import { ProductService } from "../product.service";
import { FormsModule } from "@angular/forms";


@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  imports: [FormsModule],
})
export class ProductFormComponent {
  product: Product = {
    kod: '',
    nazwa: '',
    cena: 0
  }

  constructor(private productService: ProductService) { }

  submit() {
    this.productService.addProduct(this.product)
      .subscribe(() => {
        alert('Produkt został dodany');
        this.product = { kod: '', nazwa: '', cena: 0 };
    });
  }
}
