import { CategoryModel } from "./category-model";

export class ProductModel {
  productId: number;
  description: string;
  price: number;
  categories: Array<CategoryModel>;
}
