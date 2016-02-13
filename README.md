# Base.SPApp

Sample Visual Studio 2010 solution for Sharepoint 2007 / MOSS.

![Sharepoint MOSS 2007 Logo](http://blogs.technet.com/cfs-file.ashx/__key/communityserver-blogs-components-weblogfiles/00-00-00-93-68-metablogapi/sharepoint_5F00_2007_5F00_logo_5F00_1F653D74.jpg)

## This project contains :
 1. feature deploy the custom master page [site scope]
 2. other feature deploy two others features (list + webpart) [web scope] (list : http://blogit.create.pt/andrevala/2008/05/17/sharepoint-2007-deployment-list-template-features/)
 3. features receivers
 4. list items receivers (http://aarebrot.net/blog/2010/08/creating-custom-list-event-receivers-in-sharepoint-2007/)
 5. the masterpage with codebehind
 6. webpart only code
 7. MainMenu is a custom UserControl with codebehind (check in "12/TEMPLATE/CONTROLTEMPLATES/BaseMenu/MainMenu.ascx")
 8. BaseSPPlusWebPart : webpart with usercontrol and acsx, this one use SharepointPlus javascript library load lists & list items (http://aymkdn.github.io/SharepointPlus/)

## Requires
 1. Visual Studio 2010 on the Sharepoint Server
 2. [WSPBuilder VS2010 extensions](http://wspbuilder.codeplex.com/downloads/get/94507?releaseId=30858)
 3. [Add custom external tools for get PublicTokenKey](https://blogs.msdn.microsoft.com/kaevans/2008/06/18/getting-public-key-token-of-assembly-within-visual-studio/) [Caution: you can have an other version of Microsoft SDKs]

## Prequesites
 1. Create your first WebApplication in your farm (_admin/applications.aspx > Create or extend Web application) [http://dev-baseapp/]
 2. Create site collection for this new Wep Application [directly in root, same url that Web Application] with "Publishing Portal" template.

## Solution

 ### 1 - Deployment

	  #### Base.SPApp is use for generate your WSP.
		- 12 folder equi "C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\12"
			= Contains features descriptions
		- 80 folder equi "C:\Inetpub\wwwroot\wss\VirtualDirectories\dev-baseapp80"
			= contains dll that you want deploy internally
		- GAC folder equi "C:\WINDOWS\assembly"
			= contains dll that you want deploy globally
		- install wsp.bat : remove if exist the current wsp from solutions store, and deploys the new one.

	  #### How to generate WSP :
		- Rebuild all solution > right click on the Base.SPApp project > WSPBuilder > Build WSP for generate WSP
		- Right click on the Base.SPApp project > Open Folder in solution explorer > and use the .bat for deploy solution

  ### 2 - Sharepoint [recommend to deploy globally]

	- Receivers & somes tools for sharepoint

  ### 3 - WebSite [recommend to deploy globally]

	- MasterPages + WebParts CodeBehind
	- WebControls ...

## Infos

- Each project have "build events" (right click > properties on project > Build Events) that copy is own dll in correct folder of Base.SPApp (for this sample all dll are copied in GAC folder).
- Each project : 3.5 Framework
- The base solution is created with WSPBuilder. To default, an ".snk" file is added. For each new project use this signature. 
- to prefer to use the ".bat" file before the shortcut "deploy" from WSPBuilder. 

## Helps

Debug feature : http://www.dotnetmafia.com/blogs/dotnettipoftheday/archive/2008/04/01/debugging-a-feature-when-using-stsadm-exe.aspx
Controls : http://stackoverflow.com/questions/1648447/why-does-onload-createchildcontrols-order-change-at-postback
Features receivers : https://social.msdn.microsoft.com/Forums/office/en-US/d90a3595-a08e-4d44-a89e-ed74e60f3044/failed-to-create-feature-receiver-object-from-assembly-on-activate-feature?forum=sharepointdevelopmentlegacy
MSDN ;)