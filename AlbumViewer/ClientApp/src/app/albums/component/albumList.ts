import { Component, OnInit } from '@angular/core';
import { AlbumService } from "../service/albumService";
import { Album } from '../../common/entities';
import { Router } from "@angular/router";
import { slideIn, slideInLeft } from "../../common/animations";
import { ErrorInfo } from "../../common/errorDisplay";

declare var $: any;

@Component({
  selector: 'album-list',
  templateUrl: './albumList.html',
  animations: [slideIn]
})
export class AlbumList implements OnInit {

  constructor(private router: Router,
    private albumService: AlbumService) {
  }

  albumList: Album[] = [];
  busy: boolean = true;
  error: ErrorInfo = new ErrorInfo();


  ngOnInit() {
    this.getAlbums();

    setTimeout(() => {
      $("#SearchBox").focus();
    }, 200);
  }

  getAlbums() {
    this.busy = true;
    this.albumList = [];
    this.albumService.getAlbums()
      .subscribe(albums => {
        this.albumList = albums;
        this.busy = false;
        console.log(albums);
        console.log(this.albumList);
        // reset to last scroll position of the list
        setTimeout(() => $("#MainView").scrollTop(this.albumService.listScrollPos), 100);
      }, err => {
        if (!err.message)
          this.error.error("Unable to load albums right now. Most likely the server is not responding.");
        else
          this.error.error(err);
        this.busy = false;
      });
  }

  albumClick(album: Album) {
    // save scroll position before navigation
    this.albumService.listScrollPos = $("#MainView").scrollTop();

    this.router.navigate(['/album', album.id]);
  }


  addAlbum() {

  }

  deleteAlbum(album: Album) {

  }
}
