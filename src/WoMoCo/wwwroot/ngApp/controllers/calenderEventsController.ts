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

    export class CalenderUserEventsController {
        public calenderEvents;

        public getAllUserCalenderEvents() {
            return this.calenderEventService.getCalenderEventsByUser();
        }

        constructor(private calenderEventService: WoMoCo.Services.CalenderEventService) {
            this.calenderEvents = this.getAllUserCalenderEvents();
        }
    }

    export class CalenderAddEventController {
        public calenderEvent;
        public eventDate;
        public eventTime;

        public saveEvent() {
            // becuase the form fields didn't let me do a datetime picker in one field, I broke them out
            // this.calenderEvent.eventDateTime = this.calenderEventService.combineEventDateTime(this.eventDate, this.eventTime);
            this.calenderEvent.eventDateTime = this.utilitiesService.combineEventDateTime(this.eventDate, this.eventTime);

            this.calenderEventService.saveCalenderEvent(this.calenderEvent)
                .then(() => {
                    this.calenderEvent = null;
                    this.$state.go(`calenderEvents`);
                });
        }

        constructor(
            private calenderEventService: WoMoCo.Services.CalenderEventService,
            private $state: ng.ui.IStateService,
            private utilitiesService: WoMoCo.Services.UtilitiesService
        ) {
        }
    }
    angular.module(`WoMoCo`).controller(`CalenderAddEventController`, CalenderAddEventController);

    export class CalenderViewEventController {
        public singleCalenderEvent;

        public getCalenderEvent(id: number) {
            this.singleCalenderEvent = this.calenderEventService.getCalenderEventById(id);
            console.log(this.singleCalenderEvent);
        }

        constructor(
            private calenderEventService: WoMoCo.Services.CalenderEventService,
            private $stateParams: ng.ui.IStateParamsService
        ) {
            this.getCalenderEvent($stateParams[`id`]);
        }
    }
    angular.module(`WoMoCo`).controller(`CalenderViewEventController`, CalenderViewEventController);

    class calenderEvent {
        public id: number;
        public name: string;
        public eventDate: string;
        public eventTime: string;
        public location: string;
        public eventType: string;
        public isActive: boolean;
        public ownerName: string;

        constructor(eventObject) {
            this.id = eventObject.id;
            this.name = eventObject.name;
            this.eventDate = eventObject.eventDate;
            this.eventTime = eventObject.eventTime;
            this.location = eventObject.location;
            this.eventType = eventObject.eventType;
            this.isActive = eventObject.isActive;
            this.ownerName = eventObject.ownerName;
        }
    }

    class eventAlarm {
        
        constructor(
            public id: number,
            public method: string,
            public offsetTime: number,
            public offsetPeriod: string) {

        }
    }

    export class CalenderEditEventController {
        public calenderEvent;
        public eventDate;
        public eventTime;
        public GetResource;
        // alarm properties
        public alarmMethod;
        public alarmOffSetTime;
        public alarmOffSetPeriod;

        public getCalenderEvent(id: number) {
            // this.calenderEvent = this.calenderEventService.getCalenderEventById(id);
            let tmpEvent = this.GetResource.get({ id: id });
            this.calenderEvent = tmpEvent;
            let nonAnonEvent = new calenderEvent(this.calenderEvent);
            //this.calenderEvent = tmpEvent;
            //console.log(nonAnonEvent);
        }


        public saveCalenderEvent() {
            // don't forget to update the date
            this.calenderEvent.eventDateTime = this.utilitiesService.combineEventDateTime(this.eventDate, this.eventTime);
            this.calenderEventService.saveCalenderEvent(this.calenderEvent).then(() => {
                    this.calenderEvent = null;
                    this.$state.go(`calenderEvents`);
                });
        }

        public SaveNewAlarm() {
            let newAlarm = new eventAlarm(0, this.alarmMethod, this.alarmOffSetTime, this.alarmOffSetPeriod);
            this.eventAlarmService.setEventAlarm(newAlarm, this.calenderEvent);
            /*
            console.log(this.alarmMethod);
            console.log(this.alarmOffSetTime);
            console.log(this.alarmOffSetPeriod);
            console.log(this.calenderEvent.eventDate);
            console.log(this.calenderEvent.eventTime);
            */
        }

        constructor(
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService,
            private calenderEventService: WoMoCo.Services.CalenderEventService,
            private eventAlarmService: WoMoCo.Services.EventAlarmService,
            private utilitiesService: WoMoCo.Services.UtilitiesService,
            private $resource: angular.resource.IResourceService
        ) {
            this.GetResource = $resource(`/api/calenderEvents/:id`);
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