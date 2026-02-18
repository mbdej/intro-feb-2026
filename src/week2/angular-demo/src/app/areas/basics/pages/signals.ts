import { Component, ChangeDetectionStrategy, signal } from '@angular/core';

@Component({
  selector: 'app-basics-signals',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [],
  template: `
    <div class="flex flex-row p-8 gap-4">
      <button class="btn btn-sm btn-warning btn-circle" (click)="decrement()">-</button>
      <span class="mx-2">{{ current() }}</span>
      <button class="btn btn-sm btn-primary btn-circle" (click)="increment()">+</button>
      <button class="btn btn-sm btn-secondary" (click)="current.set(0)">Reset</button>
    </div>
  `,
  styles: ``,
})
export class SignalsPage {
  current = signal(0);

  increment() {
    this.current.update((oldVal) => oldVal + 1);
  }

  decrement() {
    this.current.update((oldVal) => oldVal - 1);
  }
}
