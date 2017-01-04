namespace WoMoCo.Controllers {
    export class AdminController {
        public posts;
        public activities;
        public connections;
        public messages;
        

        public getActivities() {
            let act = this.activitiesService.getAllUsersActivities();
            return act;
        }

        public getConnections() {
            let con =
                this.connectionService.getAllMyConnections();
            return con;
        }
        public getPost() {
            return this.PostService.getPost();
        }
        public deletePost(id:number) {
            for (let i = 0; i < this.posts.length; i++) {
                if (this.posts[i].id == id) {
                    this.PostService.deletePost(this.posts[i].id).$promise
                        .then(() => {
                            //post = null;
                            //this.$state.go(`postAdmin`);
                        });
                }
            }
        }

        public getMessages() {
            let fiveMessages = this.commService.getFirstMessagesFiveForAdminPage();
            return fiveMessages;
        }

        //for iteration 2
        //public getFiveActivities() {
        //    var fiveActivities = this.activitiesService.getFiveAtivity();
        //    return fiveActivities;
        //}

        constructor(private $resource: angular.resource.IResourceService,
            private accountService: WoMoCo.Services.AccountService,
            private activitiesService: WoMoCo.Services.ActivitiesService,
            private connectionService: WoMoCo.Services.ConnectionService,
            private PostService: WoMoCo.Services.PostService,
            private commService: WoMoCo.Services.CommService,
            ) {
            this.activities = this.getActivities();
            this.connections = this.getConnections();
            this.posts = this.getPost();
            this.messages = this.getMessages();
            
        }
    }

}