namespace WoMoCo.Services {
    export class InterestService {
        public GetUserInterestsResource;

        public saveInterest(interest) {
            // I have a return on this because the promise/then is in the controller
            return this.$resource(`/api/interest`).save(interest);
        }

        public getAllUsersInterest() {
            let temp = this.GetUserInterestsResource.getMyInterests();
            return temp;
        }

        // ---- CONSTRUCTOR ---------------------------------------------------
        constructor(
            private $resource: angular.resource.IResourceService
        ) {
            this.GetUserInterestsResource = $resource(`/api/interest`, null, {
                getMyInterests: {
                    method: `GET`,
                    url: `/api/interest/getMy`,
                    isArray: true
                }
            });

        }
    }
    angular.module('WoMoCo').service('interestService', InterestService);

}