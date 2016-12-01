namespace WoMoCo.Controllers {

    export class MessageController {
        public messages;
        private MessageResource;
        
        public getMessages() {
            this.messages = this.MessageResource.query();
        }
        public saveMessage() {
            this.MessageResource.save(this.messages).$promise.then(() => {
                this.messages = null;
                this.$state.go('messageHome');
            })
        }
        public message;
        public getMessage(id: number) {
            this.messages = this.MessageResource.get({ id: id });
        }


        constructor(private $resource: angular.resource.IResourceService,
            public $stateParams: ng.ui.IStateParamsService,
            public $state: ng.ui.IStateService) {
            this.MessageResource = this.$resource('/api/messages');
            this.getMessage($stateParams["id"]);
            this.MessageResource = this.$resource('/api/messages/:id');
        }


    

    }
    export class EditMessageController {
        public MessageResource;
        public message;
        public MessageController;

        public getMessage(id: number) {
            this.message = this.MessageResource.get({ id: id })
        }
        public save() {
            this.MessageResource.save(this.message).$promise.then(() => {
                this.message = null;
                this.$state.go('messageDetail');
            })
        }
        constructor(
            private $resource: angular.resource.IResourceService,
            public $stateParams: ng.ui.IStateParamsService,
            public $state: ng.ui.IStateService) {
            this.MessageResource = this.$resource('/api/messages');
            this.getMessage($stateParams['id']);

        }
        
    }
    export class CreateMessageController {
        public MessageResource;
        public message;

        public save() {
            this.MessageResource.save(this.message).$promise.then(() => {
                this.message = null;
                this.$state.go('messageHome');

            })
        }

        public saveMessage() {
            this.MessageResource.save(this.message).$promise.then(() => {
                this.message = null;
                this.$state.go('messageHome');
            })
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            public $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {
            this.MessageResource = $resource('/api/messages');
        }
    }
    export class MessageDetailController {
        public MessageResource;
        public message;

        public getMessage(id: number) {
            this.message = this.MessageResource.get({ id: id })
        }

        constructor(
            private $resource: angular.resource.IResourceService,
            public $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {
            this.MessageResource = this.$resource('/api/messages');
            this.getMessage($stateParams['id']);
        }

    }


    

}
