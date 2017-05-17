VSTOOL ?= /Applications/Visual\ Studio.app/Contents/MacOS/vstool

VERSION=0.2.1
CONFIGURATION=Release

PROJECT_NAME=NomadCode.ProjectTemplates
PACKAGE_NAME=$(PROJECT_NAME)_$(VERSION).mpack


all : clean ./builds/$(VERSION)/$(CONFIGURATION)/$(PACKAGE_NAME)


./builds/$(VERSION)/$(CONFIGURATION) :
	mkdir -p builds/$(VERSION)/$(CONFIGURATION)


./$(PROJECT_NAME)/$(PACKAGE_NAME) : ./builds/$(VERSION)/$(CONFIGURATION)
	msbuild ./$(PROJECT_NAME) /t:Rebuild /p:Configuration=$(CONFIGURATION)


./builds/$(VERSION)/$(CONFIGURATION)/$(PACKAGE_NAME) : ./$(PROJECT_NAME)/$(PACKAGE_NAME)
	mv ./$(PROJECT_NAME)/$(PACKAGE_NAME) ./builds/$(VERSION)/$(CONFIGURATION)


clean :
	rm -rf builds/$(VERSION)
	rm -rf $(PROJECT_NAME)/bin
	rm -rf $(PROJECT_NAME)/obj