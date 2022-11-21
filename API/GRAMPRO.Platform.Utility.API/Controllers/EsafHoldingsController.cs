// using System;
// using System.Collections.Generic;
// using GRAMPRO.Platform.Utility.Implementation;
// using GRAMPRO.Platform.Utility.Model;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Configuration;
// using Newtonsoft.Json;

// namespace GRAMPRO.Platform.Utility.API.Controllers
// {
//     [ApiController]
//     [Route("esafholdings")]
//     public class EsafHoldingsController : ControllerBase
//     {
//         private IWebHostEnvironment _environment;
//         private Response _response;
//         private IEsafHoldingsImplementation _esafHoldingsImplementation;
//         public EsafHoldingsController(IWebHostEnvironment environment,
//                                      IEsafHoldingsImplementation esafHoldingsImplementation,
//                                      IConfigurationRoot config)
//         {
//             _environment = environment;
//             _esafHoldingsImplementation = esafHoldingsImplementation;
//             _response = new Response();
//         }

//         [HttpPost]
//         [Route("uploadfiles")]
//         public IActionResult UploadFiles(IList<IFormFile> postedFiles, IFormCollection data)
//         {
//             try
//             {
//                 var additionalsDetails = JsonConvert.DeserializeObject<List<DocumentAdditional>>(data["additionalDetails"]);
//                 var result = this._esafHoldingsImplementation.UploadFiles(postedFiles, additionalsDetails);
//                 return Ok(result);
//             }
//             catch (System.Exception ex)
//             {
//                 _response.Data = ex;
//                 _response.Success = false;
//                 _response.Status = ApiStatus.fail;
//                 return Ok(_response);
//             }
//         }

//         [HttpGet]
//         [Route("getdocumentlist/{rowCount}/{documentType?}")]
//         public IActionResult GetDocumentList(int rowCount, string documentType)
//         {
//             try
//             {
//                 var result = this._esafHoldingsImplementation.GetDocumentList(rowCount, documentType);
//                 return Ok(result);
//             }
//             catch (System.Exception ex)
//             {
//                 _response.Data = ex;
//                 _response.Success = false;
//                 _response.Status = ApiStatus.fail;
//                 return Ok(_response);
//             }
//         }

//         [HttpGet]
//         [Route("downloaddocument/{documentId}")]
//         public IActionResult DownloadDocument(Guid documentId)
//         {
//             try
//             {
//                 var result = this._esafHoldingsImplementation.DownloadDocument(documentId);
//                 return Ok(result);
//             }
//             catch (System.Exception ex)
//             {
//                 _response.Data = ex;
//                 _response.Success = false;
//                 _response.Status = ApiStatus.fail;
//                 return Ok(_response);
//             }
//         }

//         [HttpGet]
//         [Route("document/versioncheck/{version}/{documentType}/{documentId}")]
//         public IActionResult DownloadDocument(Int16 version, string documentType, int documentId)
//         {
//             try
//             {
//                 var result = this._esafHoldingsImplementation.VersionCheck(version, documentType, documentId);
//                 return Ok(result);
//             }
//             catch (System.Exception ex)
//             {
//                 _response.Data = ex;
//                 _response.Success = false;
//                 _response.Status = ApiStatus.fail;
//                 return Ok(_response);
//             }
//         }

//         [HttpPost]
//         [Route("deletedocument")]
//         public IActionResult DeleteDocument(EHDocument doc)
//         {
//             try
//             {
//                 var result = this._esafHoldingsImplementation.DeleteDocument(doc);
//                 return Ok(result);
//             }
//             catch (System.Exception ex)
//             {
//                 _response.Data = ex;
//                 _response.Success = false;
//                 _response.Status = ApiStatus.fail;
//                 return Ok(_response);
//             }
//         }

//         [HttpPost]
//         [Route("updatedocument")]
//         public IActionResult UpdateDocument(EHDocument doc)
//         {
//             try
//             {
//                 var result = this._esafHoldingsImplementation.UpdateDocument(doc);
//                 return Ok(result);
//             }
//             catch (System.Exception ex)
//             {
//                 _response.Data = ex;
//                 _response.Success = false;
//                 _response.Status = ApiStatus.fail;
//                 return Ok(_response);
//             }
//         }
//     }
// }
