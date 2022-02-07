import { Component, OnInit, ElementRef } from '@angular/core';
import { Album } from '../../common/entities';
import { AlbumService } from "../service/albumService";
import { Router, ActivatedRoute } from "@angular/router";
import { slideIn, slideInLeft } from "../../common/animations";
import { ErrorInfo } from "../../common/errorDisplay";

import { Observable, of, Subscriber } from 'rxjs';


//declare var $:any ;
declare var $: any;
declare var toastr: any;
declare var window: any;


@Component({
  selector: 'album-editor',
  templateUrl: 'albumEditor.html',
  animations: [slideIn]
})
export class AlbumEditor implements OnInit {
  constructor(private route: ActivatedRoute,
    private router: Router,
    private albumService: AlbumService
  ) { }

  album: Album = new Album();
  error: ErrorInfo = new ErrorInfo();
  loaded = false;
  aniFrame = 'in';

  searchTerm: string;
  searchResults: Observable<string[]>;

  public searchData: any = {};

  ngOnInit() {
   var id = this.route.snapshot.params["id"];
    if (id < 1) {
      this.loaded = true;
      this.album = this.albumService.newAlbum();
      return;
    }

    this.albumService.getAlbum(id)
      .subscribe(result => {
        this.album = result;
        this.loaded = true;
      },
        err => {
          this.error.error(err);
        });

  
  }

  saveAlbum(album) {
    return this.albumService.updateAlbum(album)
      .subscribe((album: Album) => {
        var msg = album.title + " has been saved.";
        this.error.info(msg);
        window.document.getElementById("MainView").scrollTop = 0;

        setTimeout(() => {
          this.router.navigate(["/album", album.id]);
        }, 1500)
      },
        err => {
          let msg = `Unable to save album: ${err.message}`;
          this.error.error(msg);

        });
  };

  changeTypeaheadLoading(e: boolean): void {

  }
  /**
   * Used to format the result data from the lookup into the
   * display and list values
   * @param value For
   */
  resultFormatBandListValue(value: any) {
    return value.name;
  }
  inputFormatBandListValue(value: any) {
    if (value.name)
      return value.name;
    return value;
  }
}
