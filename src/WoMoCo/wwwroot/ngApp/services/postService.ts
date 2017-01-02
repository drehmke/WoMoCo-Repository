namespace WoMoCo.Services {
    export class PostService {
        public PostResource;
        public AdminPostResource;
        public AdminGetResource;
        public posts;
        
        constructor(
            private $resource: ng.resource.IResourceService,
            private $state: ng.ui.IStateService
        ) {
            this.PostResource = $resource('api/posts', null, {
                getPosts: {
                    method: 'GET',
                    url: 'api/posts/getPostByUser',
                    isArray: true
                }
            });
            this.AdminPostResource = $resource(`/api/posts/:id`, null, {
                getAdmin: {
                    method: `GET`,
                    url: `/api/posts/AdminGet/:id`,
                    isArray: true
                }
            });
            //this.posts = this.getPost();
        }
        public getPostByUsername() {
            return this.PostResource.getPosts();
        }

        public getPost() {
            return this.AdminPostResource.query();
        }
        public deletePost(id: number) {
            return this.AdminPostResource.delete({ id: id });
        }

        public getAllPostsAdmin() {
            return this.AdminPostResource.getAdmin();
        }
    }
    angular.module("WoMoCo").service("PostService", PostService);
}