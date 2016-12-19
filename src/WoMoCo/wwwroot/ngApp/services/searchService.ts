namespace WoMoCo.Services {

    export class SearchService {
        public userSearchResource;
        public searches;

        public getUsers() {
            return this.userSearchResource.query();
        }

        constructor(private $resource: angular.resource.IResourceService) {
            this.userSearchResource = this.$resource('/api/searches');
        }
    }
        angular.module(`WoMoCo`).service(`SearchService`, SearchService);
}

        //public getUserByUserName() {
        //    return this.SearchResource.getUserByUsername();
        //}