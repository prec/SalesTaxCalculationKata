import { ProductModel } from "./models/product-model";
import { OrderModel } from "./models/order-model";

export class ProductSelectMessage {
  constructor(public selectedProduct: ProductModel, public order: OrderModel) { }
}

export class OrderCreateMessage {
    constructor(public order) { }
}
