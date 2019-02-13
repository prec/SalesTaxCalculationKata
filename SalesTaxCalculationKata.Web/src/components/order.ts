import { bindable, inject } from "aurelia-framework";
import { EventAggregator, Subscription } from "aurelia-event-aggregator";
import { ProductSelectMessage } from "../messages";

@inject(EventAggregator)
export class Order {
  @bindable orderId: number;
  @bindable salesTaxTotal: number;
  @bindable grandTotal: number;
  @bindable isComplete: boolean;

  subscriber: Subscription;

  constructor(private eventAggregator: EventAggregator) {

  }

  attached() {
    this.subscriber = this.eventAggregator.subscribe(ProductSelectMessage,
      message => {
        this.salesTaxTotal = message.order.salesTaxTotal;
        this.grandTotal = message.order.grandTotal;
        this.isComplete = message.order.isComplete;
      });
  }

  detached() {
    this.subscriber.dispose();
  }
}
