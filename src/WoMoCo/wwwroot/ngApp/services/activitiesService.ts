namespace WoMoCo.Services {
    export class ActivitiesService {
        public GetUserActivitiesResource;

        public getAllUsersActivities() {
            let temp = this.GetUserActivitiesResource.getMyActivities();
            console.log(temp);
            return temp;
        }

        constructor(private $resource: angular.resource.IResourceService) {
            this.GetUserActivitiesResource = $resource(`/api/activityForums`, null, {
                getMyActivities: {
                    method: `GET`,
                    url: `/api/activityForums/GetActivityForum/`,
                    isArray: true
                }
            });
        }
    }
    angular.module("WoMoCo").service("activitiesService", ActivitiesService);
}