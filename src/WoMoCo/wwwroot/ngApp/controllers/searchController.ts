namespace WoMoCo.Controllers {

    class Com {
        constructor(public recId: string, public subject: string) {
            this.recId = recId;
            this.subject = subject;
            
        }
    }

    export class SearchController {
        public SearchResource;
        public users;
        public requests;
        public RequestResource;
        

        public getUsers() {
            this.users = this.SearchService.getUsers();
            console.log(this.users);
        }

        public reqConnect(recUser: string) {
            let Comm = new Com(recUser, "connection request");
            this.RequestResource.save(Comm).$promise.then(() =>
            {
                Comm = null;
                recUser = null;
            });
        }



        constructor(
            private SearchService: WoMoCo.Services.SearchService,
            private $resource: angular.resource.IResourceService) {
            this.RequestResource = $resource('/api/comms/');
            ////this.userByUsername($stateParams['username']);
            this.getUsers();

        }
    }


    //getUserByUsername/:username
    
    //export class UserByUsername {
    //    public UserResource;
    //    public user;

    //    public userByUsername(username: string) {
    //        this.user = this.UserResource.get({ username: username });
    //    }

    //    constructor(private $resource: angular.resource.IResourceService,
    //            private $stateParams: ng.ui.IStateParamsService) {
    //        this.UserResource = this.$resource('/api/users');
    //        this.userByUsername($stateParams['username']);
    //    }
    //}
}