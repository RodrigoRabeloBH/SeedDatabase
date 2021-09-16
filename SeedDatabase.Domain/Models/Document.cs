using MongoDB.Bson;
using SeedDatabase.Domain.Interfaces;

namespace SeedDatabase.Domain.Models
{
    public class Document : IDocument
    {
        public ObjectId Id { get; set; }
    }
}