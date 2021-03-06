﻿namespace WoMoCo.Controllers {
    export class PostController {
        public posts;
        public PostResource;

        public getPost() {
            this.posts = this.PostResource.query();
        }

        constructor(
            private accountService: WoMoCo.Services.AccountService,
            private $resource: ng.resource.IResourceService,
            private $http: ng.IHttpService) {
            this.PostResource = $resource('api/posts');
            this.getPost();
        }
    }

    // admin getAll
    export class PostAdminController {
        public posts;

        public getPost() {
            return this.PostService.getAllPostsAdmin();
        }

        constructor(
            private PostService: WoMoCo.Services.PostService
        ) {
            this.posts = this.getPost();
        }
    }

    //get post by username
    export class GetByUsernameController {
        public posts;
        public PostResource;

        public getPostByUsername() {
            return this.PostResource.getPosts()
        }

        constructor(
            private accountService: WoMoCo.Services.AccountService,
            private $resource: ng.resource.IResourceService,
            private $stateParams: ng.ui.IStateParamsService) {

            this.PostResource = $resource('api/posts', null, {
                getPosts: {
                    method: 'GET',
                    url: 'api/posts/getPostByUser',
                    isArray: true
                }
            });
            this.posts = this.getPostByUsername();
            //console.log(this.posts);
        }
    }

    //Add Post Controller
    export class AddPostController {
        public post;
        public PostResource;

        public save() {
            this.PostResource.save(this.post).$promise.then(() => {
                this.post = null;
                this.$state.go('post')
            });
        }

        constructor(
            private $resource: ng.resource.IResourceService,
            private $state: ng.ui.IStateService) {

            this.PostResource = this.$resource('api/posts');


        }
    }

    //edit post controller
    export class EditPostController {
        public post;
        public PostResource;

        public getPostById(id: number) {
            this.post = this.PostResource.get({id: id})
        }
        public savePost() {
            this.PostResource.save(this.post).$promise.then(() => {
                this.post = null;
                this.$state.go('post');
            })
        }
        constructor(
            private $resource: ng.resource.IResourceService,
            public $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {

            this.PostResource = this.$resource('/api/posts/:id');
            this.getPostById($stateParams['id']);
        }
    }

    // admin edit post controller
    export class EditPostAdminController {
        public post;
        public PostGetResource;
        public PostSaveResource;

        public getPostById(id: number) {
            return this.PostGetResource.get({ id: id });
        }
        public savePost() {
            this.PostSaveResource.save(this.post).$promise
                .then(() => {
                    this.post = null;
                    this.$state.go(`postAdmin`);
                });
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService
        ) {
            this.PostGetResource = $resource(`/api/posts/AdminGetPost/:id`);
            this.PostSaveResource = $resource(`/api/posts/AdminPost/`);
            this.post = this.getPostById($stateParams[`id`]);
        }
    }

    //delete post controller
    export class DeletePostController {
        public post;
        public PostResource;

        public getPost(id: number) {
            this.post = this.PostResource.get({id: id})
        }

        public deletePost() {
            this.PostResource.delete({ id: this.post.id }).$promise.then(() => {
                this.post = null;
                this.$state.go('post');
            })
        }
        constructor(
            private $resource: ng.resource.IResourceService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {

            this.PostResource = $resource('/api/posts/:id');
            this.getPost($stateParams['id'])
        }
    }

    // admin delete in in the AdminPostDeleteController.ts file because it
    // didn't work in here for some reason.
}
