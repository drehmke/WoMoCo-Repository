namespace WoMoCo.Services {

    export class CalenderEventService {
        private getEventsByUserResource;

        public getAllCalenderEvents() {
            return this.$resource('/api/calenderEvents').query();
        }

        public saveCalenderEvent(calenderEvent) {
            return this.$resource(`/api/calenderEvents`).save(calenderEvent).$promise
                .then(() => {
                    calenderEvent = null;
                });
        }

        public getCalenderEventById(id: number) {
            // return this.$resource(`/api/calenderEvents/:id`).get({id: id});
            let tempResource = this.$resource(`/api/calenderEvents/:id`);
            let tempResult = tempResource.get({ id: id });
            console.log(tempResult);
            return tempResult;
        }

        public getCalenderEventsByUser() {
            let tempList = this.getEventsByUserResource.getMyEvents();
            console.log(tempList);
            return tempList;
        }

        public deleteCalenderEvent(id: number) {
            return this.$resource(`/api/calenderEvents/:id`).delete({ id: id }).$promise
                .then(() => {
                    id = null;
                });
        }
        
        constructor(
            private $resource: angular.resource.IResourceService
        ) {
            this.getEventsByUserResource = $resource(`/api/calenderEvents`, null, {
                getMyEvents: {
                    method: `GET`,
                    url: `/api/calenderEvents/getMy`,
                    isArray: true
                }
            });
        }
    }

    angular.module('WoMoCo').service('calenderEventService', CalenderEventService);
}