import { bindable } from "aurelia-framework";

export class OrderItem {
  @bindable orderItemId: number;
  @bindable productId: number;
  @bindable productPrice: number;
  @bindable productDescription: string;
  @bindable salesTax: number;
}
