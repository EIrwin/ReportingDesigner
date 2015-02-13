using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using ReportingDesigner.Data.Extensibility;
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
                        map.MapProperty(x => x.FormatSettings);
                    });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof (FormatSettings)))
            {
                BsonClassMap.RegisterClassMap<FormatSettings>(map =>
                    {
                        map.AutoMap();
                        map.GetMemberMap(c => c.Margin).SetSerializer(new StructBsonSerializer());
                        map.MapProperty(c => c.PageFormat);
                        map.MapProperty(c => c.PageOrientation);
                        map.MapProperty(c => c.Height);
                        map.MapProperty(c => c.Width);
                        map.MapProperty(c => c.UnitType);
                    });
            }

            if(!BsonClassMap.IsClassMapRegistered(typeof(PageSize)))
            {
                BsonClassMap.RegisterClassMap<PageSize>(map =>
                    {
                        map.AutoMap();
                        map.MapProperty(c => c.Height);
                        map.MapProperty(c => c.Width);
                    });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(PageFormat)))
            {
                BsonClassMap.RegisterClassMap<PageFormat>(map =>
                {
                    map.AutoMap();
                    map.MapProperty(c => c.Name);
                    map.MapProperty(c => c.PageSize);
                    map.MapProperty(c => c.UnitType);
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(PageOrientation)))
            {
                BsonClassMap.RegisterClassMap<PageOrientation>(map =>
                {
                    map.AutoMap();
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof (UnitType)))
            {
                BsonClassMap.RegisterClassMap<UnitType>(map =>
                    {
                        map.AutoMap();
                    });
            }
        }

        public PageTemplate Insert(PageTemplate pageTemplate)
        {
            _collection.Insert(pageTemplate);
            return pageTemplate;
        }

        public PageTemplate Save(PageTemplate pageTemplate)
        {
            _collection.Save(pageTemplate);
            return pageTemplate;
        }

        public IQueryable<PageTemplate> AsQueryable()
        {
            return _collection.AsQueryable<PageTemplate>();
        }

    }
}
