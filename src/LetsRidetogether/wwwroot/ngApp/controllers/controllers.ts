namespace LetsRidetogether.Controllers {

    export class HomeController {

        public trips;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $uibModal: angular.ui.bootstrap.IModalService
        ) {

            $http.get('api/trips').then((res) => {

                this.trips = res.data;
                console.log(this.trips);

            });
        }

        public post(trip) {
            this.$http.post('api/trips', trip).then((res) => {
                this.$state.reload();
            });


        }
        public delete(tripId) {
            this.$http.delete(`api/trips/${tripId}`).then((res => {
                this.$state.reload();
            }));

        }

    }



    export class DetailController {
        public trip;
        public reviewDTO;
        public profile;
        //public center; /*= { latitude:this.trip.startAdress, longitude:this.trip.endAddress};*/
       
        public mapOptions;
        public geocoder;
        public startAddrLatLong;
        public endAddrLatLong;
        public map;
    public center = { latitude: 29.7604, longitude: -95.3698 };
        public zoom = 4;

        constructor(public $http: ng.IHttpService, public $stateParams: ng.ui.IStateParamsService,
            public $state: ng.ui.IStateService) {
            $http.get(`api/trips/${$stateParams['id']}`).then((res) => {
                this.trip = res.data;
                console.log(this.trip);
            })
                .then(() => {
                    this.mapOptions = {
                       
                    }

                //    var latitude = this.trip.endAddress.latitude;
                //    var longitude = this.trip.endAddress.longitude;
                //    var marker = new marker({
                //        map: this.map,
                //        latitude: latitude(),
                //        longitude: longitude()
                //    })

                //},
                //(error) => {
                //    console.log(error);
                });

        }



        public addCar(car) {
            this.$http.post(`api/trips/${this.$stateParams['id']}`, car).then((res) => {
                this.$state.reload();
                console.log(this.$state);
            });

        }
        public deleteCar(car) {
            this.$http.delete(`api/trips/${this.$stateParams['id']}`, car).then((res) => {
                console.log(res);
                this.$state.reload();
            }).catch((err) => {
                console.log(err);
            });
        }

        public post(review) {
            this.reviewDTO = review;
            console.log(this.reviewDTO);
            this.$http.post(`api/reviews/${this.$stateParams['id']}`, this.reviewDTO).then((res) => {
                //this.$state.reload();
                // console.log(this.$state);
                console.log(res);
            });
        }

        public editProfile() {
            this.$http.put(`api/trips/${this.$stateParams['id']}`, this.trip).then((res) => {
                this.$state.go('home');
                console.log(this.$state);
            });

        }
        public cancel() {
            this.$state.go('profile');
        }



    }
    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }
    export class AboutController {
        public trip;
        constructor(public $http: ng.IHttpService, public $stateParams: ng.ui.IStateParamsService,
            public $state: ng.ui.IStateService) {
            $http.get(`api/trips/${$stateParams['id']}`).then((res) => {
                this.trip = res.data;
                console.log(this.trip);
            });
        }

    }

    export class CarpoolController {
        public trip;
        constructor(public $http: ng.IHttpService, public $stateParams: ng.ui.IStateParamsService,
            public $state: ng.ui.IStateService) {
            $http.get(`api/trips/${$stateParams['id']}`).then((res) => {
                this.trip = res.data;
                console.log(this.trip);
            });
        }
        public editCar() {
            this.$http.put(`api/trips/${this.$stateParams['id']}`, this.trip).then((res) => {
                this.$state.go('home');
                console.log(this.$state);
            });

        }
        public cancel() {
            this.$state.go('home');
        }

        public delete(tripId) {
            this.$http.delete(`api/trips/${tripId}`).then((res => {
                this.$state.reload();
            }));




        }









        //        public showModal(startAddress: string, endAddress: string, cost: string, comment: string, model: string, seatCapacity: string) {
        //            this.$uibModal.open({
        //                controller: CarpoolController,
        //                controllerAs: 'controller',
        //                templateUrl: '/ngApp/views/dialog.html',
        //                resolve: {

        //                    startAddress: () => startAddress,
        //                    endAddress: () => endAddress,
        //                    cost: () => cost,

        //                    model: () => model,
        //                    seatCapacity: () => seatCapacity
        //                },
        //            });



        //        }


        //        public ok() {
        //            this.$uiModalInstance.close();
        //        }
    }
}
