#!/bin/sh

envsubst '$URL_POLL_ADMIN' < appsettings.json.template > appsettings.json

dotnet MoonlyBird.Poll.Api.dll