namespace WoMoCo.Controllers {
    //Chat Controller
    export class ChatController {
        public chat;
        public ChatResource;

        public getChats() {
            this.chat = this.ChatResource.query();
        }

        constructor(private $resource: angular.resource.IResourceService) {
            this.ChatResource = this.$resource(`/api/chat`);
            this.getChats();
        }
    }

    //Add Chat Controller
    export class AddChatController {
        public chat;
        public ChatResource;

        public save() {
            this.ChatResource.save(this.chat).$promise.then(() => {
                this.chat = null;
                this.$state.go(`chat`);
            });
        }
        constructor(private $resource: angular.resource.IResourceService, private $state: ng.ui.IStateService) {
            this.ChatResource = this.$resource(`/api/chat`);
        }
    }
}