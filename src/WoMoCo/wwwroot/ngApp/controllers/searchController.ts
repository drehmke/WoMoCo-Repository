namespace WoMoCo.Controllers {

    class Com {
        constructor(public recId: string, public subject: string, public commType: string) {
            this.recId = recId;
            this.subject = subject;
            this.commType = commType;
        }
    }

    export class SearchController {
        public SearchResource;
        public users;
        public requests;
        public RequestResource;
        public ConnectResource;
        

        public getUsers() {
            this.users = this.SearchService.getUsers();
        }

        public reqConnect(recUser: string) {
            let Comm = new Com(recUser, "connection request", "connection request");
            this.saveUser(recUser);
            this.RequestResource.save(Comm).$promise.then(() =>
            {
                Comm = null;
                recUser = null;
            });
        }

        public saveUser( recUser: string) {

            this.ConnectResource.save({ connectedUserId : recUser }).$promise.then(() => {

            });
        }

        public deleteUser() {

        }


        constructor(
            private SearchService: WoMoCo.Services.SearchService,
            private $resource: angular.resource.IResourceService) {
            this.RequestResource = $resource('/api/comms/');
            this.ConnectResource = $resource('/api/connections/');
            this.getUsers();

        }
    }

    export class SearchAdminController {
        public users;

        public getUsers() {
            return this.SearchService.getUsers();
        }

        constructor(
            private SearchService: WoMoCo.Services.SearchService
        ) {
            this.users = this.getUsers();
        }
    }

}