﻿import { HttpClient } from "aurelia-fetch-client";
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

  async create() : Promise<OrderModel> {
    const response = await this.httpClient.fetch("Orders", {
        method: "post"
    });
    const data = await response.json();

    return data as OrderModel;
  }

  async addItem(orderId: number, productId: number) : Promise<OrderModel> {
    const payload = {
      productId: productId
    };

    const response = await this.httpClient.fetch(`Orders/${orderId}/AddProduct`, {
      method: "post",
      body: JSON.stringify(payload)
    });
    const data = await response.json();

    return data as OrderModel;
  }
}
