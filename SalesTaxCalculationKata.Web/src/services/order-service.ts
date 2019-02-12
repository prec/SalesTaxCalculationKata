import { HttpClient } from "aurelia-fetch-client";
import { inject } from "aurelia-framework";

@inject(HttpClient)
export class OrderService {
  constructor(private httpClient: HttpClient) {

  }


}
