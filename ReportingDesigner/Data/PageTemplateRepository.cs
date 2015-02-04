using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using ReportingDesigner.Extensibility;

namespace ReportingDesigner.Data
{
    public class PageTemplateRepository
    {
        private MongoCollection _collection;

        public PageTemplateRepository()
        {
            var client = new MongoClient("mongodb://ds1.datamonkeytech.com:27017");
            var server = client.GetServer();
            var database = server.GetDatabase("PortLogic");
            _collection = database.GetCollection<BsonDocument>("Templates");

            RegisterConventions();
        }

        private void RegisterConventions()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof (PageTemplate)))
            {
                BsonClassMap.RegisterClassMap<PageTemplate>(map =>
                    {
                        map.AutoMap();
                        var memberMap = map.GetMemberMap(x => x.ID);
                        memberMap.SetIdGenerator(GuidGenerator.Instance);
                        map.SetIdMember(memberMap);
                    });
            }
        }

        public PageTemplate Insert(PageTemplate pageTemplate)
        {
            _collection.Insert(pageTemplate);
            return pageTemplate;
        }

        public IQueryable<PageTemplate> AsQueryable()
        {
            return _collection.AsQueryable<PageTemplate>();
        }

    }
}
