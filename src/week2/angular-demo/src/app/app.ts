import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  template: `
    <p>This is the story of my life</p>
    <h2>Chapter 1 - in the beginning</h2>
  `,
  styles: [],
})
export class App {
  protected readonly title = signal('angular-demo');
}
