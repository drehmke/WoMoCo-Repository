namespace WoMoCo.Services {

    export class MessageService {
        public MessageResource;

        constructor(private $resource: angular.resource.IResourceService) {
            this.MessageResource = this.$resource('/api/message/:id', null, {
                getMsgsByUser: {
                    method: 'GET',
                    url: '/api/message/getMsgsByUser',
                    isArray: false
                }
            });
        }

        public getMsgsByUser() {
            return this.MessageResource.getMsgsByUser();
        }

        public getMessageInfo(id) {
            return this.MessageResource.get({ id: id });
        }

        //save message
        public sendMessage(messageToSend) {
            return this.MessageResource.save(messageToSend).$promise;
        }

        //delete message
        public deleteMessage(id) {
            return this.MessageResource.delete({ id: id }).$promise;
        }
    }
    angular.module('WoMoCo').service('MessageService', MessageService);
}
