function PlayersComponent() {
    var root = {};

    root.AllPlayers = [];

    root.Players = ko.observableArray([]);
    root.Filter = ko.observable('');
    root.Filter.subscribe(function (newValue) {
        var filter = newValue || '';
        if (filter.length > 0) {
            var filteredPlayers = root.AllPlayers.filter(function (player) {
                return player.FullName.toLowerCase().indexOf(filter.toLowerCase()) > -1;
            });
            root.Players(filteredPlayers);
        }
        else {
            root.clearFilter();
        }
    });

    getAllPlayers().done(function (response) {
        response.Data.forEach(function (player) {
            player.Age = player.Age && player.Age > 0 ? player.Age : '';

            root.AllPlayers.push(player);
        });

        root.AllPlayers.sort(function (player1, player2) {
            if (player1.FullName > player2.FullName) {
                return 1;
            }
            if (player1.FullName < player2.FullName) {
                return -1;
            }
            return 0;
        });

        root.Players(root.AllPlayers);
    });

    root.clearFilter = function (sender, event) {
		if(event) {
			if (event.type === 'click' || event.keyCode === 27) {
				root.Players(root.AllPlayers);
				root.Filter('');
			}
		}
		else {
			root.Players(root.AllPlayers);
		}
        return true;
    };

    function getAllPlayers() {
        var data = {
            Model: {},
            Command: { Page: 0, PageSize: 0 }
        };

        var request = $.ajax({
            url: "/Players",
            type: 'POST',
            data: JSON.stringify(data),
            contentType: 'application/json',
        })
        .fail(onRequestError);

        return request;
    }

    function onRequestError(response) {
        console.log('Players load error: ' + response.statusText);
    }

    return root;
}