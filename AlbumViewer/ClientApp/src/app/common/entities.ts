import { Injectable, OnInit } from '@angular/core';
declare var $: any;

@Injectable()
export class Album {
  id: number = 0;
  artistId: number = 0;
  title: string = null;
  description: string = null;
  year: number = 0;
  imageUrl: string = null;
  amazonUrl: string = null;
  spotifyUrl: string = null;

  Artist: Artist = new Artist();
  tracks: Track[] = [];
}

@Injectable({
  providedIn: 'root'
})
export class Artist {
  Id: number = 0;
  artistName: string = null;
  description: string = null;
  imageUrl: string = null;
  amazonUrl: string = null;
  albumCount: number = 0;
  Albums: Album[] = [];
}

@Injectable({
  providedIn: 'root'
})
export class ArtistResult {
  Artist: Artist = null;
  Albums: Album[] = [];
}

@Injectable({
  providedIn: 'root'
})
export class Track {
  id: number = 0;
  albumId: number = 0;
  songName: string = null;
  length: string = null;
  bytes: number = 0;
  unitPrice: number = 0;
}
