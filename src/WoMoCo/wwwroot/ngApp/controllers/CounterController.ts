namespace WoMoCo.Controllers {
    export class CounterController {
        public newMessageCount;

        public getNewMessageCount() {
            this.$http.get(`/api/comms/GetUserNewMessageCount/`).then((results) => {
                this.newMessageCount = results.data;
            })
        }

        constructor(private $http: ng.IHttpService) {
            this.getNewMessageCount();
        }
    }
    angular.module(`WoMoCo`).controller(`CounterController`, CounterController);
}