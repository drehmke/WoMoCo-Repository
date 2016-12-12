namespace WoMoCo.Controllers {

    export class InfoMessageController {
        public messageDetails;

        constructor(private MessageService: WoMoCo.Services.MessageService, private $stateParams: ng.ui.IStateParamsService) {
           // this.messageDetails = this.messageService.getMessageInfo($stateParams['id']);
        }
    }
}