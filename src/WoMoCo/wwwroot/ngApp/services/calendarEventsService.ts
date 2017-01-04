namespace WoMoCo.Services {

    export class CalendarEventService {
        private getEventsByUserResource;
        private getPullDownResource;
        private getSharedEventsResource;
        private getCalendarAdminFiveResource;

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
            // return this.$resource(`/api/calendarEvents/:id`).get({id: id});
            let tempResource = this.$resource(`/api/calendarEvents/:id`);
            let tempResult = tempResource.get({ id: id });
            //console.log(tempResult);
            return tempResult;
        }

        public GetCalendarEventsByUser() {
            let tempList = this.getEventsByUserResource.getMyEvents();
            //console.log(tempList);
            return tempList;
        }

        public GetUsersForPullDown() {
            let tempResults = this.getPullDownResource.getUsersForPulldown();
            //console.log(tempResults);
            return tempResults;
        }

        public GetFirstFiveForAdminPage() {
            let tempResults = this.getCalendarAdminFiveResource.getAdminFive();
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
            this.getCalendarAdminFiveResource = $resource(`/api/calenderEvents,`, null, {
                getAdminFive: {
                    method: `GET`,
                    url: `/api/calendarEvents/GetAdminFirstFive`,
                    isArray: true
                }
            });
        }
    }

    angular.module('WoMoCo').service('calendarEventService', CalendarEventService);
}