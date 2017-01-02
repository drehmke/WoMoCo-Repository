namespace WoMoCo.Controllers {

    export class HomeController {
        //public posts;
        public newMessageCount;

        constructor(
            //private PostService: WoMoCo.Services.PostService,
            private $http: ng.IHttpService
        ) {
            //this.posts = this.getPostByUsername();
            this.getNewMessageCount();
        }
        //public getPostByUsername() {
        //    return this.PostService.getPostByUsername()
        //}
        public getNewMessageCount() {
            this.$http.get(`/api/comms/GetUserNewMessageCount/`).then((results) => {
                this.newMessageCount = results.data;
            });
            
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


