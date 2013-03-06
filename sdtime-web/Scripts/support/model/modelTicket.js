var Ticket = function(name, number, assigned, client, description, budget, ticketNotes, bucket) {
    this.name = name;
    this.number = number;
    this.client = client;
    this.assigned = assigned;
    this.description = description;
    this.ticketNotes = ko.observableArray();
    this.budget = budget;
    this.bucket = bucket;
    if (ticketNotes){
		for (var i=0; i<ticketNotes.length; i++){
		  	this.ticketNotes.push(new TicketNote (ticketNotes[i].note));
	  	}
	}
    
}
 