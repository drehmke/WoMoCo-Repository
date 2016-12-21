namespace WoMoCo.Services {

    class DayElement {
        constructor(public DayName: string, public DayNum: number) {
            this.DayName = DayName;
            this.DayNum = DayNum;
        }
    }

    export class CalendarEventService {
        private getEventsByUserResource;
        private getPullDownResource;
        private getSharedEventsResource;

        public GetAllCalendarEvents() {
            return this.$resource('/api/calendarEvents').query();
        }

        public SaveCalendarEvent(calendarEvent) {
            return this.$resource(`/api/calendarEvents`).save(calendarEvent).$promise
                .then(() => {
                    calendarEvent = null;
                });
        }

        public GetCalendarEventById(id: number) {
            let tempResource = this.$resource(`/api/calendarEvents/:id`);
            let tempResult = tempResource.get({ id: id });
            return tempResult;
        }

        public GetCalendarEventsByUser() {
            let tempList = this.getEventsByUserResource.getMyEvents();
            return tempList;
        }

        public GetUsersForPullDown() {
            let tempResults = this.getPullDownResource.getUsersForPulldown();
            return tempResults;
        }

        public ShareThisEvent(shareCalenderEvent) {
            // Currently not used - the Controller has the API point
            return this.$resource(`/api/calenderEvents/ShareEvent`).save(shareCalenderEvent);
        }

        public GetSharedEventsForUser() {
            return this.getSharedEventsResource.getMyShared();
        }

        public DeleteCalendarEvent(id: number) {
            // I am returning this because the $promise on the controller side needs something returned
            return this.$resource(`/api/calendarEvents/:id`).delete({ id: id });
        }

        /* ---- Calendar Setup Private Functions ---- */
        private getDaysInMonth(month, year) {
            return new Date(year, month, 0).getDate();
        }
        

        /* ---- Calendar Setup Public Function ---- */
        public createViewMonthly(dateToCheck) {
            // create a list for the month 
            // the list will contain 4-5 arrays holding a weekList 
            // Each weekList has 7 day objects
            console.log(dateToCheck);
            let totalMonthDays = new Date(dateToCheck.month, dateToCheck.year, 0).getDate();
            for (let i = 1; i < totalMonthDays; i++) {
                console.log(new Date(dateToCheck.year, (dateToCheck.month - 1), i).getDay());
            }
        }
        
        constructor(
            private $resource: angular.resource.IResourceService
        ) {
            this.getEventsByUserResource = $resource(`/api/calendarEvents`, null, {
                getMyEvents: {
                    method: `GET`,
                    url: `/api/calendarEvents/getMy`,
                    isArray: true
                }
            });
            this.getSharedEventsResource = $resource(`/api/calendarEvents`, null, {
                getMyShared: {
                    method: `GET`,
                    url: `/api/calendarEvents/getMyShared`,
                    isArray: true
                }
            });
            this.getPullDownResource = $resource(`/api/users`, null, {
                getUsersForPulldown: {
                    method: `GET`,
                    url: `/api/users/GetUsersForPulldown`,
                    isArray: true
                }
            });
        }
    }

    angular.module('WoMoCo').service('calendarEventService', CalendarEventService);
}