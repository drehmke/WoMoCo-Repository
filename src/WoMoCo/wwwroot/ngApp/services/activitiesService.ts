namespace WoMoCo.Services {
    export class ActivitiesService {
        public GetUserActivitiesResource;
        public fiveResource;

        public getAllUsersActivities() {
            let temp = this.GetUserActivitiesResource.getMyActivities();
            //console.log(temp);
            return temp;
        }

        public googleMapEncode(textToEncode: string) {
            //let test =  encodeURIComponent(textToEncode);
            let test = textToEncode.replace(/\s/g, '+'); // any white space
            return test;
        }

        //for iteration 2
        //public getFiveAtivity() {
        //    let things = this.fiveResource.fiveThings();
        //    return things;
        //}

        constructor(private $resource: angular.resource.IResourceService) {
            this.GetUserActivitiesResource = $resource(`/api/activityForums`, null, {
                getMyActivities: {
                    method: `GET`,
                    url: `/api/activityForums/GetActivityForum/`,
                    isArray: true
                }
            });

            //for iteration 2
            //this.fiveResource = $resource("/api/activityForums", null, {
            //    fiveThings: {
            //        method: "GET",
            //        url: "/api/activityForums/GetAdFiveActivity",
            //        isArray: true
            //    }
            //});

        }
    }
    angular.module("WoMoCo").service("activitiesService", ActivitiesService);
}