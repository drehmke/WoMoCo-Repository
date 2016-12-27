namespace WoMoCo.Controllers {

    export class InboxController {

        public MessageResource;
        public CommsResource;
        public comms;
        public comm;
        
        //get comms by logged In user
        public getCommsByUserName() {
            return this.CommsResource.getCommsByUserName();
            
        }

      
        constructor(private $resource: angular.resource.IResourceService,
            public $state: ng.ui.IStateService,
            private accountService: WoMoCo.Services.AccountService,
            private $stateParams: ng.ui.IStateParamsService) {            
            this.CommsResource = this.$resource('api/comms', null, {
                getCommsByUserName: {
                    method: 'GET',
                    url: 'api/comms/getCommsByUserName',
                    isArray: true
                }
            });
            this.comms = this.getCommsByUserName();         
        }
    }
}
