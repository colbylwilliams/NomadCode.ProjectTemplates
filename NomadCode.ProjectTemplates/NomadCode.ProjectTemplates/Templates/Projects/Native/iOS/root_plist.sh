#!/bin/bash

# c0lby:

## Create New Root.plist file ##

PreparePreferenceFile

		AddNewTitleValuePreference  -k "VersionNumber" 	-d "$versionNumber ($buildNumber)" 	-t "Version"


	AddNewPreferenceGroup 	-t "Diagnostics Key"
		AddNewStringNode 	-e "FooterText" 	-v "$copyright"


	AddNewTitleValuePreference  -k "UserReferenceKey" 	-d "anonymous"  	-t ""
