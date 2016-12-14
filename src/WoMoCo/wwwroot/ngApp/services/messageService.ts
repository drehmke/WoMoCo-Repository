namespace WoMoCo.Services {

    export class MessageService {
        public MessageResource;

        public getAllComms() {
            return this.$resource(`/api/comms`).query();
        }
        public getCommById(id: number) {
            return this.MessageResource.get({ id: id });
            
        }
        public saveComm(comm) {
            return this.$resource(`/api/comms`).save(comm).$promise.then(() => {
                comm = null;
            });
        }

       
      

        public getMsgsByUser() {
            return this.MessageResource.getMsgsByUser();
        }

        
        
        
        //save message

        public sendMessage(messageToSend) {
            return this.MessageResource.save(messageToSend).$promise;
                
         
        }

        //delete message
        public deleteMessage(id) {
           return this.MessageResource.delete({ id: id }).$promise;
        }

        constructor(private $resource: angular.resource.IResourceService,
            public $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {
            //this.MessageResource = $resource('/api/comms')
            this.MessageResource = $resource('/api/comms/:id')
            //    , null, {
            //    getMsgsByUser: {
            //        method: 'GET',
            //        url: '/api/message/getMsgsByUser',
            //        isArray: false
            //    }
            //});
        }
    }
    angular.module('WoMoCo').service('MessageService', MessageService);
}
