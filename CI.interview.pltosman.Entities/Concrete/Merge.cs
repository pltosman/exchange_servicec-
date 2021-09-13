using System;
using CI.interview.pltosman.Core.Entities;

namespace CI.interview.pltosman.Entities.Concrete
{
    public class Merge:IEntity
    {
        //TODO
        public Guid Id { get; set; }

        public string Timestamp { get; set; }

        public bool Success { get; set; }

        public DateTime Date { get; set; }

        public string Quote { get; set; }

        public string Base { get; set; }

    }
}
