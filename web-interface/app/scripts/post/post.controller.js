app.controller('PostController', ['$scope', 'PostService', 'Cacher', 'RawInfoRetriever', 'Resizer', 'LOF',
    function ($scope, PostService, Cacher, RawInfoRetriever, Resizer, LOF) {

        $scope.title.text = 'Посади викладачів';
        $scope.Data = Cacher.post ? Cacher.post : [];
        $scope.configRequest = {};
        $scope.showLoader = false;
        $scope.showTable = Cacher.post ? true : false;

        $scope.fetch = function () {
            $scope.showLoader = true;

            PostService.getAll().then(function (data) {
                $scope.Data = RawInfoRetriever(data);
                Cacher.post = $scope.Data;

                $scope.showLoader = false;
                $scope.showTable = true;

                Resizer();
            });
        };

        $scope.onBlur = function (event) {
        };

        $scope.gridOptions = {
            data: 'Data',
            enableColumnResize: true
        };

        $scope.tmpData2 = [
            {
                "$id": "1",
                "teacher": 6474,
                "Sum": 100
            }, {
                "$id": "2",
                "teacher": 6476,
                "Sum": 200
            }, {
                "$id": "3",
                "teacher": 6484,
                "Sum": 589
            }, {
                "$id": "4",
                "teacher": 6485,
                "Sum": 530
            }, {
                "$id": "5",
                "teacher": 6486,
                "Sum": 491
            }, {
                "$id": "6",
                "teacher": 6490,
                "Sum": 487
            }, {
                "$id": "7",
                "teacher": 6625,
                "Sum": 520
            }, {
                "$id": "8",
                "teacher": 9107,
                "Sum": 460
            }, {
                "$id": "9",
                "teacher": 9117,
                "Sum": 499
            }, {
                "$id": "10",
                "teacher": 9118,
                "Sum": 50
            }
        ];
        $scope.tmpData = [{
            "$id": "1",
            "teacher": 6474,
            "Sum": 409
        }, {
            "$id": "2",
            "teacher": 6476,
            "Sum": 504
        }, {
            "$id": "3",
            "teacher": 6484,
            "Sum": 589
        }, {
            "$id": "4",
            "teacher": 6485,
            "Sum": 435
        }, {
            "$id": "5",
            "teacher": 6486,
            "Sum": 491
        }, {
            "$id": "6",
            "teacher": 6490,
            "Sum": 433
        }, {
            "$id": "7",
            "teacher": 6625,
            "Sum": 629
        }, {
            "$id": "8",
            "teacher": 9107,
            "Sum": 333
        }, {
            "$id": "9",
            "teacher": 9117,
            "Sum": 434
        }, {
            "$id": "10",
            "teacher": 9118,
            "Sum": 480
        }, {
            "$id": "11",
            "teacher": 9120,
            "Sum": 408
        }, {
            "$id": "12",
            "teacher": 9124,
            "Sum": 382
        }, {
            "$id": "13",
            "teacher": 9125,
            "Sum": 558
        }, {
            "$id": "14",
            "teacher": 10951,
            "Sum": 495
        }, {
            "$id": "15",
            "teacher": 10958,
            "Sum": 779
        }, {
            "$id": "16",
            "teacher": 327681,
            "Sum": 294
        }, {
            "$id": "17",
            "teacher": 327682,
            "Sum": 252
        }, {
            "$id": "18",
            "teacher": 327684,
            "Sum": 411
        }, {
            "$id": "19",
            "teacher": 327686,
            "Sum": 429
        }, {
            "$id": "20",
            "teacher": 327687,
            "Sum": 552
        }, {
            "$id": "21",
            "teacher": 327690,
            "Sum": 178
        }, {
            "$id": "22",
            "teacher": 327693,
            "Sum": 347
        }, {
            "$id": "23",
            "teacher": 327694,
            "Sum": 379
        }, {
            "$id": "24",
            "teacher": 327695,
            "Sum": 493
        }, {
            "$id": "25",
            "teacher": 327696,
            "Sum": 569
        }, {
            "$id": "26",
            "teacher": 327711,
            "Sum": 440
        }, {
            "$id": "27",
            "teacher": 327714,
            "Sum": 431
        }, {
            "$id": "28",
            "teacher": 327718,
            "Sum": 438
        }, {
            "$id": "29",
            "teacher": 327719,
            "Sum": 334
        }, {
            "$id": "30",
            "teacher": 327725,
            "Sum": 256
        }, {
            "$id": "31",
            "teacher": 327728,
            "Sum": 421
        }, {
            "$id": "32",
            "teacher": 327729,
            "Sum": 465
        }, {
            "$id": "33",
            "teacher": 327730,
            "Sum": 781
        }, {
            "$id": "34",
            "teacher": 327731,
            "Sum": 505
        }, {
            "$id": "35",
            "teacher": 327739,
            "Sum": 360
        }, {
            "$id": "36",
            "teacher": 327742,
            "Sum": 455
        }, {
            "$id": "37",
            "teacher": 327743,
            "Sum": 365
        }, {
            "$id": "38",
            "teacher": 327749,
            "Sum": 456
        }, {
            "$id": "39",
            "teacher": 327750,
            "Sum": 481
        }, {
            "$id": "40",
            "teacher": 327751,
            "Sum": 510
        }, {
            "$id": "41",
            "teacher": 327752,
            "Sum": 483
        }, {
            "$id": "42",
            "teacher": 327755,
            "Sum": 272
        }, {
            "$id": "43",
            "teacher": 327758,
            "Sum": 525
        }, {
            "$id": "44",
            "teacher": 327759,
            "Sum": 516
        }, {
            "$id": "45",
            "teacher": 327764,
            "Sum": 536
        }, {
            "$id": "46",
            "teacher": 327770,
            "Sum": 278
        }, {
            "$id": "47",
            "teacher": 327776,
            "Sum": 370
        }, {
            "$id": "48",
            "teacher": 327778,
            "Sum": 557
        }, {
            "$id": "49",
            "teacher": 327779,
            "Sum": 659
        }, {
            "$id": "50",
            "teacher": 327786,
            "Sum": 503
        }, {
            "$id": "51",
            "teacher": 327789,
            "Sum": 433
        }, {
            "$id": "52",
            "teacher": 327796,
            "Sum": 407
        }, {
            "$id": "53",
            "teacher": 327801,
            "Sum": 341
        }, {
            "$id": "54",
            "teacher": 327804,
            "Sum": 419
        }, {
            "$id": "55",
            "teacher": 327805,
            "Sum": 427
        }, {
            "$id": "56",
            "teacher": 327812,
            "Sum": 545
        }, {
            "$id": "57",
            "teacher": 327831,
            "Sum": 620
        }, {
            "$id": "58",
            "teacher": 327840,
            "Sum": 257
        }, {
            "$id": "59",
            "teacher": 327844,
            "Sum": 410
        }, {
            "$id": "60",
            "teacher": 327851,
            "Sum": 501
        }, {
            "$id": "61",
            "teacher": 327852,
            "Sum": 519
        }, {
            "$id": "62",
            "teacher": 11245346,
            "Sum": 304
        }, {
            "$id": "63",
            "teacher": 11245349,
            "Sum": 490
        }, {
            "$id": "64",
            "teacher": 11246495,
            "Sum": 104
        }, {
            "$id": "65",
            "teacher": 11247071,
            "Sum": 504
        }, {
            "$id": "66",
            "teacher": 11247773,
            "Sum": 444
        }, {
            "$id": "67",
            "teacher": 11247961,
            "Sum": 284
        }, {
            "$id": "68",
            "teacher": 11248035,
            "Sum": 459
        }, {
            "$id": "69",
            "teacher": 11248253,
            "Sum": 417
        }, {
            "$id": "70",
            "teacher": 11248567,
            "Sum": 424
        }, {
            "$id": "71",
            "teacher": 11248765,
            "Sum": 498
        }, {
            "$id": "72",
            "teacher": 11248847,
            "Sum": 694
        }, {
            "$id": "73",
            "teacher": 11248907,
            "Sum": 451
        }, {
            "$id": "74",
            "teacher": 11250267,
            "Sum": 327
        }, {
            "$id": "75",
            "teacher": 11250269,
            "Sum": 602
        }, {
            "$id": "76",
            "teacher": 11250271,
            "Sum": 629
        }, {
            "$id": "77",
            "teacher": 11250273,
            "Sum": 543
        }, {
            "$id": "78",
            "teacher": 11250965,
            "Sum": 614
        }, {
            "$id": "79",
            "teacher": 11250969,
            "Sum": 605
        }, {
            "$id": "80",
            "teacher": 11250971,
            "Sum": 160
        }, {
            "$id": "81",
            "teacher": 11251241,
            "Sum": 545
        }, {
            "$id": "82",
            "teacher": 11252025,
            "Sum": 565
        }, {
            "$id": "83",
            "teacher": 11252191,
            "Sum": 465
        }, {
            "$id": "84",
            "teacher": 11252199,
            "Sum": 612
        }];

        $scope.calculate = function() {
            var kdistArray = LOF.kDist($scope.tmpData, 35);
            var lrdArray = LOF.lrd(kdistArray);
            var lofArray = LOF.lof(lrdArray);

            var x = lofArray;
        };

    }]);