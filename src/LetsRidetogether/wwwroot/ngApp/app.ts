namespace LetsRidetogether {

    angular.module('LetsRidetogether', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        //,'google.places', 'ngGplaces'
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider,
        //ngGPlacesAPIProvider
       
      
       
    ) => {
        

        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: LetsRidetogether.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('details', {
                url: '/details/:id',
                templateUrl: '/ngApp/views/details.html',
                controller: LetsRidetogether.Controllers.DetailController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: LetsRidetogether.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: LetsRidetogether.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: LetsRidetogether.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: LetsRidetogether.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            })
            .state('about', {
                url: '/about/:id',
                templateUrl: '/ngApp/views/about.html',
                controller: LetsRidetogether.Controllers.AboutController,
                controllerAs: 'controller'
            })

            //.state('dialog', {
            //    url: '/dialog/:id',
            //    templateUrl: '/ngApp/views/dialog.html',
            //    controller: LetsRidetogether.Controllers.ModalController,
            //    controllerAs: 'controller'
            //})

            .state('carpool', {
                url: '/carpool/:id',
                templateUrl: '/ngApp/views/carpool.html',
                controller: LetsRidetogether.Controllers.CarpoolController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'

            })
            .state('profile', {
                url: '/profile/:id',
                templateUrl: '/ngApp/views/profile.html',
                controller: LetsRidetogether.Controllers.DetailController,
                controllerAs: 'controller'
            });
       

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
        
        

    });

    
    angular.module('LetsRidetogether').factory('authInterceptor', (
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

    angular.module('LetsRidetogether').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

  

}
