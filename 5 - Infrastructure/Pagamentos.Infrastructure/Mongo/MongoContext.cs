using MongoDB.Driver;
using Pagamentos.Domain.Entities;

namespace Pagamentos.Infrastructure.Mongo
{
    public class MongoContext
    {
        public IMongoCollection<Pagamento> Pagamentos { get; }

        public IMongoCollection<Comprovante> Comprovantes { get; }

        public MongoContext()
        {          

            var client = new MongoClient("mongodb://root:root@localhost:27017/pagamentos?authSource=admin");
            var database = client.GetDatabase("PagamentosDB");
            Pagamentos = database.GetCollection<Pagamento>("Pagamentos");
            Comprovantes = database.GetCollection<Comprovante>("Comprovantes");
        }
    }
}
