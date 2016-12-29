namespace WoMoCo.Controllers {
    export class UserController {
        public user;
        public UserResource;
        // interests
        public interests; // this is for the list
        public interest; // this is for the add 
        // links
        public links; // this is for the list
        public link; // this is for the add
        // activities
        public activities; // this is for the list
        // connections
        public connections; // this is for the list

        public getUser() {
          return this.UserResource.get();
        }
        
        // get all Interests for the currently logged in user
        public getMyInterests() {
            return this.interestService.getAllUsersInterest();
        }

        // add an interest
        public addInterest() {
            this.interestService.saveInterest(this.interest).$promise
                .then(() => {
                    this.interest = null;
                    this.interests = this.getMyInterests();
                });
        }
        // remove an interest
        public removeInterest(id: number) {
            this.interestService.removeInterest(id).$promise
                .then(() => {
                    this.interests = this.getMyInterests();
                });
        }

        // get all the Links for the currently logged in user
        public getMyLinks() {
            return this.linkService.getAllUserLinks();
        }
        // add a link
        public addLink() {
            this.linkService.saveLink(this.link).$promise
                .then(() => {
                    this.link = null;
                    this.links = this.getMyLinks();
                });
        }
        // remove a link
        public removeLink(id: number) {
            this.linkService.removeLink(id).$promise
                .then(() => {
                    this.links = this.getMyLinks();
                });
        }

        //get all Activities for the currently logged in user
        public getMyActivities() {
            let temp = this.activitiesService.getAllUsersActivities();
            return temp;
        }
        // TODO: Remove an activity

        // get all the Connections for the currently logged in user
        public getMyConnections() {
            let temp = this.connectionService.getAllMyConnections();
            return temp;
        }
        public removeConnection(id: string) {
            this.connectionService.removeConnection(id).$promise
                .then(() => {
                    this.connections = this.getMyConnections();
                });
        }
        
        constructor(
            private accountService: WoMoCo.Services.AccountService,
            private $resource: angular.resource.IResourceService,
            private interestService: WoMoCo.Services.InterestService,
            private activitiesService: WoMoCo.Services.ActivitiesService,
            private linkService: WoMoCo.Services.LinkService,
            private connectionService: WoMoCo.Services.ConnectionService
            ) {
            this.UserResource = $resource('/api/users/getUser');
            this.user = this.getUser();
            this.interests = this.getMyInterests();
            this.links = this.getMyLinks();
            this.activities = this.getMyActivities();
            this.connections = this.getMyConnections();
            console.log(this.connections);
        }
    }
    angular.module(`WoMoCo`).controller(`UserController`, UserController);

    //Add UserController controller
    export class AddUserController {
        public user;
        public UserResource;

        public save() {
            this.UserResource.save(this.user).$promise.then(() => {
                this.user = null;
                this.$state.go('home')
            });
        }

        constructor(private $resource: angular.resource.IResourceService, private $state: ng.ui.IStateService) {
            this.UserResource = this.$resource('/api/users');
        }
    }
    //edit User Controller
    export class EditUserController {
        public user;
        public PostResource;
        public GetResource;
        //get a user for editing
        public getUserById(id: string) {
            this.user = this.GetResource.get({ id: id })
        }

        public saveUser() {
            this.PostResource.save(this.user).$promise.then(() => {
                this.user = null;
                this.$state.go('profile');
            })
        }
        constructor(private $resource: angular.resource.IResourceService,
            public $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {

            this.PostResource = this.$resource('/api/users');
            this.GetResource = this.$resource(`/api/users/getUser`);
            this.getUserById($stateParams['id'])
        }
    }
    //get user by username
    export class GetUserByUsername {
        public user;
        public UserResource;

        public getByUsername(username: string) {
            this.user = this.UserResource.get({ username: username })
        }
        constructor(
            public $resource: angular.resource.IResourceService,
            public $stateParams: ng.ui.IStateParamsService) {
            this.UserResource = $resource('/api/users');
            this.getByUsername($stateParams['username']);
        }


    }

    //delete user controller
    export class DeleteUserController {
        public user;
        public UserResource;

        public getUser(id: string) {
            this.user = this.UserResource.get({ id: id })
        }

        public deleteUser() {
            this.UserResource.delete({ id: this.user.id }).$promise.then(() => {
                this.user = null;
                this.$state.go('home');
            })
        }
        constructor(private $resource: angular.resource.IResourceService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {
            this.UserResource = $resource('/api/users/:id');
            this.getUser($stateParams['id'])
        }
    }
}

