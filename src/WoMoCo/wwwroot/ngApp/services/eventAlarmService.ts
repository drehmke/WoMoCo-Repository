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

        constructor(
            private $resource: angular.resource.IResourceService
        ) {

        }
    }
    angular.module(`WoMoCo`).service(`eventAlarmService`, EventAlarmService);
}