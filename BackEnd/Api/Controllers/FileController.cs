﻿using DAApi.Interfaces;
using DAApi.Models;
using DAApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DAApi.Controllers
{
    [Authorize]
    [Route("Api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
        /// <summary>
        /// Atribute that handle the services and configurations
        /// </summary>
        private readonly IFileService _fileService;
        private readonly MongoFileService _mongoFileService;

        /// <summary>
        /// Constructor of FileController
        /// </summary>
        /// <param name="fileService">
        /// File service
        /// </param>
        public FileController(IFileService fileService, MongoFileService mongoFileService)
        {
            _fileService = fileService;
            _mongoFileService = mongoFileService;
        }

        /// <summary>
        /// Method that searches all the files in the database
        /// </summary>
        /// <returns>
        /// List with all the database files
        /// </returns>
        [Route("Files")]
        [HttpGet]
        public IEnumerable<File> GetFiles()
        {
            try
            {
                return _fileService.GetFiles();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        /// <summary>
        /// Method that searches a mongo database entry with the file id
        /// </summary>
        /// <param name="id">
        /// Id of the file to search
        /// </param>
        /// <returns>
        /// Mongo database entry found
        /// </returns>
        [Route("{id}")]
        [HttpGet]
        public string Get(string id)
        {
            try
            {
                var fileData = _mongoFileService.Get(id);

                if (fileData == null)
                {
                    return null;
                }

                return fileData;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }

        }
    }
}
