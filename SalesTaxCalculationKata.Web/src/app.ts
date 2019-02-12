import "bootstrap";
import { ProductService } from "./services/product-service";
import { inject, View } from "aurelia-framework";
import { Product } from "product";

@inject(ProductService)
export class App {
  heading = "Sales Tax Calculator Kata";
  products: Array<Product>;

  constructor(private productService: ProductService) {

  }

  async attached(owningView: View, myView: View) {
    const products = await this.productService.get();

    this.products = [];

    for (let p of products) {
      this.products.push(p as Product);
    }

    debugger;
  }
}
