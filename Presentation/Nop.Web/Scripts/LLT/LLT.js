'user strict'

var LLT = (function(root, $, undefined) {
    var root = {};

    root.init = function () {
        setupComponents();

        ko.applyBindings(new MainView());
    };

    function setupComponents() {
        var templateFromUrlLoader = {
            loadTemplate: function (name, templateConfig, callback) {
                if (templateConfig.url) {
                    $.get(templateConfig.url, function (markupString) {
                        ko.components.defaultLoader.loadTemplate(name, markupString, callback);
                    });
                }
                else {
                    callback(null);
                }
            }
        };
        ko.components.loaders.unshift(templateFromUrlLoader);

        ko.components.register('players-list-component', {
            viewModel: PlayersComponent,
            template: { url: '/Scripts/LLT/Views/Components/PlayersComponent.html'}
        });
    }

    return root;
})(LLT || {}, jQuery);

jQuery(document).ready(function() {
    LLT.init();
});