namespace WoMoCo.Controllers {

    export class InfoMessageController {
        
        public comm;
        
        public getComm(id) {
           this.comm =  this.MessageService.getCommById(id);
            
            
        }
        ////modal 
        //public messageModal(commId) {
        //    this.$uibModal.open({
        //        templateUrl: '/ngApp/views/message/modal/messageModal.html',
        //        controller: WoMoCo.Controllers.CreateMessageController,
        //        controllerAs: 'controller',
        //        resolve: {
        //            commId: () => commId
        //        },
        //        size: 'lg'
        //    });
        //}
        


        constructor(private $resource: angular. resource.IResourceService,
            private MessageService: WoMoCo.Services.MessageService,
            public $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService
            /*public $uibModal: angular.ui.bootstrap.IModalService*/) {            
            this.getComm($stateParams[`id`]);
       

        }
    }
}