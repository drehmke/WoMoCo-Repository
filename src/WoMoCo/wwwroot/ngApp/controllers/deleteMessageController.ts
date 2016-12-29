namespace WoMoCo.Controllers {

    export class DeleteMessageController {
        
        public comm;
        public getComm(id) {
            this.comm = this.MessageService.getCommById(id);
        }

        public deleteCommById() {
            
            this.comm = this.MessageService.deleteCommById(this.comm);
        }    
        constructor(private $resource: angular.resource.IResourceService,
        private MessageService: WoMoCo.Services.MessageService,
        public $stateParams: ng.ui.IStateParamsService,
        private $state: ng.ui.IStateService,
        private accountService: WoMoCo.Services.AccountService) {
        this.getComm($stateParams[`id`]);

        }

    }   
        
}