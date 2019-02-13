import { ProductModel } from "./models/product-model";
import { OrderModel } from "./models/order-model";

export class ProductSelectMessage {
  selectedProduct: ProductModel;
  order: OrderModel;
}

export class OrderCreateMessage {
  order: OrderModel
}
