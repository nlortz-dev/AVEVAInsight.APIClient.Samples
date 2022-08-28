// Regional URL. Can be:
//  https://online.wonderware.com/
//  https://online.wonderware.eu/
//  https://online.wonderware.net.au/
var url = "https://online.wonderware.com/";

// API Key Token can be acquired from Admin portal
var apiKeyToken = "<MyAPIKeyToken>";

// Upload token can be acquired from Data Source Management page
var csvJsonUploadToken = "<MyBearerToken>";

#region Tag Groups

// Returns a list of all Tag Groups (Data Sources) belonging to the Solution
var tagGroups = TagGroups.GetTagGroups(url, apiKeyToken);

#endregion

# region Tag(s) Retrieval

// Retrieve Tag data for a single tag
var tag = TagRetrieval.RetrieveTag(url, apiKeyToken, "MyDataSourceName.MyTagName");

// Retrieve Tag data for a batch of (up-to) 100 Tags
var tagsToRetrieve = new string[] { "MyDataSourceName.MyTagName1", "MyDataSourceName.MyTagName2" };
var tags = TagRetrieval.RetrieveTags(url, apiKeyToken, tagsToRetrieve);

// Retrieve tag data for all Tags belonging to Solution 
var allTags = TagRetrieval.RetrieveAllTags(url, apiKeyToken);

#endregion

#region Tag Properties

// Retrieve all tag properties (fixed and custom) belonging to Solution
var tagProperties = TagProperties.GetTagProperties(
    url, apiKeyToken);

#endregion

#region Tag Update

var locationUpdateSuccess = TagRevision.UpdateTagLocation(
    url, apiKeyToken, "MyDataSourceName.MyTagName", "MyNewLocation");

var aliasUpdateSuccess = TagRevision.UpdateTagAlias(
    url, apiKeyToken, "MyDataSourceName.MyTagName", "MyNewAlias");

var updateSuccess = TagRevision.UpdateTag(url, apiKeyToken, 
    "MyDataSourceName.MyTagName", "Location", "California", "string");

#endregion

#region Tag(s) Delete

// Delete a single Tag from the Solution
// This is a permanent action. Perform at your own discretion.
var deleteSuccess = TagDeletion.DeleteTag(
    url, apiKeyToken, "MyDataSourceName.MyTagName");

// Delete a batch of (up-tp) 100 Tags from the Solution
// This is a permanent action. Perform at your own discretion.
var tagsToDelete = new string[] { "MyDataSourceName.MyTagName1", 
   "MyDataSourceName.MyTagName2" };

var bulkDeleteSuccess = TagDeletion.DeleteTags(
    url, apiKeyToken, tagsToDelete);

#endregion

#region Process Values

// Construct query request body
var processValuesQuery = new ProcessValuesQuery()
{
    FQN = new string[] { "MyDataSourceName.MyTagName" },
    StartDateTime = "2022-01-01T00:00:00.000Z",
    EndDateTime = "2022-01-31T00:00:00.000Z",
    RetrievalMode = "BestFit",
    Resolution = 3600000,
    InterpolationType = "Linear",
};

// Retrieve all Process Values
var processValues = ProcessValues.RetrieveProcessValues(
    url, apiKeyToken, processValuesQuery);

#endregion

#region Tenant Metrics

// Returns total Tag count and Tag History count of the Solution
var tenantMetrics = TenantMetrics.GetTenantMetrics(url, apiKeyToken);

#endregion

#region Events

var eventStartTime = "2022-01-01T00:00:00.000Z";
var eventEndTime = "2022-01-02T00:00:00.000Z";

// Retrieves all Events belonging to the Solution
var events = Events.RetrieveEvents(url, apiKeyToken, eventStartTime, eventEndTime);

#endregion

#region Engineering Unit Catalog

// Retrieves all items of the Engineering Unit Catalog
var engineeringUnitCatalog = EngineeringUnitCatalog.
    GetEngineeringUnitCatalog(url, apiKeyToken);

#endregion

#region Engineering Unit Map

// Retrieves all Engineering Units that have been mapped to the Engineering Unit Catalog 
var engineeringUnitMap = EngineeringUnitMap.
    GetEngineeringUnitMap(url, apiKeyToken);

#endregion

#region Engineering Units

// Retrieves all "related" Engineering Units to the input Engineering Unit
// E.g., Returns "in", "ft", "km", when "m" is passed 

var engineeringUnits = EngineeringUnits.GetRelatedEngineeringUnits(
    url, apiKeyToken, "m");

#endregion

#region Csv/Json Uploader, Upload File

var filePathAndName = "C:\\MyDirectory\\MyJsonFile.json";

// Returns a unique Job ID
var jobID1 = UploadFile.UploadRequestFile(url, csvJsonUploadToken, filePathAndName);

#endregion

#region Csv/Json Uploader, Upload File Content

// Alternatively, admins may write csv or json-file content directly
var jsonRequestBody = "{\"metadata\": [{\"TagName\": \"MyTagName\", \"Description\": \"My unique description\"}]}";

// Returns a unique Job ID
var jobID2 = UploadFile.UploadRequestBody(url, csvJsonUploadToken, jsonRequestBody);

#endregion

#region Csv/Json Uploader Job ID Status

// Retrieves the status of the file upload, based on unique Job ID
var jobID = "123456789";

var jobIdStatus = UploadStatus.RetrieveFileUploadStatus(
    url, csvJsonUploadToken, jobID);

#endregion