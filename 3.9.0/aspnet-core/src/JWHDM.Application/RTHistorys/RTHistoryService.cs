using Abp.Authorization;
using JWHDM.Authorization;
using JWHDM.RTHistorys.Dto;
using MongoDB.Bson;
using MongoDB.Driver;
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
        //[AbpAuthorize(PermissionNames.Pages_RTHistorys_Query)]
        public string GetDatas(QueryRTHistoryDto dto)// (string tenantid, string pointid, long beginTimestamp, long endTimestamp)
        {
            //创建约束生成器
            FilterDefinitionBuilder<BsonDocument> builderFilter = Builders<BsonDocument>.Filter;
            //约束条件
            //FilterDefinition<BsonDocument> filter = builderFilter.Eq("name", "jack36");
            FilterDefinition<BsonDocument> filter = builderFilter.Eq("pointid", $"{dto.pointid}") & builderFilter.Eq("tenantid", $"{dto.pointid}");
            if(dto.beginTimestamp>0)
                filter &= builderFilter.Gte("timestampclient", dto.beginTimestamp);
            if(dto.endTimestamp>0)
                filter &= builderFilter.Lte("timestampclient", dto.endTimestamp);
            //获取数据
            var tenantResult = _context.HistoryPointDatasBson($"{dto.tenantid}.datas").Find<BsonDocument>(filter).Sort(Builders<BsonDocument>.Sort.Ascending("timestampclient")).Skip(0).Limit(2000);
            return tenantResult.ToList().ToJson();
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
