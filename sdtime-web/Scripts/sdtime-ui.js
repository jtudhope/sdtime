/* TOGGLE WEEK Click Event
---------------------------------------- */
jQuery(document).ready(function() {
    jQuery('.toggle-week').click(function () {
        jQuery('.toggle-day-selected').attr('class', 'toggle-day');
        jQuery('.toggle-week').attr('class', 'toggle-week-selected');
        jQuery('#content-table').animate({ marginLeft: '-940px' }, 250, function() {
            
            /* TOGGLE DAY Click Event (bound after week executed)
            ---------------------------------------- */
            jQuery('.toggle-day').click(function () {
                jQuery('.toggle-week-selected').attr('class', 'toggle-week');
                jQuery('.toggle-day').attr('class', 'toggle-day-selected');
                jQuery('#content-table').animate({ marginLeft: '0' }, 250, function () {
                    // any actions happening after animation?
                });
            });

        });
    });
});