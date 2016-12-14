namespace WoMoCo.Controllers {

    export class MessageController {
        
        public MessageResource;
        public friendRequests;
        public comms;
       

        public getAllComms() {
            return this.MessageService.getAllComms();
            
        }
                      

        public msgsByUser() {
            this.MessageService.getMsgsByUser().$promise.then((data) => {
                this.comms = data.messages;
                
            });
        }
        

              



        public deleteMessage(id) {
            this.MessageService.deleteMessage(id).then(() => {
                this.msgsByUser();
            });
        }

        constructor(
            private MessageService: WoMoCo.Services.MessageService,) {
            
            this.comms = this.getAllComms();
            
                     


        }

        
    }
    

}
