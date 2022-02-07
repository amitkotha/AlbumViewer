import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AlbumDisplay } from './albums/component/albumdisplay';
import { AlbumList } from './albums/component/albumList';
import { AlbumEditor } from './albums/component/albumEditor';
import { AlbumSongList } from "./albums/component/albumSongList";
import { ErrorDisplay, ErrorInfo } from './common/errorDisplay';

import { AngularFontAwesomeModule } from 'angular-font-awesome';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AlbumDisplay,
    AlbumList,
    ErrorDisplay,
    AlbumEditor,
    AlbumSongList
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AngularFontAwesomeModule,
    RouterModule.forRoot([
      { path: '', component: AlbumList, pathMatch: 'full' },
      { path: 'albums', component: AlbumList },
      { path: 'album/:id', component: AlbumDisplay },
      { path: 'album/edit/:id', component: AlbumEditor },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
