import "bootstrap";
import { ProductService } from "./services/product-service";
import { OrderService } from "./services/order-service";
import { Order } from "./components/order";
import { OrderItem } from "./components/order-item";
import { ReceiptItem } from "./components/receipt-item";
import { inject, View } from "aurelia-framework";
import { Product } from "./components/product";
import { EventAggregator, Subscription } from "aurelia-event-aggregator";
import { OrderCreateMessage, ProductSelectMessage } from "./messages";
import { OrderItemModel } from "./models/order-model";

@inject(ProductService, OrderService, EventAggregator)
export class App {
  products: Array<Product> = [];
  order: Order;
  orderItems: Array<OrderItem> = [];
  receiptItems: Array<ReceiptItem> = [];

  subscription: Subscription;

  constructor(private productService: ProductService, private orderService, private eventAggregator) {

  }

  async attached() {

    await this.updateProducts();

    this.subscription = this.eventAggregator.subscribe(ProductSelectMessage,
      message => {
          this.updateOrderDetails(message);

        this.orderItems.splice(0);
        this.receiptItems.splice(0);

        const receipt = [];

        for (let oi of message.order.orderItems) {
          this.orderItems.push(oi);
          this.generateReceipt(oi, receipt);
        }

        for (let ri in receipt) {
          this.receiptItems.push(receipt[ri]);
        }
      });

    await this.createOrder();
  }

  async updateProducts() {
    const products = await this.productService.get();

    for (let p of products) {
      this.products.push(p as Product);
     }
  }

  updateOrderDetails(message: ProductSelectMessage) {
    this.order.orderId = message.order.orderId;
    this.order.salesTaxTotal = message.order.salesTaxTotal;
    this.order.grandTotal = message.order.grandTotal;
    this.order.isComplete = message.order.isComplete;
  }

  generateReceipt(orderItem: OrderItemModel, receipt) {
    const productExists = receipt[orderItem.productId] != null;

    if (productExists) {
      receipt[orderItem.productId].numberPurchased += 1;
      receipt[orderItem.productId].lineTotal += orderItem.productPrice + orderItem.salesTax;
    } else {
      const combinedTotal = orderItem.productPrice + orderItem.salesTax;

      receipt[orderItem.productId] = {
        orderItemId: orderItem.orderItemId,
        productId: orderItem.productId,
        productPrice: orderItem.productPrice,
        productDescription: orderItem.productDescription,
        salesTax: orderItem.salesTax,
        numberPurchased: 1,
        combinedTotal: combinedTotal,
        lineTotal: combinedTotal
      } as ReceiptItem;
    }
  }

  detached() {
    this.subscription.dispose();
  }

  async createOrder() {
    const order = await this.orderService.create();
    this.order = order as Order;

    this.eventAggregator.publish(new OrderCreateMessage(order));
  }
}
