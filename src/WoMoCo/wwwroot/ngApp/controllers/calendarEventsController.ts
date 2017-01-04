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
        public eventAlarms;

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
            if (this.eventTimeObject.getMinutes() == 0) {
                this.eventDateTime += "00"; // padding zero or it will break
            } else {
                this.eventDateTime += this.eventTimeObject.getMinutes();
            }
            this.eventDateTime += ":";
            if (this.eventTimeObject.getSeconds() == 0) {
                this.eventDateTime += "00"; // padding zero or it will break
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
            this.eventAlarms = eventObject.eventAlarms;
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
        public calendarShared;

        public getAllUserCalendarEvents() {
            return this.calendarEventService.GetCalendarEventsByUser();
        }

        public getSharedEvents() {
            this.calendarShared = this.calendarEventService.GetSharedEventsForUser();
        }

        constructor(private calendarEventService: WoMoCo.Services.CalendarEventService) {
            this.calendarEvents = this.getAllUserCalendarEvents();
            this.getSharedEvents();
        }
    }

    export class CalendarAddEventController {
        public calendarEvent;
        public eventDate;
        public eventTime;
        

        public saveEvent() {
            // becuase the form fields didn't let me do a datetime picker in one field, I broke them out
            //this.calendarEvent.setEventDateTime();
            this.calendarEvent.eventDateTime = this.utilitiesService.combineEventDateTime(this.eventDate, this.eventTime);
            this.calendarEventService.SaveCalendarEvent(this.calendarEvent)
                .then(() => {
                    this.calendarEvent = null;
                    this.$state.go(`profile`);
                });
        }

        constructor(
            private calendarEventService: WoMoCo.Services.CalendarEventService,
            private utilitiesService: WoMoCo.Services.UtilitiesService,
            private $state: ng.ui.IStateService,
        ) {
            
        }
    }
    angular.module(`WoMoCo`).controller(`calendarAddEventController`, CalendarAddEventController);


    class ShareEvent {

        constructor(public userId: string, public calendarEventId: number) { }
    }

    export class CalendarViewEventController {
        public calendarEvent;
        public pulldownUsers;
        public shareWithUserName;
        private ShareResource;
        private eventToShare;

        public shareThisEvent() {
            let eventToShare = new ShareEvent(this.shareWithUserName, this.$stateParams[`id`]);
            this.ShareResource.save(eventToShare).$promise
                .then(() => {
                    eventToShare = null;
                    this.$state.go(`profile`);
                });
        }

        constructor(
            private calendarEventService: WoMoCo.Services.CalendarEventService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService,
            private $resource: angular.resource.IResourceService
        ) {
            this.ShareResource = $resource(`/api/calendarEvents/shareEvent`);
            this.calendarEvent = this.calendarEventService.GetCalendarEventById($stateParams[`id`]);
            this.pulldownUsers = this.calendarEventService.GetUsersForPullDown();
        }
    }
    angular.module(`WoMoCo`).controller(`calendarViewEventController`, CalendarViewEventController);


    export class CalendarEditEventController {
        public GetResource;
        public AlarmResource;
        public calendarEvent: CalendarEvent;
        public eventAlarm: EventAlarm;
        public eventAlarms;

        public GetCalendarEvent(id: number) {
            this.GetResource.get({ id: id }).$promise
                .then((tmpResult) => {
                    this.calendarEvent = new CalendarEvent(tmpResult);
                    //console.log(this.calendarEvent);
                });
        }

        public SaveCalendarEvent() {
            this.calendarEvent.setEventDateTime();
            this.calendarEventService.SaveCalendarEvent(this.calendarEvent).then(() => {
                    this.calendarEvent = null;
                    this.$state.go(`profile`);
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
        public currentCalenderEvent;

        public GetCalendarEvent(id: number) {
            return this.calendarEventService.GetCalendarEventById(id);
        }
        public DeleteCalendarEvent() {
            this.calendarEventService.DeleteCalendarEvent(this.currentCalenderEvent.id).$promise
                .then(() => {
                    this.currentCalenderEvent = null;
                    this.$state.go(`profile`);
                });
        }

        constructor(
            private calendarEventService: WoMoCo.Services.CalendarEventService,
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService,
            private $resource: angular.resource.IResourceService
        ) {
            this.currentCalenderEvent = this.GetCalendarEvent($stateParams[`id`]);
        }
    }
    angular.module(`WoMoCo`).controller(`calendarDeleteEventController`, CalendarDeleteEventController);
}