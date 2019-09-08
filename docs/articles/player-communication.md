# Player communication

On serverside two ways exists to send data to clients.

The first way is to use ```Alt.EmitAllClients(eventName, args)``` to send data to all connected clients.

The second way sends data to a specific player directly via ```player.Emit(eventName, args)```.

args expects a ```object[]```.

Supported arguments types inside the array are ```object```, ```bool```, ```int```, ```long```, ```uint```, ```ulong```, ```float```, ```double```, ```string```, ```IPlayer``` (or any types extending IPlayer), ```IVehicle``` (or any types extending IVehicle), ```Dictionary<string, (any type listed here)```, ```Alt.Function```, any type listed here as array e.g. int[].
Also any dictionary in dictionary, array in array, ect. endless depth types are supported, because they are resolved recursively.

## Clientside

To catch the event inside clientside javascript.

```js
import * as alt from "alt";

alt.onServer(eventName, (args) => {

});
// or
alt.onServer(eventName, (arg1, arg2) => {

});
// ect.
```

To send events to server from clientside javascript.

```js
import * as alt from "alt";

alt.emitServer(eventName, args);
```