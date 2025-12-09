# EA WRC bridge

A quick and dirty way to make [Pacenote Pal](https://github.com/Koenvh1/PacenotePal) 
work with EA WRC. Support for EA WRC in Pacenote Pal might be included by default later.

## Setup

1)
Requires `pacenotepal.json` to be copied to `Documents\My Games\WRC\telemetry\udp`. Edit
`Documents\My Games\WRC\telemetry\config.json` to add:  

```
      {
        "structure": "pacenotepal",
        "packet": "session_update",
        "ip": "127.0.0.1",
        "port": 31117,
        "frequencyHz": -1,
        "bEnabled": true
      }
```


2)
Extract the folder to your Pacenote Pal folder.

3)
Start EAWRCbridge.exe. It will asks whether it is allowed network access. Click "allow".

4)
Open PacenotePal.exe. Select the voice JJ in the settings. You probably also want to
reduce the call distance to ~0.5.

All the other steps are equal to those of PacenotePal.

Included are the default male English and German voice for EA WRC and the pacenotes for 
all the stages.