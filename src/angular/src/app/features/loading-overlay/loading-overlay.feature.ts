import { Injectable } from "@angular/core";
import { LoadingOverlayItem } from "@app/features/loading-overlay/loading-overlay.feature.abstractions";



@Injectable()
export class LoadingOverlay {

  private _lastId = 0;

  items: Map<string, LoadingOverlayItem> = new Map();

  dequeue(id: string): void {
    this.items.delete(id);
  }

  enqueue(id?: string): string {

    id ??= `loading-overlay-${this._lastId}`;

    this.items.set(id, {
      id,
      enqueuement: new Date()
    });

    return id;
  }

  async merge<T>(fn: () => Promise<T>, id?: string): Promise<T> {
    id = this.enqueue(id);
    try { return await fn(); }
    catch (e) { throw e; }
    finally { this.dequeue(id); }
  }
}
