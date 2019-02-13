import { CategoryModel } from "../models/category-model";
import { OrderService } from "../services/order-service";
import { bindable, inject } from "aurelia-framework";
import { EventAggregator, Subscription } from "aurelia-event-aggregator";
import { ProductSelectMessage, OrderCreateMessage } from "../messages";

@inject(OrderService, EventAggregator)
export class Product {
  @bindable productId: number;
  @bindable description: string;
  @bindable price: number;
  @bindable categories: Array<CategoryModel>;

  orderId: number;
  subscriber: Subscription;

  constructor(private orderService, private eventAggregator) {

  }

  attached() {
    this.subscriber = this.eventAggregator.subscribe(OrderCreateMessage,
      message => {
        this.orderId = message.order.orderId;
      });
  }

  async selectProduct() {
    const order = await this.orderService.addItem(this.orderId, this.productId);

    const message = new ProductSelectMessage();
    message.order = order;
    message.selectedProduct = this;

    this.eventAggregator.publish(message);
  }
}
