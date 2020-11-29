import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, CanActivate } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ModalModule } from 'ngx-bootstrap/modal';
import { SummaryPipe } from '../pipes/summary/summary.pipe';
import { LoginFormComponent } from '../api-authorization/login-form/login-form.component';

import { LoaderComponent } from './components/loader/loader.component';
import { PostDetailComponent } from './issue-tickets/post-detail/post-detail.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { PostFormComponent } from './components/post-form/post-form.component';
import { PostsComponent } from './issue-tickets/posts.component';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SummaryPipe,
    LoginFormComponent,
    PostsComponent,
    LoaderComponent,
    PostDetailComponent,
    NotFoundComponent,
    PostFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    FontAwesomeModule,
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      {
        path: '',
        component: HomeComponent,
        pathMatch: 'full'
      },
      {
        path: 'login',
        component: LoginFormComponent
      },
      {
        path: 'posts/:title/:issueTicketId',
        component: PostDetailComponent,
        canActivate: [AuthorizeGuard]
      },
  
      {
        path: '**',
        component: NotFoundComponent
      },
    ]),
    BrowserAnimationsModule,
    ModalModule.forRoot()
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
