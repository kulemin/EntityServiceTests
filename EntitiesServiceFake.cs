using EntityService.Models;
using EntityService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityServiceTests
{
    internal class EntitiesServiceFake : IEntitiesService
    {
        static Guid guid1 = Guid.Parse("cfaa0d3f-7fea-4423-9f69-ebff826e2f89");
        static Guid guid2 = Guid.Parse("cfaa0d3f-7fea-4423-9f69-ebff826e2f90");
        private readonly Dictionary<Guid, Entity> Entities = new Dictionary<Guid, Entity>()
        {
            { guid1, new Entity() { Id = guid1, OperationDate = new DateTime(2023, 1, 1), Amount = (decimal)19.2 } },
            { guid2, new Entity() { Id = guid2, OperationDate = new DateTime(2023, 1, 2), Amount = (decimal)20.3 } }
        };
        public Entity GetById(Guid guid)
        {
            return Entities[guid];
        }

        public void Insert(Entity entity)
        {
            Entities[entity.Id] = entity;
        }

        public bool CheckById(Guid guid)
        {
            return Entities.ContainsKey(guid);
        }

        public void UpdateById(Guid guid, decimal amount)
        {
            Entities[guid].Amount = amount;
        }
    }
}
