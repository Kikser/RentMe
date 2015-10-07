$('#calendar').fullCalendar({
    header: {
        left: 'prev,next today',
        center: 'title',
        right: 'month,agendaWeek,agendaDay'
    },
    defaultDate: '2015-02-12',
    selectable: true,
    selectHelper: true,

    eventRender: function (event, element) {
        console.log(event);

        var html = '<a data-event-id="' + event.id + '" class="' + ((event.strikeout) ? 'strikeout' : '') + ' fc-day-grid-event fc-h-event fc-event fc-start fc-end fc-draggable">';
        html += '<div class="fc-content">';
        html += ' <label><input type="checkbox" ' + ((event.strikeout) ? 'checked' : '') + '> <span class="fc-time">' + event.start.format('ha') + '</span> ';
        html += ' <span class="fc-title">' + event.title + '</span>';
        html += '</label></div></a>';

        var $event = $(html);

        addRightClickMenu($event);

        return $event;

    },

    select: function (start, end) {
        var title = prompt('Event Title:');
        if (title) {
            $('#calendar').fullCalendar('renderEvent', {
                title: title, start: start, end: end
            }, true);
        }
        $('#calendar').fullCalendar('unselect');
    },
    editable: true,
    events: [{ id: 1, strikeout: false, title: 'Event #1', start: '2015-02-05T12:00:00' }, { id: 2, strikeout: false, title: 'Event #2', start: '2015-02-07' }]
});





function addRightClickMenu($event) {
    $event.contextmenu({
        target: '#context-menu',
        onItem: function (context, e) {
            console.log(context);

            var event = $("#calendar").fullCalendar('clientEvents', [context.data('event-id')])[0];

            alert($(e.target).text() + ' for event "' + event.title + '"');
        }
    });
}


$('#calendar').on('change', ':checkbox', function () {

    var event = $("#calendar").fullCalendar('clientEvents', [$(this).parents('.fc-event:first').data('event-id')])[0];

    event.strikeout = $(this).is(':checked');
    $("#calendar").fullCalendar('renderEvent', event, true);

});