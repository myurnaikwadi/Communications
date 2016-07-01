app.controller('ksCommunicationController', function ($rootScope, $scope, serverCommunication, $stateParams) {
    console.error($stateParams)
    $scope.conversationList = [{ name: 'HARSHADA D' }
                , { name: 'SAGAR N' }
                , { name: 'SAGAR P' }
                , { name: 'MAYUR' }

    ]

    $scope.conversationLoad = function (iIndex, iCategory) {
        for (var i = 0 ; i < $scope.conversationList.length ; i++) {
            $scope.conversationList[i].selectedConversation = false;
        }
        if (iCategory.selectedConversation == true) {
            iCategory.selectedConversation = false;
        } else {
            iCategory.selectedConversation = true;
        }
    };
   
});