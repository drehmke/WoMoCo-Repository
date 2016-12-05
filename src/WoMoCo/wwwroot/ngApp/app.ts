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
            // ---- Calender Events -------------------------------------------
            .state('calenderEvents', {
                url: `/admin/calender/allEvents`,
                templateUrl: `/ngApp/views/calender/eventsList.html`,
                controller: WoMoCo.Controllers.CalenderEventsController,
                controllerAs: `controller`
            })
            .state(`calenderAddEvent`, {
                url: `/admin/calender/addEvent`,
                templateUrl: `/ngApp/views/calender/addEvent.html`,
                controller: WoMoCo.Controllers.CalenderAddEventController,
                controllerAs: `controller`
            })
            .state(`calenderViewEvent`, {
                url: `/calender/viewEvent/:id`,
                templateUrl: `/ngApp/views/calender/viewEvent.html`,
                controller: WoMoCo.Controllers.CalenderViewEventController,
                controllerAs: `controller`
            })
            // TODO: can I have a similar state for non-admin edit
            .state(`calenderEditEvent`, {
                url: `/admin/calender/editEvent/:id`,
                templateUrl: `/ngApp/views/calender/editEvent.html`,
                controller: WoMoCo.Controllers.CalenderEditEventController,
                controllerAs: `controller`
            })
            //TODO: can I have a similar state for non-admin delete
            .state(`calenderDeleteEvent`, {
                url: `/admin/calender/deleteEvent/:id`,
                templateUrl: `/ngApp/views/calender/deleteEvent.html`,
                controller: WoMoCo.Controllers.CalenderDeleteEventController,
                controllerAs: `controller`
            })
            // ---- end Calender Events ---------------------------------------
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
