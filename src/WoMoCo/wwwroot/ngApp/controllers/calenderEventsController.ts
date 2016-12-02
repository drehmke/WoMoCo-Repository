namespace WoMoCo.Controllers {
    export class CalenderEventsController {
        public calenderEvents;

        public getAllCalenderEvents() {
            return this.calenderEventService.getAllCalenderEvents();
        }

        constructor(private calenderEventService: WoMoCo.Services.CalenderEventService) {
            this.calenderEvents = this.getAllCalenderEvents();
        }
    }
    angular.module(`WoMoCo`).controller(`CalenderEventsController`, CalenderEventsController);

    export class CalenderAddEventController {
        public calenderEvent;
        public eventDate;
        public eventTime;

        public saveEvent() {
            // becuase the form fields didn't let me do a datetime picker in one field, I broke them out
            this.calenderEvent.eventDateTime = this.calenderEventService.combineEventDateTime(this.eventDate, this.eventTime);

            this.calenderEventService.saveCalenderEvent(this.calenderEvent)
                .then(() => {
                this.calenderEvent = null;
                this.$state.go(`calenderEvents`);
                })
        }

        constructor(
            private calenderEventService: WoMoCo.Services.CalenderEventService,
            private $state: ng.ui.IStateService
        ) {
        }
    }
    angular.module(`WoMoCo`).controller(`CalenderAddEventController`, CalenderAddEventController);

    export class CalenderViewEventController {
        public calenderEvent;

        public getCalenderEvent(id: number) {
            this.calenderEvent = this.calenderEventService.getCalenderEventById(id);
        }

        constructor(
            private calenderEventService: WoMoCo.Services.CalenderEventService,
            private $stateParams: ng.ui.IStateParamsService
        ) {
            this.getCalenderEvent($stateParams[`id`]);
        }
    }
    angular.module(`WoMoCo`).controller(`CalenderViewEventController`, CalenderViewEventController);

    export class CalenderEditEventController {
        public calenderEvent;
        public eventDate;
        public eventTime;

        public getCalenderEvent(id: number) {
            //this.calenderEvent = this.calenderEventService.getCalenderEventById(id);
            let tmpEvent = this.calenderEventService.getCalenderEventById(id);
            console.log(tmpEvent);
            this.calenderEvent = tmpEvent;
            //this.eventDate = tmpEvent.eventDateTime;
            /*
            console.log(this.calenderEvent);
            console.log(this.calenderEvent.eventDateTime);
            if (this.calenderEvent != null) {
                // break apart the calenderEvent.eventDateTime to fill in eventDate and eventTime
                this.eventDate = this.calenderEventService.isolateDate(this.calenderEvent.eventDateTime);
                this.eventTime = this.calenderEventService.isolateTime(this.calenderEvent.eventDateTime);
            }
            */
        }


        public saveCalenderEvent() {
            // don't forget to update the date
            this.calenderEvent.eventDateTime = this.calenderEventService.combineEventDateTime(this.eventDate, this.eventTime);
            this.calenderEventService.saveCalenderEvent(this.calenderEvent).then(() => {
                    this.calenderEvent = null;
                    this.$state.go(`calenderEvents`);
                });
        }

        constructor(
            private calenderEventService: WoMoCo.Services.CalenderEventService,
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService
        ) {
            this.getCalenderEvent($stateParams[`id`]);
        }
    }
    angular.module(`WoMoCo`).controller(`CalenderEditEventController`, CalenderEditEventController);

    export class CalenderDeleteEventController {
        public calenderEvent;

        public getCalenderEvent(id: number) {
            this.calenderEvent = this.calenderEventService.getCalenderEventById(id);
        }
        public deleteCalenderEvent() {
            this.calenderEventService.deleteCalenderEvent(this.calenderEvent.id).then(() => {
                    this.calenderEvent = null;
                    this.$state.go(`calenderEvents`);
                });
        }

        constructor(
            private calenderEventService: WoMoCo.Services.CalenderEventService,
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService
        ) {
            this.getCalenderEvent($stateParams[`id`]);
        }
    }
    angular.module(`WoMoCo`).controller(`CalenderDeleteEventController`, CalenderDeleteEventController);
}