namespace WoMoCo.Controllers {

    export class AdminPostDeleteController {
        public post;
        public PostResource;

        public getPost(id: number) {
            return this.PostResource.get({ id: id });
        }

        public deletePost() {
            this.PostService.deletePost(this.post.id).$promise
                .then(() => {
                    this.post = null;
                    this.$state.go(`postAdmin`);
                });
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService,
            private PostService: WoMoCo.Services.PostService
        ) {
            this.PostResource = $resource(`/api/posts/AdminGetPost/:id`);
            this.post = this.getPost($stateParams[`id`]);
        }
    }
}