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

        /*
        public msgsByUser() {
                    this.MessageService.getMsgsByUser().$promise.then((data) => {
                        this.comms = data.messages;

                    });
                }
        */
        /*
        public deleteMessage(id) {
                    this.MessageService.deleteMessage(id).then(() => {
                        this.msgsByUser();
                    });

                }        
        */
        constructor(private $resource: angular.resource.IResourceService,
                    private MessageService: WoMoCo.Services.MessageService,
                    public $state: ng.ui.IStateService,
                    private accountService: WoMoCo.Services.AccountService) {
                    this.comms = this.getAllComms();          
                }    
    }
}
