import { isNullOrUndefined } from 'util';
import { CartState, CartKaper, CartSubscription } from './types';
import EventBus from '@/plugins/eventBus'

const cartStateKey:string = 'cartState';

class CartService {
  setState(state: CartState) {
    const jsonItem = JSON.stringify(state);
    localStorage.setItem(cartStateKey, jsonItem);
    EventBus.$emit('cart:changed');
  }

  get state(): CartState | null {
    const stateJson = localStorage.getItem(cartStateKey);

    return isNullOrUndefined(stateJson) ? null : CartState.parseJson(stateJson);
  }

  addItem(kaper: CartKaper) {
    if(isNullOrUndefined(this.state)) return;

    const state = this.state;
    const stateKaper = this.state.getKaper(kaper.id);

    stateKaper 
          ? stateKaper.addSubscription(kaper.subscriptions[0])
          : state.addKaper(kaper);

    this.setState(state);
  }

  removeKaper(cart: CartState, id: number) {
    if(isNullOrUndefined(this.state)) return;

    const state = this.state;

    state.removeKaper(id);
    cart.removeKaper(id);

    this.setState(state);
  }

  removeSubscription(cart: CartState, id: number) {
    if(isNullOrUndefined(this.state)) return;

    const state = this.state;
    const kaper = state.getKaperBySubscription(id);

    if(kaper) {
      if(kaper.subscriptions.length <= 1) {
        state.removeKaper(kaper.id);
        cart.removeKaper(kaper.id);
      } else {
        kaper.removeSubscription(id);
        (cart.getKaper(kaper.id) as any).removeSubscription(id);
      }
    }

    this.setState(state);
  }
}

const cartService = new CartService();
export default cartService;