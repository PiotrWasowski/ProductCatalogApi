import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable, Subject, switchMap, startWith, tap } from 'rxjs';
import { Product } from "./models/product";

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl = 'http://localhost:7172/api/products';

  private refresh$ = new Subject<void>();

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.refresh$.pipe(
      startWith(void 0),
      switchMap(() => this.http.get<Product[]>(this.apiUrl))
    );
  }

  addProduct(product: Product) {
    return this.http.post(this.apiUrl, product).pipe(
      switchMap(() => {
        this.refresh$.next();
        return this.http.get<Product[]>(this.apiUrl);
      })
    );
  }

  deleteProduct(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`).pipe(
      tap(() => this.refresh$.next())
    );
  }
}
