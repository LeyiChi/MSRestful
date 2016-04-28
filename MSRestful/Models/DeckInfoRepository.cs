using MSRestful.CommonLibrary;
using MSRestful.DataMethod;
using MSRestful.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSRestful.Models
{
    public class DeckInfoRepository : IDeckInfoRepository
    {
        DeckInfoMethod deckInfoMethod = new DeckInfoMethod();
        public ResponseResult getDeckInfo(DataConnection pclsCache)
        {
            return deckInfoMethod.getDeckInfo(pclsCache);
        }

        public ResponseResult getDeckInfoById(DataConnection pclsCache, string id)
        {
            return deckInfoMethod.getDeckInfoById(pclsCache,id);
        }

        public ResponseResult getDeckInfoDetailById(DataConnection pclsCache, string id)
        {
            return deckInfoMethod.getDeckInfoDetailById(pclsCache, id);
        }
    }

}