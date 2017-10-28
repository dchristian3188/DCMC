import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'videoinfo',
    templateUrl: './videoinfo.component.html'
})
export class VideoInfoComponent {
    public videos: VideoInfo[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get('http://localhost:22368/api/videoinfo').subscribe(result => {
            this.videos = result.json() as VideoInfo[];
        }, error => console.error(error));
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
