namespace WoMoCo.Controllers {
    
    class EventAlarm {
        public id: number;
        public alarmMethod: string;
        public alarmTime: Date;
        public isActive: boolean;
        public offsetTime: number;
        public offsetPeriod: string;
        public calenderEventId: number;
        public ownerName: string;

        constructor(eventAlarm) {
            this.id = eventAlarm.id;
            this.alarmMethod = eventAlarm.alarmMethod;
            this.alarmTime = eventAlarm.alarmTime;
            this.isActive = eventAlarm.isActive;
            this.offsetTime = eventAlarm.offsetTime;
            this.offsetPeriod = eventAlarm.offsetPeriod;
            this.calenderEventId = eventAlarm.calenderEventId;
            this.ownerName = eventAlarm.ownerName;
        }
    }
    
    export class EventAlarmController {
        public alarmsList;

        public getAllAlarms() {
            return this.eventAlarmService.getAllEventAlarms();
        }

        constructor(
            private eventAlarmService: WoMoCo.Services.EventAlarmService
        ) {
            this.alarmsList = this.getAllAlarms();
            //console.log(this.alarmsList);
        }
    }
    angular.module(`WoMoCo`).controller(`eventAlarmController`, EventAlarmController);

    export class EventDeleteAlarmController {
        //public eventAlarm;

        public DeleteAlarm(id: number, eventid: number) {
            this.eventAlarmService.deleteAlarm(id).$promise
                .then(() => {
                    this.$state.go(`calendar`, eventid);
                });
        }

        constructor(
            private eventAlarmService: WoMoCo.Services.EventAlarmService,
            private $state: angular.ui.IStateService,
            private $stateParams: angular.ui.IStateParamsService
        ) {
            this.DeleteAlarm($stateParams[`id`], $stateParams[`eventId`]);
        }
    }

    // Shouldn't need this ... this is just to test basic editablility
    export class EventAddAlarmController {
        public eventAlarm: EventAlarm;

        public SaveNewAlarm() {
            console.log(this.eventAlarm);
            this.eventAlarmService.saveEventAlarm(this.eventAlarm)
                .then(() => {
                    this.eventAlarm = null;
                    this.$state.go(`eventAlarms`);
                });
        }

        constructor(
            private eventAlarmService: WoMoCo.Services.EventAlarmService,
            private $state: angular.ui.IStateService
        ) {

        }
    }
    angular.module(`WoMoCo`).controller(`eventAddAlarmController`, EventAddAlarmController);
}