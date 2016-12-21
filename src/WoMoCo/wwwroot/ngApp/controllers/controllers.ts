namespace WoMoCo.Controllers {

    export class HomeController {
        public posts;
        public newMessageCount;

        constructor(
            private PostService: WoMoCo.Services.PostService,
            private MessageService: WoMoCo.Services.MessageService
        ) {
            this.posts = this.getPostByUsername();
            this.newMessageCount = this.getNewMessageCount();
            console.log(this.newMessageCount);
        }
        public getPostByUsername() {
            return this.PostService.getPostByUsername()
        }
        public getNewMessageCount() {
            let temp = this.MessageService.getNewMessageCount();
            console.log(temp);
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


