(function() {
    var _dragged;
    ko.bindingHandlers.drag = {
        init: function(element, valueAccessor, allBindingsAccessor, viewModel) {
            var dragElement = $(element);
            var dragOptions = {
                helper: 'clone',
                revert: true,
                revertDuration: 0,
                start: function() {
                    _dragged = ko.utils.unwrapObservable(valueAccessor().value);
                },
                cursor: 'default'
            };
            dragElement.draggable(dragOptions).disableSelection();
        }
    };

    ko.bindingHandlers.drop = {
        init: function(element, valueAccessor, allBindingsAccessor, viewModel) {
            var dropElement = $(element);
            var dropOptions = {
                hoverClass: "drop-hover",
                drop: function(event, ui) {
                    bucket = valueAccessor().params;
                    if (valueAccessor().index == 0) {
                        index = 0;
                    } else {
                        index = valueAccessor().index()+1;
                    }
                    //Remove the item from the old
                    _dragged.bucket.relinquish(_dragged);
                    //Add the item to the new bucket
                    bucket.receive(_dragged, index);
                    
                }
            };
            dropElement.droppable(dropOptions);
        }
    };
})();
