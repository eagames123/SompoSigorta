using System.Collections.Generic;

namespace SompoSigorta.Project.Entities.EngineAPI
{
    public class ApiResponse
    {
        public class Status
        {
            public string Value { get; set; }
           
            public string Name { get; set; }
        }

        public class Result
        {
            public string Code { get; set; }
          
            public string Description { get; set; }
            
            public Status Status { get; set; }
        }

        public class Root
        {
            public List<Result> Results { get; set; }
        }
    }
}