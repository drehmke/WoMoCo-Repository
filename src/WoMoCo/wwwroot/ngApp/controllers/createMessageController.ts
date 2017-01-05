namespace WoMoCo.Controllers {

    export class CreateMessageController {
        public MessageResource;
        public getPullDownResource;
        public pulldownUsers;
        public comm;

        public saveComm() {
            this.MessageResource.save(this.comm).$promise.then(() => {

                this.$state.go('inbox');
            })

        }

        public GetUsersForPullDown() {
            let tempResults = this.getPullDownResource.getUsersForPulldown();
            console.log(tempResults);
            return tempResults;
        }

        constructor(private $resource: angular.resource.IResourceService,
            public $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService,
            private accountService: WoMoCo.Services.AccountService,
            private MessageService: WoMoCo.Services.MessageService
        ) {
            this.MessageResource = this.$resource('/api/comms');
            this.getPullDownResource = $resource(`/api/users`, null, {
                getUsersForPulldown: {
                    method: `GET`,
                    url: `/api/users/GetUsersForPulldown`,
                    isArray: true
                }
            });

            this.pulldownUsers = this.GetUsersForPullDown();
        }

    }
}
