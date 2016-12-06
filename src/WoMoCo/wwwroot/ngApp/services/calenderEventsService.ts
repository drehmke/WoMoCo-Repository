namespace WoMoCo.Services {
    export class CalenderEventService {

        public getAllCalenderEvents() {
            return this.$resource('/api/calenderEvents').query();
        }

        public saveCalenderEvent(calenderEvent) {
            return this.$resource(`/api/calenderEvents`).save(calenderEvent).$promise
                .then(() => {
                    calenderEvent = null;
                });
        }
        
        public combineEventDateTime(dateToUse, timeToUse) {

            let test = dateToUse.getFullYear() + "-" + dateToUse.getMonth() + "-" + dateToUse.getDate() + "T";
            test += timeToUse.getHours() + ":" + timeToUse.getMinutes();
            return test;
        }
        
        public getCalenderEventById(id: number) {
            // return this.$resource(`/api/calenderEvents/:id`).get({id: id});
            let tempResource = this.$resource(`/api/calenderEvents/:id`);
            let tempResult = tempResource.get({ id: id });
            return tempResult;
        }
        
        public isolateDate(eventDateTime) {
            console.log(eventDateTime);
            let justDate = new Date();
            justDate.setMonth(eventDateTime.getMonth());
            justDate.setDate(eventDateTime.getDate());
            justDate.setFullYear(eventDateTime.getFullYear());
            return justDate;
        }
        public isolateTime(eventDateTime) {
            let justTime = new Date();
            justTime.setHours(eventDateTime.getHours());
            justTime.setMinutes(eventDateTime.getMinutes());
            return justTime;
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
           
        }
    }

    angular.module('WoMoCo').service('calenderEventService', CalenderEventService);
}