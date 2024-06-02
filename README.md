# GagSpeak-ServerAPI


The API to help outline the structure of the format used by both the webservice and the tasks to be called upon by the client.

Further documentation TBD as this is a heavy WIP.

## Purposes of the folders within the API:
### Data
Contains the main data components of the objects used to define the DTo's

### DTo's
The data transfer objects that are sent from client to server, a way of packaging together information so it can be
easily transferred.


### Routes
The pages that can be accessed within the GagSpeak-Webservice, a way of communicating with addresses of the hosted server without needing to visually see them???

### SignalR
The controller for communication sent from client to server, this is how the contact is made, while the other folders handle the organization and structure of everything.