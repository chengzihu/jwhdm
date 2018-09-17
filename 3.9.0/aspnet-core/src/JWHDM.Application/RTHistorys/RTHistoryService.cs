using Abp.Authorization;
using JWHDM.Authorization;
using JWHDM.RTHistorys.Dto;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWHDM.RTHistorys
{
    /// <summary>
    /// http://www.mamicode.com/info-detail-2245792.html
    /// </summary>
    //[AbpAuthorize(PermissionNames.Pages_RTHistorys)]
    public class RTHistoryService: JWHDMAppServiceBase, IRTHistoryService
    {
        private readonly RTContext _context = new RTContext();
        public JArray GetDatas(QueryRTHistoryDto dto)// (string tenantid, string pointid, long beginTimestamp, long endTimestamp)
        {
            int pageLimit = 2000;
            //创建约束生成器
            FilterDefinitionBuilder<BsonDocument> builderFilter = Builders<BsonDocument>.Filter;
            //约束条件
            FilterDefinition<BsonDocument> filter = builderFilter.Eq("pointid", $"{dto.pointid}") & builderFilter.Eq("tenantid", $"{dto.pointid}");
            if (dto.beginTimestamp > 0)
                filter &= builderFilter.Gte("timestampclient", dto.beginTimestamp);
            if (dto.endTimestamp > 0)
                filter &= builderFilter.Lte("timestampclient", dto.endTimestamp);
            //获取数据
            var tenantResult = new List<BsonDocument>();
            var tenantResultHt = _context.RTPointDatasBson($"{dto.tenantid}.datas").Find<BsonDocument>(filter).Sort(Builders<BsonDocument>.Sort.Ascending("timestampclient")).Skip(0).Limit(pageLimit).ToList();
            var tenantResultHistory = _context.HistoryPointDatasBson($"{dto.tenantid}.datas").Find<BsonDocument>(filter).Sort(Builders<BsonDocument>.Sort.Ascending("timestampclient")).Skip(0).Limit(pageLimit).ToList();
            if (tenantResultHt != null && tenantResultHt.Count > 0)
                tenantResult.AddRange(tenantResultHt);
            if (tenantResultHistory != null && tenantResultHistory.Count > 0)
                tenantResult.AddRange(tenantResultHistory);

            var tenantResultHistoryFirstAfter = _context.HistoryPointDatasBson($"{dto.tenantid}.datas").Find<BsonDocument>(builderFilter.Eq("pointid", $"{dto.pointid}") & builderFilter.Eq("tenantid", $"{dto.pointid}")& builderFilter.Gte("timestampclient",dto.endTimestamp)).FirstOrDefault();
            var tenantResultHistoryFirstBefore = _context.HistoryPointDatasBson($"{dto.tenantid}.datas").Find<BsonDocument>(builderFilter.Eq("pointid", $"{dto.pointid}") & builderFilter.Eq("tenantid", $"{dto.pointid}") & builderFilter.Lte("timestampclient",dto.beginTimestamp)).FirstOrDefault();
            var tenantResultHTFirstAfter = _context.RTPointDatasBson($"{dto.tenantid}.datas").Find<BsonDocument>(builderFilter.Eq("pointid", $"{dto.pointid}") & builderFilter.Eq("tenantid", $"{dto.pointid}") & builderFilter.Gte("timestampclient", dto.endTimestamp)).FirstOrDefault();
            var tenantResultHTFirstBefore = _context.RTPointDatasBson($"{dto.tenantid}.datas").Find<BsonDocument>(builderFilter.Eq("pointid", $"{dto.pointid}") & builderFilter.Eq("tenantid", $"{dto.pointid}") & builderFilter.Lte("timestampclient", dto.beginTimestamp)).FirstOrDefault();

            if (tenantResultHistoryFirstBefore != null)
                tenantResult.Insert(0, tenantResultHistoryFirstBefore);
            else if(tenantResultHTFirstBefore!=null)
                tenantResult.Insert(0, tenantResultHTFirstBefore);
            if (tenantResultHTFirstAfter != null)
                tenantResult.Add(tenantResultHTFirstAfter);
            else if (tenantResultHistoryFirstAfter != null)
                tenantResult.Add(tenantResultHistoryFirstAfter);
            
            tenantResult.ForEach((item) => {
                item.RemoveAt(0);
                item["timestampclient"] = item["timestampclient"].ToString();
                item["timestampserver"] = item["timestampserver"].ToString();
            });
            var jsonObj = JArray.Parse(tenantResult.ToJson());
            for (int i = 0; i < jsonObj.Count; i++)
            {
                jsonObj[i]["timestampclient"] = Convert.ToInt64(jsonObj[i]["timestampclient"]);
                jsonObj[i]["timestampserver"] = Convert.ToInt64(jsonObj[i]["timestampserver"]);
            }
            return jsonObj;
        }

        //[AbpAuthorize(PermissionNames.Pages_RTHistorys_Query)]
        public JArray GetHistoryDatas(QueryRTHistoryDto dto)// (string tenantid, string pointid, long beginTimestamp, long endTimestamp)
        {
            int pageLimit = 2000;
            //创建约束生成器
            FilterDefinitionBuilder<BsonDocument> builderFilter = Builders<BsonDocument>.Filter;
            //约束条件
            FilterDefinition<BsonDocument> filter = builderFilter.Eq("pointid", $"{dto.pointid}") & builderFilter.Eq("tenantid", $"{dto.pointid}");
            if(dto.beginTimestamp>0)
                filter &= builderFilter.Gte("timestampclient", dto.beginTimestamp);
            if(dto.endTimestamp>0)
                filter &= builderFilter.Lte("timestampclient", dto.endTimestamp);
            //获取数据
            var tenantResultHistory = _context.HistoryPointDatasBson($"{dto.tenantid}.datas").Find<BsonDocument>(filter).Sort(Builders<BsonDocument>.Sort.Ascending("timestampclient")).Skip(0).Limit(pageLimit).ToList();
            var tenantResultHistoryFirstAfter = _context.HistoryPointDatasBson($"{dto.tenantid}.datas").Find<BsonDocument>(builderFilter.Eq("pointid", $"{dto.pointid}") & builderFilter.Eq("tenantid", $"{dto.pointid}") & builderFilter.Gte("timestampclient", dto.endTimestamp)).FirstOrDefault();
            var tenantResultHistoryFirstBefore = _context.HistoryPointDatasBson($"{dto.tenantid}.datas").Find<BsonDocument>(builderFilter.Eq("pointid", $"{dto.pointid}") & builderFilter.Eq("tenantid", $"{dto.pointid}") & builderFilter.Lte("timestampclient", dto.beginTimestamp)).FirstOrDefault();
            if (tenantResultHistoryFirstBefore != null)
                tenantResultHistory.Insert(0, tenantResultHistoryFirstBefore);
            if (tenantResultHistoryFirstAfter != null)
                tenantResultHistory.Add(tenantResultHistoryFirstAfter);

            tenantResultHistory.ForEach((item) => {
                item.RemoveAt(0);
                item["timestampclient"] = item["timestampclient"].ToString();
                item["timestampserver"] = item["timestampserver"].ToString();
            });
            JArray jsonObj = JArray.Parse(tenantResultHistory.ToJson());
            for (int i = 0; i < jsonObj.Count; i++)
            {
                jsonObj[i]["timestampclient"] =Convert.ToInt64(jsonObj[i]["timestampclient"]);
                jsonObj[i]["timestampserver"] = Convert.ToInt64(jsonObj[i]["timestampserver"]);
            }

            return jsonObj;
        }

        public JArray GetHTDatas(QueryRTHistoryDto dto)// (string tenantid, string pointid, long beginTimestamp, long endTimestamp)
        {
            int pageLimit = 2000;
            //创建约束生成器
            FilterDefinitionBuilder<BsonDocument> builderFilter = Builders<BsonDocument>.Filter;
            //约束条件
            FilterDefinition<BsonDocument> filter = builderFilter.Eq("pointid", $"{dto.pointid}") & builderFilter.Eq("tenantid", $"{dto.pointid}");
            if (dto.beginTimestamp > 0)
                filter &= builderFilter.Gte("timestampclient", dto.beginTimestamp);
            if (dto.endTimestamp > 0)
                filter &= builderFilter.Lte("timestampclient", dto.endTimestamp);
            //获取数据
            var tenantResultHt = _context.RTPointDatasBson($"{dto.tenantid}.datas").Find<BsonDocument>(filter).Sort(Builders<BsonDocument>.Sort.Ascending("timestampclient")).Skip(0).Limit(pageLimit).ToList();
            var tenantResultHTFirstAfter = _context.RTPointDatasBson($"{dto.tenantid}.datas").Find<BsonDocument>(builderFilter.Eq("pointid", $"{dto.pointid}") & builderFilter.Eq("tenantid", $"{dto.pointid}") & builderFilter.Gte("timestampclient", dto.endTimestamp)).FirstOrDefault();
            var tenantResultHTFirstBefore = _context.RTPointDatasBson($"{dto.tenantid}.datas").Find<BsonDocument>(builderFilter.Eq("pointid", $"{dto.pointid}") & builderFilter.Eq("tenantid", $"{dto.pointid}") & builderFilter.Lte("timestampclient", dto.beginTimestamp)).FirstOrDefault();
            if (tenantResultHTFirstBefore != null)
                tenantResultHt.Insert(0, tenantResultHTFirstBefore);
            if (tenantResultHTFirstAfter != null)
                tenantResultHt.Add(tenantResultHTFirstAfter);

            tenantResultHt.ForEach((item) => {
                item.RemoveAt(0);
                item["timestampclient"] = item["timestampclient"].ToString();
                item["timestampserver"] = item["timestampserver"].ToString();
            });
            JArray jsonObj = JArray.Parse(tenantResultHt.ToJson());
            for (int i = 0; i < jsonObj.Count; i++)
            {
                jsonObj[i]["timestampclient"] = Convert.ToInt64(jsonObj[i]["timestampclient"]);
                jsonObj[i]["timestampserver"] = Convert.ToInt64(jsonObj[i]["timestampserver"]);
            }

            return jsonObj;
        }

        //public string GetDatasLte(QueryRTHistoryLteDto dto)
        //{
        //    //创建约束生成器
        //    FilterDefinitionBuilder<BsonDocument> builderFilter = Builders<BsonDocument>.Filter;
        //    //约束条件
        //    //FilterDefinition<BsonDocument> filter = builderFilter.Eq("name", "jack36");
        //    FilterDefinition<BsonDocument> filter = builderFilter.Eq("pointid", $"{dto.pointid}") & builderFilter.Eq("tenantid", $"{dto.pointid}");
        //    filter &= builderFilter.Lte("timestampclient", dto.endTimestamp);
        //    //获取数据
        //    var tenantResult = _context.HistoryPointDatasBson($"{dto.tenantid}.datas").Find<BsonDocument>(filter).Sort(Builders<BsonDocument>.Sort.Ascending("timestampclient")).Skip(0).Limit(2000);
        //    return tenantResult.ToList().ToJson();
        //}

        //public string GetDatasGte(QueryRTHistoryGteDto dto)
        //{
        //    //创建约束生成器
        //    FilterDefinitionBuilder<BsonDocument> builderFilter = Builders<BsonDocument>.Filter;
        //    //约束条件
        //    //FilterDefinition<BsonDocument> filter = builderFilter.Eq("name", "jack36");
        //    FilterDefinition<BsonDocument> filter = builderFilter.Eq("pointid", $"{dto.pointid}") & builderFilter.Eq("tenantid", $"{dto.pointid}");
        //    filter &= builderFilter.Gte("timestampclient", dto.beginTimestamp);
        //    //获取数据
        //    var tenantResult = _context.HistoryPointDatasBson($"{dto.tenantid}.datas").Find<BsonDocument>(filter).Sort(Builders<BsonDocument>.Sort.Ascending("timestampclient")).Skip(0).Limit(2000);
        //    return tenantResult.ToList().ToJson();
        //}
    }
}
