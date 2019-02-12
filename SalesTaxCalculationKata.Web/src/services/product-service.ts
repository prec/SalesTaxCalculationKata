import { HttpClient } from "aurelia-fetch-client";
import { inject } from "aurelia-framework";
import { ProductModel } from "../models/product-model";

@inject(HttpClient)
export class ProductService {
  constructor(private httpClient: HttpClient) {

  }

  async get() : Promise<Array<ProductModel>> {
    const response = await this.httpClient.fetch("Products");
    const products = await response.json();

    return products as Array<ProductModel>;
  }
}
