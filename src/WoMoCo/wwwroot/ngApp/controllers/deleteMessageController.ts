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

    export class DeleteMessageAdminController {
        public comm;

        public getComm(id: number) {
            return this.MessageService.getCommByIdAdmin(id);
        }

        public deleteCommById() {
            //console.log(this.comm);
            this.MessageService.deleteCommByIdAdmin(this.comm.id);
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            private $stateParams: ng.ui.IStateParamsService,
            private MessageService: WoMoCo.Services.MessageService
        ) {
            this.comm = this.getComm($stateParams[`id`]);
        }
    } 
        
}