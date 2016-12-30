namespace WoMoCo.Services {
    export class PostService {
        public PostResource;
        public PostingResource;
        
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
            //this.PostingResource = $resource('api/posts');
            //this.getPostings();
        }
        public getPostByUsername() {
            return this.PostResource.getPosts();
        }
        //public getPostings() {
        //    let postings = this.
        //}
    }
    angular.module("WoMoCo").service("PostService", PostService);
}