import { Album } from '../../common/entities';
import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { style, animate, state, transition, trigger } from '@angular/animations';
import { AlbumService } from "../service/albumService";
import { ActivatedRoute, Router } from "@angular/router";
import { ErrorInfo } from "../../common/errorDisplay";
import { slideIn, slideInLeft } from "../../common/animations";

@Component({
  selector: 'album-display',
  templateUrl: './albumDisplay.html',
  animations: [slideIn]
})
export class AlbumDisplay implements OnInit {

  @Input() album: Album = new Album();
  error = new ErrorInfo();
  aniFrame = 'in';

  constructor(private route: ActivatedRoute,
    private router: Router,
    private albumService: AlbumService) {
  }

  ngOnInit() {
    this.aniFrame = 'in';

    //console.log("AlbumDisplay");
    if (!this.album.title) {
      var id = this.route.snapshot.params["id"];
      if (id < 1)
        return;

      this.albumService.getAlbum(id)
        .subscribe(result => {
          this.album = result;
        }, err => this.error.error(err));
    }
  }

  ngOnDestroy() {
    this.aniFrame = 'out';
    console.log("ngDestroy")
  }

  deleteAlbum(album) {
    this.albumService.deleteAlbum(album)
      .subscribe(result => {
        this.error.info("Album '" + album.title + "' has been deleted.");
        setTimeout(() => this.router.navigate(["/albums"]), 1500);
      },
        (err) => this.error.error(err));
  }

}
