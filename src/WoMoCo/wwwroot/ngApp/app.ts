namespace WoMoCo {
    angular.module('WoMoCo', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: WoMoCo.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/notUsing/secret.html',
                controller: WoMoCo.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: WoMoCo.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: WoMoCo.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/notUsing/externalRegister.html',
                controller: WoMoCo.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            })

            //=======home-login ===>
         
            .state(`home-login`, {

                url: `/home-login`,
                templateUrl: `/ngApp/views/home-login.html`,
                controller: WoMoCo.Controllers.HomeController,
                controllerAs: 'controller'
            })

            // ========== Interest =====>
            .state(`addInterest`, {
                url: `/addInterest`,
                templateUrl: `/ngApp/views/interest/addInterest.html`,
                controller: WoMoCo.Controllers.AddInterestController,
                controllerAs: `controller`
            })
            .state(`editInterest`, {
                url: `/editInterest/:id`,
                templateUrl: `/ngApp/views/interest/editInterest.html`,
                controller: WoMoCo.Controllers.EditInterestController,
                controllerAs: `controller`
            })

            .state(`deleteInterest`, {
                url: `/deleteInterest/:id`,
                templateUrl: `/ngApp/views/interest/deleteInterest.html`,
                controller: WoMoCo.Controllers.DeleteInterestController,
                controllerAs: `controller`
            })
            .state(`interest`, {
                url: `/interest`,
                templateUrl: `/ngApp/views/interest/interest.html`,
                controller: WoMoCo.Controllers.InterestController,
                controllerAs: `controller`
            })
        //=============  Link ======>
            .state(`addLink`, {
                url: `/addLink`,
                templateUrl: `/ngApp/views/links/addLink.html`,
                controller: WoMoCo.Controllers.AddLinkController,
                controllerAs: `controller`
            })

            .state(`editLink`, {
                url: `/editLink/:id`,
                templateUrl: `/ngApp/views/links/editLink.html`,
                controller: WoMoCo.Controllers.EditLinkController,
                controllerAs: `controller`
            })

            .state(`deleteLink`, {
                url: `/deleteLink/:id`,
                templateUrl: `/ngApp/views/links/deleteLink.html`,
                controller: WoMoCo.Controllers.DeleteLinkController,
                controllerAs: `controller`
            })
            /*
            .state(`link`, {
                url: `/link`,
                templateUrl: `/ngApp/views/links/link.html`,
                controller: WoMoCo.Controllers.LinkController,
                controllerAs: `controller`
            })
            */
            .state(`linkAdmin`, {
                url: `/admin/links`,
                templateUrl: `/ngApp/views/links/link.html`,
                controller: WoMoCo.Controllers.AdminLinkController,
                controllerAs: `controller`
            })
            //======= Baby Sitter Links =======>
            .state(`babySitterlink`, {
                url: `/babySitterlink`,
                templateUrl: `/ngApp/views/babySitterLinks/babySitterlink.html`,
                controller: WoMoCo.Controllers.BabySitterController,
                controllerAs: `controller`
            })
            //========================================================>
            // ---- calendar Events -----------------------------------
            .state(`calendar`, {
                url: `/calendar`,
                templateUrl: `/ngApp/views/calendar/userEventsList.html`,
                controller: WoMoCo.Controllers.CalendarUserEventsController,
                controllerAs: `controller`
            })

            .state('calendarEvents', {
                url: `/admin/calendar/allEvents`,
                templateUrl: `/ngApp/views/calendar/eventsList.html`,
                controller: WoMoCo.Controllers.CalendarEventsController,
                controllerAs: `controller`
            })
            .state(`calendarAddEvent`, {
                url: `/admin/calendar/addEvent`,
                templateUrl: `/ngApp/views/calendar/addEvent.html`,
                controller: WoMoCo.Controllers.CalendarAddEventController,
                controllerAs: `controller`
            })
            .state(`calendarViewEvent`, {
                url: `/calendar/viewEvent/:id`,
                templateUrl: `/ngApp/views/calendar/viewEvent.html`,
                controller: WoMoCo.Controllers.CalendarViewEventController,
                controllerAs: `controller`
            })
            // TODO: can I have a similar state for non-admin edit
            .state(`calendarEditEvent`, {
                url: `/admin/calendar/editEvent/:id`,
                templateUrl: `/ngApp/views/calendar/editEvent.html`,
                controller: WoMoCo.Controllers.CalendarEditEventController,
                controllerAs: `controller`,
            })
            //TODO: can I have a similar state for non-admin delete
            .state(`calendarDeleteEvent`, {
                url: `/admin/calendar/deleteEvent/:id`,
                templateUrl: `/ngApp/views/calendar/deleteEvent.html`,
                controller: WoMoCo.Controllers.CalendarDeleteEventController,
                controllerAs: `controller`
            })
            // ---- end calendar Events -------------------------------
            // ---- Events Alarms -------------------------------------
            .state(`eventAlarms`, {
                url: `/admin/alarms/allAlarms`,
                templateUrl: `/ngApp/views/alarms/list.html`,
                controller: WoMoCo.Controllers.EventAlarmController,
                controllerAs: `controller`
            })
            .state(`eventAlarmAdd`, {
                url: `/admin/alarms/addAlarm`,
                templateUrl: `/ngApp/views/alarms/add.html`,
                controller: WoMoCo.Controllers.EventAddAlarmController,
                controllerAs: `controller`
            })
            .state(`eventAlarmDelete`, {
                url: `/alarm/delete/:id/:eventId`,
                controller: WoMoCo.Controllers.EventDeleteAlarmController,
                controllerAs: `controller`
            })
            // ---- end Event Alarms ----------------------------------
            .state(`activityForum`, {
                url: `/activityForum`,
                templateUrl: `/ngApp/views/activityForum/activitiesForum.html`,
                controller: WoMoCo.Controllers.ActivitiesController,
                controllerAs: `controller`
            })
            .state(`addActivity`, {
                url: `/addActivity`,
                templateUrl: `/ngApp/views/activityForum/activitiesPost.html`,
                controller: WoMoCo.Controllers.AddActivitiesController,
                controllerAs: `controller`
            })
            .state(`chat`, {
                url: `/chat`,
                templateUrl: `/ngApp/views/interest/interst.html`,
                controller: WoMoCo.Controllers.ChatController,
                controllerAs: `controller`
            })
            .state(`addChat`, {
                url: `/addChat`,
                templateUrl: `/ngApp/views/addChat.html`,
                controller: WoMoCo.Controllers.AddChatController,
                controllerAs: `controller`
            })

            .state(`inbox`, {
                url: `/message/inbox`,
                templateUrl: `/ngApp/views/message/inbox.html`,
                controller: WoMoCo.Controllers.MessageController,
                controllerAs: `controller`
            })
            .state(`message`, {
                url: `/message/message/:id`,
                templateUrl: `/ngApp/views/message/message.html`,
                controller: WoMoCo.Controllers.InfoMessageController,
                controllerAs: `controller`
            })
            .state(`messageModal`, {
                url: `/message/modal/messageModal`,
                templateUrl: `/ngApp/views/message/modal/messageModal.html`,
                controller: WoMoCo.Controllers.CreateMessageController,
                controllerAs: `controller`
            })
            .state(`deleteMessage`, {
                url: `/message/deleteMessage/:id`,
                templateUrl: `/ngApp/views/message/deleteMessage.html`,
                controller: WoMoCo.Controllers.DeleteMessageController,
                controllerAs: `controller`
            })
            .state(`adminMessageList`, {
                url: `/admin/message/adminList`,
                templateUrl: `/ngApp/views/message/adminList.html`,
                controller: WoMoCo.Controllers.MessageController,
                controllerAs: `controller`
            })
        //====================================>
          
            //=============Search=========================================
            .state('searches', {
                url: '/search',
                templateUrl: '/ngApp/views/search/search.html',
                controller: WoMoCo.Controllers.SearchController,
                controllerAs: 'controller'
            })

            //=============End Search====================================

            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: WoMoCo.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            })
            .state('profile', {
                url: '/profile',
                templateUrl: 'ngApp/views/user/profile.html',
                controller: WoMoCo.Controllers.UserController,
                controllerAs: 'controller'
            })
            .state('editProfile', {
                url: '/editProfile',
                templateUrl: 'ngApp/views/user/editProfile.html',
                controller: WoMoCo.Controllers.EditUserController,
                controllerAs: 'controller'
            })
            //Posting or bloging stuffs---------------------------------
            .state('post', {
                url: '/post',
                templateUrl: 'ngApp/views/posts/post.html',
                controller: WoMoCo.Controllers.PostController,
                controllerAs: 'controller'
            })
            .state('addPost', {
                url: '/addPost',
                templateUrl: 'ngApp/views/posts/addPost.html',
                controller: WoMoCo.Controllers.AddPostController,
                controllerAs: 'controller'
            })
            .state('editPost', {
                url: '/editPost/:id',
                templateUrl: 'ngApp/views/posts/editPost.html',
                controller: WoMoCo.Controllers.EditPostController,
                controllerAs: 'controller'
            })
            .state('deletePost', {
                url: '/deletePost/:id',
                templateUrl: 'ngApp/views/posts/deletePost.html',
                controller: WoMoCo.Controllers.DeletePostController,
                controllerAs: 'controller'
            })
            .state('editingPost', {
                url: '/editingPost',
                templateUrl: 'ngApp/views/posts/editingPost.html',
                controller: WoMoCo.Controllers.GetByUsernameController,
                controllerAs: 'controller'
            });
            

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });


    angular.module('WoMoCo').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('WoMoCo').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });


}
