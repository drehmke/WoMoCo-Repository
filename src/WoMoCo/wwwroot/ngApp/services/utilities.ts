namespace WoMoCo.Services {
    export class UtilitiesService {
        static combineEventDateTime(dateToUse, timeToUse) {

            let test = dateToUse.getFullYear() + "-" + dateToUse.getMonth() + "-" + dateToUse.getDate() + "T";
            test += timeToUse.getHours() + ":" + timeToUse.getMinutes();
            return test;
        }

        static isolateDate(eventDateTime) {
            console.log(eventDateTime);
            let justDate = new Date();
            justDate.setMonth(eventDateTime.getMonth());
            justDate.setDate(eventDateTime.getDate());
            justDate.setFullYear(eventDateTime.getFullYear());
            return justDate;
        }

        static isolateTime(eventDateTime) {
            let justTime = new Date();
            justTime.setHours(eventDateTime.getHours());
            justTime.setMinutes(eventDateTime.getMinutes());
            return justTime;
        }
    }

    angular.module(`WoMoCo`).service(`utils`, UtilitiesService);
}