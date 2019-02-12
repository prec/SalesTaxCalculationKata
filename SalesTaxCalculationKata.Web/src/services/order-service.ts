import { HttpClient } from "aurelia-fetch-client";
import { inject } from "aurelia-framework";
import { OrderModel } from "../models/order-model";

@inject(HttpClient)
export class OrderService {
  constructor(private httpClient: HttpClient) {

  }

  async get(id: number) : Promise<OrderModel> {
    const response = await this.httpClient.fetch(`Orders/${id}`);
    const data = await response.json();

    return data as OrderModel;
  }
}
