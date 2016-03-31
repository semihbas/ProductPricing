(function () {
    'use strict';

    angular
        .module('productPricingApp')
        .factory('SupplierService', SupplierService);

    SupplierService.$inject = ['$resource', '$q', '$http'];

    function SupplierService($resource, $q, $http) {
        var resource = $resource('/api/Suppliers/:action/:param', { action: '@action', param: '@param' }, {
            'update': { method: 'PUT' }
        });

        var _getSuppliers = function () {
            var deferred = $q.defer();
            resource.query({ action: "get", param: "" },
				function (result) {
				    if (result == null) {
				        result = [];
				    };
				    deferred.resolve(result);
				},
				function (response) {
				    deferred.reject(response);
				});
            return deferred.promise;
        };

        var _getSupplierById = function (supplierId) {
            var deferred = $q.defer();
            resource.query({ action: 'ById', param: supplierId },
				function (result) {
				    if (result == null) {
				        result = [];
				    };

				    deferred.resolve(result);
				},
				function (response) {
				    deferred.reject(response);
				});
            return deferred.promise;
        };

        var _addSupplier = function (supplierDto) {
            var deferred = $q.defer();

            $http.post('/api/Suppliers', supplierDto)
                .then(function (result) {
                    deferred.resolve(result);
                },
                        function (response) {
                            deferred.reject(response);
                        });

            return deferred.promise;
        };

        var _updateSupplier = function (supplierDto) {
            var deferred = $q.defer();

            $http.put('/api/Suppliers/' + supplierDto.id, supplierDto)
                .then(function (result) {
                    deferred.resolve(result);
                },
                        function (response) {
                            deferred.reject(response);
                        });

            return deferred.promise;
        };

        var _deleteSupplier = function (supplierId) {
            var deferred = $q.defer();

            resource.delete({ action: "", param: supplierId },
                    function (result) {
                        if (result == null) {
                            result = [];
                        };
                        deferred.resolve(result);
                    },
                    function (response) {
                        deferred.reject(response);
                    });
            return deferred.promise;
        };

        return {
            getSuppliers: _getSuppliers,
            getSupplierById: _getSupplierById,
            addSupplier: _addSupplier,
            updateSupplier: _updateSupplier,
            deleteSupplier: _deleteSupplier
        };
    }
})();