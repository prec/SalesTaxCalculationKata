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

@inject(ProductService, OrderService, EventAggregator)
export class App {
  products: Array<Product>;
  order: Order;
  orderItems: Array<OrderItem>;
  receiptItems: Array<ReceiptItem>;

  subscription: Subscription;

  constructor(private productService: ProductService, private orderService, private eventAggregator) {

  }

  async attached() {
    const products = await this.productService.get();

    this.products = [];
    this.orderItems = [];
    this.receiptItems = [];

    for (let p of products) {
      this.products.push(p as Product);
    }

    this.subscription = this.eventAggregator.subscribe(ProductSelectMessage,
      message => {
        this.order.orderId = message.order.orderId;
        this.order.salesTaxTotal = message.order.salesTaxTotal;
        this.order.grandTotal = message.order.grandTotal;
        this.order.isComplete = message.order.isComplete;

        this.orderItems.splice(0);
        this.receiptItems.splice(0);

        const receipt = [];

        for (let oi of message.order.orderItems) {
          this.orderItems.push(oi);

          if (receipt[oi.productId] != null) {
            receipt[oi.productId].numberPurchased += 1;
            receipt[oi.productId].lineTotal += oi.productPrice + oi.salesTax;
          } else {
            receipt[oi.productId] = {
              orderItemId: oi.orderItemId,
              productId: oi.productId,
              productPrice: oi.productPrice,
              productDescription: oi.productDescription,
              salesTax: oi.salesTax,
              numberPurchased: 1,
              lineTotal: oi.productPrice + oi.salesTax
            };
          }
        }

        for (let ri in receipt) {
          this.receiptItems.push(receipt[ri]);
        }
      });

    await this.createOrder();
  }

  detached() {
    this.subscription.dispose();
  }

  async createOrder() {
    const order = await this.orderService.create();
    this.order = order as Order;

    const message = new OrderCreateMessage();
    message.order = order;

    this.eventAggregator.publish(message);
  }
}
