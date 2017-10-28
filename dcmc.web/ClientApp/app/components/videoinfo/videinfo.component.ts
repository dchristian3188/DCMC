import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'videoinfo',
    templateUrl: './videoinfo.component.html'
})
export class VideoInfoComponent {
    public videos: VideoInfo[];

    public filteredVideos: VideoInfo[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get('http://localhost:22368/api/videoinfo').subscribe(result => {
            this.videos = result.json() as VideoInfo[];
            this.filteredVideos = this.videos;
        }, error => console.error(error));
    }

    _filterString: string;

    get filterString(): string {
        return this._filterString;
    }

    set filterString(value: string) {
        this._filterString = value;
        this.filteredVideos = value ? this.filterVideos(value) : this.videos;
    }

    filterVideos(filter: string): VideoInfo[] {
        filter = filter.toLocaleLowerCase();
        return this.videos.filter((video: VideoInfo) =>
            video.filePath.toLocaleLowerCase().indexOf(filter) !== -1);
    }
}

interface VideoInfo {
    id: string;
    filePath: string;
    name: string;
    extension: string;
    sizeMB: number;
    tags: string[];
}
