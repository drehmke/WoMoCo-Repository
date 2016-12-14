namespace WoMoCo.Controllers {

    export class DeleteMessageController {

        public messageToDelete;
        private messageId;
        constructor(private $stateParams: angular.ui.IStateParamsService, private $state: angular.ui.IStateService, private MessageService: WoMoCo.Services.MessageService) {
            this.messageId = this.$stateParams['messageId'];
            //this.getMessage();
        }

        //public getMessage() {
        //    this.messageToDelete = this.MessageService.getMessageInfo(this.messageId);
        //}

        public deleteMessage() {
            this.MessageService.deleteMessage(this.messageId)
                .then(() => {
                    this.$state.go('inbox');
                })
                .catch(() => {
                    console.log("something went wrong!");
                });
        }
    }
}