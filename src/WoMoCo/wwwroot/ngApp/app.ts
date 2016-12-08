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
                templateUrl: '/ngApp/views/secret.html',
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
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: WoMoCo.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            }) 
           // ================ Interest======>
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
            // ---- calendar Events -------------------------------------------
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
            // ---- end calendar Events ---------------------------------------
            // ---- Events Alarms ---------------------------------------------
            .state(`eventAlarms`, {
                url: `/admin/alerts/allAlerts`,
                templateUrl: `/ngApp/views/alarms/list.html`,
                controller: WoMoCo.Services.EventAlarmService,
                controllerAs: `controller`
            })
            // ---- end Event Alarms ------------------------------------------
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
                templateUrl: 'ngApp/views/profile.html',
                controller: WoMoCo.Controllers.UserController,
                controllerAs: 'controller'
            })
            .state('editProfile', {
                url: '/editProfile',
                templateUrl: 'ngApp/views/editProfile.html',
                controller: WoMoCo.Controllers.EditUserController,
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
