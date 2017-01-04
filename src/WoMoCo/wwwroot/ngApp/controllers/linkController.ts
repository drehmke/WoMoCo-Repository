namespace WoMoCo.Controllers {
    export class LinkController {
        public links;
        public LinkResource;

        public getLinks() {
            this.links = this.LinkResource.query();
        }
        constructor(private $resource:
            angular.resource.IResourceService) {


            this.LinkResource = this.$resource(`/api/link`);
            this.getLinks();

        }
    }
    export class AddLinkController {
        public link;
        public LinkResource
        public save() {

            this.LinkResource.save(this.link).$promise.then(() => {
                this.link = null;
                this.$state.go(`link`);
            });
        }

        constructor(private $resource: angular.resource.IResourceService, private $state: ng.ui.IStateService) {
            this.LinkResource = this.$resource(`/api/link`);
        }
    }
    export class EditLinkAdminController {
        public link;
        public LinkGetResource;
        public LinkSaveResource;

        public getLink(id: number) {
            return this.LinkGetResource.get({ id: id });
        }
        public saveLink() {
            this.LinkSaveResource.save(this.link).$promise
                .then(() => {
                    this.link = null;
                    this.$state.go(`linkAdmin`)
                });
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService
        ) {
            this.LinkGetResource = $resource(`/api/link/Admin/:id`);
            this.LinkSaveResource = $resource(`/api/link/AdminUpdate`);
            this.link = this.getLink($stateParams[`id`]);
        }
    }

    export class EditLinkController {
        public link;
        public LinkResource;

        public getLink(id: number) {
            this.link = this.LinkResource.get({ id: id });
        }

        public saveLink() {
            this.LinkResource.save(this.link).$promise.then(() => {
                this.link = null;
                this.$state.go(`link`);

            });

        }

        constructor(
            private $resource: angular.resource.IResourceService,
            public $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {

            this.LinkResource = this.$resource(`/api/link/:id`);
            this.getLink($stateParams[`id`])


        }
    }
    //DeleteLinkController
    export class DeleteLinkController {
        public link;
        public LinkResource;

        public getLink(id: number) {
            this.link = this.LinkResource.get({ id: id });
        }
        public deleteLink() {
            this.LinkResource.delete({ id: this.link.id }).$promise.then(() => {
                this.link = null
                this.$state.go(`link`);

            })

        }
        constructor(
            private $resource:
                angular.resource.IResourceService,
            public $stateParams:
                ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {
            this.LinkResource = this.$resource(`/api/link/:id`);
            this.getLink($stateParams[`id`]);

        }
    }

    export class DeleteLinkAdminController {
        public link;
        public LinkResource;

        public getLink(id: number) {
            return this.LinkResource.get({ id: id });
        }
        public deleteLink() {
            this.LinkResource.delete({ id: this.link.id }).$promise
                .then(() => {
                    this.link = null;
                    this.$state.go(`linkAdmin`);
                });
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService
        ) {
            this.LinkResource = $resource(`/api/link/Admin/:id`);
            this.link = this.getLink($stateParams[`id`]);
        }
    }

    export class AdminLinkController {
        public links;
        public LinkResource;

        public getLinks() {
            this.links = this.LinkResource.getAdminList();
            //console.log(this.links);
        }
        constructor(private $resource: angular.resource.IResourceService) {
            this.LinkResource = this.$resource(`/api/link`, null, {
                getAdminList: {
                    url: `/api/link/getAdminList/`,
                    method: `GET`,
                    isArray: true
                }
            });
            this.getLinks();

        }

    }
}