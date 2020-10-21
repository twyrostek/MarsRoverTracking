Send POST with JSON body to https://localhost:44339/api/rover for update rover function
Send GET to https://localhost:44339/api/rover?RoverId= with RoverId appeneded to end of url for get position function

Both requests are No Auth.
You might have to change the port number in the request.
Check the url in the browser for port number if needed.
Make sure SSL verification is disabled when sending requests.

DB:
Database must be published. I published to Localdb using windows auth. Below is the connect string.
If you use something other than Localdb, update this connectionString and add to MarsRoverTracking.Repository/App.Config and MarsRoverTracking/Web.Config

<add name="RoverEntities" connectionString="metadata=res://*/MarsRoverTrackingEntities.csdl|res://*/MarsRoverTrackingEntities.ssdl|res://*/MarsRoverTrackingEntities.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(LocalDb)\Roverdb;initial catalog=Rover;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />