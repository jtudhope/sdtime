var Ticket = function (name, number, assigned, client, description, budget, actual, ticketNotes, bucket) {
    this.name = name;
    this.number = number;
    this.client = client;
    this.assigned = assigned;
    this.description = description;
    this.ticketNotes = ko.observableArray();
    this.budget = ko.observable(budget);
    this.actual = actual;
    this.bucket = ko.observable(bucket);
    this.statusId = bucket.statusId;
    if (ticketNotes) {
        for (var i = 0; i < ticketNotes.length; i++) {
            this.ticketNotes.push(new TicketNote(ticketNotes[i].note));
        }
    }

    this.bucket.subscribe(function (val) {
        this.statusId = val.statusId;
        this.saveTicket();
    }, this);

    this.budget.subscribe(function (val) {
        this.saveTicket();
    }, this);

    Ticket.prototype.toJSON = function () {
        var copy = ko.toJS(this); //easy way to get a clean copy
        delete copy.bucket; //remove an extra property
        return copy; //return the copy to be serialized
    };

    this.saveTicket = function () {
        $.ajax({
            url: "/SupportServices/UpdateTicket",
            type: "POST",
            data: ko.toJSON(this),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (e) {
                
            },
            error: function (xhr, status, error) {
                alert("Failure to Synchronize - " + error);

            }
        });
    }

}
 