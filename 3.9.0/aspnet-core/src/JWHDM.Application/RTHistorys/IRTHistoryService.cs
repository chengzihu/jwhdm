using JWHDM.RTHistorys.Dto;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWHDM.RTHistorys
{
    public interface IRTHistoryService
    {
        JArray GetDatas(QueryRTHistoryDto dto);
        JArray GetHistoryDatas(QueryRTHistoryDto dto);// (string tenantid, string pointid, long beginTimestamp, long endTimestamp);
        //string GetDatasLte(QueryRTHistoryLteDto dto);
        //string GetDatasGte(QueryRTHistoryGteDto dto);
        JArray GetHTDatas(QueryRTHistoryDto dto);
    }
}
