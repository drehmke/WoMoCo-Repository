namespace WoMoCo.Controllers {

    export class HomeController {
        public posts;
        constructor(
            private PostService: WoMoCo.Services.PostService
        ) {
            this.posts = this.getPostByUsername();
        }
        public getPostByUsername() {
            return this.PostService.getPostByUsername()
        }

    }


    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {

    }
}


