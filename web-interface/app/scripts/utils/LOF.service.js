app.factory('LOF', function () {
    function kDistance(arr, k) {

        var result = _.sortBy(arr, 'Sum');
        _.forEach(arr, function (item, index, array) {
            var nextIndex = 1;
            var prevIndex = 1;

            var NextDist;
            var PreviousDist;
            var neighbors = 0;
            var allDistances = [];
            result[index].Nk = [];

            do {

                if (array[index + nextIndex]) {
                    NextDist = Math.abs(item.Sum - array[index + nextIndex].Sum); // DOES THE SIGN MATTERS?
                }
                if (array[index - prevIndex]) {
                    PreviousDist = Math.abs(item.Sum - array[index - prevIndex].Sum);
                }


                if (!!(NextDist && PreviousDist)) {
                    if (NextDist > PreviousDist) {
                        _.forEach(arr, function (innerItem, innerIndex, innerArray) {
                            if (Math.abs(item.Sum - innerItem.Sum) == PreviousDist){
                                result[index].Nk.push({
                                    id: innerItem.teacher,
                                    Sum: innerItem.Sum,
                                    dist: PreviousDist
                                });

                                neighbors++;
                                allDistances.push(PreviousDist);
                            }
                        });
                        prevIndex++;
                    } else {
                        _.forEach(arr, function (innerItem, innerIndex, innerArray) {
                            if (Math.abs(item.Sum - innerItem.Sum) == NextDist) {
                                result[index].Nk.push({
                                    id: innerItem.teacher,
                                    Sum: innerItem.Sum,
                                    dist: NextDist
                                });

                                neighbors++;
                                allDistances.push(NextDist);
                            }
                        });
                        nextIndex++;
                    }

                } else {
                    var distToPush = NextDist ? NextDist : PreviousDist;
                    _.forEach(arr, function (innerItem, innerIndex, innerArray) {
                        if (Math.abs(item.Sum - innerItem.Sum) == distToPush) {
                            result[index].Nk.push({
                                id: innerItem.teacher,
                                Sum: innerItem.Sum,
                                dist: distToPush
                            });

                            neighbors++;
                            allDistances.push(distToPush);
                        }
                    });
                    nextIndex++;
                    prevIndex++;
                }
            } while (neighbors < k);

            result[index].kDistance = Math.max.apply(null, allDistances);

        });

        return result;
    }

    function LocalReachabilityDensity(arr) {
        _.forEach(arr, function (item, index, array) {
            var Sum = 0;

            _.forEach(item.Nk, function (innerItem, innerIndex, innerArray) { /// how can reach-dist be > than k-distance if we take Sum by Nk(p)!!!
                var neededItem = _.findWhere(array, {'teacher': innerItem.id});
                var isInKdistance = _.findWhere(neededItem.Nk, {'id': item.teacher});

                if (isInKdistance) {
                    Sum += neededItem.kDistance;
                } else {
                    Sum += innerItem.dist;
                }
            });
            item.lrd = 1 / (Sum / item.Nk.length);
        });

        return arr;
    }

    function LOF(arr) {
        _.forEach(arr, function (item, index, array) {
            var lrdOfKnearest = [];
            _.forEach(item.Nk, function (innerItem, innerIndex, innerArray) {
                var neededItem = _.findWhere(array, {'teacher': innerItem.id});
                lrdOfKnearest.push(neededItem.lrd);
            });

            var Sum = 0;

            _.forEach(lrdOfKnearest, function (item) {
                Sum += item;
            });

            var LOF = (Sum / item.lrd) / item.Nk.length;
            item.LOF = LOF;
        });

        return arr;
    }

    return {
        kDist: kDistance,
        lrd: LocalReachabilityDensity,
        lof: LOF
    };
});
