namespace WoMoCo.Controllers {

    export class SearchController {
        public SearchResource;
        public users;
        

        public getUsers() {
            this.users = this.SearchService.getUsers();
            console.log(this.users);
        }

        constructor(
            private SearchService: WoMoCo.Services.SearchService,
            private $resource: angular.resource.IResourceService) {
            //this.SearchResource = $resource('/api/filters/');
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