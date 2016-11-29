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
        public InterestResource
        public save() {

            this.InterestResource.save(this.interest).$promise.then(() => {
                this.interest = null;
                this.$state.go(`interest`);
            });
        }

        constructor(private $resource: angular.resource.IResourceService, private $state: ng.ui.IStateService) {
            this.InterestResource = this.$resource(`/api/interest`);
        }
    }

    export class EditInterestController {
        public interest;
        public InterestResource;

        public getInterest(id: number) {
            this.interest = this.InterestResource.get({ id: id });
        }

        public saveInterest() {
            this.InterestResource.save(this.interest).$promise.then(() => {
                this.interest = null;
                this.$state.go(`interest`);

            });

        }

        constructor(
            private $resource: angular.resource.IResourceService,
            public $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {

            this.InterestResource = this.$resource(`/api/interest/:id`);
            this.getInterest($stateParams[`id`])


        }
    }
    //DeleteMovieController
    export class DeleteInterestController {
        public interest;
        public InterestResource;

        public getInterest(id: number) {
            this.interest = this.InterestResource.get({ id: id });
        }
        public deleteInterest() {
            this.InterestResource.delete({ id: this.interest.id }).$promise.then(() => {
                this.interest = null
                this.$state.go(`interest`);

            })

        }
        constructor(
            private $resource:
                angular.resource.IResourceService,
            public $stateParams:
                ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {
            this.InterestResource = this.$resource(`/api/interest/:id`);
            this.getInterest($stateParams[`id`]);

        }

    }
}