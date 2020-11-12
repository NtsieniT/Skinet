import {v4 as uuidv4} from 'uuid';


export interface IBasket {
    id: string;
    items: IBasketItem[];
}

export interface IBasketItem {
        id: number;
        productName: string;
        price: number;
        quantity: number;
        pictureUrl: string;
        brand: string;
        type: string;
    }

export class Basket implements IBasket{

    // uuid is a unique guid generator which will give us a unique number
    id = uuidv4();
    items: IBasketItem[] = [];

}


export interface IBasketTotals{
    shipping: number;
    subtotal: number;
    total: number;
}


