namespace WoMoCo.Services {

    export class MessageService {
        public MessageResource;
        
        
        //get all Comms
        public getAllComms() {
            return this.$resource(`/api/comms`).query();
        }
        //get Comm By Id
        public getCommById(id: number) {
            return this.MessageResource.get({ id: id });
            
        }
      
        //delete message
        public deleteMessage(id) {
            return this.MessageResource.delete({ id: id }).$promise;
        }

        constructor(private $resource: angular.resource.IResourceService,
            public $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {            
            this.MessageResource = $resource('/api/comms/:id');


        }           
         

        
        
        
       

        
    }
    angular.module('WoMoCo').service('MessageService', MessageService);
}
