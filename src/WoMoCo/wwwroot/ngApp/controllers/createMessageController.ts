namespace WoMoCo.Controllers {

    export class CreateMessageController {
        public messageToSend;
        public message;
        public msg;

        //Message Modal 
        public messageModal(messageId) {
            this.$uibModal.open({
                templateUrl: '/ngApp/views/modal/messageModal.html',
                controller: WoMoCo.Controllers.CreateMessageController,
                controllerAs: 'c',
                resolve: {
                    messageId: () => messageId
                },
                size: 'lg'
            });
        }
        constructor(private messageService: WoMoCo.Services.MessageService,
            private userId, private accountService: WoMoCo.Services.AccountService,
            private $state: angular.ui.IStateService,
            private $uibModal: angular.ui.bootstrap.IModalServiceInstance) {

        }

        public sendMessage() {
            this.messageToSend.recId = this.userId;
            this.messageToSend.sendingUser = this.accountService.getUserName();
            this.messageService.sendMessage(this.messageToSend).
                then(() => {
                    this.$uibModal.close();
                })
                .catch(() => {
                    console.log("Message didnt Save");
                })
        }

        public exit() {
            this.$uibModal.close();
        }
    }
}