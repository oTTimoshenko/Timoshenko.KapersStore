import { isNullOrUndefined } from 'util';

class CartSubscription {
  id!: number;
  kaperId!: number;
  name!: string;
  count!: number;
  price!: number;

  public get totalPrice() {
    return this.count * this.price;
  }

  static getCloneOfObj(subscription: CartSubscription) {
    return new CartSubscription(subscription.id, subscription.name, subscription.price, subscription.count);
  }

  constructor(id: number, name: string, price: number, count?: number) {
    this.id = id;
    this.name = name;
    this.count = count || 0;
    this.price = price;
  }

  plusCount(count?: number) {
    this.count = count ? this.count + count : this.count + 1;
  }

  minusCount(count?: number) {
    if(this.count > 1) this.count = count ? this.count - count : this.count - 1; 
    else this.count = 1;
  }
}

class CartKaper {
  id!: number;
  name!: string;
  subscriptions!: CartSubscription[];

  public get totalPrice() {
    return this.subscriptions 
            ? this.subscriptions.reduce((sum, current) => sum + current.totalPrice, 0) 
            : 0;
  }

  public get subscriptionsCount() {
    return this.subscriptions 
            ? this.subscriptions.reduce((sum, current) => sum + current.count, 0)
            : 0;
  }

  static getCloneOfObj(kaper: CartKaper) {
    return new CartKaper(kaper.id, kaper.name, kaper.subscriptions.map(s => CartSubscription.getCloneOfObj(s)));
  }

  constructor(id: number, name: string, subscriptions: CartSubscription[]) {
    this.id = id;
    this.name = name;
    this.subscriptions = subscriptions;
    this.subscriptions.forEach(s => s.kaperId = id);
  }

  addSubscription(subscription: CartSubscription) {
    const item = this.subscriptions.find(s => s.id === subscription.id);
    
    if(item) {
      const index = this.subscriptions.indexOf(item);

      if(index !== -1) this.subscriptions[index] = subscription;
    } else 
      this.subscriptions.push(subscription);
  }

  removeSubscription(id: number) {
    this.subscriptions = this.subscriptions.filter(s => s.id !== id);
  }
}

class CartState {
  items!: CartKaper[];

  public get totalPrice() {
    return this.items 
            ? this.items.reduce((sum, current) => sum + current.totalPrice, 0)
            : 0;
  }

  public get subscriptionsCount() {
    return this.items
            ? this.items.reduce((sum, current) => sum + current.subscriptionsCount, 0)
            : 0;
  }

  static parseJson(json: string): CartState | null  {
    if(isNullOrUndefined(json)) return null;

    const cartFromJson = JSON.parse(json) as CartState;
    const kapers = cartFromJson.items.map(kaper => CartKaper.getCloneOfObj(kaper));
    const cart = new CartState(kapers);
    return cart;
  }

  constructor(kapers: CartKaper[]) {
    this.items = kapers;
  }

  getKaper(id: number) {
    return this.items.find(k => k.id === id);
  }

  getKaperBySubscription(id: number): CartKaper | undefined {
    return this.items.find(i => i.subscriptions
                                    .find(s => s.id === id));
  }

  addKaper(kaper: CartKaper) {
    const item = this.items.find(i => i.id === kaper.id);
    
    if(item) {
      const index = this.items.indexOf(item);

      if(index !== -1) this.items[index] = kaper;
    } else 
      this.items.push(kaper);
  }

  removeKaper(id: number) {
    this.items = this.items.filter(k => k.id !== id);
  }
}

export { CartSubscription, CartKaper, CartState };
