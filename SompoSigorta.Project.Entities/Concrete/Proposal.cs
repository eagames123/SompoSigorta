using SompoSigorta.Core.Entity;
using System;

namespace SompoSigorta.Project.Entities.Concrete
{
    public class Proposal : IEntity
    {
        public int Id { get; set; }

        public long ProposalNo { get; set; }

        public int RenewalNo { get; set; }

        public int EndorsNo { get; set; }

        public string ProductNo { get; set; }

        public string ApiRequest { get; set; }

        public string ApiResponse { get; set; }

        public DateTime Created { get; set; }
    }
}