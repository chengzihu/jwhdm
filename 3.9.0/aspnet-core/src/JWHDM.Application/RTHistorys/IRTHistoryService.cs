using JWHDM.RTHistorys.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWHDM.RTHistorys
{
    public interface IRTHistoryService
    {
        string GetHistoryDatas(QueryRTHistoryDto dto);// (string tenantid, string pointid, long beginTimestamp, long endTimestamp);
        //string GetDatasLte(QueryRTHistoryLteDto dto);
        //string GetDatasGte(QueryRTHistoryGteDto dto);
        string GetHTDatas(QueryRTHistoryDto dto);
    }
}
