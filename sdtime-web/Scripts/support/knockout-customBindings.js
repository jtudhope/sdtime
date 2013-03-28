(function() {
    var _dragged;
	
	ko.bindingHandlers.sortable = {
        init: function(element, valueAccessor, allBindingsAccessor, viewModel) {
            var sortableElement = $(element);
            var sortableOptions = {
				connectWith: ".bucket ul",
				containment: $("#container"),
				items: "li",
				tolerance: "pointer",
                cursor: "move",
				// On drag start
				start: function(event, ui) {
					// Set placeholder height to item height minus border;
					var border = 2;
					ui.placeholder.height(ui.item.height() - (border * 2));
					_dragged = ko.utils.unwrapObservable(valueAccessor().value);
				},
				// On drag finish (if elements were reordered)
				update: function(event, ui) {
					var index = ui.item.index(),
					bucketIndex = ui.item.parents(".bucket").index(),
					destinationBucket = buckets()[bucketIndex],
					ticket = ko.utils.arrayFirst(_dragged.tickets(), function(item) {
						return ui.item.attr('id') == item.number;
					});
					
					if (ticket != null) {
					// Remove the item from the old bucket
                    _dragged.relinquish(ticket);
					
					// Add the item to the new bucket
                    destinationBucket.receive(ticket, index);
					}
				}
            };
            sortableElement.sortable(sortableOptions).disableSelection();
        }
    };
})();
