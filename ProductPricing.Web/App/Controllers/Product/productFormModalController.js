(function () {
    'use strict';

    angular
        .module('productPricingApp')
        .controller('ProductFormModalController', ProductFormModalController);

    ProductFormModalController.$inject = ['$scope', '$modalInstance'];

    function ProductFormModalController($scope, $modalInstance) {
        $scope.ok = function () {
            $modalInstance.close($scope.product);
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    }
})();