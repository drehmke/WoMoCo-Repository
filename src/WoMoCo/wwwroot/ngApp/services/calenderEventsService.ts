namespace WoMoCo.Services {
    export class CalenderEventService {
        //private CalenderEventResource;
        //public calenderEvents;
        //public calenderEvent;

        public getAllCalenderEvents() {
            return this.$resource('/api/calenderEvents').query();
        }

        public saveCalenderEvent(calenderEvent) {
            return this.$resource(`/api/calenderEvents`).save(calenderEvent).$promise
                .then(() => {
                    calenderEvent = null;
                });
        }


        constructor(
            private $resource: angular.resource.IResourceService
        ) {
           
        }
    }

    angular.module('WoMoCo').service('calenderEventService', CalenderEventService);
}