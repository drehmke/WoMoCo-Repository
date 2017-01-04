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
        // calender events
        public calenderEvents;

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
            let activities = this.activitiesService.getAllUsersActivities();
            return activities;
        }
        // TODO: Remove an activity

        // get all the Connections for the currently logged in user
        public getMyConnections() {
            let connections = this.connectionService.getAllMyConnections();
            return connections;
        }
        public removeConnection(id: string) {
            this.connectionService.removeConnection(id).$promise
                .then(() => {
                    this.connections = this.getMyConnections();
                });
        }

        // calender event list
        public getCalenderEvents() {
            return this.calendarEventService.GetCalendarEventsByUser();
        }
        public removeCalenderEvent(id: number) {
            this.calendarEventService.DeleteCalendarEvent(id).$promise
                .then(() => {
                    this.calenderEvents = this.getCalenderEvents();
                });
        }

        constructor(
            private accountService: WoMoCo.Services.AccountService,
            private $resource: angular.resource.IResourceService,
            private interestService: WoMoCo.Services.InterestService,
            private activitiesService: WoMoCo.Services.ActivitiesService,
            private linkService: WoMoCo.Services.LinkService,
            private connectionService: WoMoCo.Services.ConnectionService,
            private calendarEventService: WoMoCo.Services.CalendarEventService
            ) {
            this.UserResource = $resource('/api/users/getUser');
            this.user = this.getUser();
            this.interests = this.getMyInterests();
            this.links = this.getMyLinks();
            this.activities = this.getMyActivities();
            this.connections = this.getMyConnections();

            //console.log(this.connections);
            this.calenderEvents = this.getCalenderEvents();
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
    //export class GetUserByUsername {
    export class EditUserAdminController {
        public user;
        public UserResource;
        public UserUpdateResource;

        public getByUsername(username: string) {
            if (username != null) {
                return this.UserResource.get({ userName: username });
            }
        }
        public saveUser() {
            this.UserUpdateResource.save(this.user).$promise
                .then(() => {
                    this.user = null;
                    this.$state.go(`userAdmin`);
                });
        }
        constructor(
            public $resource: angular.resource.IResourceService,
            public $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService
        ) {
            this.UserResource = $resource('/api/users/Admin/GetUser/:userName');
            this.UserUpdateResource = $resource(`/api/users/AdminUpdate`);
            this.user = this.getByUsername($stateParams['id']);
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
            this.UserResource.delete({ userName: this.user.id }).$promise.then(() => {
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
     // delete user controller - admin version
    export class DeleteUserAdminController {
        public user;
        public UserGetResource;
        public UserDeleteResource;

        public getUser(username: string) {
            return this.UserGetResource.get({ userName: username });
        }

        public deleteUser() {
            this.UserDeleteResource.delete(this.user).$promise
                .then(() => {
                    this.user = null;
                    this.$state.go(`userAdmin`);
                });
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService
        ) {
            this.UserGetResource = $resource(`/api/users/Admin/GetUser/:userName`);
            this.UserDeleteResource = $resource(`/api/users/Admin/DeleteUser/:userName`);
            this.user = this.getUser($stateParams[`id`]);
        }
    }
}

