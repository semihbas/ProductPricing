(function () {
    'use strict';

    angular
        .module('productPricingApp')
        .controller('SupplierFormModalController', SupplierFormModalController);

    SupplierFormModalController.$inject = ['$scope', '$modalInstance'];

    function SupplierFormModalController($scope, $modalInstance) {
        $scope.ok = function () {
            $modalInstance.close($scope.supplier);
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    }
})();