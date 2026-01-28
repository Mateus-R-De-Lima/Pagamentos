using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Pagamentos.Domain.Enums;

namespace Pagamentos.Domain.Entities
{
    public class Pagamento
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Titulo { get; set; } = string.Empty;
        public double Valor { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;       
        public DateTime DataPagamento { get; set; }     
        public StatusPagamento StatusPagamento { get; set; }
    }
}
