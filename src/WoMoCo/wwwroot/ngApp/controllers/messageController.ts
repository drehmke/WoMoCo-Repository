namespace WoMoCo.Controllers {

    export class MessageController {
        
        public MessageResource;
        public friendRequests;
        public comms;
        public comm;
        public getAllComms() {
            return this.MessageService.getAllComms();
            
        }           

        public saveComm() {
            this.MessageResource.save(this.comm).$promise.then(() => {

                this.$state.go('inbox');
            });

        }        
       
        constructor(private $resource: angular.resource.IResourceService,
            private MessageService: WoMoCo.Services.MessageService,
            public $state: ng.ui.IStateService,
            private $uibModal: angular.ui.bootstrap.IModalService,
            private accountService: WoMoCo.Services.AccountService) {
            this.comms = this.getAllComms();          

            
        }
        
    }    

}
