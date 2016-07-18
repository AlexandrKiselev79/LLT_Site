function PlayersComponent() {
    var root = {};

    var itemsPerPage = 10;

    root.DataLoaded = ko.observable(false);
    root.CurrentPage = ko.observable(0);
    root.TotalPages = ko.observable(0);
    var AllPlayers = [];

    root.Players = ko.observableArray([]);
    root.Filter = ko.observable('');
    root.Filter.subscribe(function (newValue) {
        var filter = newValue || '';
        if (filter.length > 0) {
            var filteredPlayers = AllPlayers.filter(function (player) {
                return player.FullName.toLowerCase().indexOf(filter.toLowerCase()) > -1;
            });
            root.Players(filteredPlayers);
        }
        else {
            root.clearFilter();
        }
    });

    getAllPlayers().done(function (response) {
        var players = response.Data;

        players.sort(function (player1, player2) {
            if (player1.FullName > player2.FullName) {
                return 1;
            }
            if (player1.FullName < player2.FullName) {
                return -1;
            }
            return 0;
        });

        players.forEach(function (player, index) {
            var pageNumber = Math.floor(index / itemsPerPage) + 1;
            player.PageNumber = pageNumber;

            AllPlayers.push(player);
        });

        root.DataLoaded(true);
        root.CurrentPage(AllPlayers.length > 0 ? 1 : 0);
        root.TotalPages(Math.ceil(AllPlayers.length / itemsPerPage));
        showPagedPlayers();
    });

    root.clearFilter = function (sender, event) {
        if (event) {
            if (event.type === 'click' || event.keyCode === 27) {
                showPagedPlayers();
                root.Filter('');
            }
        }
        else {
            showPagedPlayers();
        }
        return true;
    };

    root.pagePrevious = function () {
        if (root.CurrentPage() > 1) {
            root.CurrentPage(root.CurrentPage() - 1);
            showPagedPlayers();
        }
    };

    root.pageNext = function () {
        if (root.CurrentPage() < root.TotalPages()) {
            root.CurrentPage(root.CurrentPage() + 1);
            showPagedPlayers();
        }
    };

    root.goToFirstPage = function () {
        if (root.TotalPages()> 0) {
            root.CurrentPage(1);
            showPagedPlayers();
        }
    };

    function showPagedPlayers() {
        var players = AllPlayers.filter(function (item) {
            return itemsPerPage === 0 || item.PageNumber === root.CurrentPage();
        });
        root.Players(players);
    }

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