using JWHDM.RTHistorys.Dto;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWHDM.RTHistorys
{
    public interface IRTHistoryService
    {
        List<BsonDocument> GetHistoryDatas(QueryRTHistoryDto dto);// (string tenantid, string pointid, long beginTimestamp, long endTimestamp);
        //string GetDatasLte(QueryRTHistoryLteDto dto);
        //string GetDatasGte(QueryRTHistoryGteDto dto);
        List<BsonDocument> GetHTDatas(QueryRTHistoryDto dto);
    }
}
