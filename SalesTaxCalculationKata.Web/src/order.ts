import { bindable } from "aurelia-framework";
import { OrderItemModel } from "./models/order-model";

export class Order {
  @bindable orderId: number;
  @bindable orderItems: Array<OrderItemModel>;
  @bindable salesTaxTotal: number;
  @bindable grandTotal: number;
  @bindable isComplete: boolean;
}
