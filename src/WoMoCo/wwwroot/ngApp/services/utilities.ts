namespace WoMoCo.Services {
    export class UtilitiesService {
        public combineEventDateTime(dateToUse, timeToUse) {
            let test = dateToUse.getFullYear() + "-" + dateToUse.getMonth() + "-" + dateToUse.getDate() + "T";
            test += timeToUse.getHours() + ":";
            if (timeToUse.getMinutes() == "0" || timeToUse.getMinutes() == "00") {
                test += "00"
            } else {
                test += timeToUse.getMinutes();
            }
            test += ":";
            if (timeToUse.getSeconds() == "0" || timeToUse.getSeconds() == "00") {
                test += "00";
            } else {
                test += timeToUse.getSeconds();
            }
            return test;
        }
    }

    angular.module(`WoMoCo`).service(`utilitiesService`, UtilitiesService);
}