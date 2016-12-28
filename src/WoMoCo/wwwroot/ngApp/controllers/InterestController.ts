namespace WoMoCo.Controllers {
    export class InterestController {
        public interest;
        public InterestResource;

        public getInterests() {
            this.interest = this.InterestResource.query();
        }
        constructor(private $resource:
            angular.resource.IResourceService) {

            this.InterestResource = this.$resource(`/api/interest`);
            this.getInterests();

        }
    }

    export class AddInterestController {
        public interest;
        public InterestResource;

        public save() {
            this.InterestResource.save(this.interest).$promise.then(() => {
                this.interest = null;
                this.$state.go(`interest`);
            });
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            private $state: ng.ui.IStateService
        ) {
            this.InterestResource = this.$resource(`/api/interest`);
        }
    }
    angular.module(`WoMoCo`).controller(`addInterestController`, AddInterestController);

    export class EditInterestController {
        public interest;
        private InterestGetResource;
        private InterestSaveResource;

        public getInterest(id: number) {
            this.interest = this.InterestGetResource.get({ id: id });
        }

        public saveInterest() {
            this.InterestSaveResource.save(this.interest).$promise.then(() => {
                this.interest = null;
                this.$state.go(`interestAdmin`);
            });
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            public $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {

            //this.InterestResource = this.$resource(`/api/interest/:id`);
            this.InterestSaveResource = $resource(`/api/interest/AdminSave`);
            this.InterestGetResource = $resource(`/api/interest/Admin/:id`);
            this.getInterest($stateParams[`id`])
       }
    }
 
    export class DeleteInterestController {
        public interest;
        public InterestResource;

        public getInterest(id: number) {
            this.interest = this.InterestResource.get({ id: id });
        }
        public deleteInterest() {
            this.InterestResource.delete({ id: this.interest.id }).$promise.then(() => {
                this.interest = null
                this.$state.go(`interestAdmin`);

            })

        }
        constructor(
            private $resource:
                angular.resource.IResourceService,
            public $stateParams:
                ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {
            this.InterestResource = this.$resource(`/api/interest/Admin/:id`);
            this.getInterest($stateParams[`id`]);

        }

    }
}