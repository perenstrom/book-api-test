#!/bin/bash
rm -rf publish
dotnet publish -r linux-x64 -o publish
