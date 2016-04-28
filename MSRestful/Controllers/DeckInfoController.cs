using MSRestful.CommonLibrary;
using MSRestful.DataModels;
using MSRestful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MSRestful.Controllers
{
    public class DeckInfoController : ApiController
    {
        static readonly IDeckInfoRepository repository = new DeckInfoRepository();
        DataConnection pclsCache = new DataConnection();

        [Route("Api/v1/deckInfo")]
        public ResponseResult getDeckInfo()
        {
            return repository.getDeckInfo(pclsCache);
        }

        [Route("Api/v1/deckInfo/{id}")]
        public ResponseResult getDeckInfoById(string id)
        {
            return repository.getDeckInfoById(pclsCache,id);
        }

        [Route("Api/v1/deckInfoDetail/{id}")]
        public ResponseResult getDeckInfoDetailById(int id)
        {         
            return repository.getDeckInfoDetailById(pclsCache, id.ToString());
        }
    }
}
