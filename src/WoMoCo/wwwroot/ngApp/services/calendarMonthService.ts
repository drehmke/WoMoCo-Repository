namespace WoMoCo.Services {

    export class CalendarMonthService {

        public createMonthView() {
            let today: Date = new Date();
            let monthTotal = new Date(today.getFullYear(), today.getMonth(), 0).getDate();
            let sundays = [];
            let mondays = [];
            let tuesdays = [];
            let wednesdays = [];
            let thursdays = [];
            let fridays = [];
            let saturdays = [];
            for (let i = 0; i < monthTotal; i++) {
                
                switch (new Date(today.getFullYear(), (today.getMonth() + 1), i).getDay())
                {
                    case 0:
                        sundays.push(new Date(today.getFullYear(), (today.getMonth() + 1), i).getDate());
                        break;
                    case 1:
                        mondays.push(new Date(today.getFullYear(), (today.getMonth() + 1), i).getDate());
                        break;
                    case 2:
                        tuesdays.push(new Date(today.getFullYear(), (today.getMonth() + 1), i).getDate());
                        break;
                    case 3:
                        wednesdays.push(new Date(today.getFullYear(), (today.getMonth() + 1), i).getDate());
                        break;
                    case 4:
                        thursdays.push(new Date(today.getFullYear(), (today.getMonth() + 1), i).getDate());
                        break;
                    case 5:
                        fridays.push(new Date(today.getFullYear(), (today.getMonth() + 1), i).getDate());
                        break;
                    case 6:
                        saturdays.push(new Date(today.getFullYear(), (today.getMonth() + 1), i).getDate());
                        break;
                }
            }
            console.log(sundays);
            console.log(mondays);
            console.log(tuesdays);
            console.log(wednesdays);
            console.log(thursdays);
            console.log(fridays);
            console.log(saturdays);
            //return monthTotal;
        }



        constructor(
            private $resource: angular.resource.IResourceService
        ) {

        }

    }

    angular.module(`WoMoCo`).service('calendarMonthService', CalendarMonthService);
}