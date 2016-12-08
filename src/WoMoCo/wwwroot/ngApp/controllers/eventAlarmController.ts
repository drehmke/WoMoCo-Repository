namespace WoMoCo.Controllers {
    export class EventAlarmsController {
        public alarmsList;

        public getAllAlarms() {
            return this.eventAlarmService.getAllEventAlarms();
        }

        constructor(
            private eventAlarmService: WoMoCo.Services.EventAlarmService
        ) {
            this.alarmsList = this.getAllAlarms();
        }
    }
    angular.module(`WoMoCo`).controller(`eventAlarmsController`, EventAlarmsController);

}