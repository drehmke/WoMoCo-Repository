namespace WoMoCo.Services {
    export class LinkService {
        public GetUserLinkResource;

        public saveLink(link) {
            // I have a return on this because the promise/then is in the controller
            return this.$resource(`/api/link`).save(link);
        }

        public getAllUserLinks() {
            let temp = this.GetUserLinkResource.getMyLinks();
            return temp;
        }

        public removeLink(id: number) {
            return this.$resource(`/api/link/:id`).delete({ id: id });
        }

        // ---- CONSTRUCTOR ---------------------------------------------------
        constructor(
            private $resource: angular.resource.IResourceService
        ) {
            this.GetUserLinkResource = $resource(`/api/link`, null, {
                getMyLinks: {
                    method: `GET`,
                    url: `/api/link/getMy`,
                    isArray: true
                }
            })
        }
    }
    angular.module(`WoMoCo`).service(`linkService`, LinkService);
}