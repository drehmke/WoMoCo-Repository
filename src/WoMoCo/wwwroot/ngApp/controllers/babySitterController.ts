namespace WoMoCo.Controllers {
    export class BabySitterController {
        public babySitters;
        public BabySitterResource;

        public getBabySitters() {

            this.babySitters = this.BabySitterResource.query();
            console.log(this.babySitters);
        }
        constructor(private $resource:
            angular.resource.IResourceService) {


            this.BabySitterResource = this.$resource(`/api/babySitterLink`);
            this.getBabySitters();

        }
    }
 angular.module(`WoMoCo`).controller(`BabySitterController`, BabySitterController);
}
