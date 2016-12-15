namespace WoMoCo.Controllers {
    //Activity Forum Controller
    export class ActivitiesController {
        public activities;
        public ActivityResource;

        //public getActivities() {
        //    this.activities = this.ActivityResource.GetActivities();
        //}
        public getActivities() {
            this.activities = this.ActivityResource.query();
        }

        constructor(private $resource: angular.resource.IResourceService) {
            this.ActivityResource = this.$resource(`/api/activityForums`);
            
            this.getActivities();
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
}