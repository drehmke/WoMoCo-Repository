namespace WoMoCo.Controllers {
    // NOTES: Edit event date is showing one day off on the edit form.
    class CalendarEvent {
        public id: number;
        public name: string;
        public eventDate: string;
        public eventDateObject: Date;
        public eventTime: string;
        public eventTimeObject: Date;
        public eventDateTime: string;
        //public createdDate: Date;
        public location: string;
        public eventType: string;
        public isActive: boolean;
        public ownerName: string;

        public setEventDateTime() {
            //2016-12-08T11:05:20.0926197
            this.eventDateTime = this.eventDateObject.getFullYear() + "-" + (this.eventDateObject.getMonth()+1) + "-" + this.eventDateObject.getDate();
            this.eventDateTime += "T";
            if (this.eventTimeObject.getHours() < 10) {
                this.eventDateTime += "0" + this.eventTimeObject.getHours(); // padding zero or it won't recognize AM
            } else {
                this.eventDateTime += this.eventTimeObject.getHours();
            }
            this.eventDateTime += ":";
            //this.eventDateTime += this.eventTimeObject.getHours() + ":";
            if (this.eventTimeObject.getMinutes() == 0) {
                this.eventDateTime += "00"; // padding zero or it will break
            } else {
                this.eventDateTime += this.eventTimeObject.getMinutes();
            }
            this.eventDateTime += ":";
            if (this.eventTimeObject.getSeconds() == 0) {
                this.eventDateTime += "00"; // padding zerio or it will break
            } else {
                this.eventDateTime += this.eventTimeObject.getSeconds();
            }
            
        }

        public splitTime(timeString: string) {
            let stringBits = timeString.split(':');
            return stringBits;
        }

        constructor(eventObject) {
            this.id = eventObject.id;
            this.name = eventObject.name;
            this.eventDate = eventObject.eventDate;
            this.eventTime = eventObject.eventTime;
            this.eventDateTime = eventObject.DateTime;
            this.location = eventObject.location;
            this.eventType = eventObject.eventType;
            this.isActive = eventObject.isActive;
            this.ownerName = eventObject.ownerName;
            //this.createdDate = new Date(eventObject.createDate);
            this.eventDateObject = new Date(this.eventDate);
            console.log(this.eventDateObject);
            if (this.eventTime != null) {
                let timeBits = this.splitTime(this.eventTime);
                this.eventTimeObject = new Date(null, null, null, parseInt(timeBits[0]), parseInt(timeBits[1]), parseInt(timeBits[2]));
            }
        }
    }

    class EventAlarm {
        public id: number;
        public alarmMethod: string;
        public alarmTime: Date;
        public isActive: boolean;
        public offsetTime: number;
        public offsetPeriod: string;
        public calenderEventId: number;
        public ownerName: string;

        constructor( eventAlarm ) {
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
        public calendarEvent: CalendarEvent;

        public saveEvent() {
            // becuase the form fields didn't let me do a datetime picker in one field, I broke them out
            this.calendarEvent.setEventDateTime();
            this.calendarEventService.SaveCalendarEvent(this.calendarEvent)
                .then(() => {
                    this.calendarEvent = null;
                    this.$state.go(`calendarEvents`);
                });
        }

        constructor(
            private calendarEventService: WoMoCo.Services.CalendarEventService,
            private $state: ng.ui.IStateService,
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
        public GetResource;
        public AlarmResource;
        public calendarEvent: CalendarEvent;
        public eventAlarm: EventAlarm;

        public GetCalendarEvent(id: number) {
            this.GetResource.get({ id: id }).$promise
                .then((tmpResult) => {
                    this.calendarEvent = new CalendarEvent(tmpResult);
                    console.log(this.calendarEvent);
                });
        }
        
        public SaveCalendarEvent() {
            this.calendarEvent.setEventDateTime();
            this.calendarEventService.SaveCalendarEvent(this.calendarEvent).then(() => {
                    this.calendarEvent = null;
                    this.$state.go(`calendarEvents`);
                });
            
        }

        public SaveNewAlarm() {
            let alarmToSave = new EventAlarm(this.eventAlarm);
            alarmToSave.calenderEventId = this.calendarEvent.id;
            console.log(alarmToSave);
            this.eventAlarmService.saveEventAlarm(alarmToSave)
                .then(() => {
                    alarmToSave = null;
                    this.eventAlarm = null;
                });
            
        }

        constructor(
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService,
            private $resource: angular.resource.IResourceService,
            private calendarEventService: WoMoCo.Services.CalendarEventService,
            private eventAlarmService: WoMoCo.Services.EventAlarmService
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