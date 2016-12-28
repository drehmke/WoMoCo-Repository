namespace WoMoCo.Controllers {

    export class InboxController {
        public CommsResource;
        public comms;
        
        //get comms by logged In user
        public getCommsByUserName() {
            return this.CommsResource.getCommsByUserName();
            
        }

      
        constructor(private $resource: angular.resource.IResourceService,
            public $state: ng.ui.IStateService
        ) {            
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
    angular.module(`WoMoCo`).controller(`InboxController`, InboxController);
}
