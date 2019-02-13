import { bindable } from "aurelia-framework";

export class ReceiptItem {
  @bindable orderItemId: number;
  @bindable productId: number;
  @bindable productPrice: number;
  @bindable productDescription: string;
  @bindable salesTax: number;
  @bindable numberPurchased: number;
  @bindable lineTotal: number;
}
