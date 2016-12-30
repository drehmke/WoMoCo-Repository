namespace WoMoCo.Controllers {

    export class InfoMessageController {
        
        public comm;
        
        public getComm(id) {
           this.comm =  this.MessageService.getCommById(id);
            
            
        }


        constructor(private $resource: angular. resource.IResourceService,
            private MessageService: WoMoCo.Services.MessageService,
            public $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService,
            private accountService: WoMoCo.Services.AccountService) {            
            this.getComm($stateParams[`id`]);       


            this.getComm($stateParams[`id`]);
        }

    }

    export class InforMessageAdminController {
        public comm;

        public getCommAdmin(id) {
            return this.MessageService.getCommById(id);
        }

        constructor(
            private MessageService: WoMoCo.Services.MessageService,
            private $stateParams: ng.ui.IStateParamsService
        ) {
            this.comm = this.getCommAdmin($stateParams[`id`]);
        }
    }
}