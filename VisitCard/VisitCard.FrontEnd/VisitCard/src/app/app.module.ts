import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes} from '@angular/router';

import { AppComponent } from './app.component';
import { CreateComponent } from './visit-card/create/create.component';
import { ViewComponent } from './visit-card/view/view.component';

const appRoutes: Routes = [
  { path: '', component: CreateComponent },
  { path: 'view', component: ViewComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    CreateComponent,
    ViewComponent
  ],
    imports: [
        BrowserModule,
        RouterModule.forRoot(appRoutes),
        HttpClientModule,
        AppRoutingModule,
        FormsModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule {
  title = 'Visit Card';
}
