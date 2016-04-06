Tosca Commander DefectIntegration
===========================

The Defect Integration is a template project provided as an example of how to integrate a bugtracker application with the Tosca Testsuite. It allows the creation and synchronization of external tickets or issue from Tosca Commander.

----------

Architecture
-------------
This integration uses Tosca's built-in SimpleDefectTracking interface, which provides the tasks for **create/open/update** defects on ExecutionEntries, and creates an xml file within the workspace directory including additional information for the integration.

----------
Installation
-------------

 - The ToscaSimple Defect Tracking AddIn must be installed.
 - The TCDefectIntegration.exe and TCDefectIntegration.exe.config have to be deployed to **%TRICENTIS_HOME%\ToscaCommander**.
 
----------

