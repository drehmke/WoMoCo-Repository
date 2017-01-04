namespace WoMoCo.Controllers {

    export class MessageController {

        public MessageResource;
        
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
                    private accountService: WoMoCo.Services.AccountService) {
                    this.comms = this.getAllComms();
                             
                }    
    }

    export class MessageAdminController {
        public comms;

        public getAllComms() {
            return this.MessageService.getAllCommsAdmin();
        }

        constructor(
            private MessageService: WoMoCo.Services.MessageService
        ) {
            this.comms = this.getAllComms();
            //console.log(this.comms);
        }
    }
}
