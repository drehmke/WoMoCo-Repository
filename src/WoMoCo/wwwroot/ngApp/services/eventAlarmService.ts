namespace WoMoCo.Services {
    export class EventAlarmService {

        public getAllEventAlarms() {
            return this.$resource(`/api/eventAlarms`).query();
        }

        public saveEventAlarm(eventAlarm) {
            return this.$resource(`/api/eventAlarms`).save(eventAlarm).$promise
                .then(() => {
                    eventAlarm = null;
                });
        }

        public setEventAlarm(eventAlarm, calenderEvent) {
            //console.log(eventAlarm);
            //console.log(calenderEvent);
            // get the date and time from the calender Event
            let eventDateTime = calenderEvent.eventDate;
            console.log(eventDateTime);
        }

        constructor(
            private $resource: angular.resource.IResourceService
        ) {

        }
    }
    angular.module(`WoMoCo`).service(`eventAlarmService`, EventAlarmService);
}