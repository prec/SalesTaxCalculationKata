import { CategoryModel } from "./models/category-model";
import { OrderService } from "./services/order-service";
import { bindable, inject } from "aurelia-framework";

@inject(OrderService)
export class Product {
  @bindable productId: number;
  @bindable description: string;
  @bindable price: number;
  @bindable categories: Array<CategoryModel>;

  constructor(private orderService) {

  }

  async selectProduct() {
    alert(`${this.description} Selected!`);
  }
}
