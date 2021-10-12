UDP in this case serves only one purpose

1. It's constanly asking sending packets to network, asking where other computers are.
These request comes in clocked cycles and returns IP address of active users.

2. When user is found active, there is a temp object(ActiveSession of the other user) created. This object holds information in form of IP address about online and comunicating computer.

3.From the temp object definition, program takes an IP of an active user(not sending packets to the whole LAN) and sends him request, to send his ActiveSession(his Nickname, AccountName etc.)

4.Server Adds this user to the list of active users.

NOTE: For now, no more comunication than this is needed, later with chat windows there will be a 5th point, where server will create TCP established connection with user.