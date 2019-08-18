import { isNullOrUndefined } from 'util';

const cartStateKey:string = 'cartState';

class CartService {
  setState(state: Object) {
    const jsonItem = JSON.stringify(state);
    localStorage.setItem(cartStateKey, jsonItem)
  }

  get state(): Object {
    const state = localStorage.getItem(cartStateKey);

    return isNullOrUndefined(state) ? null : JSON.parse(state);
  }

  addItem(item: Object) {
    const state = this.state;
    const kapper = this.getKaper(item.kaper.id);

    kapper ? kapper.subscribes.push(item.subscribe)
           : state.kapers.push(item);

    this.setState(state);
  }

  removeKaper(id: number) {
    const state = this.state;
    const kappers = state.kappers.filter(k => k.id !== id);

    state.kappers = kappers;

    this.setState(state);
  }

  removeSubscription(id: Object) {
    const state = this.state;
    const kapper = state.kappers.find(k => k.subscribes
                                              .find(s => s.id === id));

    kapper.subscribes = kapper.subscribes.filter(s => s.id !== id);

    this.setState(state);
  }

  private getKaper(id: number) {
    return this.state.kapers.find(k => k.id === id);
  }
}

const cartService = new CartService();
export default cartService;