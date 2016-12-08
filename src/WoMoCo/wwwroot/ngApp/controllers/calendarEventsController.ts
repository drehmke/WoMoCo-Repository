namespace WoMoCo.Controllers {

    class CalendarEvent {
        public id: number;
        public name: string;
        public eventDate: string;
        public eventDateObject: Date;
        public eventTime: string;
        public eventTimeObject: Date;
        public location: string;
        public eventType: string;
        public isActive: boolean;
        public ownerName: string;

        public splitTime(timeString: string) {
            let stringBits = timeString.split(':');
            return stringBits;
        }

        constructor(eventObject) {
            this.id = eventObject.id;
            this.name = eventObject.name;
            this.eventDate = eventObject.eventDate;
            this.eventTime = eventObject.eventTime;
            this.location = eventObject.location;
            this.eventType = eventObject.eventType;
            this.isActive = eventObject.isActive;
            this.ownerName = eventObject.ownerName;
            this.eventDateObject = new Date(this.eventDate);
            if (this.eventTime != null) {
                let timeBits = this.splitTime(this.eventTime);
                this.eventTimeObject = new Date(null, null, null, parseInt(timeBits[0]), parseInt(timeBits[1]), parseInt(timeBits[2]));
            }
        }
    }

    class EventAlarm {

        constructor(
            public id: number,
            public method: string,
            public offsetTime: number,
            public offsetPeriod: string) {

        }
    }

    export class CalendarEventsController {
        public calendarEvents;

        public getAllCalendarEvents() {
            return this.calendarEventService.GetAllCalendarEvents();
        }

        constructor(private calendarEventService: WoMoCo.Services.CalendarEventService) {
            this.calendarEvents = this.getAllCalendarEvents();
        }
    }
    angular.module(`WoMoCo`).controller(`calendarEventsController`, CalendarEventsController);

    export class CalendarUserEventsController {
        public calendarEvents;

        public getAllUserCalendarEvents() {
            return this.calendarEventService.GetCalendarEventsByUser();
        }

        constructor(private calendarEventService: WoMoCo.Services.CalendarEventService) {
            this.calendarEvents = this.getAllUserCalendarEvents();
        }
    }

    export class CalendarAddEventController {
        public calendarEvent;
        public eventDate;
        public eventTime;

        public saveEvent() {
            // becuase the form fields didn't let me do a datetime picker in one field, I broke them out
            // this.calendarEvent.eventDateTime = this.calendarEventService.combineEventDateTime(this.eventDate, this.eventTime);
            this.calendarEvent.eventDateTime = this.utilitiesService.combineEventDateTime(this.eventDate, this.eventTime);

            this.calendarEventService.SaveCalendarEvent(this.calendarEvent)
                .then(() => {
                    this.calendarEvent = null;
                    this.$state.go(`calendarEvents`);
                });
        }

        constructor(
            private calendarEventService: WoMoCo.Services.CalendarEventService,
            private $state: ng.ui.IStateService,
            private utilitiesService: WoMoCo.Services.UtilitiesService
        ) {
        }
    }
    angular.module(`WoMoCo`).controller(`calendarAddEventController`, CalendarAddEventController);

    export class CalendarViewEventController {
        public calendarEvent;

        constructor(
            private calendarEventService: WoMoCo.Services.CalendarEventService,
            private $stateParams: ng.ui.IStateParamsService,
        ) {
            this.calendarEvent = this.calendarEventService.GetCalendarEventById($stateParams[`id`]);
        }
    }
    angular.module(`WoMoCo`).controller(`calendarViewEventController`, CalendarViewEventController);

    export class CalendarEditEventController {
        public calendarEvent: CalendarEvent;
        public GetResource;
        // alarm properties
        public eventAlarm: EventAlarm;

        public GetCalendarEvent(id: number) {
            this.GetResource.get({ id: id }).$promise
                .then((tmpResult) => {
                    this.calendarEvent = new CalendarEvent(tmpResult);
                });
        }


        public SaveCalendarEvent() {
            // don't forget to update the date - FIX ME BEFORE YOU SAVE
            //this.calendarEvent.eventDateTime = this.utilitiesService.combineEventDateTime(this.eventDate, this.eventTime);
            this.calendarEventService.SaveCalendarEvent(this.calendarEvent).then(() => {
                    this.calendarEvent = null;
                    this.$state.go(`calendarEvents`);
                });
        }

        public SaveNewAlarm() {
            //let newAlarm = new EventAlarm(0, this.alarmMethod, this.alarmOffSetTime, this.alarmOffSetPeriod);
            //this.eventAlarmService.setEventAlarm(newAlarm, this.calendarEvent);
            /*
            console.log(this.alarmMethod);
            console.log(this.alarmOffSetTime);
            console.log(this.alarmOffSetPeriod);
            console.log(this.calendarEvent.eventDate);
            console.log(this.calendarEvent.eventTime);
            */
        }

        constructor(
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService,
            private calendarEventService: WoMoCo.Services.CalendarEventService,
            private eventAlarmService: WoMoCo.Services.EventAlarmService,
            private utilitiesService: WoMoCo.Services.UtilitiesService,
            private $resource: angular.resource.IResourceService
        ) {
            this.GetResource = $resource(`/api/calendarEvents/:id`);
            this.GetCalendarEvent($stateParams[`id`]);
        }
    }
    angular.module(`WoMoCo`).controller(`calendarEditEventController`, CalendarEditEventController);

    export class CalendarDeleteEventController {
        public calendarEvent;

        public GetCalendarEvent(id: number) {
            this.calendarEvent = this.calendarEventService.GetCalendarEventById(id);
        }
        public DeleteCalendarEvent() {
            this.calendarEventService.DeleteCalendarEvent(this.calendarEvent.id).then(() => {
                    this.calendarEvent = null;
                    this.$state.go(`calendarEvents`);
                });
        }

        constructor(
            private calendarEventService: WoMoCo.Services.CalendarEventService,
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService
        ) {
            this.GetCalendarEvent($stateParams[`id`]);
        }
    }
    angular.module(`WoMoCo`).controller(`calendarDeleteEventController`, CalendarDeleteEventController);
}