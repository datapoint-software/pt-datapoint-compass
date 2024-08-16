import { Injectable } from "@angular/core";
import { LoadingOverlayItem } from "@app/features/loading-overlay/loading-overlay.feature.abstractions";

@Injectable()
export class LoadingOverlayFeature {

  private static _id: number = 0;

  readonly items = new Map<string, LoadingOverlayItem>();

  dequeue(id: string): void {
    this.items.delete(id);
  }

  enqueue(id?: string): string {

    id ??= `loading-overlay-${++LoadingOverlayFeature._id}`;

    this.items.set(id, ({
      id,
      enqueuement: new Date()
    }));

    return id;
  }

  enqueueWhile<T>(fn: () => Promise<T>, id?: string): Promise<T> {

    id = this.enqueue(id);

    return fn()
      .then((result) => { this.dequeue(id); return result })
      .catch((error) => { this.dequeue(id); throw error; });
  }
}
