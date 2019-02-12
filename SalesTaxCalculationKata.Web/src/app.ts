import "bootstrap";
import { ProductService } from "./services/product-service";
import { OrderService } from "./services/order-service";
import { Order } from "./order";
import { inject, View } from "aurelia-framework";
import { Product } from "product";

@inject(ProductService, OrderService)
export class App {
  heading = "Sales Tax Calculator Kata";
  products: Array<Product>;
  order: Order;

  constructor(private productService: ProductService, private orderService) {

  }

  async attached() {
    const products = await this.productService.get();

    this.products = [];

    for (let p of products) {
      this.products.push(p as Product);
    }

    const order = await this.orderService.get(1);

    this.order = order as Order;
  }
}
