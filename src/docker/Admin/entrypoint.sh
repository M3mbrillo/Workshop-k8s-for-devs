#!/bin/sh

envsubst '$CONNECTION_STRING' < appsettings.json.template > appsettings.json

dotnet MoonlyBird.Poll.Admin.dll