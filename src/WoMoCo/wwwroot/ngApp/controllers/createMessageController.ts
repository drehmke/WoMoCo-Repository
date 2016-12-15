﻿namespace WoMoCo.Controllers {

    export class CreateMessageController {
        public MessageResource;
        public comm;
                  
        public saveComm() {
            this.MessageResource.save(this.comm).$promise.then(() => {
                
                this.$state.go('inbox');
            })           
            
        }
        public ok() {
            this.$uibModalInstance.close();
        }
               
        
        constructor(private $resource: angular.resource.IResourceService,
            public $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService,
            private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance) {
             
            this.MessageResource = this.$resource('/api/comms');               
                
        }
        
    }     
}

