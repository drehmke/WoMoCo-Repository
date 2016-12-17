namespace WoMoCo.Controllers {

    export class CreateMessageController {
        public MessageResource;
        public comm;
      
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
        public saveComm() {
            this.MessageResource.save(this.comm).$promise.then(() => {
                
                this.$state.go('inbox');
            })           
           
        }
          constructor(private $resource: angular.resource.IResourceService,
            public $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService,
            private accountService: WoMoCo.Services.AccountService) {
            this.MessageResource = this.$resource('/api/comms');               
                
        }
        
    }     

}

