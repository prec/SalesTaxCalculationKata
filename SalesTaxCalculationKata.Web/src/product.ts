import { CategoryModel } from "./models/category-model";
import { bindable } from "aurelia-framework";

export class Product {
  @bindable productId: number;
  @bindable description: string;
  @bindable price: number;
  @bindable categories: Array<CategoryModel>;
}
