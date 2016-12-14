namespace WoMoCo.Controllers {

    export class InfoMessageController {
        
        public comm;
        
        public getComm(id) {
           this.comm =  this.MessageService.getCommById(id);
            console.log(this.comm);
            
        }

        constructor(private $resource: angular. resource.IResourceService,
            private MessageService: WoMoCo.Services.MessageService,
            public $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {
            
            this.getComm($stateParams[`id`]);
       

        }
    }
}