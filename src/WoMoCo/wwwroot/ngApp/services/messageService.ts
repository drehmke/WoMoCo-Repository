namespace WoMoCo.Services {

    export class MessageService {
        public MessageResource;
        public MessageAdminResource;
        public comm;
        
        
        //get all Comms
        public getAllComms() {
            return this.$resource(`/api/comms`).query();
        }

        public getAllCommsAdmin() {
            return this.$resource(`/api/comms/`).query();
        }
       

        //get Comm By Id
        public getCommById(id: number) {
            return this.MessageResource.get({ id: id });
        }

        public getCommByIdAdmin(id: number) {
            return this.MessageAdminResource.get({ id: id });
        }
        //delete message
        public deleteCommById(id: number) {
            this.MessageResource.delete(id).$promise.then(() => {
                this.comm = null;
                this.$state.go(`inbox`);
            })
        }

        public deleteCommByIdAdmin(id: number) {
            this.MessageAdminResource.delete({ id: id }).$promise
                .then(() => {
                    this.comm = null;
                    this.$state.go(`messageAdmin`);
                });
        }

        constructor(private $resource: angular.resource.IResourceService,
            public $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService,
            private accountService: WoMoCo.Services.AccountService) {            
            this.MessageResource = $resource('/api/comms/:id');
            this.MessageAdminResource = $resource(`/api/comms/AdminGet/:id`);
          }           
    }
    angular.module('WoMoCo').service('MessageService', MessageService);
}
