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
        public test;
        public validationMessages;

        public saveEvent() {
            // becuase the form fields didn't let me do a datetime picker in one field, I broke them out
            console.log(this.test);
            //let eventDateTime = new Date();

            /*
            this.calenderEventService.saveCalenderEvent(this.calenderEvent)
                .then(() => {
                this.calenderEvent = null;
                this.$state.go(`calenderEvents`);
                })
            */
        }

        constructor(
            private calenderEventService: WoMoCo.Services.CalenderEventService,
            private $state: ng.ui.IStateService
        ) {
        }
    }
}