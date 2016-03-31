(function () {
    'use strict';

    angular
        .module('productPricingApp')
        .factory('ProductService', ProductService);

    ProductService.$inject = ['$resource', '$q', '$http'];

    function ProductService($resource, $q, $http) {
        var resource = $resource('/api/Products/:action/:param', { action: '@action', param: '@param' }, {
            'update': { method: 'PUT' }
        });

        var _getProducts = function () {
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

        

        var _getProductsBySuplierId = function (supplierId) {
            var deferred = $q.defer();
            resource.query({ action: 'BySupplierId', param: supplierId },
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

        var _getProductById = function (productId) {
            var deferred = $q.defer();
            resource.query({ action: 'ById', param: productId },
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

        var _addProduct = function (productDto) {
            var deferred = $q.defer();

            $http.post('/api/Products', productDto)
                .then(function (result) {
                    deferred.resolve(result);
                },
                        function (response) {
                            deferred.reject(response);
                        });

            return deferred.promise;
        };

        var _updateProduct = function (productDto) {
            var deferred = $q.defer();

            $http.put('/api/Products/' + productDto.id, productDto)
                .then(function (result) {
                    deferred.resolve(result);
                },
                        function (response) {
                            deferred.reject(response);
                        });

            return deferred.promise;
        };

        var _deleteProduct = function (productId) {
            var deferred = $q.defer();

            resource.delete({ action: "", param: productId },
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
            getProducts: _getProducts,
            getProductById: _getProductById,
            addProduct: _addProduct,
            updateProduct: _updateProduct,
            deleteProduct: _deleteProduct,
            getProductsBySuplierId: _getProductsBySuplierId
        };
    }
})();