import { Product } from "./product";
import { bindable } from "aurelia-framework";

export class ProductList {
  @bindable products: Array<Product>
}
