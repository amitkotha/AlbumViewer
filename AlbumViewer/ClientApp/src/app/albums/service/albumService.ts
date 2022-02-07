import { Inject,Injectable,Component } from '@angular/core';
import { Album, Artist, Track } from '../../common/entities';
import { ErrorInfo } from "../../common/errorDisplay";
import { Observable } from "rxjs";
import { map, catchError, tap } from "rxjs/operators";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AlbumService {
  constructor(private httpClient: HttpClient) {
  }

  albumList: Album[] = [];
  album: Album = new Album();

  //artistList: Artist[] = [];
  listScrollPos = 0;

  getAlbums(): Observable<any> {
    return this.httpClient.get<Album[]>('api/albums')
      .pipe(
        map(albumList => this.albumList = albumList),
        catchError(new ErrorInfo().parseObservableResponseError)
      );

  }

  getAlbum(id): Observable<any> {
    return this.httpClient.get<Album>("api/album"+"/" + id)
      .pipe(
        map(album => {
          this.album = album;

          if (!this.albumList || this.albumList.length < 1)
            this.getAlbums(); // load up albums in background

          return this.album;
        }),
        catchError(new ErrorInfo().parseObservableResponseError)
      );
  }

  newAlbum(): Album {
    this.album = new Album();
    return this.album;
  }

  updateAlbum(album): Observable<any> {
    return this.httpClient.put<Album>("api/album" + "/" + album.id,
      album)
      .pipe(map(album => {
        this.album = album;

        // explicitly update the list with the updated data
        this.update(this.album);
        return this.album;
      }),
        catchError(new ErrorInfo().parseObservableResponseError)
      );
  }

  deleteAlbum(album: Album): Observable<any> {
    return this.httpClient.delete<boolean>("api/album"+"/"+album.id)
      .pipe(
        map(result => {
          if (result)
            this.removeAlbum(album); // client side remove
        }),
        catchError(new ErrorInfo().parseObservableResponseError)
      );
  }


  /**
   * Updates the .albumList property by updating the actual
   * index entry in the existing list, adding new entries and
   * removing 0 entries.
   * @param album  - the album to update
   */
  update(album) {
    var i = this.albumList.findIndex((a) => (a.id == album.id));
    if (i > -1)
      this.albumList[i] = album;
    else {
      this.albumList.push(album);
      this.albumList.sort((a: Album, b: Album) => {
        var aTitle = a.title.toLocaleLowerCase();
        var bTitle = b.title.toLocaleLowerCase();
        if (aTitle > bTitle)
          return 1;
        if (aTitle < bTitle)
          return -1;
        return 0;
      })
    }

    this.albumList = this.albumList.filter((a) => a.id != 0);
  }

  removeAlbum(album) {
    this.albumList = this.albumList.filter((a) => a.id != album.Id);
  }

  addSong(track: Track) {
    this.album.tracks.push(track);
  }

  removeSong(track: Track) {
    var idx = this.album.tracks.findIndex((t) => track.id == t.id);
    if (idx > -1)
      this.album.tracks.splice(idx, 1);
  }


}

export class ArtistSearchResult {

}
