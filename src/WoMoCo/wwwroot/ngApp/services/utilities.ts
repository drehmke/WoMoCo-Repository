namespace WoMoCo.Services {
    export class UtilitiesService {
        public combineEventDateTime(dateToUse, timeToUse) {
            let test = dateToUse.getFullYear() + "-" + (dateToUse.getMonth() + 1) + "-" + dateToUse.getDate();
            test += "T";
            if (timeToUse.getHours() < 10) {
                test += "0" + timeToUse.getHours(); // padding zero or it won't recognize AM
            } else {
                test += timeToUse.getHours();
            }
            test += ":";
            if (timeToUse.getMinutes() == 0) {
                test += "00"; // padding zero or it will break
            } else {
                test += timeToUse.getMinutes();
            }
            test += ":";
            if (timeToUse.getSeconds() == 0) {
                test += "00"; // padding zero or it will break
            } else {
                test += timeToUse.getSeconds();
            }
            return test;
        }
    }

    angular.module(`WoMoCo`).service(`utilitiesService`, UtilitiesService);
}