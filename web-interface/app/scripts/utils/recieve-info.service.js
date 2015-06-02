app.factory('RawInfoRetriever', function () {
    function GetRawInfo (restangularizedData) {
        var rawObjects = [];

        if(_.isArray(restangularizedData))
        {
            _.forEach(restangularizedData, function (infoItem) {
                if (infoItem.plain) {
                    rawObjects.push(infoItem.plain());
                } else {
                    rawObjects.push(infoItem);
                }
            });
        } else {
            rawObjects.push(restangularizedData.plain());
        }


        return rawObjects
    }
    return GetRawInfo;
});
