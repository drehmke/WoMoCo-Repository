namespace WoMoCo.Controllers {

    export class MessageController {
        public messages;
        public friendRequests;

        constructor(private messageService: WoMoCo.Services.MessageService,
            private $state: angular.ui.IStateService,
            private $uibModal: angular.ui.bootstrap.IModalService) {
            this.msgsByUser();
            
            
        }

        public msgsByUser() {
            this.messageService.getMsgsByUser().$promise.then((data) => {
                this.messages = data.messages;
                console.log(this.messages);
            });
        }
              



        public deleteMessage(id) {
            this.messageService.deleteMessage(id).then(() => {
                this.msgsByUser();
            });
        }

        
    }
    

}
