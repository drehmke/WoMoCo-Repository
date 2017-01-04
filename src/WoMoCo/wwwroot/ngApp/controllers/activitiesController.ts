﻿namespace WoMoCo.Controllers {
    //Activity Forum Controller
    export class ActivitiesController {
        public activities;
        public ActivityResource;

        public getActivities() {
            this.activities = this.ActivityResource.query();
        }

        constructor(private $resource: angular.resource.IResourceService) {
            //this.ActivityResource = this.$resource(`/api/activityForums`, null, {
            //    getMyActivities: {
            //        method: `GET`,
            //        url: `/api/activityForums/GetActivityForum`,
            //        isArray: true
            //    }
            //});
            this.ActivityResource = $resource("/api/activityForums");
            this.getActivities();
            console.log(this.activities);
        }
    }

    // Activity Forum Controller - Admin Get All
    export class ActivitiesControllerAdminList {
        public activities;
        public ActivityResource;
        //Iteration 2
        //public fiveActivities;
        //public ActivitiesResource;

        public getActivities() {
            return this.ActivityResource.query();
        }

        //Iteraation 2
        //public getFiveActivities() {
        //    return this.activitiesService.getFiveAtivity();
        //}

        constructor(private $resource: angular.resource.IResourceService,
            private activitiesService: WoMoCo.Services.ActivitiesService) {
            this.ActivityResource = this.$resource(`/api/activityForums`);
            this.activities = this.getActivities();
            //this.fiveActivities = this.getFiveActivities();  for iteration 2
        }
    }

    //Add Activity Controller
    export class AddActivitiesController {
        public activity
        public ActivityResource;

        public saveActivity() {
            this.ActivityResource.save(this.activity).$promise.then(() => {
                this.activity = null;
                this.$state.go(`activityForum`);
            });
        }
        constructor(private $resource: angular.resource.IResourceService, private $state: ng.ui.IStateService) {
            this.ActivityResource = this.$resource(`/api/activityForums`);
        }
    }

    // User Edit Post
    export class ActivitiesControllerEdit {
        public activity;
        public ActivityResource;

        public getActivity(id: number) {
            return this.ActivityResource.get({ id: id });
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService
        ) {
            this.ActivityResource = $resource(`/api/activityForums/:id`);
            this.activity = this.getActivity($stateParams[`id`]);
        }
    }

    // Admin Edit Post
    export class ActivitiesControllerAdminEdit {
        public activity;
        public ActivityResource;
        public ActivitySaveResource;

        public GetActivity(id: number) {
            return this.ActivityResource.get({ id: id });
        }

        public saveActivity() {
            this.ActivitySaveResource.save(this.activity).$promise.then(() => {
                this.activity = null;
                this.$state.go(`activityForumAdminList`);
            });
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService
        ) {
            this.ActivityResource = $resource(`/api/activityForums/AdminGetId/:id`);
            this.ActivitySaveResource = $resource(`/api/activityForums/adminSave`);
            this.activity = this.GetActivity($stateParams[`id`]);
        }
    }

    export class ActivitiesControllerAdminDelete {
        public activity;
        public ActivityResource;
        public ActivityDeleteResource;

        public GetActivity(id: number) {
            return this.ActivityResource.get({ id: id });
        }

        public DeleteActivity() {
            this.ActivityDeleteResource.delete({ id: this.activity.id }).$promise
                .then(() => {
                    this.activity = null;
                    this.$state.go(`activityForumAdminList`);
                });
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService
        ) {
            this.ActivityResource = $resource(`/api/activityForums/AdminGetId/:id`);
            this.ActivityDeleteResource = $resource(`/api/activityForums/AdminDelete/:id`);
            this.activity = this.GetActivity($stateParams[`id`]);
        }
    }
}