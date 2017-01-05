namespace WoMoCo.Services {

    export class CommService {
        private getMessageAdminResource;

        public getFirstMessagesFiveForAdminPage() {
            // I'm returning this, so that the controller can handle the $promise
            return this.getMessageAdminResource.getFiveMessages();
        }

        constructor(
            private $resource: angular.resource.IResourceService
        ) {
            // get the first give messages for the admin view
            this.getMessageAdminResource = $resource(`/api/comms/`, null, {
                getFiveMessages: {
                    method: `GET`,
                    url: `/api/comms/getAdminFirstFive`,
                    isArray: true
                }
            })
        }
    }
    angular.module(`WoMoCo`).service(`commService`, CommService);
}