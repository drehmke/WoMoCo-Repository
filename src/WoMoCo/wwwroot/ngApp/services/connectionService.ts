namespace WoMoCo.Services {

    export class ConnectionService {
        public GetConnectionsResource;

        public getAllMyConnections() {
            // I am returning this so that the $promise/then in the controller have something
            return this.GetConnectionsResource.getMyConnections();
        }

        constructor(
            private $resource: angular.resource.IResourceService
        ) {
            this.GetConnectionsResource = $resource(`/api/connections/`, null, {
                getMyConnections: {
                    method: `GET`,
                    url: `api/connections/getConnections`,
                    isArray: true
                }
            })
        }
    }
    angular.module(`WoMoCo`).service(`connectionService`, ConnectionService);
}