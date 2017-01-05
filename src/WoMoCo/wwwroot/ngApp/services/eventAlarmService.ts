namespace WoMoCo.Services {
    export class EventAlarmService {

        public getAllEventAlarms() {
            return this.$resource(`/api/eventAlarm`).query();
            //return this.$resource('/api/calendarEvents').query();
        }

        public saveEventAlarm(eventAlarm) {
            return this.$resource(`/api/eventAlarm`).save(eventAlarm).$promise
                .then(() => {
                    eventAlarm = null;
                });
        }

        public setEventAlarm(eventAlarm, calendarEvent) {
            // get the date and time from the calendar Event
            let eventDateTime = calendarEvent.eventDate;
            //console.log(eventDateTime);
        }

        public getEventAlarm(id: number) {
            return this.$resource(`/api/eventAlarm/:id`).get({ id: id });
        }

        public deleteAlarm(id: number) {
            return this.$resource(`/api/eventAlarm/:id`).delete({ id: id });
        }

        constructor(
            private $resource: angular.resource.IResourceService
        ) {
        }
    }
    angular.module(`WoMoCo`).service(`eventAlarmService`, EventAlarmService);
}