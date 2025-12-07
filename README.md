# EA WRC bridge

A quick and dirty way to make [Pacenote Pal](https://github.com/Koenvh1/ACRally-Pacenote) 
work with EA WRC. 

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

EA WRC is not the focus of PacenotePal, so this is very rough. 

Included are the default male voice for EA WRC and the pacenotes for all the stages.