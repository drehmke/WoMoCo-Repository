namespace WoMoCo.Controllers {

    export class MessageController {
        
        public MessageResource;
        public friendRequests;
        public comms;
       

        public getAllComms() {
            return this.MessageService.getAllComms();
            
        }               
           
                  
        
        public deleteMessage(id) {
            this.MessageService.deleteMessage(id).then(() => {
                
            });
        }

        //modal >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public comm;
        public saveComm() {
            this.MessageResource.save(this.comm).$promise.then(() => {

                this.$state.go('inbox');
            });

        }        
        public messageModal(commId) {
            this.$uibModal.open({
                templateUrl: '/ngApp/views/message/modal/messageModal.html',
                controller: WoMoCo.Controllers.CreateMessageController,
                controllerAs: 'controller',
                resolve: {
                    commId: () => commId
                },
                size: 'lg'
            });
        }
        //modal>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        constructor(private $resource: angular.resource.IResourceService,
            private MessageService: WoMoCo.Services.MessageService,
            public $state: ng.ui.IStateService,
            private $uibModal: angular.ui.bootstrap.IModalService) {
            
            this.comms = this.getAllComms();
            this.MessageResource = this.$resource('/api/comms/:id');           
                  


        }

        
    }
    

}
