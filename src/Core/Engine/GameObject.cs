using System;
using System.Collections.Generic;

namespace BlazorMUD.Core.Engine
{
    public class GameObject
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Short { get; init; }
        public string Long { get; init; }
        public string Article { get; init; }
        public IEnumerable<string> Nouns { get; init; }
        public string Description { get; init; }
    }
}
