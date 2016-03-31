(function () {
    'use strict';

    angular
        .module('productPricingApp')
        .controller('ProductController', ProductController);

    ProductController.$inject = ['$scope', '$q', 'ProductService', 'SupplierService', 'errorHandler', '$modal', '$filter'];

    function ProductController($scope, $q, ProductService, SupplierService, errorHandler, $modal, $filter) {
        (function startup() {
            
            getAllProduct();
            var suppliers = SupplierService.getSuppliers();

            

            $q.all([
                suppliers
            ]).then(function (data) {
                if (data != null) {
                    $scope.suppliers = data[0];
                }
            }, function (reason) {
                errorHandler.logServiceError('SupplierController', reason);
            }, function (update) {
                errorHandler.logServiceNotify('SupplierController', update);
            });
        })();

        function getAllProduct() {
            var products = ProductService.getProducts();
            $q.all([
                products
            ]).then(function (data) {
                if (data != null) {
                    $scope.products = data[0];
                }
            }, function (reason) {
                errorHandler.logServiceError('ProductController', reason);
            }, function (update) {
                errorHandler.logServiceNotify('ProductController', update);
            });
        };

        function removeProduct(productId) {
            for (var i = 0; i < $scope.products.length; i++) {
                if ($scope.products[i].id == productId) {
                    $scope.products.splice(i, 1);
                    break;
                }
            }
        };

        $scope.products = [];

        $scope.Commands = {
            saveProduct: function (product) {
                ProductService.addProduct(product).then(
                    function (result) {
                        $scope.products.push(result.data);
                    },
                    function (response) {
                        console.log(response);
                    });
            },
            updateProduct: function (product) {
                ProductService.updateProduct(product).then(
                    function (result) {
                    },
                    function (response) {
                        console.log(response);
                    });
            },
            saveSupplier: function (supplier) {
                SupplierService.addSupplier(supplier).then(
                    function (result) {
                        $scope.suppliers.push(result.data);
                    },
                    function (response) {
                        console.log(response);
                    });
            },
            updateSupplier: function (supplier) {
                SupplierService.updateSupplier(supplier).then(
                    function (result) {
                    },
                    function (response) {
                        console.log(response);
                    });
            }
        };

        $scope.DropdownListCommand = {
            suplierListSelectedItem: "",
            productListSelectedItem: "",
            suplierListChanged: function (suplierListSelectedItem) {
                if (suplierListSelectedItem != 0)
                    var suppProducts = ProductService.getProductsBySuplierId(suplierListSelectedItem);

                $q.all([
                suppProducts
                ]).then(function (data) {
                    if (data != null) {
                        $scope.supplierProducts = data[0];
                    }
                }, function (reason) {
                    errorHandler.logServiceError('ProductController', reason);
                }, function (update) {
                    errorHandler.logServiceNotify('ProductController', update);
                });
            },
            productListChanged: function (productListSelectedItem) {
                if (productListSelectedItem != 0) {
                    $scope.products = $filter('filter')($scope.products, { id: productListSelectedItem });
                } else {
                     getAllProduct();
                }
            }
        }

        $scope.Queries = {
            getProducts: function () {
                ProductService.getProducts();
            },
            getProductById: function (productId) {
                ProductService.getProductById(productId);
            }
        };

        $scope.Modals = {
            openSupplierModal: function (supplier) {
                $scope.supplier = supplier;

                var modalInstance = $modal.open({
                    animation: true,
                    templateUrl: '/App/Templates/Supplier/SupplierFormModal.html',
                    controller: 'SupplierFormModalController',
                    size: 'lg',
                    scope: $scope,
                    backdrop: 'static'
                });

                modalInstance.result.then(
                    function (supplier) {
                        if (supplier.id != null) {
                            $scope.Commands.updateSupplier(supplier);
                        }
                        else {
                            $scope.Commands.saveSupplier(supplier);
                        }
                    },
                    function (event) {
                    });
            },

            openProductModal: function (product) {
                $scope.product = product;

                var modalInstance = $modal.open({
                    animation: true,
                    templateUrl: '/App/Templates/Product/ProductFormModal.html',
                    controller: 'ProductFormModalController',
                    size: 'lg',
                    scope: $scope,
                    backdrop: 'static'
                });

                modalInstance.result.then(
                    function (product) {
                        if (product.id != null) {
                            $scope.Commands.updateProduct(product);
                        }
                        else {
                            $scope.Commands.saveProduct(product);                            
                        }
                    },
                    function (event) {
                    });
            },

            deleteProduct: function (productId) {
                if (confirm('Are you sure you want to delete this product?')) {
                    ProductService.deleteProduct(productId).then(
                        function (data) {
                            removeProduct(productId);
                        },
                        function (response) {
                            console.log(response);
                        });
                }
                else {
                    console.log('delete cancelled');
                }
            },

            deleteSupplier: function (supplierId) {
                if (confirm('Are you sure you want to delete this supplier?')) {
                    SupplierService.deleteSupplier(supplierId).then(
                        function (data) {
                            removeSupplier(supplierId);
                        },
                        function (response) {
                            console.log(response);
                        });
                }
                else {
                    console.log('delete cancelled');
                }
            }
        }
    };
})
();