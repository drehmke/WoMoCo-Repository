namespace WoMoCo.Services {
    export class CalendarMonthService {

        public createMonthView() {
            let today: Date = Date.now();
            let monthTotal = new Date(today.getFullYear(), today.getMonth(), 0).getDate();
            for (let i = 0; i < monthTotal; i++) {
                console.log(i + " - " + new Date(today.getFullYear(), (today.getMonth() + 1), i).getDay());
            }
            //return monthTotal;
        }

        constructor(
            private $resource: angular.resource.IResourceService
        ) {

        }

    }

    angular.module(`WoMoCo`).service('calendarMonthService', CalendarMonthService);
}