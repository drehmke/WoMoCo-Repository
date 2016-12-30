namespace WoMoCo.Controllers {
    export class AdminController {
        public posts;
        public activities;
        public connections;

        public getActivities() {
            let act = this.activitiesService.getAllUsersActivities();
            return act;
        }

        public getConnections() {
            let con =
                this.connectionService.getAllMyConnections();
            return con;
        }

        public getPosts() {
            let pos = this.PostService.getPostings();
            return pos;
        }

        constructor(private $resource: angular.resource.IResourceService,
            private accountService: WoMoCo.Services.AccountService,
            private activitiesService: WoMoCo.Services.ActivitiesService,
            private connectionService: WoMoCo.Services.ConnectionService,
            private PostService: WoMoCo.Services.PostService) {
            this.activities = this.getActivities();
            this.connections = this.getConnections();
            //this.posts = this.getPosts();
        }
    }

}