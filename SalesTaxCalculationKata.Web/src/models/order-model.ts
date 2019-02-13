export class OrderModel {
  orderId: number;
  orderItems: Array<OrderItemModel>;
  salesTaxTotal: number;
  grandTotal: number;
  isComplete: boolean;
}

export class OrderItemModel {
  orderItemId: number;
  productId: number;
  productPrice: number;
  productDescription: string;
  salesTax: number;
}
