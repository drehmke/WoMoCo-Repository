namespace WoMoCo.Services {
    export class PostService {
        public PostResource;

        constructor(
            private $resource: ng.resource.IResourceService
        ) {
            this.PostResource = $resource('api/posts', null, {
                getPosts: {
                    method: 'GET',
                    url: 'api/posts/getPostByUser',
                    isArray: true
                }
            });
        }
        public getPostByUsername() {
            return this.PostResource.getPosts();
        }
    }
    angular.module("WoMoCo").service("PostService", PostService);
}