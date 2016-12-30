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
            //=======home-login ==============================================>
            // ---- Delete this when we have a logged in home page
            .state(`home-login`, {

                url: `/home-login`,
                templateUrl: `/ngApp/views/home-login.html`,
                controller: WoMoCo.Controllers.HomeController,
                controllerAs: 'controller'
            })
            // ========== Interest ===========================================>
            .state(`addInterest`, {
                url: `/interest/add`,
                templateUrl: `/ngApp/views/interest/addInterest.html`,
                controller: WoMoCo.Controllers.AddInterestController,
                controllerAs: `controller`
            })

            .state(`interestAdmin`, { // admin
                url: `/admin/interest`,
                templateUrl: `/ngApp/views/interest/interest.html`,
                controller: WoMoCo.Controllers.InterestController,
                controllerAs: `controller`
            })
            .state(`interestAdminEdit`, { // admin
                url: `/admin/interest/edit/:id`,
                templateUrl: `/ngApp/views/interest/editInterest.html`,
                controller: WoMoCo.Controllers.EditInterestController,
                controllerAs: `controller`
            })
            .state(`deleteInterest`, { // admin
                url: `/admin/interest/delete/:id`,
                templateUrl: `/ngApp/views/interest/deleteInterest.html`,
                controller: WoMoCo.Controllers.DeleteInterestController,
                controllerAs: `controller`
            })
        //========== Link ====/js added on TemplateURl===>
            .state(`addLink`, {
                url: `/addLink`,
                templateUrl: `/js/ngApp/views/links/addLink.html`,
                controller: WoMoCo.Controllers.AddLinkController,
                controllerAs: `controller`
            })

            .state(`editLink`, { // admin
                url: `/admin/link/edit/:id`,
                templateUrl: `/ngApp/views/links/editAdmin.html`,
                controller: WoMoCo.Controllers.EditLinkAdminController,
                controllerAs: `controller`
            })

            .state(`deleteLink`, { // admin
                url: `/admin/link/delete/:id`,
                templateUrl: `/ngApp/views/links/deleteAdmin.html`,
                controller: WoMoCo.Controllers.DeleteLinkAdminController,
                controllerAs: `controller`
            })
            .state(`linkAdmin`, { // admin
                url: `/admin/links`,
                templateUrl: `/ngApp/views/links/link.html`,
                controller: WoMoCo.Controllers.LinkController,
                controllerAs: `controller`
            })

            //======= Baby Sitter Links ======================================>
            .state(`babySitterlink`, {
                url: `/babySitterlink`,
                templateUrl: `/ngApp/views/babySitterLinks/babySitterlink.html`,
                controller: WoMoCo.Controllers.BabySitterController,
                controllerAs: `controller`
            })
            //================================================================>
            // ---- calendar Events -------------------------------------------
            // TODO: Admin
            .state(`calendar`, {
                url: `/calendar`,
                templateUrl: `/ngApp/views/calendar/userEventsList.html`,
                controller: WoMoCo.Controllers.CalendarUserEventsController,
                controllerAs: `controller`
            })
            .state('calendarEvents', { // admin
                url: `/admin/calendar/allEvents`,
                templateUrl: `/ngApp/views/calendar/eventsList.html`,
                controller: WoMoCo.Controllers.CalendarEventsController,
                controllerAs: `controller`
            })
            .state(`calendarAddEvent`, {
                url: `/calendar/addEvent`,
                templateUrl: `/ngApp/views/calendar/addEvent.html`,
                controller: WoMoCo.Controllers.CalendarAddEventController,
                controllerAs: `controller`
            })
            // TODO: create admin view
            .state(`calendarViewEvent`, {
                url: `/calendar/viewEvent/:id`,
                templateUrl: `/ngApp/views/calendar/viewEvent.html`,
                controller: WoMoCo.Controllers.CalendarViewEventController,
                controllerAs: `controller`
            })
            // TODO: create admin view
            .state(`calendarEditEvent`, {
                url: `/calendar/editEvent/:id`,
                templateUrl: `/ngApp/views/calendar/editEvent.html`,
                controller: WoMoCo.Controllers.CalendarEditEventController,
                controllerAs: `controller`,
            })
            // TODO: create admin view
            .state(`calendarDeleteEvent`, {
                url: `/calendar/deleteEvent/:id`,
                templateUrl: `/ngApp/views/calendar/deleteEvent.html`,
                controller: WoMoCo.Controllers.CalendarDeleteEventController,
                controllerAs: `controller`
            })
            // ---- end calendar Events ---------------------------------------
            // ---- Events Alarms ---------------------------------------------
            // Not going to implement for demo
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
            // ---- end Event Alarms ------------------------------------------
            // --- activity Forums --------------------------------------------
            .state(`activityForum`, {
                url: `/activity/`,
                templateUrl: `/ngApp/views/activityForum/activitiesForum.html`,
                controller: WoMoCo.Controllers.ActivitiesController,
                controllerAs: `controller`
            })
            .state(`addActivity`, {
                url: `/activity/add`,
                templateUrl: `/ngApp/views/activityForum/activitiesPost.html`,
                controller: WoMoCo.Controllers.AddActivitiesController,
                controllerAs: `controller`
            })
            .state(`editActivity`, {
                url: `/activity/edit/:id`,
                templateUrl: `/ngApp/views/activityForum/edit.html`,
                controller: WoMoCo.Controllers.ActivitiesControllerEdit,
                controllerAs: `controller`
            })
            .state(`activityForumAdminList`, { // admin
                url: `/admin/activity/list`,
                templateUrl: `/ngApp/views/activityForum/adminList.html`,
                controller: WoMoCo.Controllers.ActivitiesControllerAdminList,
                controllerAs: `controller`
            })
            .state(`activityForumAdminEditActivity`, { // admin
                url:`/admin/activity/edit/:id`,
                templateUrl: `/ngApp/views/activityForum/adminEdit.html`,
                controller: WoMoCo.Controllers.ActivitiesControllerAdminEdit,
                controllerAs: `controller`
            })
            .state(`activityForumAdminDeleteActivity`, { // admin
                url: `/admin/activity/delete/:id`,
                templateUrl: `/ngApp/views/activityForum/adminDelete.html`,
                controller: WoMoCo.Controllers.ActivitiesControllerAdminDelete,
                controllerAs: `controller`
            })
            // ---- end activity Forums ---------------------------------------
            // ---- Messaging -------------------------------------------------
            // TODO: Admin
            .state(`inbox`, {
                url: `/message/inbox`,
                templateUrl: `/ngApp/views/message/inbox.html`,
                controller: WoMoCo.Controllers.InboxController,
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
            .state(`messageAdmin`, { // admin
                url: `/admin/messages`,
                templateUrl: `/ngApp/views/message/adminList.html`,
                controller: WoMoCo.Controllers.MessageAdminController,
                controllerAs: `controller`
            })
            .state(`messageEditAdmin`, { // admin 
                url: `/admin/messages/edit/:id`,
                templateUrl: `/ngApp/views/message/adminEdit.html`,
                controller: WoMoCo.Controllers.InforMessageAdminController,
                controllerAs: `controller`
            })
            .state(`messageDeleteAdmin`, { // admin 
                url: `/admin/messages/delete/:id`,
                templateUrl: `/ngApp/views/message/adminDelete.html`,
                controller: WoMoCo.Controllers.DeleteMessageAdminController,
                controllerAs: `controller`
            })
            //---- end Messaging ----------------------------------------------
            //=============Search=========================================
            .state('searches', {
                url: '/search',
                templateUrl: '/ngApp/views/search/search.html',
                controller: WoMoCo.Controllers.SearchController,
                controllerAs: 'controller'
            })

            //=============End Search====================================
            // ---- User Profile ----------------------------------------------
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
            .state(`userAdmin`, { // admin
                url: `/admin/user/list`,
                templateUrl: `/ngApp/views/user/listAdmin.html`,
                controller: WoMoCo.Controllers.SearchAdminController,
                controllerAs: `controller`
            })
            .state(`userAdminEdit`, { // admin
                url: `/admin/user/edit/:id`,
                templateUrl: `/ngApp/views/user/editProfile.html`,
                controller: WoMoCo.Controllers.EditUserAdminController,
                controllerAs:`controller`
            })
            .state(`userAdminDelete`, { // admin
                url: `/admin/user/delete/:id`,
                templateUrl: `/ngApp/views/user/deleteAdmin.html`,
                controller: WoMoCo.Controllers.DeleteUserAdminController,
                controllerAs: `controller`
            })
            // ---- end User Profile ------------------------------------------
            // ---- Posting or bloging stuffs----------------------------------
            .state('post', {
                url: '/post',
                templateUrl: '/ngApp/views/posts/post.html',
                controller: WoMoCo.Controllers.PostController,
                controllerAs: 'controller'
            })
            .state('addPost', {
                url: '/post/add',
                templateUrl: '/ngApp/views/posts/addPost.html',
                controller: WoMoCo.Controllers.AddPostController,
                controllerAs: 'controller'
            })
            .state('editPost', {
                url: '/post/edit/:id',
                templateUrl: '/ngApp/views/posts/editPost.html',
                controller: WoMoCo.Controllers.EditPostController,
                controllerAs: 'controller'
            })
            .state('deletePost', {
                url: '/post/delete/:id',
                templateUrl: '/ngApp/views/posts/deletePost.html',
                controller: WoMoCo.Controllers.DeletePostController,
                controllerAs: 'controller'
            })
            .state('userPost', {
                url: '/posts/my',
                templateUrl: '/ngApp/views/posts/userPost.html',
                controller: WoMoCo.Controllers.GetByUsernameController,
                controllerAs: 'controller'
            })
            .state(`postAdmin`, { // admin
                url: `/admin/post`,
                templateUrl: `/ngApp/views/posts/adminList.html`,
                controller: WoMoCo.Controllers.PostAdminController,
                controllerAs: `controller`
            })
            .state(`postEditAdmin`, { // admin
                url: `/admin/post/edit/:id`,
                templateUrl: `/ngApp/views/posts/editAdmin.html`,
                controller: WoMoCo.Controllers.EditPostAdminController,
                controllerAs: `controller`
            })
            .state(`postDeleteAdmin`, { // admin
                url: `/admin/post/delete/:id`,
                templateUrl: `/ngApp/views/posts/deleteAdmin.html`,
                controller: WoMoCo.Controllers.DeletePostAdminController,
                controllerAs: `controller`
            })
            //---- end Posting/blogging stuffs --------------------------------
            //===================Bios==========================================
            .state('stephenBoatman', {
            url: '/bios/stephenBoatman',
            templateUrl: 'ngApp/views/bios/stephenBoatman.html',
            controller: WoMoCo.Controllers.AboutController,
            controllerAs: 'controller'
            })

            // ---- Defaults - About / Not Found ------------------------------
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
